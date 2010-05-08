#region Information and licence agreements

/*
 * Bookmark.cs
 * Created by Peter Holmdal, 2006-12-03
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

namespace SharpWired.Connection.Bookmarks {
    /// <summary>This class is a Bookmark to a server. It consist of server info together with a login.</summary>
    [Serializable]
    public class Bookmark : IComparable {
        #region Properties

        // Setting default classes to be able to save an empty bookmark.
        private string name = "";
        private UserInformation userInformation = new UserInformation();
        private Server server = new Server();

        /// <summary>The name of the bookmark.</summary>
        public string Name { get { return name; } set { name = value; } }

        /// <summary>Request/Set the login to the server.</summary>
        public UserInformation UserInformation { get { return userInformation; } set { userInformation = value; } }

        /// <summary>Request/Set the Server info.</summary>
        public Server Server { get { return server; } set { server = value; } }

        public Server Transfer {
            get {
                return new Server(server.ServerPort + 1,
                                  server.MachineName, server.ServerName);
            }
        }

        #endregion

        #region Constructors

        /// <summary>Construct.</summary>
        /// <param name="name">The name of the bookmark.</param>
        /// <param name="server">The server.</param>
        /// <param name="userInformation">The user information.</param>
        public Bookmark(string name, Server server, UserInformation userInformation) {
            Name = name;
            Server = server;
            UserInformation = userInformation;
        }

        /// <summary>Constructor without name.</summary>
        /// <param name="server">The server.</param>
        /// <param name="userInformation">The user information.</param>
        public Bookmark(Server server, UserInformation userInformation)
            : this("", server, userInformation) {}

        /// <summary>Parameterless constructor for de-serialization. For Xml.</summary>
        public Bookmark() {}

        #endregion

        #region

        /// <summary>Compares the objects using .Equals() fo Server and UserInformation.</summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>T/F.</returns>
        public override bool Equals(object obj) {
            var b = obj as Bookmark;
            if (b == null) {
                return false;
            }
            return b.Name.Equals(Name)
                   && b.Server.Equals(Server)
                   && b.UserInformation.Equals(UserInformation);
        }

        /// <summary>Returns a short representation of this Bookmark.</summary>
        /// <returns>[Name]</returns>
        public string ToShortString() {
            if (Name == "") {
                return ToString();
            }

            return Name;
        }

        /// <summary>A string for this Bookmark.</summary>
        /// <returns>[UserName]@[ServerName]:[Port]</returns>
        public override string ToString() {
            return Name + "[" + userInformation + "@" + server + "]";
        }

        /// <summary>Base.GetHashCode().</summary>
        /// <returns>Code de la Hash.</returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        #endregion

        #region IComparable Members

        /// <summary>Compares this object by name with the given object</summary>
        /// <param name="obj">The object to compare with</param>
        /// <returns></returns>
        public int CompareTo(object obj) {
            return Name.CompareTo((obj as Bookmark).Name);
        }

        #endregion
    }
}