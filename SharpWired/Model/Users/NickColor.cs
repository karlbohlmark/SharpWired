using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SharpWired.Model.Users {
	public class NickColor {
		private string nick;
		public Color RGB { get; private set; }
		public int Hash {
			get {
				return BitConverter.GetBytes(nick.GetHashCode())[0];
			}
		}

		public NickColor(String nick) {
			this.nick = nick;
            
            var hue = (int)((float)Hash * (360.0 / 255.0));
            var saturation = 60;
            var light = 40;

			var hsl = new HSLColor(hue, saturation, light);
			RGB = hsl.ToColor();
		}

		public class HSLColor {
			public int H { get; private set; }
			public int S { get; private set; }
			public int L { get; private set; }

			public HSLColor(int h, int s, int l) {
				H = h;
				S = s;
				L = l;
			}

			// Implemented from: http://www.easyrgb.com/index.php?X=MATH&H=19#text19
			public Color ToColor() {
				double h = (double)H / 360.0;
				double s = (double)S / 100.0;
				double l = (double)L / 100.0;

				double r, g, b;

				if (s == 0.0) { // Greyscale
					r = l;
					g = l;
					b = l;
				} else {
					double p1, p2;

					if (l <= 0.5) {
						p2 = l * (1.0 + s);
					} else {
						p2 = (l + s) - (s * l);
					}

					p1 = 2.0 * l - p2;

					r = HueToRGB(p1, p2, h + (1.0 / 3.0));
					g = HueToRGB(p1, p2, h);
					b = HueToRGB(p1, p2, h - (1.0 / 3.0));
				}

				return Color.FromArgb((int)Math.Round(r * 255.0),
				                      (int)Math.Round(g * 255.0),
				                      (int)Math.Round(b * 255.0));
			}

			private double HueToRGB(double q1, double q2, double hue) {
				if (hue < 0.0)
					hue += 1.0;
				if (hue > 1.0)
					hue -= 1.0;
				if ((6.0 * hue) < 1.0)
					return (q1 + (q2 - q1) * 6.0 * hue);
				if ((2.0 * hue) < 1.0)
					return (q2);
				if ((3.0 * hue) < 2.0)
					return (q1 + (q2 - q1) * ((2.0 / 3.0) - hue) * 6.0);
				return (q1);
			}
		}
	}
}
