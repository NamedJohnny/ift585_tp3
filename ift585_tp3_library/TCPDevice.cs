using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ift585_tp3_library
{
    public abstract class TCPDevice
    {
        protected Func<Tuple<Socket, string>, int> Receive;

        public TCPDevice(Func<Tuple<Socket, string>, int> receive)
        {
            Receive = receive;
        }

        protected void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                //Socket socket = (Socket) ar.AsyncState;
                Socket socket = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = socket.EndSend(ar);
                //Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                //sendDone.Set();
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
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    //  Get the rest of the data.
                    //string request = state.sb.ToString();
                    string response = System.Text.Encoding.Default.GetString(state.buffer);
                    //Console.WriteLine(response);
                    Receive(new Tuple<Socket,string>(client, response));
                    //client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    /*if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                        Console.WriteLine(response);
                    }*/
                    // Signal that all bytes have been received.
                    //receiveDone.Set();
                }
                BeginReceive(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
