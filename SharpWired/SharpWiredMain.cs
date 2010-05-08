#region Information and licence agreements

/*
 * SharpWiredMain.cs 
 * Created by Ola Lindberg, 2006-07-23
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
using SharpWired.Controller;
using SharpWired.Gui;
using SharpWired.Model;
using System.Threading;
using System.Windows.Forms;

namespace SharpWired {
    internal class SharpWiredMain {

        [STAThread]
        private static void Main() {
            Application.ThreadException += HandleError;
            Thread.CurrentThread.Name = "main";
            new SharpWiredMain();
        }

        public SharpWiredMain() {
            SharpWiredModel.Instance = new SharpWiredModel();
            SharpWiredController.Instance = new SharpWiredController(SharpWiredModel.Instance);
            new SharpWiredGui(SharpWiredModel.Instance, SharpWiredController.Instance);
        }

        static void HandleError(object sender, ThreadExceptionEventArgs e) {
            MessageBox.Show("Oups! SharpWired crashed and we don't know why. Sorry!");
            //TODO: Fix error reporting
            throw e.Exception;
        }
    }
}