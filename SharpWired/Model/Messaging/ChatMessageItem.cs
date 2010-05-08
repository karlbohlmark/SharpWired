#region Information and licence agreements

/*
 * ChatObject.cs 
 * Created by Ola Lindberg and Peter Holmdahl, 2006-11-25
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
using SharpWired.MessageEvents;
using SharpWired.Model.Users;

namespace SharpWired.Model.Messaging {
    /// <summary>The standard chat object that other chat object inherits from</summary>
    public class ChatMessageItem {
        private readonly bool isActionChatMessage;
        private readonly MessageEventArgs_300301 messageEventArgs;
        private readonly DateTime timeStamp = DateTime.Now;
        private readonly User fromUser;

        /// <summary>
        /// Request the timestamp for this message. 
        /// NOTE! Timestamps are not available from protocol and this 
        /// date is therefore created when the message arrive to the client
        /// and not when the message was sent from the server.
        /// </summary>
        public DateTime Time { get { return timeStamp; } }

        /// <summary>Gets if this message is an action chat message or not.</summary>
        public bool IsActionChatMessage { get { return isActionChatMessage; } }

        /// <summary>Request the chat message for this chat object</summary>
        public String ChatMessage { get { return messageEventArgs.Message; } }

        /// <summary>Gets the user that sent this message</summary>
        public User FromUser { get { return fromUser; } }

        public ChatMessageItem(MessageEventArgs_300301 messageEventArgs,
                               User fromUser, bool isActionChatMessage) {
            this.isActionChatMessage = isActionChatMessage;
            this.messageEventArgs = messageEventArgs;
            this.fromUser = fromUser;
        }
    }
}