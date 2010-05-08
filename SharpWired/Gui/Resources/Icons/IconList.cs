#region Information and licence agreements

/*
 * IconHandler.cs 
 * Created by Peter Holmdahl, 2007-06-25
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

using System.Collections.Generic;
using SharpWired.Utils;

namespace SharpWired.Gui.Resources.Icons {
    /// <summary>A list with the icons and their filenames.</summary>
    internal class IconList {
        private static readonly SortedDictionary<string, Pair<string, string>> sIcons = new SortedDictionary<string, Pair<string, string>>();

        private static readonly Pair<string, string> sFile = new Pair<string, string>("File", "file.png");
        private static readonly Pair<string, string> sFolderClosed = new Pair<string, string>("FolderClosed", "folderClosed.png");
        private static readonly Pair<string, string> sUserImage = new Pair<string, string>("UserImage", "userImage.png");

        /// <summary>Request the file icon name and filename pair</summary>
        public static Pair<string, string> File {
            get { return sFile; }
            //set { sFile = value; }
        }

        /// <summary>Request the folder closed icon and filename pair</summary>
        public static Pair<string, string> FolderClosed {
            get { return sFolderClosed; }
            //set { sFolderClosed = value; }
        }

        /// <summary>Request the user image icon and filename pair</summary>
        public static Pair<string, string> UserImage { get { return sUserImage; } }

        /// <summary>Gets the list of icon pairs.</summary>
        public static SortedDictionary<string, Pair<string, string>> Icons { get { return sIcons; } }

        /// <summary>
        /// Adds all the icon pairs to a list. Add your added properties to
        /// this list!
        /// </summary>
        static IconList() {
            sIcons.Add(sFile.Key, sFile);
            sIcons.Add(sFolderClosed.Key, sFolderClosed);
        }
    }
}