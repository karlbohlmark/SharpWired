#region Information and licence agreements

/*
 * FileListingModel.cs 
 * Created by Ola Lindberg, 2007-01-28
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
using SharpWired.MessageEvents;

namespace SharpWired.Model.Files {
    public class FileTree : Folder {
        private readonly Dictionary<string, List<MessageEventArgs_410420>> Listings = new Dictionary<string, List<MessageEventArgs_410420>>();
        //home/ola/ -> message1, message2

        public FileTree() : base("/", DateTime.Now, DateTime.Now, 0) {
            ConnectionManager.Messages.FileListingEvent += OnFileListingEvent;
            ConnectionManager.Messages.FileListingDoneEvent += OnFileListingDoneEvent;
        }

        private void OnFileListingEvent(MessageEventArgs_410420 message) {
            var p = message.FullPath;

            // message.Path = "/f1"
            // message.Path = "/f1/sub"

            var name = p.Substring(p.LastIndexOf('/') + 1);
            var folder = "/";

            if (p.LastIndexOf('/') != 0) // Path is not in root (e.g. "/folder/file")
            {
                folder = p.Substring(0, p.LastIndexOf('/'));
            }

            if (Listings.ContainsKey(folder)) {
                Listings[folder].Add(message);
            } else {
                var children = new List<MessageEventArgs_410420>();
                children.Add(message);
                Listings.Add(folder, children);
            }
        }

        private void OnFileListingDoneEvent(MessageEventArgs_411 message) {
            var folder = message.Path;
            var n = (Folder) Get(folder); //path is always to a folder

            if (Listings.ContainsKey(folder)) {
                n.AddChildren(Listings[folder]);
            } else {
                n.AddChildren(new List<MessageEventArgs_410420>());
            }
            Listings.Remove(folder);
        }
    }
}