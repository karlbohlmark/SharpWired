#region Information and licence agreements

/*
 * ICommands.cs 
 * Created by Adam Lindberg, 2009-06-02
 * 
 * SharpWired - a Wired client.
 * See: http://www.zankasoftware.com/wired/ for more infromation about Wired
 * 
 * Copyright (C) Ola Lindberg (http://olalindberg.com)
 * Copyright (C) Adam Lindberg (http://namsisi.com)
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
using System.Drawing;
using SharpWired.Connection.Sockets;

namespace SharpWired.Connection
{
	public interface ICommands {
		void SendMessage(string message);
		void InitConnection(UserInformation userInformation);
		void Ban(int id, string message);
		void Banner();
		void Broadcast(string message);
		void Clearnews();
		void Client();
		void Comment(string path, string comment);
		void CreateUser(string name, string password);
		void CreateGroup(string name);
		void Decline(int id);
		void Delete(string path);
		void DeleteUser(string name);
		void DeleteGroup(string @group);
		void EditUser(string name, string password, string @group, string privileges);
		void EditGroup(string name, string privileges);
		void Folder(string path);
		void Get(string path, long offset);
		void Groups();
		void Hello(string machineName, int serverPort, string serverName);
		void Icon(int icon, Image image);
		void Info(int userId);
		void Invite(int userId, int chatId);
		void Join(int chatId);
		void Kick(int userId, string message);
		void Leave(int chatId);
		void List(string path);
		void Me(int id, string message);
		void Move(string @from, string to);
		void Msg(int id, string message);
		void News();
		void Nick(string nick);
		void Pass(string password);
		void Ping(object sender);
		void Post(string message);
		void PrivateChat();
		void Privileges();
		void Put(string path, int size, string checksum);
		void ReadUser(string name);
		void ReadGroup(string name);
		void Say(string message);
		void Say(int id, string message);
		void Search(string query);
		void Stat(string path);
		void Status(string status);
		void Topic(int chatId, string topic);
		void Transfer(string hash);
		void Type(string path, int folderType);
		void User(string login);
		void Users();
		void Who(int chat);
	}
}
