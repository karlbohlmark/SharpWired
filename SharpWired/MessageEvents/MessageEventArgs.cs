#region Information and licence agreements

/*
 * MessageEventArgs.cs 
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
    /// <summary>This class is the base event class. Many other events inherits from this.</summary>
    public class MessageEventArgs {
        /// 
        /// All variables declared here have a property associated below.
        /// 
        private readonly int messageId;

        private readonly string messageName;

        /// <summary>The ID for this message</summary>
        public int MessageId { get { return messageId; } }

        /// <summary>The name for the message</summary>
        public string MessageName { get { return messageName; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId"></param>
        /// <param name="messageName"></param>
        public MessageEventArgs(int messageId, string messageName) {
            this.messageId = messageId;
            this.messageName = messageName;
        }
    }
}