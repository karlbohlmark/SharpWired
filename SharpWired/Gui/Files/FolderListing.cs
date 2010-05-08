#region Information and licence agreements

/*
 * FileDetailsControl.cs
 * Created by Ola Lindberg and Peter Holmdahl, 2007-09-29
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SharpWired.Gui.Resources.Icons;
using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    public partial class FolderListing : SharpWiredGuiBase, IFilesView {
        private readonly IconHandler iconHandler = IconHandler.Instance;
        private Folder CurrentFolder { get; set; }

        public List<INode> SelectedItems {
            get {
                var n = new List<INode>();
                foreach (var s in detailsListView.SelectedItems) {
                    n.Add(((WiredListNode) s).ModelNode);
                }
                return n;
            }
        }

        private delegate void ClearCallback();

        private delegate void NodeListDelegate(List<INode> nodes);

        // TODO: Use the FolderSelectedDelaget instead? Same signature...
        public delegate void NodeDelegate(INode node);

        public event NodeSelectedDelegate NodeSelected;

        public FolderListing() {
            InitializeComponent();
        }

        public override void Init() {
            base.Init();

            var fileViewIcons = new ImageList();
            fileViewIcons.ColorDepth = ColorDepth.Depth32Bit;
            try {
                fileViewIcons.Images.Add("FOLDER", iconHandler.GetFolderIconFromSystem());
            } catch (Exception e) {
                Debug.WriteLine("FileUserControl.cs | Failed to add images for rootTreView. Exception: " + e); //TODO: Throw exception
            }

            detailsListView.SmallImageList = fileViewIcons;
            detailsListView.LargeImageList = fileViewIcons;
            detailsListView.View = View.Details;
            ContextMenu = new FileMenu(Controller, this);
        }

        public void SetCurrentNode(INode node) {
            if (node is Folder) {
                var folder = node as Folder;

                if (CurrentFolder != null) {
                    CurrentFolder.Updated -= OnFolderUpdated;
                }

                CurrentFolder = folder;
                CurrentFolder.Updated += OnFolderUpdated;
            }
        }

        private void UpdateListView(List<INode> newNodes) {
            if (InvokeRequired) {
                Invoke(new NodeListDelegate(UpdateListView), new object[] {newNodes});
            } else {
                detailsListView.Columns.Clear();

                detailsListView.LabelEdit = true;
                detailsListView.AllowColumnReorder = true;

                detailsListView.Columns.Add("Name", 200);
                detailsListView.Columns.Add("Size", 50, HorizontalAlignment.Right);
                detailsListView.Columns.Add("Added", 150);
                detailsListView.Columns.Add("Modified", 150);

                detailsListView.Items.Clear();

                newNodes.Sort();

                foreach (var folder in newNodes) {
                    if (folder is IFolder) {
                        AddToListView(folder, "FOLDER");
                    }
                }

                foreach (var child in newNodes) {
                    if (child is IFile) {
                        try {
                            var imageKey = Path.GetExtension(child.Name);

                            if (imageKey == "") {
                                imageKey = "FILE";
                            }

                            if (!detailsListView.SmallImageList.Images.ContainsKey(imageKey)) {
                                detailsListView.SmallImageList.Images.Add(
                                    imageKey,
                                    iconHandler.GetFileIconFromSystem(child.Name));
                            }

                            AddToListView(child, imageKey);
                        } catch (ArgumentException e) {
                            // TODO: Error handling
                            Debug.WriteLine(e.Message + ": " + child.Path);
                        }
                    }
                }
            }
        }

        private void AddToListView(INode child, string imageKey) {
            var wln = new WiredListNode(child);
            wln.ImageIndex = detailsListView.SmallImageList.Images.IndexOfKey(imageKey);
            //wln.StateImageIndex = wln.Type;
            wln.SubItems.Add(wln.Size);
            wln.SubItems.Add(wln.Created.ToString());
            wln.SubItems.Add(wln.Modified.ToString());

            detailsListView.Items.Add(wln);
        }

        private void Clear() {
            if (InvokeRequired) {
                ClearCallback callback = Clear;
                Invoke(callback);
            } else {
                detailsListView.Clear();
            }
        }

        private void OnFolderUpdated(INode node) {
            UpdateListView(((Folder) node).Children);
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e) {
            var node = (WiredListNode) detailsListView.GetItemAt(e.X, e.Y);
            if (node == null) return;
            
            if (NodeSelected != null) {
                NodeSelected(node.ModelNode);
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (detailsListView.SelectedItems.Count == 1) {
                    var n = ((WiredListNode) detailsListView.SelectedItems[0]).ModelNode;
                    if (n != null && NodeSelected != null) {
                        NodeSelected(n);
                    }
                }
            }
        }
    }
}