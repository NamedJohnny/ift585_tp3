﻿using System;
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

        public TCPServer(int port, Func<Tuple<Socket, Data>, int> receive) : base (receive)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            listener.BeginAcceptTcpClient(ClientConnectedCallback, null);
        }

        protected void ClientConnectedCallback(IAsyncResult result)
        {
            TcpClient tcpClient = listener.EndAcceptTcpClient(result);
            Console.WriteLine("Client connected.");
            BeginReceive(tcpClient.Client);
            listener.BeginAcceptTcpClient(ClientConnectedCallback, null);
        }

        public void Send(Socket socket, Data msg)
        {
            byte[] byteData = Data.Serialize(msg);

            if (byteData.Length == SocketState.BufferSize)
                Console.WriteLine("Won't be able to make difference between end of byte array and end of message.");
            else if (byteData.Length > SocketState.BufferSize)
            {
                Console.WriteLine("Message is too long. It is currently not supported.");
            }
            else
            {
                socket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), socket);
            }
        }
    }
}
