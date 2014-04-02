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
    class TCPClient : TCPDevice
    {
        protected TcpClient client;

        public TCPClient(string ip, int port, Func<Tuple<Socket, string>, int> receive)
            : base(receive)
        {
            client = new TcpClient();
            //client.BeginConnect("localhost", 1337, new AsyncCallback(ConnectCallback), client);
            client.Connect(ip, port);
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
            client.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client.Client);
        }

        //private void ReceiveCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        // Retrieve the state object and the client socket 
        //        // from the asynchronous state object.
        //        SocketState state = (SocketState)ar.AsyncState;
        //        Socket client = state.workSocket;
        //        // Read data from the remote device.
        //        int bytesRead = client.EndReceive(ar);
        //        if (bytesRead > 0)
        //        {
        //            // There might be more data, so store the data received so far.
        //            //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
        //            //  Get the rest of the data.
        //            //string request = state.sb.ToString();
        //            string response = System.Text.Encoding.Default.GetString(state.buffer);
        //            //Console.WriteLine(response);
        //            Receive(response);
        //            //client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
        //        }
        //        else
        //        {
        //            // All the data has arrived; put it in response.
        //            /*if (state.sb.Length > 1)
        //            {
        //                response = state.sb.ToString();
        //                Console.WriteLine(response);
        //            }*/
        //            // Signal that all bytes have been received.
        //            //receiveDone.Set();
        //        }
        //        BeginReceive(client);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}
    }
}
