using SharpWired.Connection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SharpWired.Model.Files;

namespace SharpWired.Model.Transfers {
    public class FolderTransfer : ModelBase, ITransfer {
        public string Destination { get; private set; }
        public INode Source { get; private set; }
        
        private Status status;
        public Status Status { 
        	get {
        		if (((IFolder)Source).Count != 0) {
        			//TODO: Should return aggregated status of all subtransfers
        		} 
        		return status;
        	} 
        	private set {
        		status = value;
        	}
        }

        public TimeSpan? EstimatedTimeLeft { get { throw new NotImplementedException(); } }
        public double Progress {
        	get {
        		if (((IFolder)Source).Count != 0) {
        			// TODO: Should return mean value of all sub transfer statuses.
        		} else if (Status == Status.Done) {
        			return 1.0;
        		}
        		
        		return 0.0;
        	}
        }
        public long Size { 
        	get {
        		if (((IFolder)Source).Count == 0){
        			return 0; 	
        		} else {
        			throw new NotImplementedException();
        		}
        	} 
        }
        public long Received { get { throw new NotImplementedException(); } }
        public long Speed { get { throw new NotImplementedException(); } }
        
        public event TransferDoneDelegate TransferDone;

        private Transfers Transfers { get; set; }
        private List<ITransfer> SubTransfers;
        private bool listingDone;
        private bool startCalled;

        private void OnNodeUpdated(INode node) {
        	if (!node.Equals(Source)){
        		throw new ArgumentException("Received updated callback for wrong node");
        	}
        	
        	Source.Updated -= OnNodeUpdated;
            
            foreach (var child in ((IFolder)node).Children) {
            	ITransfer t = Transfers.CreateTransfer(child, Path.Combine(Destination, child.Name), 0);
            	SubTransfers.Add(t);
            }
        	
        	if (startCalled) {
        		Download();
        	} else {
        		Status = Status.Pending;
	        	listingDone = true;
        	}
        }
        
        public FolderTransfer(ICommands commands, Transfers transfers, IFolder node, string destination) {
        	Transfers = transfers;
        	
            Source = (INode)node;
            Destination = destination;
            Status = Status.Idle;
            SubTransfers = new List<ITransfer>();
            
        	Source.Updated += OnNodeUpdated;
        	listingDone = false;
            commands.List(Source.FullPath);
        }

        public void Start() {
        	if (listingDone) {
        		Download();
        	} else {
        		Status = Status.Pending;
        		startCalled = true;
        	}
        }
        
        private void Download() {
        	Status = Status.Active;
            System.IO.Directory.CreateDirectory(Destination);
            Status = Status.Done;
            
            foreach(var t in SubTransfers){
            	t.Start();
            }

            if (TransferDone != null) {
                TransferDone();
            }
        }

        public void Pause() {
        	// TODO: Implement!
            throw new NotImplementedException();
        }

        public void Cancel() {
        	// TODO: Implement!
            throw new NotImplementedException();
        }
    }
}