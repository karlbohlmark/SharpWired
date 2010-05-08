using SharpWired.MessageEvents;
using System;
using NUnit.Framework;
using SharpWired.Model.Files;

namespace SharpWired.Tests.Model.Files {
	[TestFixture]
	public class FileTest {
		
		[Test]
		public void File_update() {
			var f = new File("/parent/child", new DateTime(1), new DateTime(2), 1);
			f.Update(new MessageEventArgs_410420(1, "", "/parent/child", FileType.FILE, 2, new DateTime(3), new DateTime(4)));
			Assert.That(f.Created,  Is.EqualTo(new DateTime(3)), "Created time has not updated.");
			Assert.That(f.Modified, Is.EqualTo(new DateTime(4)), "Modified time has not updated.");
			Assert.That(f.Size,     Is.EqualTo(2), "File size has not updated.");
		}
	}
}
