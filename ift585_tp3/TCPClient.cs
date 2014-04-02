using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ift585_tp3
{
    class TCPClient
    {
        protected TcpClient client;

        protected Func<string, int> Receive;

        public TCPClient(Func<string, int> receive)
        {
            Receive = receive;

            client = new TcpClient();
            //client.BeginConnect("localhost", 1337, new AsyncCallback(ConnectCallback), client);
            client.Connect("localhost", 1337);
            //client.BeginConnect
            BeginReceive(client.Client);
            Send("penis hahaha");
            Send("vagin huehuehue");

            Thread.Sleep(500);
            Send("a slap in the face");
        }

        public void Send(string msg)
        {
            // Convert the string data to byte data using ASCII encoding.
            //byte[] byteData = Encoding.ASCII.GetBytes(msg);
            byte[] byteData = Encoding.ASCII.GetBytes(msg);

            // TODO send truc pas concatener avec autre truc
            // Begin sending the data to the remote device.
            client.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);
        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                //Socket socket = (Socket) ar.AsyncState;
                TcpClient _client = (TcpClient)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = _client.Client.EndSend(ar);
                //Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                //sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void BeginReceive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
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
                StateObject state = (StateObject)ar.AsyncState;
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
                    Receive(response);
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

    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
}
