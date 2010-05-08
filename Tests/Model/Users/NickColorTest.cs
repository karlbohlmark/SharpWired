using NUnit.Framework;
using SharpWired.Model.Users;
using System.Drawing;

namespace SharpWired.Tests.Model.Users {
    [TestFixture]
    public class NickColorTest {
        NickColor ola = new NickColor("ola");
        NickColor adam = new NickColor("adam");

        [Test]
        public void NickColor_should_not_be_black() {
            NickColor nc = new NickColor("ola");
            Color c = nc.RGB;
            Assert.That(c.A, Is.EqualTo(255));
            AssertRGBNotEqual(c, Color.Black);
            AssertRGBNotEqual(c, Color.White);
        }

        [Test]
        public void Two_NickColors_should_not_be_equal() {
            Color c1 = ola.RGB;
            Color c2 = adam.RGB;
            AssertRGBNotEqual(c1, c2);
        }

        [Test]
        public void Same_NickColor_should_be_equal() {
            Color c1 = ola.RGB;
            Color c2 = new NickColor("ola").RGB;
            AssertRGBEqual(c1, c2);
        }

        [Test]
        public void Should_hash_two_nicks_that_should_not_be_equal() {
            Assert.That(ola.Hash, Is.Not.EqualTo(adam.Hash));
        }

        [Test]
        public void Nearly_identical_names_should_have_unqique_hashes() {
            var name1 = new NickColor("manheusntahoesuntasnoeuhsntahoeusnthaosnetasuteuhnsaotheunsatoheusn");
            var name2 = new NickColor("manheusntahoesuntasnoeuhsntahoeusnthaosnetasuteuhnsaotheunsatoheusx");
            Assert.That(name1.Hash, Is.Not.EqualTo(name2.Hash));

            var name3 = new NickColor("abc");
            var name4 = new NickColor("abd");
            Assert.That(name3.Hash, Is.Not.EqualTo(name4.Hash));
        }

        [Test]
        public void HSLColor_creation_assigns_HSL_color() {
            var hsl = new NickColor.HSLColor(0, 0, 0);
            Assert.That(hsl.H, Is.EqualTo(0));
            Assert.That(hsl.S, Is.EqualTo(0));
            Assert.That(hsl.L, Is.EqualTo(0));

            var hsl2 = new NickColor.HSLColor(255, 255, 255);
            Assert.That(hsl2.H, Is.EqualTo(255));
            Assert.That(hsl2.S, Is.EqualTo(255));
            Assert.That(hsl2.L, Is.EqualTo(255));
        }

        struct Colors {
            public int H, S, L, R, G, B;
            public Colors(int h, int s, int l, int r, int g, int b) {
                H = h; S = s; L = l; R = r; G = g; B = b;
            }
        };

        [Test]
        public void HSLColor_should_be_RGB_convertable() {
            Colors[] colortable = new []{
                new Colors(  0,   0,   0,   0,   0,   0), // Black
                new Colors(360, 100,   0,   0,   0,   0), // Black
                new Colors(  0,   0, 100, 255, 255, 255), // White
                new Colors(360, 100, 100, 255, 255, 255), // White

                new Colors(  0,  80,  50, 230,  25,  25),
                new Colors( 90,  80,  50, 128, 230,  25),
                new Colors(180,  80,  50,  25, 229, 230),
                new Colors(270,  80,  50, 127,  25, 230),

                new Colors( 72,  36,  28,  87,  97,  46)
            };

            foreach (Colors colors in colortable) {
                var hsl = new NickColor.HSLColor(colors.H, colors.S, colors.L);
                var rgb = Color.FromArgb(colors.R, colors.G, colors.B);    
                AssertRGBEqual(hsl.ToColor(), rgb);
            }
        }

        private static void AssertRGBNotEqual(Color c1, Color c2) {
        	Assert.That(c1.R != c2.R || c1.G != c2.G || c1.B != c2.B);
        }

        private static void AssertRGBEqual(Color c1, Color c2) {
        	Assert.That(c1.R == c2.R && c1.G == c2.G && c1.B == c2.B);
        }
    }
}
