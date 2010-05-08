#region Information and licence agreements

/*
 * UserController.cs 
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

using System.Collections.Generic;
using SharpWired.Model;
using SharpWired.Model.Users;

namespace SharpWired.Controller {
    /// <summary>
    /// This class represents the users connected to the chat. If this chat is the public chat, 
    /// it represents the users connected to the server, if it is a private chat it represents
    /// the users available in that chat.
    /// </summary>
    public class UserController : ControllerBase {
        /// <summary>Constructor</summary>
        public UserController(SharpWiredModel model) : base(model) {}

        /// <summary>Request the user information for the given list of users.</summary>
        /// <param name="users"></param>
        public void GetUserInfo(List<User> users) {
            foreach (var u in users) {
                GetUserInfo(u);
            }
        }

        /// <summary>Request the user information for the given user.</summary>
        /// <param name="user"></param>
        public void GetUserInfo(User user) {
            commands.Info(user.UserId);
        }
    }
}