/*
 * SecureSocket.cs 
 * Created by Ola Lindberg, 2006-06-20
 * 
 * SharpWired - a Wired client.
 * See: http://www.zankasoftware.com/wired/ for more infromation about Wired
 * 
 * Copyright (C) Ola Lindberg (http://olalindberg.com) & Adam Lindberg (http://namsisi.com)
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
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SharpWired.Connection.Sockets {
    /// <summary>
    /// This class handels all socket connections.
    /// 
    /// NOTE: This class has derived from the Socio Project. See http://socio.sf.net/
    /// </summary>
    public class BinarySecureSocket {
        /// <summary>Used to create the SSL Stream.</summary>
        private TcpClient client;

        /// <summary> The secure connection to the server.</summary>
        private SslStream sslStream;

        private DateTime TimeOfLastNotify { get; set; }

        /// <summary>The default size of the buffer to use</summary>
        private static int BUFFER_SIZE = 2048;

        /// <summary>Default transmission parameters. Only used internally</summary>
        protected static readonly int BUFFER_BLOCK_SIZE = 512; // The number of bytes to receive in every block

        private Int64 bytesTransferred;

        public Int64 BytesTransferred { get { return bytesTransferred; } }

        /// <summary>A delegate type for hooking up message received notifications.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="data"></param>
        public delegate void BinaryMessageReceivedHandler(object sender, EventArgs e, byte[] data);

        internal void Start() {}

        /// <summary>Connects to the server using Connect(Port, MachineName, ServerName).</summary>
        /// <param name="server">The Server to connect to.</param>
        /// <param name="stream"></param>
        /// <param name="fileSize"></param>
        /// <param name="offset"></param>
        internal void Connect(Server server, FileStream stream, long fileSize, long offset) {
            Connect(server.ServerPort, server.MachineName, server.ServerName, stream, fileSize, offset);
        }

        /// <summary>Connects the client to the server.</summary>
        /// <param name="serverPort">The port for the server to use for this connection</param>
        /// <param name="machineName">The host running the server application</param>
        /// <param name="serverName">The machine name for the server, must match the machine name in the server certificate</param>
        /// <param name="stream"></param>
        /// <param name="fileSize"></param>
        /// <param name="offset"></param>
        private void Connect(int serverPort, string machineName, string serverName, FileStream stream, long fileSize, long offset) {
            // Create a TCP/IP client socket.
            // Set up a temporary connection that is unencrypted, used to transfer the certificates?
            try {
                client = new TcpClient(machineName, serverPort);
                Debug.WriteLine("Client connected.");
            } catch (ArgumentNullException argExp) {
                throw new ConnectionException("Host or machine name is null", argExp);
            } catch (ArgumentOutOfRangeException argORExp) {
                throw new ConnectionException("The Port is incorrect", argORExp);
            } catch (SocketException argSExp) {
                throw new ConnectionException("There is a problem with the Socket", argSExp);
            }

            // Create an SSL stream that will close the client's stream.
            // TODO: The validate server certificate allways returns true
            //       If the validation fails we should ask the user to connect anyway
            sslStream = new SslStream(client.GetStream(),
                                      false,
                                      ValidateServerCertificate,
                                      null);

            // The server name must match the name on the server certificate.
            try {
                sslStream.AuthenticateAsClient(serverName);
            } catch (ArgumentNullException argExp) {
                throw new ConnectionException("Target host is null", argExp);
            } catch (AuthenticationException argExp) {
                throw new ConnectionException("The authentication failed and left this object in an unusable state.", argExp);
            } catch (InvalidOperationException argExp) {
                throw new ConnectionException("Authentication has already occurred or Server authentication using this SslStream was tried previously org Authentication is already in progress.", argExp);
            }

            // When we are connected we can now set up our receive mechanism
            var readBuffer = new byte[BUFFER_SIZE];
            var stateObj = new FileTransferStateObject();
            stateObj.fileSize = fileSize;
            stateObj.sslStream = sslStream;
            stateObj.target = stream;
            stateObj.transferBuffer = readBuffer;
            stateObj.transferOffset = offset;

            TimeOfLastNotify = DateTime.Now;

            sslStream.BeginRead(readBuffer, 0, readBuffer.Length, ReadCallback, stateObj);
        }

        /// <summary>Verifies the remote Secure Sockets Layer (SSL) certificate used for authentication.</summary>
        /// <param name="sender">An object that contains state information for this validation.</param>
        /// <param name="certificate">The certificate used to authenticate the remote party.</param>
        /// <param name="chain">The chain of certificate authorities associated with the remote certificate.</param>
        /// <param name="sslPolicyErrors">One or more errors associated with the remote certificate.</param>
        /// <returns>Returns true all the time, shoulh be: True if the certificate is valid, false otherwise</returns>
        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
            if (sslPolicyErrors == SslPolicyErrors.None) {
                return true;
            }
            // TODO: fix certificate validation
            return true;
        }

        #region Send Message

        /// <summary>Send a message to the server.</summary>
        /// <param name="message">The message to be sent (without any EOT).</param>
        public void SendMessage(string message) {
            if (sslStream != null) {
                var messsage = Encoding.UTF8.GetBytes(message + Utility.EOT);
                sslStream.Write(messsage);
                sslStream.Flush();
            }
        }

        #endregion

        /// <summary>Disconnect this connection</summary>
        public void Disconnect() {
            // try { sslStream.Close(); } catch { } finally { sslStream = null; }
            //try { client.Close(); } catch { } finally { client = null; }
            //trans.target.Close();

            if (client != null) {
                client.Close();
            }
            if (sslStream != null) {
                sslStream.Close();
            }
        }

        public event IntervalDelegate Interval;

        public delegate void IntervalDelegate();

        /// <summary>
        /// The read callback acts as the asynchronous message receive loop.
        /// Note: This code is inspired from Socio (see: socio.sf.net for more information)
        /// </summary>
        /// <param name="result">The result that the socket received</param>
        private void ReadCallback(IAsyncResult result) {
            if (client.Connected) {
                var now = DateTime.Now;
                if (now > TimeOfLastNotify.AddSeconds(1)) {
                    TimeOfLastNotify = now;
                    if (Interval != null) {
                        Interval();
                    }
                }

                var trans = (FileTransferStateObject) result.AsyncState;
                var bytesRead = trans.sslStream.EndRead(result);

                if (bytesRead > 0) // Check if there is any data
                {
                    trans.transferOffset += bytesRead;
                    bytesTransferred += bytesRead;

                    // Synchronosly write data to file...
                    // Make sure that when filestream is created it is created so
                    // that data written to it appends to the file...
                    trans.target.Write(trans.transferBuffer, 0, bytesRead);

                    // Transfer might not be complete
                    trans.transferBuffer = new byte[BUFFER_SIZE];
                    var r = trans.sslStream.BeginRead(trans.transferBuffer, 0, BUFFER_SIZE,
                                                      ReadCallback, trans);
                } else {
                    // All data has been received close ssl connection
                    //trans.sslStream.Shutdown();
                    trans.sslStream.Close();

                    // Close fileStream
                    trans.target.Close();

                    if (DataReceivedDoneEvent != null) {
                        DataReceivedDoneEvent();
                    }
                }
            }
        }

        /// <summary>Event for telling when received data is done</summary>
        public event DataReceivedDoneDelegate DataReceivedDoneEvent;

        public delegate void DataReceivedDoneDelegate();

        //FileTransfer classen år tänkt att skickas in som state objekt för överföringen
        internal class FileTransferStateObject {
            internal long fileSize; // Number of bytes in the file
            internal long transferOffset; // Number of bytes transfered
            internal byte[] transferBuffer = new byte[BUFFER_SIZE]; // A byte buffer for the transfer.
            internal FileStream target; //The file beng transfered
            internal SslStream sslStream;
        }
    }
}