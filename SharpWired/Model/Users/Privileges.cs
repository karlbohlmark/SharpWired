#region Information and licence agreements

/*
 * Privileges.cs 
 * Created by Ola Lindberg, 2006-10-14
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

namespace SharpWired.Model.Users {
    /// <summary>
    /// This class represents the privileges a user has on a Wired server.
    /// TODO: This object should be able to have predefined values based on what group it belongs to.
    /// </summary>
    public class Privileges {
        private string userName;
        private bool getUserInfo;
        private bool broadcast;
        private bool postNews;
        private bool clearNews;
        private bool download;
        private bool upload;
        private bool uploadAnywhere;
        private bool createFolders;
        private bool alterFiles;
        private bool deleteFiles;
        private bool viewDropboxes;
        private bool createAccounts;
        private bool editAccounts;
        private bool deleteAccounts;
        private bool elevatePrivileges;
        private bool kickUsers;
        private bool banUsers;
        private bool cannotBeKicked;
        private int downloadSpeed;
        private int uploadSpeed;
        private int downloadLimit;
        private int uploadLimit;
        private bool changeTopic;

        /// <summary>Request the user id for this privileges mask (object).</summary>
        public string UserName { get { return userName; } }

        /// <summary>Request if this user is allowed to get user information or not?</summary>
        public bool GetUserInfo { get { return getUserInfo; } }

        /// <summary>Request or set whether this user is allowed to send broadcast messages or not?</summary>
        public bool Broadcast { get { return broadcast; } }

        /// <summary>Request or set whether this user is allowed to post news or not?</summary>
        public bool PostNews { get { return postNews; } }

        /// <summary>Request or set whether this user is allowed to clear news or not?</summary>
        public bool ClearNews { get { return clearNews; } }

        /// <summary>Request or set whether this user is allowed to download or not?</summary>
        public bool Download { get { return download; } }

        /// <summary>Request or set whether this user is allowed to upload or not?</summary>
        public bool Upload { get { return upload; } }

        /// <summary>Request or set whether this user is allowed to upload anywhere or not?</summary>
        public bool UploadAnywhere { get { return uploadAnywhere; } }

        /// <summary>Request or set whether this user is allowed to create folders or not?</summary>
        public bool CreateFolders { get { return createFolders; } }

        /// <summary>Request or set whether this user is allowed to alter files or not?</summary>
        public bool AlterFiles { get { return alterFiles; } }

        /// <summary>Request or set whether this user is allowed to delete files or not?</summary>
        public bool DeleteFiles { get { return deleteFiles; } }

        /// <summary>Request or set whether this is user allowed to view dropboxe or not?</summary>
        public bool ViewDropboxes { get { return viewDropboxes; } }

        /// <summary>Request or set whether this user is allowed to create accounts or not?</summary>
        public bool CreateAccounts { get { return createAccounts; } }

        /// <summary>Request or set whether this user is allowed to edit accounts or not?</summary>
        public bool EditAccounts { get { return editAccounts; } }

        /// <summary>Request or set whether this user is allowed to delete accounts or not?</summary>
        public bool DeleteAccounts { get { return deleteAccounts; } }

        /// <summary>Request or set whether this user is allowed to elevate privileges or not?</summary>
        public bool ElevatePrivileges { get { return elevatePrivileges; } }

        /// <summary>Request or set whether this user is allowed to kick users or not?</summary>
        public bool KickUsers { get { return kickUsers; } }

        /// <summary>Request or set whether this user is allowed to ban users or not?</summary>
        public bool BanUsers { get { return banUsers; } }

        /// <summary>Request or set whether this user is allowed to be kicked or not.</summary>
        public bool CannotBeKicked { get { return cannotBeKicked; } }

        /// <summary>Request or set the download speed for this user.</summary>
        public int DownloadSpeed { get { return downloadSpeed; } }

        /// <summary>Request or set the upload speed for this user.</summary>
        public int UploadSpeed { get { return UploadSpeed; } }

        /// <summary>Request or set whether the download limit for this user.</summary>
        public int DownloadLimit { get { return downloadLimit; } }

        /// <summary>Request or set whether the upload limit for this user.</summary>
        public int UploadLimit { get { return uploadLimit; } }

        /// <summary>Request or set whether this user is allowed to change chat topic or not?</summary>
        public bool ChangeTopic { get { return changeTopic; } }

        public Privileges(Privileges p) {
            UpdatePrivileges(p);
        }

        /// <summary>
        /// This privileges object is converted to a privileges string 
        /// compatible with the Wired protocol.
        /// </summary>
        /// <returns></returns>
        private string convertToWiredPrivilegesMask() {
            string wiredPrivilegesMask;

            wiredPrivilegesMask =
                GetUserInfo + Utility.FS +
                Broadcast + Utility.FS +
                PostNews + Utility.FS +
                ClearNews + Utility.FS +
                Download + Utility.FS +
                Upload + Utility.FS +
                UploadAnywhere + Utility.FS +
                CreateFolders + Utility.FS +
                AlterFiles + Utility.FS +
                DeleteFiles + Utility.FS +
                ViewDropboxes + Utility.FS +
                CreateAccounts + Utility.FS +
                EditAccounts + Utility.FS +
                DeleteAccounts + Utility.FS +
                ElevatePrivileges + Utility.FS +
                KickUsers + Utility.FS +
                BanUsers + Utility.FS +
                CannotBeKicked + Utility.FS +
                DownloadSpeed + Utility.FS +
                UploadSpeed + Utility.FS +
                DownloadLimit + Utility.FS +
                UploadLimit + Utility.FS +
                ChangeTopic;

            return wiredPrivilegesMask;
        }

        /// <summary>Update this users privileges with the given privileges </summary>
        /// <param name="p">The updated privileges</param>
        public void UpdatePrivileges(Privileges p) {
            alterFiles = p.AlterFiles;
            banUsers = p.BanUsers;
            broadcast = p.Broadcast;
            cannotBeKicked = p.CannotBeKicked;
            changeTopic = p.ChangeTopic;
            clearNews = p.ClearNews;
            createAccounts = p.CreateAccounts;
            createFolders = p.CreateFolders;
            deleteAccounts = p.DeleteAccounts;
            deleteFiles = p.DeleteFiles;
            download = p.Download;
            downloadLimit = p.DownloadLimit;
            downloadSpeed = p.DownloadSpeed;
            editAccounts = p.EditAccounts;
            elevatePrivileges = p.ElevatePrivileges;
            getUserInfo = p.GetUserInfo;
            kickUsers = p.KickUsers;
            postNews = p.PostNews;
            upload = p.Upload;
            uploadAnywhere = p.UploadAnywhere;
            uploadLimit = p.UploadLimit;
            uploadSpeed = p.UploadSpeed;
            userName = p.UserName;
            viewDropboxes = p.ViewDropboxes;
        }
    }
}