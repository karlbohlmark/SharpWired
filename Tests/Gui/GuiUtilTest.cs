using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SharpWired.Gui;
using SharpWired.Model;

namespace SharpWired.Tests.Gui {
    [TestFixture]
    public class GuiUtilTest {

        [Test]
        public void FormatGiB() {
            Assert.That(GuiUtil.FormatByte(0, "GiB"), new EqualConstraint("0 GiB"));
            Assert.That(GuiUtil.FormatByte(1024 * 1024 * 1024 * 1, "GiB"), new EqualConstraint("1 GiB"));
            Assert.That(GuiUtil.FormatByte(67108864, "GiB"), new EqualConstraint("0.1 GiB"));
        }

        [Test]
        public void FormatMiB() {
            Assert.That(GuiUtil.FormatByte(0, "MiB"), new EqualConstraint("0 MiB"));
            Assert.That(GuiUtil.FormatByte(1024 * 1024 * 1, "MiB"), new EqualConstraint("1 MiB"));
            Assert.That(GuiUtil.FormatByte(65536, "MiB"), new EqualConstraint("0.1 MiB"));
        }

        [Test]
        public void FormatKiB() {
            Assert.That(GuiUtil.FormatByte(-1024, "KiB"), new EqualConstraint("-1 KiB"));
            Assert.That(GuiUtil.FormatByte(0, "KiB"), new EqualConstraint("0 KiB"));
            Assert.That(GuiUtil.FormatByte(511, "KiB"), new EqualConstraint("0 KiB"));
            Assert.That(GuiUtil.FormatByte(512, "KiB"), new EqualConstraint("1 KiB"));
            Assert.That(GuiUtil.FormatByte(1024, "KiB"), new EqualConstraint("1 KiB"));
            Assert.That(GuiUtil.FormatByte(65536, "KiB"), new EqualConstraint("64 KiB"));
        }

        [Test]
        public void FormatB() {
            Assert.That(GuiUtil.FormatByte(0, "B"), new EqualConstraint("0 B"));
            Assert.That(GuiUtil.FormatByte(1, "B"), new EqualConstraint("1 B"));
        }

        [Test]
        public void FormatHumanReadable() {
            Assert.That(GuiUtil.FormatByte(0), new EqualConstraint("0 B"));
            Assert.That(GuiUtil.FormatByte(1023), new EqualConstraint("1023 B"));
            Assert.That(GuiUtil.FormatByte(1024), new EqualConstraint("1 KiB"));
            Assert.That(GuiUtil.FormatByte((1024 * 1024) - 513), new EqualConstraint("1023 KiB"));
            Assert.That(GuiUtil.FormatByte(1024 * 1024), new EqualConstraint("1 MiB"));
            Assert.That(GuiUtil.FormatByte(1024 * 1024 + 65536), new EqualConstraint("1.1 MiB"));
            Assert.That(GuiUtil.FormatByte(1024 * 1024 * 1024), new EqualConstraint("1 GiB"));
            Assert.That(GuiUtil.FormatByte(1024 * 1024 * 1024 + 67108864), new EqualConstraint("1.1 GiB"));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void InvalidFormatThrowsException() {
            GuiUtil.FormatByte(0, "invalid format example");
        }
    }
}
