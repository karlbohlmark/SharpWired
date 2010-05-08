#region Information and licence agreements

/*
 * UserListControl.cs
 * Created by Ola Lindberg, 2006-11-20
 * Refactored by Ola and Adam, 2008-03-07
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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SharpWired.Model.Users;

namespace SharpWired.Gui.Chat {
    /// <summary>The gui class for the user list</summary>
    public partial class UserList : SharpWiredGuiBase {
        #region Fields

        private Model.Users.UserList userList;

        #endregion

        #region Events

        private delegate void RemoveUserCallback(User removeUser);

        private delegate void AddUserCallback(User newUser);

        private delegate void RedrawUserListCallback(List<User> userList);

        #endregion

        #region Event listeners

        private void AddUser(User user) {
            if (InvokeRequired) {
                AddUserCallback ucb = AddUser;
                Invoke(ucb, new object[] {user});
            } else {
                var items = userListView.Items;
                if (!items.ContainsKey(user.UserId.ToString())) {
                    user.Updated += UpdateUser;

                    if (user.Image != null) {
                        userListView.LargeImageList.Images.Add(user.UserId.ToString(), user.Image);
                    }

                    var item = new WiredListViewItem(user,
                                                     new[] {user.Nick, user.Status}, user.UserId.ToString());
                    items.Add(item);
                }
            }
        }

        private void UpdateUser(User user) {
            if (InvokeRequired) {
                AddUserCallback ucb = UpdateUser;
                Invoke(ucb, new object[] {user});
            } else {
                var u = FindUserById(user);
                if (u != null) {
                    if (user.Image != null) {
                        userListView.LargeImageList.Images.Add(user.UserId.ToString(), user.Image);
                    }

                    u.Text = user.Nick;
                    u.SubItems[1].Text = user.Status;
                }
            }
        }

        private void RemoveUser(User user) {
            if (InvokeRequired) {
                AddUserCallback ucb = RemoveUser;
                Invoke(ucb, new object[] {user});
            } else {
                user.Updated -= UpdateUser;
                var u = FindUserById(user);
                if (u != null) {
                    userListView.Items.Remove(u);
                }
            }
        }

        private WiredListViewItem FindUserById(User user) {
            var items = userListView.Items;
            WiredListViewItem u = null;
            foreach (WiredListViewItem wli in items) {
                if (wli.UserItem.UserId == user.UserId) {
                    u = wli;
                }
            }

            return u;
        }

        protected override void OnOnline() {
            userList = Model.Server.PublicChat.Users;

            userList.ClientJoined += AddUser;
            userList.ClientLeft += RemoveUser;
        }

        protected override void OnOffline() {
            userList.ClientJoined -= AddUser;
            userList.ClientLeft -= RemoveUser;
            userListView.Clear();
        }

        #endregion

        #region Initialization of UserListControl

        /// <summary>Constructor</summary>
        public UserList() {
            InitializeComponent();
            userListView.LargeImageList = new ImageList();
            userListView.LargeImageList.ImageSize = new Size(32, 32);
            userListView.ContextMenu = new ContextMenu();

            var s = new Size(130, 34);
            userListView.TileSize = s;
        }

        #endregion

        private void OnClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var cm = userListView.ContextMenu;
                cm.MenuItems.Clear();
                var users = userListView.SelectedItems;
                if (users.Count > 0) {
                    cm.MenuItems.Add("Information", OnInformationClick);
                    cm.MenuItems.Add("-");
                    cm.MenuItems.Add("Private Chat").Enabled = false;
                    cm.MenuItems.Add("Private Message").Enabled = false;
                    cm.MenuItems.Add("-");
                    cm.MenuItems.Add("Kick").Enabled = false;
                    cm.MenuItems.Add("Ban").Enabled = false;
                    cm.MenuItems.Add("Ignore").Enabled = false;
                    cm.MenuItems.Add("-");
                }
                cm.MenuItems.Add("Select All").Enabled = false;
                cm.MenuItems.Add("Broadcast").Enabled = false;
            }
        }

        private void OnInformationClick(object sender, EventArgs e) {
            var userItems = userListView.SelectedItems;
            foreach (WiredListViewItem li in userItems) {
                Controller.UserController.GetUserInfo(li.UserItem);
            }
        }
    }
}