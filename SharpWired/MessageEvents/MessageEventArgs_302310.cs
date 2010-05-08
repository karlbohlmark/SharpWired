#region Information and licence agreements

/*
 * MessageEventArgs_302310.cs 
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

using System.Drawing;
using System.Net;

namespace SharpWired.MessageEvents {
    /// <summary>
    /// MessageEventArgs for:
    /// * Client Join
    /// * User List
    /// </summary>
    public class MessageEventArgs_302310 : MessageEventArgs_303331332 {
        private readonly bool idle;
        private readonly bool admin;
        private readonly int icon;
        private readonly string nick;
        private readonly string login;
        private readonly IPAddress ip;
        private readonly string host;
        private readonly string status;
        private readonly Bitmap image;

        /// <summary>Gets if this client is idle</summary>
        public bool Idle { get { return idle; } }

        /// <summary>Request if this client is admin</summary>
        public bool Admin { get { return admin; } }

        /// <summary>Request the icon for this client</summary>
        public int Icon { get { return icon; } }

        /// <summary>Request the nick for this client</summary>
        public string Nick { get { return nick; } }

        /// <summary>Request the login for this client</summary>
        public string Login { get { return login; } }

        /// <summary>Request the ip for this client</summary>
        public IPAddress Ip { get { return ip; } }

        /// <summary>Request the host for this client</summary>
        public string Host { get { return host; } }

        /// <summary>Request the status for this client</summary>
        public string Status { get { return status; } }

        /// <summary>Request the image for this client</summary>
        public Bitmap Image { get { return image; } }

        /// <summary>Constructor</summary>
        /// <param name="messageId">The id for this message</param>
        /// <param name="messageName">The name for this message</param>
        /// <param name="chatId">The chat id to where this user joined</param>
        /// <param name="userId">The user id for this user</param>
        /// <param name="idle">Is this user idle?</param>
        /// <param name="admin">Is this user admin?</param>
        /// <param name="icon">The icon for this user</param>
        /// <param name="nick">The nick for this user</param>
        /// <param name="login">The login for this user</param>
        /// <param name="ip">The ip foro this user</param>
        /// <param name="host">The host for this user</param>
        /// <param name="status">The status for this user</param>
        /// <param name="image">The image for this user</param>
        public MessageEventArgs_302310(int messageId, string messageName, int chatId, int userId,
                                       bool idle, bool admin, int icon, string nick, string login, IPAddress ip, string host, string status, Bitmap image)
            : base(messageId, messageName, chatId, userId) {
            this.idle = idle;
            this.admin = admin;
            this.icon = icon;
            this.nick = nick;
            this.login = login;
            this.ip = ip;
            this.host = host;
            this.status = status;
            this.image = image;
        }
    }
}