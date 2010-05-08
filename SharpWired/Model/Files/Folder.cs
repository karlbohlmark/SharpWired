#region Information and licence agreements

/*
 * FolderNode.cs 
 * Created by Ola Lindberg, 2007-05-01
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
using System.Collections.Generic;
using System.Diagnostics;
using SharpWired.MessageEvents;

namespace SharpWired.Model.Files {
    /// <summary>Representation of a "Wired Folder"</summary>
    public class Folder : ANode, IFolder {
        public long Count { get; private set; }
        public NodeChildren Children { get; private set; }

        public bool HasChildren { get { return Count > 0; } }

        public Folder(string path, DateTime created, DateTime modified, long count)
            : base(path, created, modified) {
            Count = count;

            Children = new NodeChildren(this);
        }
        
        public override event UpdatedDelegate Updated;
        public override event UpdatedDelegate Offline;

        public override void Reload() {
            ConnectionManager.Commands.List(FullPath);
        }

        public void Reload(int depth) {
            //run wired command LIST
            //set depth som variabel
            //säg till alla barn att lista sig med depth - 1
            throw new NotImplementedException(Name + ": Folder.Reload() is not implemented.");
        }

        public virtual INode Get(string path) {
            if (FullPath == path) {
                return this;
            }

            foreach (var child in Children) {
                if (child.FullPath == path) {
                    return child;
                } else if (child is Folder) {
                    var found = ((Folder) child).Get(path);
                    if (found != null) {
                        return found;
                    }
                }
            }

            return null;
        }

        public void AddChildren(List<MessageEventArgs_410420> list) {
        	List<INode> toBeRemoved = new List<INode>();
        	
        	foreach (var c in Children) {
        		var found = false;
        		foreach (var m in list) {
        			if (c.FullPath == m.FullPath) {
        				found = true;
        				c.Update(m);
        				break;
        			}
        		}
        		if (!found)
        			toBeRemoved.Add(c);
        	}
        	
        	foreach (var c in toBeRemoved) {
        		Children.Remove(c);
        	}
        	
        	foreach (var m in list) {
        		var found = false;
        		foreach (var c in Children) {
        			if (m.FullPath == c.FullPath) {
        				found = true;
        				break;
        			}
        		}
        		if (!found)
        			Add(m);
        	}

            if (Updated != null) {
                Updated(this);
            }
        }
        
        private void Add(MessageEventArgs_410420 message) {
       		switch (message.FileType) {
            	case FileType.FILE:
    				Children.Add(new File(message.FullPath, message.Created, message.Modified, message.Size));
					break;
				case FileType.FOLDER:
					Children.Add(new Folder(message.FullPath, message.Created, message.Modified, message.Size));
					break;
				case FileType.UPLOADS:
					//TODO: Why does this never get called? Even if we have an update folder on the server
                    Children.Add(new Folder(message.FullPath, message.Created, message.Modified, message.Size));
                    Debug.WriteLine("MODEL:Folder -> WARNING! Adding Upload as Folder.");
                    break;
                case FileType.DROPBOX:
                	//TODO: Create DropBox
                	Children.Add(new Folder(message.FullPath, message.Created, message.Modified, message.Size));
                	Debug.WriteLine("MODEL:Folder -> WARNING! Adding DropBox as Folder.");
                	break;
            }
        }
        
        public override void Update(MessageEventArgs_410420 message) {
        	base.Update(message);
        	Count = message.Size;
        	
        	if (Updated != null)
        		Updated(this);
        }
        
        public override void OnOffline(){
        	Children.ForEach(x => x.OnOffline());
        	base.OnOffline();
        	
        	if(Offline != null){
        		Offline(this);
        	}
        }
    }
}