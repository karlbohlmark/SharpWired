#region Information and licence agreements

/*
 * WiredTreeNodeArgs.cs
 * Created by Ola Lindberg, 2007-10-01
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
using SharpWired.Model.Files;

namespace SharpWired.Gui.Files {
    /// <summary>Arguments for File Messages in GUI</summary>
    public class WiredNodeArgs : EventArgs {
        /// <summary>Request or set the FileSystemEntry associated with this argument</summary>
        public INode Node { get; set; }

        /// <summary>Constructor</summary>
        /// <param name="node">The assosiated FileSystemEntry</param>
        public WiredNodeArgs(INode node) {
            Node = node;
        }
    }
}