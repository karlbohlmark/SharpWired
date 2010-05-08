#region Information and licence agreements

/*
 * UserItem.cs 
 * Created by Ola Lindberg, 2006-10-15
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
using System.Drawing;
using System.Net;
using SharpWired.MessageEvents;

namespace SharpWired.Model.Users {
    /// <summary>Represents one user that's online to a Wired server.</summary>
    public class User {
        
        private bool admin;
        private string host;
        private int icon;
        private bool idle;
        private Bitmap image;
        private IPAddress ip;
        private string login;
        private string nick;
        private string status;
        private int userId;
        private int cipherBits;
        private string cipherName;
        private string clientVersion;
        private string downloads;
        private DateTime idleTime;
        private DateTime loginTime;
        private string path;
        private int size;
        private int speed;
        private string transfer;
        private int transferred;
        private string uploads;

        private Privileges privileges;

        /// <summary>Request or set if this user is admin</summary>
        public bool Admin { get { return admin; } }

        /// <summary>Request or set the cipher bits</summary>
        public int CipherBits { get { return cipherBits; } }

        /// <summary>Request or set the cipher name</summary>
        public string CipherName { get { return cipherName; } }

        /// <summary>Request or set the client version</summary>
        public string ClientVersion { get { return clientVersion; } }

        /// <summary>Request or set the downloads</summary>
        public string Downloads { get { return Downloads; } }

        /// <summary>Request or set the host for this user</summary>
        public string Host { get { return host; } }

        /// <summary>Request or set the icon for this user</summary>
        public int Icon { get { return icon; } }

        /// <summary>Request or set the idle status for this user</summary>
        public bool Idle { get { return idle; } }

        /// <summary>Request or set the idle time</summary>
        public DateTime IdleTime { get { return idleTime; } }

        /// <summary>Request or set the image for this user</summary>
        public Bitmap Image { get { return image; } }

        /// <summary>Request or set ip for this user</summary>
        public IPAddress Ip { get { return ip; } }

        /// <summary>Request or set the login for this user</summary>
        public string Login { get { return login; } }

        /// <summary>Request or set the login time</summary>
        public DateTime LoginTime { get { return loginTime; } }

        /// <summary>Request or set the nick for this user</summary>
        public string Nick { get { return nick; } }

        /// <summary>Request or set the destination</summary>
        public string Path { get { return path; } }

        /// <summary>Request or set the size</summary>
        public int Size { get { return size; } }

        /// <summary>Request or set the speed</summary>
        public int Speed { get { return speed; } }

        /// <summary>Request or set the status for this user</summary>
        public string Status { get { return status; } }

        /// <summary>Request or set the current transfer</summary>
        public string Transfer { get { return transfer; } }

        /// <summary>Request or set the ammount of transferred data</summary>
        public int Transferred { get { return transferred; } }

        /// <summary>Request or set the uploads</summary>
        public string Uploads { get { return uploads; } }

        /// <summary>Request or set the user id for this user</summary>
        public int UserId { get { return userId; } }

        //TODO: We can now get the user privileges and the group privileges
        //      but instead it would be nice to be able to get the values
        //      for if a user can do the requested action or not (based on group 
        //      AND user privileges).
        //      The group privileges overrides the user privileges.

        /// <summary>Request or set the privileges for this user</summary>
        public Privileges UserPrivileges { get { return privileges; } set { privileges = value; } }

        /// <summary>Request or set the group for this user</summary>
        public Group Group { get; set; }

        public Color Color { get; private set; }

        /// <summary>Delegate for update event</summary>
        /// <param name="u">The new status</param>
        public delegate void UpdatedDelegate(User u);

        /// <summary>The user information for this user was updated.</summary>
        public event UpdatedDelegate Updated;

        /// <summary>Updates this user with the information given in the message.</summary>
        /// <param name="message"></param>
        public void OnStatusChangedMessage(MessageEventArgs_304 message) {
            if (message.UserId != userId) {
                throw new ApplicationException("The user from the given " +
                                               "message ('" + message + "') did not match the current " +
                                               "user ('" + this + "')");
            }

            userId = message.UserId;
            idle = message.Idle;
            admin = message.Admin;
            icon = message.Icon;
            nick = message.Nick;
            status = message.Status;

            Color = new NickColor(nick).RGB;

            if (Updated != null) {
                Updated(this);
            }
        }

        /// <summary>Call this method when the client information for this user has been updated</summary>
        /// <param name="message"></param>
        public void OnClientInformationMessage(MessageEventArgs_308 message) {
            if (message.UserId != userId) {
                throw new ApplicationException("The user from the given " +
                                               "message ('" + message + "') did not match the current " +
                                               "user ('" + this + "')");
            }

            admin = message.Admin;
            cipherBits = message.CipherBits;
            cipherName = message.CipherName;
            clientVersion = message.ClientVersion;
            downloads = message.Downloads;
            host = message.Host;
            icon = message.Icon;
            idle = message.Idle;
            idleTime = message.IdleTime;
            image = message.Image;
            ip = message.Ip;
            login = message.Login;
            loginTime = message.LoginTime;
            nick = message.Nick;
            path = message.Path;
            size = message.Size;
            speed = message.Speed;
            status = message.Status;
            transfer = message.Transfer;
            transferred = message.Transferred;
            uploads = message.Uploads;
            userId = message.UserId;
            if (Updated != null) {
                Updated(this);
            }
        }

        /// <summary>Call this method when the client image for this user has been updated</summary>
        /// <param name="message"></param>
        public void OnClientImageChangedMessage(MessageEventArgs_340 message) {
            if (message.UserId != userId) {
                throw new ApplicationException("The user from the given " +
                                               "message ('" + message + "') did not match the current " +
                                               "user ('" + this + "')");
            }

            image = message.Image;
            if (Updated != null) {
                Updated(this);
            }
        }

        /// <summary>Call this method when the privileges for this user has been updated</summary>
        /// <param name="message"></param>
        public void OnPrivilegesSpecificationMessage(MessageEventArgs_602 message) {
            if (message.Privileges.UserName != login) {
                throw new ApplicationException("The login from the given " +
                                               "message ('" + message + "') did not match the current " +
                                               "user ('" + this + "')");
            }

            privileges = new Privileges(message.Privileges);
        }

        /// <summary>Updates the user information with the information in the given message.</summary>
        /// <param name="message"></param>
        public void UpdateUserInformation(MessageEventArgs_302310 message) {
            if (message.UserId != userId) {
                throw new ApplicationException("The user from the given " +
                                               "message ('" + message + "') did not match the current " +
                                               "user ('" + this + "')");
            }

            SetUserInformation(message);
        }

        private void SetUserInformation(MessageEventArgs_302310 message) {
            admin = message.Admin;
            host = message.Host;
            icon = message.Icon;
            idle = message.Idle;
            image = message.Image;
            ip = message.Ip;
            login = message.Login;
            nick = message.Nick;
            status = message.Status;
            userId = message.UserId;
        }

        public User(MessageEventArgs_302310 message) {
            SetUserInformation(message);

            Color =  new NickColor(Nick).RGB;
        }
    }
}