#region Information and licence agreements

/*
 * FileTreeControls.cs
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

using System.Collections;
using System.Windows.Forms;
using SharpWired.Gui.Resources.Icons;
using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    /// <summary>Shows a representation of the File Model, which models the file tree on the server.</summary>
    public partial class Tree : SharpWiredGuiBase, IFilesView {
        private ArrayList nodeList = new ArrayList();

        private delegate void Callback();

        public event NodeSelectedDelegate NodeSelected;

        public Tree() {
            InitializeComponent();
        }

        public override void Init() {
            base.Init();

            var rootTreeViewIcons = new ImageList();
            rootTreeViewIcons.ColorDepth = ColorDepth.Depth32Bit;
            var iconHandler = IconHandler.Instance;
            rootTreeViewIcons.Images.Add(iconHandler.GetFolderIconFromSystem());
            rootTreeView.ImageList = rootTreeViewIcons;
        }

        public void SetCurrentNode(INode node) {
            if (node is Folder) {
                var nodes = rootTreeView.Nodes;
                var found = nodes.Find(node.FullPath, true);

                rootTreeView.SelectedNode = found[0];
            }
        }

        private void Clear() {
            if (InvokeRequired) {
                Invoke(new Callback(Clear));
            } else {
                rootTreeView.Nodes.Clear();
            }
        }

        protected override void OnOnline() {
            if (InvokeRequired) {
                Invoke(new Callback(OnOnline));
            } else {
                base.OnOnline();
                rootTreeView.Nodes.Add(new WiredTreeNode(Model.Server.FileRoot));
            }
        }

        protected override void OnOffline() {
            base.OnOffline();
            Clear();
        }

        private void OnAfterSelect(object sender, TreeViewEventArgs e) {
            var node = (WiredTreeNode) rootTreeView.SelectedNode;
            if (node != null && NodeSelected != null) {
                NodeSelected(node.ModelNode);
            }
        }
    }
}