#region Information and licence agreements

/*
 * BreadCrumbControl.cs
 * Created by Ola Lindberg, 2007-11-09
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
using System.Text;
using System.Windows.Forms;
using SharpWired.Gui.Resources.Icons;
using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    public partial class BreadCrumb : SharpWiredGuiBase, IFilesView {
        private delegate void AddButtonsToFlowLayoutCallback(Button b);

        private delegate void ClearFlowLayoutCallback();

        public event NodeSelectedDelegate NodeSelected;

        public BreadCrumb() {
            InitializeComponent();
        }

        public void SetCurrentNode(INode node) {
            if (node is Folder) {
                PopulatePathButtons(node as Folder);
            }
        }

        private void PopulatePathButtons(Folder node) {
            ClearFlowLayout();

            List<string> path;

            if (node.FullPath == "/") {
                path = new List<string>();
                path.Add("");
            } else {
                path = new List<string>(node.FullPath.Split('/'));
            }

            foreach (var folder in path) {
                var b = new Button();
                if (folder != "") {
                    b.Text = folder;
                } else {
                    var iconHandler = IconHandler.Instance;
                    b.Image = iconHandler.GoHome;
                }

                b.MouseUp += OnMouseUp;
                b.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                b.AutoSize = true;
                b.Padding = new Padding(2);
                b.Margin = new Padding(0, 0, 5, 0);
                AddButtonsToFlowLayout(b);
            }
        }

        private void AddButtonsToFlowLayout(Button b) {
            if (InvokeRequired) {
                AddButtonsToFlowLayoutCallback callback = AddButtonsToFlowLayout;
                Invoke(callback, new object[] {b});
            } else {
                breadCrumbsFlowLayoutPanel.Controls.Add(b);
            }
        }

        private void ClearFlowLayout() {
            if (InvokeRequired) {
                ClearFlowLayoutCallback callback = ClearFlowLayout;
                Invoke(callback, new object[] {});
            } else {
                breadCrumbsFlowLayoutPanel.Controls.Clear();
            }
        }

        private string CombineFilePath(String[] pathArray, int dept) {
            var sb = new StringBuilder();
            if (dept > 0 && pathArray.Length > 0) {
                for (var i = 0; i <= dept; i++) {
                    sb.Append(pathArray[i]);
                    if (i != dept) {
                        sb.Append(Utility.PATH_SEPARATOR);
                    }
                }
                return sb.ToString();
            } else {
                return Utility.PATH_SEPARATOR;
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            if (NodeSelected != null) {
                var n = (INode) ((Button) sender).Tag;
                NodeSelected(n);
            }
        }
    }
}