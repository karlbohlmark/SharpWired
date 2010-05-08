#region Information and licence agreements

/*
 * ControllerBase.cs 
 * Created by Ola Lindberg and Peter Holmdahl, 2006-11-25
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

using SharpWired.Connection;
using SharpWired.Model;

namespace SharpWired.Controller {
    /// <summary>The basic functionality for the controllers for all different controller objects</summary>
    public class ControllerBase {
        #region Fields

        protected SharpWiredModel model;
        protected Commands commands;
        protected Messages messages;

        #endregion

        #region Constructor

        /// <summary>Constructor</summary>
        /// <param name="model"></param>
        public ControllerBase(SharpWiredModel model) {
            this.model = model;
            commands = model.ConnectionManager.Commands;
            messages = model.ConnectionManager.Messages;
        }

        #endregion
    }
}