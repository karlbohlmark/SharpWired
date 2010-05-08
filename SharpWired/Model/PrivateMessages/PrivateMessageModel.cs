#region Information and licence agreements

/*
 * PrivateMessageModel.cs 
 * Created by Ola Lindberg, 2007-12-20
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

namespace SharpWired.Model.PrivateMessages {
    /// <summary>Model for sent and received users</summary>
    public class PrivateMessageModel {
        private readonly List<PrivateMessageItem> receivedMessages = new List<PrivateMessageItem>();
        private readonly List<PrivateMessageItem> sentMessages = new List<PrivateMessageItem>();

        /// <summary>
        /// Add the sent message to the local messages model.
        /// NOTE! Doesn'transfer send the message to the server, just holds it for later referencing.
        /// </summary>
        /// <param name="newSentMessage"></param>
        public void AddSentPrivateMessage(PrivateMessageItem newSentMessage) {
            sentMessages.Add(newSentMessage);

            if (SentPrivateMessageEvent != null) {
                SentPrivateMessageEvent(newSentMessage);
            }
        }

        /// <summary>Add the received message to the local messages model and raises event.</summary>
        /// <param name="newReceivedmessage"></param>
        public void AddReceivedPrivateMessage(PrivateMessageItem newReceivedmessage) {
            receivedMessages.Add(newReceivedmessage);

            if (ReceivedPrivateMessageEvent != null) {
                ReceivedPrivateMessageEvent(newReceivedmessage);
            }
        }

        /// <summary>Delegate for receiving new private message</summary>
        /// <param name="receivedPrivateMessage"></param>
        public delegate void ReceivedPrivateMessageDelegate(PrivateMessageItem receivedPrivateMessage);

        /// <summary>Event raised when a new private message is received</summary>
        public event ReceivedPrivateMessageDelegate ReceivedPrivateMessageEvent;

        /// <summary>Delegate for telling when a new private message was sent</summary>
        /// <param name="sentPrivateMessage"></param>
        public delegate void SentPrivateMessageDelegate(PrivateMessageItem sentPrivateMessage);

        /// <summary>Event raised when a new private message is sent</summary>
        public event SentPrivateMessageDelegate SentPrivateMessageEvent;
    }
}