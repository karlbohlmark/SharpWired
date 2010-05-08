#region Information and licence agreements

/*
 * MessageEventArgs_411.cs 
 * Created by Ola Lindberg, 2006-09-28
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

namespace SharpWired.MessageEvents {
    /// <summary>MessageEventArgs for File Listing Done</summary>
    public class MessageEventArgs_411 : MessageEventArgs {
        private readonly long free;
        private readonly string path;

        /// <summary>Request the amount of free disk space</summary>
        public long Free { get { return free; } }

        /// <summary>Request the destination for were file listing was requested</summary>
        public string Path { get { return path; } }

        public MessageEventArgs_411(int messageId, string messageName, string path, long free)
            : base(messageId, messageName) {
            this.free = free;
            this.path = path;
        }
    }
}