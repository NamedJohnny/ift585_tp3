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
            //client.BeginConnect("localhost", 1337, new AsyncCallback(ConnectCallback), client);
            client.Connect(ip, port);
            //client.BeginConnect
            BeginReceive(client.Client);

            //Data test = new Data();
            //test.User = new User();
            //test.User.Id = 3;
            //test.Text = "a slap in the face.";
            //Send(test);
        }

        public void Send(Data msg)
        {
            byte[] byteData = Data.Serialize(msg);

            // TODO try adding a null byte
            if (byteData.Length == SocketState.BufferSize)
                throw new Exception("Won't be able to make difference between end of byte array and end of message.");

            // Begin sending the data to the remote device.
            client.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client.Client);
        }
    }
}
