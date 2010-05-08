#region Information and licence agreements

/*
 * MessageEventArgs_304.cs 
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
    /// <summary>MessageEventArgs for Status Changed (304)</summary>
    public class MessageEventArgs_304 : MessageEventArgs_201 {
        private readonly bool idle;
        private readonly bool admin;
        private readonly int icon;
        private readonly string nick;
        private readonly string status;

        /// <summary>Request if this user is idle</summary>
        public bool Idle { get { return idle; } }

        /// <summary>Request if this user is admin</summary>
        public bool Admin { get { return admin; } }

        /// <summary>Request the icon for this user</summary>
        public int Icon { get { return icon; } }

        /// <summary>Request the nick for this user</summary>
        public string Nick { get { return nick; } }

        /// <summary>Request the status for this user</summary>
        public string Status { get { return status; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The id for this message</param>
        /// <param name="messageName">The name for this message</param>
        /// <param name="userId">The user id</param>
        /// <param name="idle">Is this user idle?</param>
        /// <param name="admin">Is this user admin?</param>
        /// <param name="icon">The icon for this user</param>
        /// <param name="nick">The nick for this user</param>
        /// <param name="status">The status for this user</param>
        public MessageEventArgs_304(int messageId, string messageName, int userId, bool idle, bool admin, int icon, string nick, string status)
            : base(messageId, messageName, userId) {
            this.idle = idle;
            this.admin = admin;
            this.icon = icon;
            this.nick = nick;
            this.status = status;
        }
    }
}