using System;
using System.IO;
using Moq;
using NUnit.Framework;
using SharpWired.Connection;
using SharpWired.Model.Files;
using SharpWired.Model.Transfers;
using System.Reflection;

namespace SharpWired.Tests.Model.Transfers {
	
	[TestFixture]
	public class FolderTransferTest {
		
		MockFactory mocks;
		Mock<IFolder> folder;
		Mock<ICommands> commands;
		string folderName = "test_folder";
		
		[SetUp]
		public void SetUp(){
			mocks = new MockFactory(MockBehavior.Strict);
			folder = mocks.Create<IFolder>();
			commands = mocks.Create<ICommands>();
			
			folder.Setup(x => x.Count).Returns(0);
			folder.Setup(x => x.FullPath).Returns(Path.Combine("/my_server/", folderName));
			commands.Setup(x => x.List(Path.Combine("/my_server/", folderName))).AtMostOnce();
		}
		
		[TearDown]
		public void TearDown() {
			mocks.VerifyAll();
			mocks = null;
			folder = null;
			commands = null;
			
			try{
				Directory.Delete(Path.Combine(Environment.CurrentDirectory, folderName), true);
			} catch (DirectoryNotFoundException) { }
		}
		
		[Test]
		public void ShouldGetCorrectEmptyFolderSize() {			
			var transfer = new FolderTransfer(commands.Object, null, folder.Object, "");
			Assert.That(transfer.Size, Is.EqualTo(0));
		}
		
		[Test, Ignore("Must mock children list. Could be hard...")]
		public void ShouldGetCorrectNonEmptyFolderSize() {
			folder.Setup(x => x.Count).Returns(1);
			var transfer = new FolderTransfer(commands.Object, null, folder.Object, "");			
			Assert.That(transfer.Size, Is.EqualTo(1));
		}
		
		[Test]
		// TODO: Break down into smaller test cases
		public void ShouldDownloadEmptyFolder() {
			var cwd = Environment.CurrentDirectory;
			
			// Create FolderTransfer with destination
			var transfer = new FolderTransfer(commands.Object, null, folder.Object, Path.Combine(cwd, folderName));
			
			//Set up expectations that ensure that the TransferDone event is fired
			Mock<IEventHandler> gui = mocks.Create<IEventHandler>();
			gui.Setup(x=>x.OnTransferDone()).AtMostOnce();
			transfer.TransferDone += gui.Object.OnTransferDone;
			//Since this test empty folders we don't need childrens
			folder.Setup(x => x.Children).Returns(new NodeChildren(null));
			
			Assert.That(transfer.Progress, Is.EqualTo(0.0));
			Assert.That(transfer.Status, Is.EqualTo(Status.Idle));
			
			transfer.Start();
			
			Assert.That(transfer.Progress, Is.EqualTo(0.0));
			Assert.That(transfer.Status, Is.EqualTo(Status.Pending));
			
			folder.Raise(x => x.Updated -= null, folder.Object);
			
			Assert.That(transfer.Progress, Is.EqualTo(1.0));
			Assert.That(transfer.Status, Is.EqualTo(Status.Done));
			
			Assert.That(Directory.Exists(Path.Combine(cwd, folderName)));
		}
		
		[Test, Ignore("TODO")]
		public void ShouldDownloadFolderWithEmptySubFolders() {}
	}
	
	public interface IEventHandler {
		void OnTransferDone();
	}
}