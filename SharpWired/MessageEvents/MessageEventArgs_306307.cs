#region Information and licence agreements

/*
 * MessageEventArgs_306307.cs 
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
    /// MessageEventArgs for Wired messages:
    ///  * 306 Client kicked
    ///  * 307 Client banned
    /// </summary>
    public class MessageEventArgs_306307 : MessageEventArgs_Messages {
        private readonly int victim;
        private readonly int killer;

        /// <summary>The ID for the user that was killed</summary>
        public int Victim { get { return victim; } }

        /// <summary>The ID for the user that killed the victim</summary>
        public int Killer { get { return killer; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">ID for this message</param>
        /// <param name="messageName">Name for this message</param>
        /// <param name="message">The message</param>
        /// <param name="victim">The ID for the user that was killed</param>
        /// <param name="killer">The ID for the user that killed the victim</param>
        public MessageEventArgs_306307(int messageId, string messageName, string message, int victim, int killer) : base(messageId, messageName, message) {
            this.victim = victim;
            this.killer = killer;
        }
    }
}