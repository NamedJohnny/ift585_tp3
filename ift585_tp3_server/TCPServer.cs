﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ift585_tp3_library;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.IO;

namespace ift585_tp3
{
    class TCPServer
    {
        protected TcpListener listener;

        protected List<Client> clients;

        protected Func<string, int> Receive;

        public TCPServer(Func<string, int> receive)
        {
            clients = new List<Client>();
            Receive = receive;

            listener = new TcpListener(IPAddress.Any, 1337);
            listener.Start();
            //Receive(listener.);
            listener.BeginAcceptTcpClient(ClientConnectedCallback, null);
        }


        private void ClientConnectedCallback(IAsyncResult result)
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
            socket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
        }
        private void SendCallback(IAsyncResult ar)
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

        public void BeginReceive(Socket client)
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
                    string request = System.Text.Encoding.Default.GetString(state.buffer);
                    Receive(request);
                    //Console.WriteLine(request);
                    Send(client, "response");
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

    public class Client
    {
        public TcpClient socket;

        public Client(TcpClient _socket)
        {
            socket = _socket;
        }
    }
}
