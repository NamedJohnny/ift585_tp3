using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ift585_tp3
{
    class TCPServer
    {
        public const int PORT = 1337;

        protected TcpListener tcpListener;
        //protected List<Client> clients;

        public TCPServer()
        {
            Console.Write("Opening port " + PORT + "...");
            tcpListener = new TcpListener(PORT);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(ClientConnectedCallback, null);

            //IPAddress ip = new IPAddress();
            //TcpListener TCPServer = new TcpListener(ip, 1337);
            Console.WriteLine("DONE");
        }

        private void ClientConnectedCallback(IAsyncResult result)
        {
            Console.WriteLine("Client connected.");

            /*byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            Client client = new Client(tcpClient, buffer);
            lock (this.clients)
            {
                this.clients.Add(client);
            }
            NetworkStream networkStream = client.NetworkStream;
            networkStream.BeginRead(client.Buffer, 0, client.Buffer.Length, ReadCallback, client);
            tcpListener.BeginAcceptTcpClient(AcceptTcpClientCallback, null);*/
        }
    }
}
