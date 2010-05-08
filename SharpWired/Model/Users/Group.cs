#region Information and licence agreements

/*
 * Group.cs 
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

namespace SharpWired.Model.Users {
    /// <summary>Represents one Wired group</summary>
    public class Group {
        /// <summary>Request or set the privileges for this group</summary>
        public Privileges Privileges { get; set; }

        /// <summary>Gets or sets the name of this group</summary>
        public string Name { get; set; }

        /// <summary>Constructor</summary>
        /// <param name="name"></param>
        /// <param name="privileges"></param>
        public Group(String name, Privileges privileges) {
            this.Name = name;
            this.Privileges = privileges;
        }
    }
}