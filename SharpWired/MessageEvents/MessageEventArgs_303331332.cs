#region Information and licence agreements

/*
 * MessageEventArgs_303331332.cs 
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
    /// <summary>
    /// The MessageEventArgs for the following Wired messages:
    ///  * 303 ClientLeave
    ///  * 331 PrivateChatInvitation
    ///  * 332 PrivateChatDeclined
    /// </summary>
    public class MessageEventArgs_303331332 : MessageEventArgs_311330 {
        private readonly int userId;

        /// <summary>Gets the user id</summary>
        public int UserId { get { return userId; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The ID for this message</param>
        /// <param name="messageName">The name of this message</param>
        /// <param name="chatId">The chat id for this message</param>
        /// <param name="userId">The user id for the user that sent this message</param>
        public MessageEventArgs_303331332(int messageId, string messageName, int chatId, int userId)
            : base(messageId, messageName, chatId) {
            this.userId = userId;
        }
    }
}