using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ift585_tp3_library;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.IO;
using ift585_tp3_server;

namespace ift585_tp3
{
    class TCPServer : TCPDevice
    {
        protected TcpListener listener;

        protected List<Client> clients;

        //protected Func<string, int> Receive;

        public TCPServer(int port, Func<Tuple<Socket, string>, int> receive) : base (receive)
        {
            clients = new List<Client>();
            //Receive = receive;

            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            //Receive(listener.);
            listener.BeginAcceptTcpClient(ClientConnectedCallback, null);
        }

        protected void ClientConnectedCallback(IAsyncResult result)
        {
            TcpClient tcpClient = listener.EndAcceptTcpClient(result);
            Console.WriteLine("Client connected.");
            clients.Add(new Client(tcpClient));
            BeginReceive(tcpClient.Client);
            listener.BeginAcceptTcpClient(ClientConnectedCallback, null);
        }

        public void Send(Socket socket, string msg)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(msg);

            // Begin sending the data to the remote device.
            socket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), socket);
        }

        public void Broadcast(string msg)
        {
            foreach (Client client in clients)
            {
                Send(client.socket.Client, msg);
            }
        }

        /*public void BeginReceive(Socket client)
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
        }*/


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
        //            string request = System.Text.Encoding.Default.GetString(state.buffer);
        //            Receive(request);
        //            //Console.WriteLine(request);
        //            Send(client, "response");
        //            //client.BeginReceive(state.buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
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
