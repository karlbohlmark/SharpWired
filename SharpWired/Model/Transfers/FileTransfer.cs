using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SharpWired.Connection;
using SharpWired.Connection.Sockets;
using SharpWired.MessageEvents;
using SharpWired.Model.Files;
using File=SharpWired.Model.Files.File;

namespace SharpWired.Model.Transfers {
    public enum Status {
        Pending,
        Idle,
        Active,
        Done
    }

    public class FileTransfer : ModelBase, ITransfer {
        private long Offset { get; set; }
        private Commands Commands { get; set; }
        private long LastBytesReceived { get; set; }
        private const int SPEED_HISTORY_LENGTH = 10;
        private BinarySecureSocket Socket { get; set; }

        public string Destination { get; private set; }
        public INode Source { get; private set; }
        public Status Status { get; private set; }

        /// <summary>Gets the time left in seconds</summary>
        public TimeSpan? EstimatedTimeLeft {
            get {
                if (SpeedHistory.Count <= 0) {
                    return null;
                }
                return TimeSpan.FromSeconds((Size - Received)/(long) SpeedHistory.Average());
            }
        }

        public double Progress {
            get {
                if (Received == 0) {
                    return 0;
                }

                return Received/(double) Size;
            }
        }

        public long Size { get { return ((File) Source).Size; } }

        public long Received {
            get {
                if (Socket != null) {
                    return Socket.BytesTransferred;
                } else {
                    return new long();
                }
            }
        }

        /// <summary>Gets the speed in bytes / second</summary>
        public long Speed { get; private set; }

        private Queue<long> SpeedHistory { get; set; }

        public event TransferDoneDelegate TransferDone;

        public FileTransfer(IFile file, string destination, Int64 offset) {
            Source = (INode)file;
            Destination = destination;
            Status = Status.Idle;
            Offset = 0;
            Speed = 0;
            SpeedHistory = new Queue<long>(SPEED_HISTORY_LENGTH);
        }

        public void Start() {
            //TODO: File exists on disk? Resume?
            ConnectionManager.Messages.TransferReadyEvent += OnTransferReady;
            Status = Status.Pending;
            ConnectionManager.Commands.Get(Source.FullPath, Offset);
        }

        private void OnTransferReady(MessageEventArgs_400 args) {
            if (Source.FullPath == args.FullPath) {
                ConnectionManager.Messages.TransferReadyEvent -= OnTransferReady;
                Status = Status.Active;
                LastBytesReceived = 0;

                CreateSocket(args.Hash);
            }
        }

        private void OnInterval() {
            Speed = Received - LastBytesReceived;
            AddToSpeedHistory(Speed);
            LastBytesReceived = Received;
        }

        private void AddToSpeedHistory(long speed) {
            if (SpeedHistory.Count >= SPEED_HISTORY_LENGTH) {
                SpeedHistory.Dequeue();
            }

            SpeedHistory.Enqueue(speed);
        }

        public void Pause() {
            Status = Status.Idle;
            Socket.Disconnect();
            Socket = null;
        }

        public void Cancel() {
            throw new NotImplementedException();
        }

        private void CreateSocket(string hash) {
            // TODO: FileMode.CreateNew should be used when resume works
            var fileStream = new FileStream(Destination, FileMode.Create);

            Socket = new BinarySecureSocket();
            Socket.DataReceivedDoneEvent += OnDataReceivedDone;
            Socket.Connect(Model.ConnectionManager.CurrentBookmark.Transfer,
                           fileStream, ((File) Source).Size, Offset);

            Debug.WriteLine("MODEL:FileTransfer -> CreateSocket: Starting transfer '" + Source.Name + "' ID '" + hash + "'");
            Socket.SendMessage("TRANSFER" + Utility.SP + hash);

            Socket.Interval += OnInterval;
        }

        private void OnDataReceivedDone() {
        	Status = Status.Done;
        	
            if (Socket != null) {
                Debug.WriteLine("MODEL:FileTransfer -> OnDataReceiveDone");
                Socket.DataReceivedDoneEvent -= OnDataReceivedDone;
                Socket.Interval -= OnInterval;
            }

            if (TransferDone != null) {
                TransferDone();
            }
        }
    }
}