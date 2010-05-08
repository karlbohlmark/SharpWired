#region Information and licence agreements

/*
 * MessageEventArgs_311330.cs 
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
    /// The MessageEventArgs for the following Wired messages
    ///  * 311 UserListDone
    ///  * 330 PrivateChatCreated
    /// </summary>
    public class MessageEventArgs_311330 : MessageEventArgs {
        private readonly int chatId;

        /// <summary>Gets the chat id</summary>
        public int ChatId { get { return chatId; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The id for this message</param>
        /// <param name="messageName">The name for this message</param>
        /// <param name="chatId">The chat id for this message</param>
        public MessageEventArgs_311330(int messageId, string messageName, int chatId)
            : base(messageId, messageName) {
            this.chatId = chatId;
        }
    }
}