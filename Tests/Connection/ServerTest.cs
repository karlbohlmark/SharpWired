using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SharpWired.Connection;

namespace SharpWired.Tests.Connection {
    [TestFixture]
    public class ServerTest {

        [Test]
        public void ShouldGetDefaultServerPort() {
            Server actual = new Server();
            Assert.That(actual.ServerPort, new EqualConstraint(2000));
        }

        [Test]
        public void ShouldGetDefaultMachineName() {
            Server actual = new Server();
            Assert.That(actual.MachineName, new EmptyConstraint());
        }

        [Test]
        public void ShouldGetDefaultServerName() {
            Server actual = new Server();
            Assert.That(actual.ServerName, new EmptyConstraint());
        }

        [Test]
        public void ShouldGetServerPort() {
            Server actual = new Server(3000, "machineNameTest", "serverNameTest");
            Assert.That(actual.ServerPort, new EqualConstraint(3000));
        }

        [Test]
        public void ShouldGetMachineName() {
            Server actual = new Server(3000, "machineNameTest", "serverNameTest");
            Assert.That(actual.MachineName, new EqualConstraint("machineNameTest"));
        }

        [Test]
        public void ShouldGetServerName() {
            Server actual = new Server(3000, "machineNameTest", "serverNameTest");
            Assert.That(actual.ServerName, new EqualConstraint("serverNameTest"));
        }

        [Test]
        public void ShouldBeEquals() {
            Server one = new Server(3000, "machineEqualNameTets", "serverEqualTest");
            Server two = new Server(3000, "machineEqualNameTets", "serverEqualTest");
            Assert.That(one.Equals(two));
        }

        [Test]
        public void ShouldNotBeEquals_Port() {
            Server one = new Server(3000, "machineEqualNameTets", "serverEqualTest");
            Server two = new Server(1000, "machineEqualNameTets", "serverEqualTest");
            Assert.That(!one.Equals(two));
        }

        [Test]
        public void ShouldNotBeEquals_MachineName() {
            Server one = new Server(3000, "machineEqualNameTets", "serverEqualTest");
            Server two = new Server(3000, "machineNotEqualNameTets", "serverEqualTest");
            Assert.That(!one.Equals(two));
        }

        [Test]
        public void ShouldNotBeEquals_ServerName() {
            Server one = new Server(3000, "machineEqualNameTets", "serverNotEqualTest");
            Server two = new Server(3000, "machineEqualNameTets", "serverEqualTest");
            Assert.That(!one.Equals(two));
        }
    }
}
