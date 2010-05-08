#region Information and licence agreements

/*
 * MessageEventArgs_341.cs 
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

using System;
using System.Net;

namespace SharpWired.MessageEvents {
    /// <summary>MessageEventArgs for message Chat Topic (341)</summary>
    public class MessageEventArgs_341 : MessageEventArgs_311330 {
        private readonly string nick;
        private readonly string login;
        private readonly IPAddress ip;
        private readonly DateTime time;
        private readonly string topic;

        /// <summary>The nick of the user that edited the topic</summary>
        public string Nick { get { return nick; } }

        /// <summary>The login of the user that editid the topic</summary>
        public string Login { get { return login; } }

        /// <summary>The ip of the user that edited the topic</summary>
        public IPAddress Ip { get { return ip; } }

        /// <summary>The time when the topic was edited</summary>
        public DateTime Time { get { return time; } }

        /// <summary>The chat topic</summary>
        public string Topic { get { return topic; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The id for the message</param>
        /// <param name="messageName">The name for the message</param>
        /// <param name="chatId">The chat id for thi topic</param>
        /// <param name="nick">The nick of the user that changed the topic</param>
        /// <param name="login">The login for the user that changed the topic</param>
        /// <param name="ip">The ip for the user that changed the topic</param>
        /// <param name="time">The time when the topic was changed</param>
        /// <param name="topic">The topic</param>
        public MessageEventArgs_341(int messageId, string messageName, int chatId,
                                    string nick, string login, IPAddress ip, DateTime time, string topic)
            : base(messageId, messageName, chatId) {
            this.nick = nick;
            this.login = login;
            this.ip = ip;
            this.time = time;
            this.topic = topic;
        }
    }
}