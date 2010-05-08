#region Information and licence agreements

/*
 * Server.cs
 * Created by Ola Lindberg, 2006-07-10
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

namespace SharpWired.Connection {
    /// <summary>Represents a Server with adress and port.</summary>
    [Serializable]
    public class Server {
        /// <summary>Request/Set the Port.</summary>
        public int ServerPort { get; set; }

        /// <summary>Request/Set the server machine name.</summary>
        public string MachineName { get; set; }

        /// <summary>Request/Set the server name; domain or IP.</summary>
        public string ServerName { get; set; }

        /// <summary>Constructs.</summary>
        /// <param name="serverPort">The port to use.</param>
        /// <param name="machineName">The servers computer name.</param>
        /// <param name="serverName">The domain name or IP adress.</param>
        public Server(int serverPort, string machineName, string serverName) {
            ServerPort = serverPort;
            MachineName = machineName;
            ServerName = serverName;
        }

        /// <summary>Parameterless constructor for de-serialization.</summary>
        public Server() {
            ServerPort = 2000;
            MachineName = "";
            ServerName = "";
        }

        /// <summary>Compares the server name, the machine name and the port using '=='.</summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>T/F.</returns>
        public override bool Equals(object obj) {
            var s = obj as Server;
            if (s == null) {
                return false;
            }

            return s.MachineName == MachineName
                   && s.ServerName == ServerName
                   && s.ServerPort == ServerPort;
        }

        /// <summary>Returns a string representing this Server.</summary>
        /// <returns>([MachineName])[ServerName]:[Port]</returns>
        public override string ToString() {
            return "(" + MachineName + ")" + ServerName + ":" + ServerPort;
        }

        /// <summary>Return base.GetHashCode().</summary>
        /// <returns>A hash code.</returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}