using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpWired.Gui.Transfers
{
    public partial class TransferMenu : ContextMenu
    {
        private Model.Transfers.ITransfer _transfer;
        
        private MenuItem OpenFolder = new MenuItem("Open folder");

        public TransferMenu(Model.Transfers.ITransfer transfer)
        {
            this._transfer = transfer;
            this.MenuItems.Add(OpenFolder);
            OpenFolder.Click += OnOpenFolder;
        }

        void OnOpenFolder(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(_transfer.Destination));
        }

    }
}
