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

        public TCPClient(string ip, int port, Func<Tuple<Socket, Data>, int> receive)
            : base(receive)
        {
            client = new TcpClient();
            client.Connect(ip, port);
            BeginReceive(client.Client);
        }

        public void Send(Data msg)
        {
            byte[] byteData = Data.Serialize(msg);

            // TODO try adding a null byte
            if (byteData.Length == SocketState.BufferSize)
                throw new Exception("Won't be able to make difference between end of byte array and end of message.");
            else if (byteData.Length > SocketState.BufferSize)
            {
                throw new Exception("Message is too long. It is currently not supported.");
            }

            // Begin sending the data to the remote device.
            client.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client.Client);
        }

        public void Close()
        {
            if (client.Connected)
            {
                client.Client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
    }
}
