#region Information and licence agreements

/*
 * FileUserControl.cs 
 * Created by Ola Lindberg and Peter Holmdahl, 2007-05-10
 * 
 * SharpWired - a Wired client.
 * See: http://www.zankasoftware.com/wired/ for more infromation about Wired
 * 
 * Copyright (C) Ola Lindberg (http://olalindberg.com)
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301 USA
 */

#endregion

using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    /// <summary>Holds referenses to and inits the other file views</summary>
    public partial class FilesContainer : SharpWiredGuiBase {
        public FilesContainer() {
            InitializeComponent();
        }

        protected override void OnOnline() {
            tree.NodeSelected += OnNodeSelected;
            breadCrumb.NodeSelected += OnNodeSelected;
            folderListing.NodeSelected += OnNodeSelected;
        }

        protected override void OnOffline() {
            tree.NodeSelected -= OnNodeSelected;
            breadCrumb.NodeSelected -= OnNodeSelected;
            folderListing.NodeSelected -= OnNodeSelected;
        }

        public override void Init() {
            base.Init();
            tree.Init();
            breadCrumb.Init();
            folderListing.Init();
        }

        private void OnNodeSelected(INode node) {
            if (node is Folder) {
                var folder = node as Folder;

                // Listen to model happens in these:
                tree.SetCurrentNode(node);
                folderListing.SetCurrentNode(node);
                breadCrumb.SetCurrentNode(node);

                // Model update happens here:
                Controller.FileListingController.ReloadFileList(folder);
            }
            if(node is File)
            {
                Controller.FileTransferController.AddDownload(node);
            }
        }
    }
}