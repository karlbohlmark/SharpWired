#region Information and licence agreements

/*
 * SharpWiredClientInfo.cs 
 * Created by Ola Lindberg, 2008-01-15
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

namespace SharpWired {
    /// <summary>Holds client and protocol information</summary>
    public static class SharpWiredClientInfo {
        //TODO: This data should updated once we are supporting Mono
        //See: http://support.microsoft.com/default.aspx?scid=kb%3Ben-us%3B304283

        // See 2.6 Version Strings in the Wired Protocol specification for more information
        private static double protocolVersion = 1.1;
        private static string clientName = "SharpWired";
        private static string architecture = "";
        private static string osVersion = "";
        private static readonly string osRelease = Environment.OSVersion.ToString();
        private static readonly string libVersion = ".Net V" + Environment.Version;
        private static readonly string appVersion = clientName + "/0.1-Pre" + Utility.SP + "(" + Os + ")" + Utility.SP + "(" + libVersion + ")";
        private static readonly string os = osRelease + "; " + osVersion + "; " + architecture;

        /// <summary>Gets the Wired protocol version Sharpwired is using.</summary>
        public static double ProtocolVersion { get { return protocolVersion; } }

        /// <summary>Gets the name for this client.</summary>
        public static string ClientName { get { return clientName; } }

        /// <summary>Gets the app version for this client.</summary>
        public static string AppVersion { get { return appVersion; } }

        /// <summary>Request the operative system info string</summary>
        public static string Os { get { return os; } }
    }
}