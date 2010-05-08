#region Information and licence agreements

/*
 * MessageEventArgs_320322.cs 
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

namespace SharpWired.MessageEvents {
    /// <summary>
    /// MessageEventArgs for Wired messages:
    ///  * 320 News
    ///  * 322 News posted
    /// </summary>
    public class MessageEventArgs_320322 : MessageEventArgs {
        private readonly string nick;
        private readonly DateTime postTime;
        private readonly string post;

        /// <summary>Gets the nick for the user that posted this news </summary>
        public string Nick { get { return nick; } }

        /// <summary>Gets the time when this post was done</summary>
        public DateTime PostTime { get { return postTime; } }

        /// <summary>Gets the news post</summary>
        public string Post { get { return post; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The id for this message</param>
        /// <param name="messageName">The name for this message</param>
        /// <param name="nick">The nick for the user that posted this message</param>
        /// <param name="postTime">The time when this message was posted</param>
        /// <param name="post">The news post</param>
        public MessageEventArgs_320322(int messageId, string messageName, string nick, DateTime postTime, string post)
            : base(messageId, messageName) {
            this.nick = nick;
            this.postTime = postTime;
            this.post = post;
        }
    }
}