using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ift585_tp3_library
{
    public abstract class TCPDevice
    {
        protected Func<Tuple<Socket, Data>, int> AllReceiveCallback;

        public TCPDevice(Func<Tuple<Socket, Data>, int> receive)
        {
            AllReceiveCallback = receive;
        }

        protected void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket socket = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.
                int bytesSent = socket.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        protected void BeginReceive(Socket client)
        {
            try
            {
                // Create the state object.
                SocketState state = new SocketState();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                SocketState state = (SocketState)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                // Append to already part of the msg that are already received
                state.received.AddRange(state.buffer);

                if (bytesRead == 0)
                {
                    // Nothing
                }
                else if (bytesRead >= SocketState.BufferSize)
                {
                    // There are bytes remaining to read
                    // Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);    
                }
                else // byte between 0 and SocketState.BufferSize
                {
                    // All bytes received
                    byte[] dataBytes = state.received.ToArray();
                    Data data = Data.Deserialize(dataBytes);
                    state.received.Clear();

                    // Warn application
                    AllReceiveCallback(new Tuple<Socket, Data>(client, data));

                    // Restart receiving other msg
                    BeginReceive(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
