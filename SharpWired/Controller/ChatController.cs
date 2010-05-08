#region Information and licence agreements

/*
 * ChatController.cs 
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

using SharpWired.Model;

namespace SharpWired.Controller {
    /// <summary>Controller for chats. Provide functionality for sending messages, setting topics etc.</summary>
    public class ChatController : ControllerBase {
        public ChatController(SharpWiredModel model) : base(model) {}

        /// <summary>Send a chat message to the server</summary>
        /// <param name="message">The message to send to the server</param>
        public void SendChatMessage(string message) {
            commands.Say(message);
        }

        /// <summary>Change the topic for this chat</summary>
        /// <param name="topic"></param>
        public void ChangeTopic(string topic) {
            //TODO: Check permissions before setting topic
            commands.Topic(1, topic); //1 for setting the topic on public chat
        }
    }
}