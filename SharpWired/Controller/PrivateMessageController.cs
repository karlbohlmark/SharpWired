#region Information and licence agreements

/*
 * PrivateMessageController.cs 
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

using System;
using SharpWired.MessageEvents;
using SharpWired.Model;
using SharpWired.Model.PrivateMessages;
using SharpWired.Model.Users;

namespace SharpWired.Controller {
    /// <summary>
    /// The logic for private messages. Provides functionality for 
    /// sending and receiving private messages.
    /// </summary>
    public class PrivateMessageController : ControllerBase {
        private readonly PrivateMessageModel privateMessageModel;

        #region Properties

        /// <summary>Request the private message model</summary>
        public PrivateMessageModel PrivateMessageModel { get { return privateMessageModel; } }

        #endregion

        #region Event Listeners

        private void OnPrivateMessageEvent(object sender, MessageEventArgs_305309 messageEventArgs) {
            var u = model.Server.PublicChat.Users.GetUser(messageEventArgs.UserId);
            privateMessageModel.AddReceivedPrivateMessage(new PrivateMessageItem(u, messageEventArgs.Message));
        }

        #endregion

        #region Sending to connection layer

        /// <summary>Send the given private message to the given user</summary>
        /// <param name="user">The user to receive the message</param>
        /// <param name="message">The message to send to the user</param>
        public void Msg(User user, String message) {
            //FIXME: Make some error checking (empty message etc)
            model.ConnectionManager.Commands.Msg(user.UserId, message);
            var newSentMessage = new PrivateMessageItem(user, message);
            privateMessageModel.AddSentPrivateMessage(newSentMessage);
        }

        #endregion

        #region Initialization

        public void OnConnected(Server s) {
            messages.PrivateMessageEvent += OnPrivateMessageEvent;
            s.Offline += OnOffline;
        }

        public void OnOffline() {
            messages.PrivateMessageEvent -= OnPrivateMessageEvent;
        }

        public PrivateMessageController(SharpWiredModel model) : base(model) {
            privateMessageModel = new PrivateMessageModel();

            model.Connected += OnConnected;
        }

        #endregion
    }
}