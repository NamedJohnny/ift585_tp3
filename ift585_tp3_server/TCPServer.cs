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

        //protected Func<string, int> Receive;

        public TCPServer(int port, Func<Tuple<Socket, Data>, int> receive) : base (receive)
        {
            //clients = new List<Client>();

            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            listener.BeginAcceptTcpClient(ClientConnectedCallback, null);
        }

        protected void ClientConnectedCallback(IAsyncResult result)
        {
            TcpClient tcpClient = listener.EndAcceptTcpClient(result);
            Console.WriteLine("Client connected.");
            //clients.Add(new Client(tcpClient));
            BeginReceive(tcpClient.Client);
            listener.BeginAcceptTcpClient(ClientConnectedCallback, null);
        }

        public void Send(Socket socket, Data msg)
        {
            // Convert the string data to byte data using ASCII encoding.
            //byte[] byteData = Encoding.ASCII.GetBytes(msg);
            //Message byteData = TCPDevice.Serialize(msg);
            byte[] byteData = Data.Serialize(msg);
            //byte[] byteData = msg.
            // Begin sending the data to the remote device.
            socket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), socket);
        }

        //public void Broadcast(Data msg)
        //{
        //    foreach (Client client in clients)
        //    {
        //        Send(client.socket.Client, msg);
        //    }
        //}
    }
}
