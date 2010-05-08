#region Information and licence agreements

/*
 * ANode.cs 
 * Created: 2007-05-01
 * Authors: Ola Lindberg
 *          Adam Lindberg
 * 
 * SharpWired - a Wired client.
 * See: http://www.zankasoftware.com/wired/ for more infromation about Wired
 * 
 * Copyright (C) SharpWired project
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

using SharpWired.MessageEvents;
using System;
using System.Diagnostics;

namespace SharpWired.Model.Files {
    public abstract class ANode : ModelBase, INode {
        public INode Parent { get; set; }
        public INode Root { get; private set; }

        public int Depth {
            get {
                if (Parent != null) {
                    return Parent.Depth + 1;
                } else {
                    return 0;
                }
            }
        }

        public string Name { get; private set; }
        public string Path { get; private set; }

        public string FullPath {
            get {
                // FIXME: Use real path joining!
                if (Path == "/" && Name == "/") {
                    return Path;
                } else {
                    return Path + Name;
                }
            }
        }

        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        public DateTime LastRefreshed { get; private set; }

        public abstract event UpdatedDelegate Updated;
        public abstract event UpdatedDelegate Offline;

        public ANode(string path, DateTime created, DateTime modified) {
            Debug.WriteLine("MODEL:ANode -> Adding node: " + path);

            if (path == "/") {
                Name = "/";
            } else {
                Name = path.Substring(path.LastIndexOf('/') + 1);
            }

            Path = path.Substring(0, path.LastIndexOf('/') + 1);

            Created = created;
            Modified = modified;
        }

        public abstract void Reload();

        public int CompareTo(object obj) {
            var node = obj as INode;
            var thisString = "" + Name + Path + Created + Modified;
            var nodeString = "" + node.Name + node.Path + node.Created + node.Modified;

            return thisString.CompareTo(nodeString);
        }
    	
		public virtual void Update(MessageEventArgs_410420 message) {
        	if (FullPath != message.FullPath)
        		throw new ArgumentException("Update only allowed on node with same path. [this.FullPath]: "
        		                            + FullPath
        		                            + ", [message.FullPath]: "
        		                            + message.FullPath,
        		                            "message");
        	
			Created = message.Created;
			Modified = message.Modified;
			LastRefreshed = DateTime.Now;
		}
        
        public virtual void OnOffline() {
        	Debug.WriteLine("MODEL:ANode -> Going offline: " + this.FullPath);
        }
    }
}