using System;
using System.Collections.Generic;
using SharpWired.Model.Files;

namespace SharpWired.Model.Transfers {
	public class Transfers : ModelBase {
		private readonly List<ITransfer> transfers = new List<ITransfer>();

		public List<ITransfer> AllTransfers { get { return transfers; } }

		public delegate void TransferDelegate(ITransfer t);

		public event TransferDelegate TransferAdded;

		public ITransfer Add(INode node, string target) {
			return Add(node, target, 0);
		}

		public ITransfer Add(INode node, string target, Int64 offset) {
			ITransfer transfer = CreateTransfer(node, target, offset);

			if (transfer != null) {
				transfers.Add(transfer);

				if (TransferAdded != null) {
					TransferAdded(transfer);
				}
			}
			return transfer;
		}

		public ITransfer CreateTransfer(INode node, string target, Int64 offset) {
			if (node is IFile) {
				return new FileTransfer((IFile)node, target, offset);
			} else if (node is IFolder) {
				return new FolderTransfer(ConnectionManager.Commands, this, (IFolder)node, target);
			}
			throw new ArgumentException("Transfer was not of type IFile or IFolder.");
		}

		public void Remove(ITransfer transfer) {
			throw new NotImplementedException();
			//Use the following event: public event TransferDelegate TransferRemoved;
		}
	}
}