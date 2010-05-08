#region Information and licence agreements

/*
 * UserModel.cs 
 * Created by Ola Lindberg, 2006-12-03
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
using SharpWired.Connection;
using SharpWired.MessageEvents;

namespace SharpWired.Model.Users {
    /// <summary>Represents a user list in a chat.</summary>
    public class UserList {
        #region Fields

        private readonly List<User> userList;

        #endregion

        #region Constructor

        /// <summary>Constructor</summary>
        public UserList(Messages m) {
            userList = new List<User>();

            m.StatusChangeEvent += OnStatusChangedMessage;
            m.ClientImageChangedEvent += OnClientImageChangedMessage;
            m.ClientInformationEvent += OnClientInformationMessage;
            m.ClientJoinEvent += OnClientJoinMessage;
            m.UserListEvent += OnUserListMessage;
            m.ClientLeaveEvent += OnClientLeaveMessage;
            m.ClientKickedEvent += OnClientKickedMessage;
            m.ClientBannedEvent += OnClientBannedMessage;
            m.PrivilegesSpecificationEvent += OnPrivilegesSpecificationMessage;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Request a copy of the list with users connected to this model.
        /// NOTE! Since we pass a copy of the list editing the content of 
        /// this list outside this class will have no effect.
        /// </summary>
        public List<User> Users { get { return new List<User>(userList); } }

        #endregion

        #region Events & Listeners

        /// <summary>
        /// Changes the status for the user in the given message.
        /// Call this method when a Status Changed Message (304) is 
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnStatusChangedMessage(MessageEventArgs_304 message) {
            var u = GetUser(message.UserId);
            if (u != null) {
                u.OnStatusChangedMessage(message);
            }
        }

        /// <summary>
        /// Changes the Client Information for the user in the given message.
        /// Call this method when a Client Information Message (308) is 
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientInformationMessage(MessageEventArgs_308 message) {
            var u = GetUser(message.UserId);
            if (u != null) {
                u.OnClientInformationMessage(message);
            }
        }

        /// <summary>
        /// Changes the Client Image for the user in the given message.
        /// Call this method when a Client Image Changes Messsage (340) is
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientImageChangedMessage(MessageEventArgs_340 message) {
            var u = GetUser(message.UserId);
            if (u != null) {
                u.OnClientImageChangedMessage(message);
            }
        }

        /// <summary>
        /// Adds the given user to the list of users for this model. 
        /// If the user exists it updates the user information.
        /// Call this method when a Client Join Message (302) is 
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientJoinMessage(MessageEventArgs_302310 message) {
            if (!UserExists(message.UserId)) {
                var newUser = new User(message);
                userList.Add(newUser);
                ClientJoined(newUser);
            } else {
                var u = GetUser(message.UserId);
                if (u != null) {
                    u.UpdateUserInformation(message);
                }
            }
        }

        /// <summary>
        /// Removes the user in the given message from this model.
        /// Call this method when a Client Leave Message (303) is
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientLeaveMessage(MessageEventArgs_303331332 message) {
            var user = GetUser(message.UserId);
            if (user != null) {
                userList.Remove(user);
                ClientLeft(user);
            }
        }

        /// <summary>
        /// Removes the user in the given message from this model since he or 
        /// she was kicked.
        /// Call this method when a Client Kicked Message (306) is
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientKickedMessage(MessageEventArgs_306307 message) {
            var user = GetUser(message.Victim);
            if (user != null) {
                userList.Remove(user);
                ClientLeft(user); //TODO: Send a message for why this user was kicked
            }
        }

        /// <summary>
        /// Removes the user in the given message from this model since he or 
        /// she was banned.
        /// Call this method when a Client Banned Message (307) is
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientBannedMessage(MessageEventArgs_306307 message) {
            var user = GetUser(message.Victim);
            if (user != null) {
                userList.Remove(user);
                ClientLeft(user); //TODO: Send a message for why this user was banned
            }
        }

        /// <summary>
        /// Adds the user in the given message if it isn'transfer already in the list 
        /// of user for this model. If the user exists it updates the user
        /// information.
        /// Call this method when a User List Message (310) is
        /// received from the server.
        /// </summary>
        /// <param name="message"></param>
        public void OnUserListMessage(MessageEventArgs_302310 message) {
            if (!UserExists(message.UserId)) {
                var newUser = new User(message);
                userList.Add(newUser);

                if (ClientJoined != null) {
                    ClientJoined(newUser);
                }
            } else {
                var u = GetUser(message.UserId);
                if (u != null) {
                    u.UpdateUserInformation(message);
                }
            }
        }

        /// <summary>Adds or updates the privileges for the user in the given message</summary>
        /// <param name="message"></param>
        public void OnPrivilegesSpecificationMessage(MessageEventArgs_602 message) {
            var u = GetUser(message.Privileges.UserName);
            if (u != null) {
                u.OnPrivilegesSpecificationMessage(message);
            }
        }

        /// <summary>Delegate for a user join event</summary>
        /// <param name="user"></param>
        public delegate void ClientJoinDelegate(User user);

        /// <summary>Notifies when a user joined this user list</summary>
        public event ClientJoinDelegate ClientJoined;

        /// <summary>Delegate for ClientLeft event</summary>
        /// <param name="user"></param>
        public delegate void ClientLeaveDelegate(User user);

        /// <summary>Notifies when a user has left this user list</summary>
        public event ClientLeaveDelegate ClientLeft;

        #endregion

        #region Methods

        /// <summary>Gets the user with the given user id</summary>
        /// <param name="userId">The UserId for the searched user</param>
        /// <returns>The UserItem with the given user name, null if no user is found</returns>
        public User GetUser(int userId) {
            foreach (var u in userList) {
                if (userId == u.UserId) {
                    return u;
                }
            }
            return null;
        }

        /// <summary>Gets the user with the given user login name</summary>
        /// <param name="login">The login for the searched user</param>
        /// <returns>The UserItem with the given user name, null if no user is found</returns>
        public User GetUser(string login) {
            foreach (var u in userList) {
                if (login == u.Login) {
                    return u;
                }
            }
            return null;
        }

        /// <summary>Gets the user with the given nick</summary>
        /// <param name="nick">The nick for the searched user</param>
        /// <returns>The UserItem with the given nick, null if no user was found</returns>
        public User GetUserByNick(string nick) {
            foreach (var u in userList) {
                if (nick == u.Nick) {
                    return u;
                }
            }
            return null;
        }

        /// <summary>Finds out if the user with the given UserId exists</summary>
        /// <param name="userId">The UserId for the user</param>
        /// <returns>True if the user exists, false otherwise</returns>
        private bool UserExists(int userId) {
            var userExists = false;
            foreach (var user in userList) {
                if (userId == user.UserId) {
                    userExists = true;
                }
            }
            return userExists;
        }

        #endregion
    }
}