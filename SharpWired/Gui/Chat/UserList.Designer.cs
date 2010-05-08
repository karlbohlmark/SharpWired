#region Information and licence agreements
/*
 * UserListControl.Designer.cs
 * Created by Ola Lindberg, 2006-11-20
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
namespace SharpWired.Gui.Chat
{
    partial class UserList
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Admin", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("User", System.Windows.Forms.HorizontalAlignment.Left);
            this.userListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // userListView
            // 
            this.userListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.userListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.userListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userListView.FullRowSelect = true;
            this.userListView.GridLines = true;
            listViewGroup1.Header = "Admin";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "User";
            listViewGroup2.Name = "listViewGroup2";
            this.userListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.userListView.Location = new System.Drawing.Point(0, 0);
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(63, 329);
            this.userListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.userListView.TabIndex = 2;
            this.userListView.TileSize = new System.Drawing.Size(188, 34);
            this.userListView.UseCompatibleStateImageBehavior = false;
            this.userListView.View = System.Windows.Forms.View.Tile;
            this.userListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nick";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // UserList
            // 
            this.Controls.Add(this.userListView);
            this.Name = "UserList";
            this.Size = new System.Drawing.Size(63, 329);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView userListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
    }
}
