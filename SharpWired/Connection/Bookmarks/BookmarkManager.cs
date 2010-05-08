#region Information and licence agreements

/*
 * BookmarkManager.cs
 * Created by Peter Holmdal, 2006-12-03
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
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SharpWired.Connection.Bookmarks {
    /// <summary>
    /// This class loads and stores the Bookmarks.
    /// The access is static. There exists only one bookmark file per user.
    /// To maintain some sort of stability, only one acces 
    /// </summary>
    internal class BookmarkManager {
        #region Fields

        private static string BookmarkFileName = "Bookmarks.wwb";
        private static readonly string BookmarkFolder = Application.UserAppDataPath;
        private static readonly string BookmarkFileFullName;

        #endregion

        #region Properties

        private static List<Bookmark> bookmarks;

        /// <summary>Request/Set the list of Bookmarks.</summary>
        public static List<Bookmark> Bookmarks { get { return bookmarks; } set { bookmarks = value; } }

        #endregion

        #region Constructors.

        /// <summary>Private hidden constructor.</summary>
        private BookmarkManager() {}

        /// <summary>The static constructor.</summary>
        static BookmarkManager() {
            var dir = new DirectoryInfo(BookmarkFolder);
            if (dir.Parent != null) {
                BookmarkFolder = dir.Parent.FullName;
            }
            BookmarkFileFullName = Path.Combine(BookmarkFolder, BookmarkFileName);

            // Takes time...
            GetBookmarks();
        }

        #endregion

        #region Request bookmarks

        private static readonly object BookmarkLock = new object();

        /// <summary>Gets a List of Bookmarks. Only one caller at a time!</summary>
        /// <returns></returns>
        public static List<Bookmark> GetBookmarks() {
            lock (BookmarkLock) {
                var file = new FileInfo(BookmarkFileFullName);
                if (!file.Exists) {
                    file = CreateBookmarkFile();
                }
                if (file != null && file.Exists) {
                    var bms = LoadBookmarks(file);
                    bookmarks = new List<Bookmark>(bms);
                    return bookmarks;
                } else {
                    throw new BookmarkException("Could not load the bookmarks from file: "
                                                + BookmarkFileFullName
                                                + ", because the file didn't exist, nor was it created!");
                }
            }
        }

        #endregion

        #region Add Bookmark(s)

        /// <summary>Adds a bookmark to the bookmark file.</summary>
        /// <returns></returns>
        public static bool AddBookmark(Bookmark bookmark, bool allowDuplicate) {
            return AddBookmarks(new[] {bookmark}, allowDuplicate);
        }

        /// <summary>Adds several bookmarks.</summary>
        /// <param name="marksToAdd"></param>
        /// <param name="allowDuplicate">If false, no bookmarks are saves if theres a duplicate.</param>
        /// <returns>True if succeded. False if not saved becouse of adding duplicates.</returns>
        /// <remarks>Reads the bookmark file and add the bookmark to the list, then saves the file.</remarks>
        public static bool AddBookmarks(Bookmark[] marksToAdd, bool allowDuplicate) {
            lock (typeof (BookmarkManager)) {
                try {
                    var save = true;
                    foreach (var bm in marksToAdd) {
                        if (!allowDuplicate && bookmarks.Contains(bm)) {
                            save = false;
                            break;
                        }
                        bookmarks.Add(bm);
                    }
                    if (save) {
                        SaveBookmarks(bookmarks, new FileInfo(BookmarkFileFullName));
                        return true;
                    }
                    return false;
                } catch (Exception e) {
                    throw new BookmarkException("Error adding bookmark to file " + BookmarkFileFullName + ".", e);
                }
            }
        }

        #endregion

        #region Remove Bookmark

        /// <summary>Removes a bookmark.</summary>
        /// <param name="bookmark"></param>
        /// <returns>Null if the bookmark wasn'transfer in the list, otherwise the bookmark that is removed.</returns>
        /// <remarks>Opens the file, loads the list, removes the bookmark, saves the file.</remarks>
        public static Bookmark RemoveBookmark(Bookmark bookmark) {
            lock (typeof (BookmarkManager)) {
                try {
                    if (bookmarks.Contains(bookmark)) {
                        bookmarks.Remove(bookmark);
                        SaveBookmarks(bookmarks, new FileInfo(BookmarkFileFullName));
                        return bookmark;
                    }
                    return null;
                } catch (Exception e) {
                    throw new BookmarkException("Error removing Bookmark from bookmark file " + BookmarkFileFullName + ".", e);
                }
            }
        }

        #endregion

        #region Load

        /// <summary>Deserializes bookmarks from the given FileInfo.</summary>
        /// <param name="file"></param>
        /// <returns>An arrays with the bookmarks.</returns>
        private static Bookmark[] LoadBookmarks(FileInfo file) {
            lock (typeof (BookmarkManager)) {
                try {
                    DecryptFile(file);

                    // If the file is empty, just return an empty list.
                    if (file.Length == 0) {
                        return new Bookmark[] {};
                    }

                    var ser = new XmlSerializer(typeof (Bookmark[]));

                    using (Stream s = File.Open(
                        file.ToString(),
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read)) {
                        var bookmarks = (Bookmark[]) ser.Deserialize(s);

                        return bookmarks;
                    }
                }
                    #region Catch And Throw

                catch (InvalidOperationException invE) {
                    throw new BookmarkException("Error loading bookmarks (" + BookmarkFileFullName + ").", invE);
                } catch (ArgumentNullException ane) {
                    throw new BookmarkException("Error loading bookmarks (" + BookmarkFileFullName + "); The serializationStream is a null reference", ane);
                } catch (SerializationException se) {
                    throw new BookmarkException("Error loading bookmarks (" + BookmarkFileFullName + ").", se);
                } catch (SecurityException sec) {
                    throw new BookmarkException("Error loading bookmarks (" + BookmarkFileFullName + "); The caller does not have the required permission.", sec);
                } catch (Exception e) {
                    throw new BookmarkException("Error loading bookmarks (" + BookmarkFileFullName + ").", e);
                }
                    #endregion

                finally {
                    EncryptFile(file);
                }
            }
        }

        #endregion

        #region Save

        /// <summary>Saves the bookmarks to the given file.</summary>
        /// <param name="bookmarks">The Bookmarks to store.</param>
        /// <param name="file">The file to save to (overwrite!).</param>
        /// <returns></returns>
        private static bool SaveBookmarks(List<Bookmark> bookmarks, FileInfo file) {
            // Lock object so we can'transfer edit it while saving.
            // NOTE: Here a lock object should probably be used, and also used in
            // load method and some other places as well.
            lock (typeof (BookmarkManager)) {
                try {
                    // Writing data to memory first in case of error.
                    // If everything went ok, save data to file.
                    var s = new MemoryStream();
                    var ser = new XmlSerializer(typeof (Bookmark[]));
                    bookmarks.Sort();
                    ser.Serialize(s, bookmarks.ToArray());

                    Stream stream = null;
                    try {
                        stream = File.Open(file.FullName, FileMode.Create, FileAccess.Write);
                    } catch (IOException ioe) {
                        try {
                            stream = File.Create(file.FullName);
                        } finally {
                            // TODO: Handle failure of saving bookmarks
                            Debug.WriteLine("Trying to save bookmarks. Failing with: " + ioe);
                        }
                    }

                    using (stream) {
                        // Up to ~2GB.
                        if (s.Length < int.MaxValue) {
                            stream.Write(s.GetBuffer(), 0, (int) s.Length);
                        } else {
                            throw new ApplicationException("Bookmark files greater than 2GB ('" + int.MaxValue + "') is not supported.");
                        }
                    }

                    EncryptFile(file);

                    return true;
                }
                    #region Catch and throw

                catch (ArgumentNullException ane) {
                    throw new BookmarkException("Error saving the bookmark file (" + BookmarkFileFullName + "); The serializationStream is a null reference", ane);
                } catch (SerializationException se) {
                    throw new BookmarkException("Error saving the bookmark file (" + BookmarkFileFullName + "); The serializationStream supports seeking, but its length is 0", se);
                } catch (SecurityException sec) {
                    throw new BookmarkException("Error saving the bookmark file (" + BookmarkFileFullName + "); The caller does not have the required permission.", sec);
                } catch (IOException ioe) {
                    throw new BookmarkException("Error saving the bookmark file (" + BookmarkFileFullName + "); The stream (file) you tried to open (before writing to it) is locked by another process.", ioe);
                } catch (Exception e) {
                    throw new BookmarkException("Error saving the bookmark file (" + BookmarkFileFullName + "); Unknown reason.", e);
                }

                #endregion
            }
        }

        #endregion

        #region Create, encrypt decrypt bookmark file

        /// <summary>Creates the Bookmark file.</summary>
        private static FileInfo CreateBookmarkFile() {
            var file = new FileInfo(BookmarkFileFullName);
            try {
                var stream = file.Create();
                // Close stream (file) so we can write to it in SaveBookmarks().
                stream.Close();
                stream.Dispose();
                // Add some stuff to it, so that it looks like an XML file.
                SaveBookmarks(new List<Bookmark>(), file);
                return file;
            } catch (Exception e) {
                throw new BookmarkException("Error trying to create file: " + BookmarkFileFullName, e);
            }
        }

        /// <summary>Encrypt the given file</summary>
        /// <param name="file"></param>
        private static void EncryptFile(FileInfo file) {
            try {
                file.Encrypt();
            } catch (Exception e) {
                Debug.WriteLine("Unknown Error Encrypting File:" + e);
                //TODO: Raise error event for error handler notifying 
                //      the user that the bookmark file is saved unencrypted
            }
        }

        /// <summary>Decrypt the given file</summary>
        /// <param name="file"></param>
        private static void DecryptFile(FileInfo file) {
            try {
                file.Decrypt();
            } catch (Exception e) {
                Debug.WriteLine("Unknown Error Decrypting File:" + e);
                //TODO: Raise error event for error handler notifying 
                //      the user that the bookmark file is saved unencrypted
            }
        }

        #endregion
    }

    #region BookmarkException

    /// <summary>Exception for Bookmarks.</summary>
    public class BookmarkException : ApplicationException {
        /// <summary>Constucts.</summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner.</param>
        public BookmarkException(string message, Exception innerException)
            : base(message, innerException) {}

        /// <summary>Constructs.</summary>
        /// <param name="message">Message.</param>
        public BookmarkException(string message)
            : base(message) {}
    }

    #endregion
}