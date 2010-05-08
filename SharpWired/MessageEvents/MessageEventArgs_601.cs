#region Information and licence agreements

/*
 * MessageEventArgs_601.cs 
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

using SharpWired.Model.Users;

namespace SharpWired.MessageEvents {
    /// <summary>MessageEventArgs for Group Specification</summary>
    public class MessageEventArgs_601 : MessageEventArgs_602 {
        private readonly string name;

        /// <summary>Request the name for this user or group</summary>
        public string Name { get { return name; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The id for this message</param>
        /// <param name="messageName">The name for this message</param>
        /// <param name="privileges">The privileges for this group</param>
        /// <param name="name">The name for this group</param>
        public MessageEventArgs_601(int messageId, string messageName, Privileges privileges, string name)
            : base(messageId, messageName, privileges) {
            this.name = name;
        }
    }
}