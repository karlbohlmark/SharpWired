#region Information and licence agreements

/*
 * WiredListNode.cs 
 * Created by Ola Lindberg, 2007-09-29
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
using System.Windows.Forms;
using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    public class WiredListNode : ListViewItem {
        private readonly INode modelNode;

        /// <summary>Gets the model node for this tree node</summary>
        public INode ModelNode { get { return modelNode; } }

        private readonly string size;
        private readonly DateTime modified;
        private readonly DateTime created;

        /// <summary>Request the size for this node. If it is a Folder the number of sub-items are listed.</summary>
        public string Size { get { return size; } }

        public DateTime Created { get { return created; } }

        public DateTime Modified { get { return modified; } }

        /// <summary>Constructor</summary>
        public WiredListNode(INode modelNode)
            : base(modelNode.Name) {
            this.modelNode = modelNode;

            if (modelNode is Folder) {
                size = ((Folder) modelNode).Count.ToString();
                created = ((Folder) modelNode).Created;
                modified = ((Folder) modelNode).Modified;
            } else if (modelNode is File) {
                size = BytesToOptimalUnit(((File) modelNode).Size);
                created = ((File) modelNode).Created;
                modified = ((File) modelNode).Modified;
            }
        }

        //Reused from http://www.developerfood.com/calculating-bytes-kb-mb-gb/microsoft-public-dotnet-languages-csharp/ef0c1ca3-15b5-4e5a-bba2-4dcdbe97c3fc/article.aspx by Steve Barnett
        private string BytesToOptimalUnit(long sizeInBytes) {
            string formattedNumber;

            if (sizeInBytes > 1073741824) {
                formattedNumber = String.Format("{0} Gb", sizeInBytes/1073741824);
            } else if (sizeInBytes > 1048576) {
                formattedNumber = String.Format("{0} Mb", sizeInBytes/1048576);
            } else if (sizeInBytes > 1024) {
                formattedNumber = String.Format("{0} Kb", sizeInBytes/1024);
            } else {
                formattedNumber = String.Format("{0} b", sizeInBytes);
            }

            return formattedNumber;
        }

        /// <summary>
        /// A constructor that allows for creation of node with a text, as the
        /// base class TreeNode does.
        /// </summary>
        /// <param name="text">The text for the node.</param>
        public WiredListNode(string text)
            : base(text) {}
    }
}