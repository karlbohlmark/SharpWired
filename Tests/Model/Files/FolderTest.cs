using System;
using System.Collections.Generic;
using NUnit.Framework;
using SharpWired.MessageEvents;
using SharpWired.Model.Files;

namespace SharpWired.Tests.Model.Files {
    [TestFixture]
    public class FolderTest {
    	Folder parentFolder;
    	int messageid = -1;
		string messageName = "test";
		string fullPath1 = "/parent/child1";
		string fullPath2 = "/parent/child2";
		string fullPath3 = "/parent/child3";
		FileType fileType = FileType.FOLDER;
		int fileSize = 1;
		DateTime created = DateTime.MinValue;
		DateTime modified = DateTime.MaxValue;
		
    	private List<MessageEventArgs_410420> getListWith1Children(){
    		var message = new MessageEventArgs_410420(messageid, messageName, fullPath1, fileType, fileSize, created, modified);
    		List<MessageEventArgs_410420> list = new List<MessageEventArgs_410420>();
    		list.Add(message);    		
    		return list;
    	}
		
		[SetUp]
		public void setUp(){
			parentFolder = new Folder("/parent", DateTime.MinValue, DateTime.MinValue, 1);
		}
		
		[Test]
		public void Getting_childrens_from_parent_with_no_childs() {
			var childrens = parentFolder.Children;
			Assert.That(childrens.Count, Is.EqualTo(0));
		}
		
		[Test]
		public void Adding_2_childrens_with_the_same_path_should_only_add_1() {
			List<MessageEventArgs_410420> list = getListWith1Children();
    		var message2 = new MessageEventArgs_410420(messageid, messageName, fullPath1, fileType, fileSize, created, modified);
    		list.Add(message2);
			parentFolder.AddChildren(list);
			var childrens = parentFolder.Children;
			Assert.That(childrens.Count, Is.EqualTo(1), "Added 2 nodes with the same path should only return 1? Not sure about this...");
		}
		
		[Test]
		public void Adding_3_childrens_with_different_paths_should_add_3() {
			List<MessageEventArgs_410420> list = getListWith1Children();
    		var message2 = new MessageEventArgs_410420(messageid, messageName, fullPath2, fileType, fileSize, created, modified);
    		var message3 = new MessageEventArgs_410420(messageid, messageName, fullPath3, fileType, fileSize, created, modified);
    		list.Add(message2);
    		list.Add(message3);
			parentFolder.AddChildren(list);
			var childrens = parentFolder.Children;
			Assert.That(childrens.Count, Is.EqualTo(3));
		}
    
    	[Test]
    	public void Adding_the_same_child_twice_should_return_same_object() {
    		var childrens = getListWith1Children();
    		parentFolder.AddChildren(childrens);
    		INode children1 = parentFolder.Children[0];    		
    		parentFolder.AddChildren(childrens);
    		INode children2 = parentFolder.Children[0];    		
    		Assert.That(parentFolder.Children.Count, Is.EqualTo(1), "Adding same object twice should only get one node");
    		Assert.That(children1, Is.EqualTo(children2), "Node is not the same object");
    	}
    	
    	[Test]
		public void Updated_node_is_updated() {
			var list = getListWith1Children();
			parentFolder.AddChildren(list);
			var oldChild = parentFolder.Children[0];
			list.Clear();
			list.Add(new MessageEventArgs_410420(messageid, messageName, fullPath1, fileType, 2, created, modified));
			parentFolder.AddChildren(list);
			Folder newChild = (Folder)parentFolder.Children[0];
			Assert.That(oldChild, Is.EqualTo(newChild), "Child is not the same object anymore");
			Assert.That(newChild.Count, Is.EqualTo(list[0].Size), "Child has wrong size attribute");
		}
    	
    	[Test]
		public void Folder_update() {
			var f = new Folder("/parent/child", new DateTime(1), new DateTime(2), 1);
			f.Update(new MessageEventArgs_410420(1, "", "/parent/child", FileType.FOLDER, 2, new DateTime(3), new DateTime(4)));
			Assert.That(f.Created,  Is.EqualTo(new DateTime(3)), "Created time has not updated.");
			Assert.That(f.Modified, Is.EqualTo(new DateTime(4)), "Modified time has not updated.");
			Assert.That(f.Count,    Is.EqualTo(2), "Folder count has not updated.");
		}
    }
}
