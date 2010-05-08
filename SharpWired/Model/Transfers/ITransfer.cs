using System;
using SharpWired.Model.Files;

namespace SharpWired.Model.Transfers {

    public delegate void TransferDoneDelegate();

    public interface ITransfer {
        string Destination { get; }
        INode Source { get; }
        Status Status { get; }
        TimeSpan? EstimatedTimeLeft { get; }
        double Progress { get; }
        long Size { get; }
        long Received { get; }
        long Speed { get; }
    
        event TransferDoneDelegate TransferDone;

        void Start();
        void Pause();
        void Cancel();
    }
}