using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace SharpWired.Tests {
    [TestFixture]
    public class UtilityTest {

        [Test]
        public void ShouldReturnEOT() {
            string expected = Encoding.ASCII.GetString(new byte[] { 0x04 });
            string actual = SharpWired.Utility.EOT;
            Assert.That(expected, new EqualConstraint(actual));
        }
    }
}
