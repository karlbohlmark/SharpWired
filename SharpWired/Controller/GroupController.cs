#region Information and licence agreements

/*
 * GroupController.cs 
 * Created by Ola Lindberg, 2007-12-14
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
using SharpWired.MessageEvents;
using SharpWired.Model;
using SharpWired.Model.Users;

namespace SharpWired.Controller {
    /// <summary>Handles groups</summary>
    internal class GroupController : ControllerBase {
        private readonly List<Group> groups = new List<Group>();

        /// <summary>Gets the group with the given name</summary>
        /// <param name="name">The name for the searched group</param>
        /// <returns>The searched group. If not found null is returned.</returns>
        public Group GetGroup(string name) {
            foreach (var g in groups) {
                if (g.Name == name) {
                    return g;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds out if the given group exists or not.
        /// NOTE! This method only finds groups that has been loaded from server.
        /// </summary>
        /// <param name="name">The name of the searched group</param>
        /// <returns>True if the given group exists, false otherwise</returns>
        public bool GroupExists(string name) {
            if (GetGroup(name) != null) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>Adds the group with the given name and privileges to the list of groups</summary>
        /// <param name="name">The name of the group</param>
        /// <param name="p">The privileges for this group</param>
        /// <returns>True if the group was added. False otherwise.</returns>
        public bool AddGroup(string name, Privileges p) {
            if (!GroupExists(name)) {
                groups.Add(new Group(name, p));
                return true;
            }
            return false;
        }

        #region Event Listeners

        private void OnGroupSpecificationEvent(object sender, MessageEventArgs_601 messageEventArgs) {
            if (GroupExists(messageEventArgs.Name)) {
                //Update existing group
                var g = GetGroup(messageEventArgs.Name);
                g.Privileges.UpdatePrivileges(messageEventArgs.Privileges);
            } else {
                //Create new group
                AddGroup(messageEventArgs.Name, messageEventArgs.Privileges);
            }
        }

        #endregion

        public void OnConnected(Server s) {
            messages.GroupSpecificationEvent += OnGroupSpecificationEvent;
            s.Offline += OnOffline;
        }

        public void OnOffline() {
            messages.GroupSpecificationEvent -= OnGroupSpecificationEvent;
        }

        public GroupController(SharpWiredModel model) : base(model) {
            model.Connected += OnConnected;
        }
    }
}