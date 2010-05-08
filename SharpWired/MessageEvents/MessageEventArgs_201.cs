#region Information and licence agreements

/*
 * MessageEventArgs_201.cs 
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
    /// <summary>MessageEventArgs for Login Succeeded (201)</summary>
    public class MessageEventArgs_201 : MessageEventArgs {
        private readonly int userId;

        /// <summary>Request the user id for the user that logged in</summary>
        public int UserId { get { return userId; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The ID for this message</param>
        /// <param name="messageName">The name for this message</param>
        /// <param name="userId">The user ID</param>
        public MessageEventArgs_201(int messageId, string messageName, int userId)
            : base(messageId, messageName) {
            this.userId = userId;
        }
    }
}