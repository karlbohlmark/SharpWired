using System;
using System.Drawing;
using System.Windows.Forms;
using SharpWired.Controller;
using SharpWired.Model.Files;
using System.Threading;

namespace SharpWired.Gui.Files {
    public class FileMenu : ContextMenu {
        private MenuItem DownloadItem { get; set; }
        private SharpWiredController Controller { get; set; }
        private Control Parent { get; set; }

        public FileMenu(SharpWiredController controller, Control parent) {
            Controller = controller;
            Parent = parent;

            MenuItems.Add(new MenuItem("&Refresh", OnRefresh));
            MenuItems.Add(new MenuItem("-"));

            DownloadItem = new MenuItem("&Download", OnDownload);
            MenuItems.Add(DownloadItem);
            DownloadItem.Visible = false;
            this.Popup += OnPopup;
        }

        private void OnRefresh(Object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void OnDownload(Object sender, EventArgs e) {
            var details = Parent as FolderListing;

            if (details != null) {
                foreach (var n in details.SelectedItems) {
                    Download(n);
                }
            }
        }

        private void OnPopup(Object sender, EventArgs e) {
            var details = Parent as FolderListing;

            if(details != null) {
                if(details.SelectedItems.Count > 0) {
                    DownloadItem.Visible = true;
                } else {
                    DownloadItem.Visible = false;
                }
            }
        }

        private void Download(INode node) {
            Controller.FileTransferController.AddDownload(node);
        }     
    }
}