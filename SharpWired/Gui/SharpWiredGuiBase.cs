#region Information and licence agreements

/*
 * SharpWiredGuiBase.cs 
 * Created by Ola Lindberg, 2008-07-09
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

using System.Windows.Forms;
using SharpWired.Controller;
using SharpWired.Model;

namespace SharpWired.Gui {
    /// <summary>
    /// Base class for SharpWired GUI files. Sets references to 
    /// shared resources (e.g. model and controller) when inited.
    /// </summary>
    public class SharpWiredGuiBase : UserControl {
        //I wanted to make this class abstract but then can'transfer the visual studio designer handle it...

        protected SharpWiredController Controller { get { return SharpWiredController.Instance; } }
        protected SharpWiredModel Model { get { return SharpWiredModel.Instance; } }

        private delegate void ToggleWindowsFormsControlCallback(Control control);

        protected delegate void Func();

        public virtual void Init() {
            Model.Connected += OnConnected;
        }

        private void OnConnected(Server s) {
            s.Offline += OnOffline;
            s.Online += OnOnline;
        }

        protected virtual void OnOnline() {}
        protected virtual void OnOffline() {}

        protected void ToggleWindowsFormControl(Control control) {
            if (InvokeRequired) {
                ToggleWindowsFormsControlCallback callback
                    = ToggleWindowsFormControl;
                Invoke(callback, new object[] {control});
            } else {
                control.Enabled = !control.Enabled;
            }
        }
    }
}