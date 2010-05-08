#region Information and licence agreements

/*
 * MessageEventArgs_600.cs 
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
    /// <summary>MessageEventArgs for User Specification (600)</summary>
    public class MessageEventArgs_600 : MessageEventArgs_601 {
        private readonly string password;
        private readonly string group;

        /// <summary>Request the hashed password</summary>
        public string Password { get { return password; } }

        /// <summary>Request the group(s) for this user</summary>
        public string Group { get { return group; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The id for this message</param>
        /// <param name="messageName">The name for this message</param>
        /// <param name="privileges">The privileges for this user</param>
        /// <param name="name">The name for this user</param>
        /// <param name="password">The hashed password for this user</param>
        /// <param name="group">The group for this user</param>
        public MessageEventArgs_600(int messageId, string messageName, Privileges privileges, string name, string password, string group)
            : base(messageId, messageName, privileges, name) {
            this.password = password;
            this.group = group;
        }
    }
}