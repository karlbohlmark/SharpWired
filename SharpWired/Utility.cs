/*
 * Utility.cs 
 * Created by Ola Lindberg, 2006-06-20
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

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SharpWired {
    /// <summary>
    /// Various utilities that are used througout the SharpWired source code.
    /// 
    /// NOTE: This class has derived from the Socio Project. See http://socio.sf.net/
    /// </summary>
    public static class Utility {
        /// <summary>
        /// This little string is used to separate folders and files in paths.
        /// Like PATHSEPARATOR Folder PATHSEPARATOR File.
        /// </summary>
        public static string PATH_SEPARATOR = "/";

        /// <summary> 
        /// Request ASCII EOT  
        ///</summary>
        public static string EOT { get { return Encoding.ASCII.GetString(new byte[] {0x04}); } }

        /// <summary> 
        /// Request ASCII FS  
        ///</summary>
        public static string FS { get { return Encoding.ASCII.GetString(new byte[] {0x1C}); } }

        /// <summary> 
        /// Request ASCII GS  
        ///</summary>
        public static string GS { get { return Encoding.ASCII.GetString(new byte[] {0x1D}); } }

        /// <summary> 
        /// Request ASCII RS  
        ///</summary>
        public static string RS { get { return Encoding.ASCII.GetString(new byte[] {0x1E}); } }

        /// <summary> 
        /// Request ASCII SP   
        ///</summary>
        public static string SP { get { return Encoding.ASCII.GetString(new byte[] {0x20}); } }

        /// <summary>Hash the password with the SHA1 algorithm  </summary>
        /// <params name="password"> The password in plain text to be hashed</params>
        /// <returns> A lowercase string of hexadecimal characters,
        /// representing a SHA1 hashed password </returns>
        public static string HashPassword(string password) {
            // If the password is more than 0, it should be hashed with SHA1
            if (password.Length > 0) {
                password = BitConverter.ToString(
                    new SHA1CryptoServiceProvider().ComputeHash(
                        Encoding.UTF8.GetBytes(password)));
                // Unfortunately, we get a string like 00-01-AA-0B- etc, 
                // so we convert it to lowercase and remove the "-"s.
                var split = password.ToLower().Split('-');
                password = "";
                foreach (var p in split) {
                    password += p;
                }
            }
            return password;
        }

        /// <summary>
        /// Converts a Base64 (as a string) to an Bitmap.
        /// Tip from David McCarter, see: http://www.vsdntips.com/Tips/VS.NET/Csharp/76.aspx
        /// </summary>
        /// <param name="imageText">The image represented as a Base64 String</param>
        /// <returns>An Bitmap with the image</returns>
        public static Bitmap Base64StringToBitmap(string imageText) {
            Bitmap image = null;
            if (imageText.Length > 0) {
                /*
                This could be used to remove all (if any) \r\n and spaces 
                System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image,Image.Length);
                sbText.Replace("\r\n", String.Empty);
                sbText.Replace(" ", String.Empty);
                */
                var bitmapData = new Byte[imageText.Length];
                bitmapData = Convert.FromBase64String(imageText);
                var streamBitmap = new MemoryStream(bitmapData);
                image = new Bitmap(Image.FromStream(streamBitmap));
            }
            return image;
        }

        /// <summary>
        /// Converts a Bitmap to a Base 64 (string)
        /// Reused from: http://dotnet-snippets.de/dns/c-bitmap-in-base64-codierten-string-wandeln-SID429.aspx
        /// </summary>
        /// <param name="image">The image to convert</param>
        /// <returns>The given image as a Base64 string</returns>
        public static string BitmapToBase64String(Image image) {
            if (image != null) {
                var memory = new MemoryStream();
                image.Save(memory, ImageFormat.Bmp);
                var base64 = Convert.ToBase64String(memory.ToArray());
                memory.Close();
                memory.Dispose();
                return base64;
            } else {
                Debug.WriteLine("Warning: Tried to convert null Bitmap to Base64");
            }
            return null;
        }

        /// <summary>Splits the a Wired string by the Utility.FS delimiter.</summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string[] SplitWiredString(string message) {
            // Parse the server information event
            char[] delimiterChars = {Convert.ToChar(FS)};
            return message.Split(delimiterChars);
        }

        /// <summary>Converts an integer to a boolean. </summary>
        /// <param name="i"></param>
        /// <returns>False if the given integer is 0, true otherwise</returns>
        public static bool ConvertIntToBool(int i) {
            if (i == 0) {
                return false;
            }
            return true;
        }

        public static string ByteArrayToString(byte[] bytes) {
            var enc = new UTF8Encoding();
            return enc.GetString(bytes);
        }
    }
}