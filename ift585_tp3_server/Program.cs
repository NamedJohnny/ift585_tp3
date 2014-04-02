using ift585_tp3;
using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_server
{
    class Program
    {
		const int PORT = 1337;

        static TCPServer server;
	
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server initiating...");

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Fecthing data...");
            XMLDatabase db = new XMLDatabase();
            db.Load();
            Console.WriteLine("DONE");
            //================================

            //================================
            Console.Write("Opening port ...");
            server = new TCPServer(PORT, ReceiveCallback);
            Console.WriteLine("DONE");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Server ready.");
            //================================

            //================================
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(">Press ESC to stop server.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            do
            {
                while (!Console.KeyAvailable)
                {
                    // TODO (vincent) logic here

                    // TODO receive from client method or whatever
                    // TODO Get data...
                    Data received = new Data();
                    switch (received.Command)
                    {
                        case Data.DataType.Login:
                            break;

                        case Data.DataType.Logout:
                            break;

                        case Data.DataType.SendMessage:
                            break;

                        case Data.DataType.GetMessages:
                            break;

                        case Data.DataType.Like:
                            break;

                        case Data.DataType.Dislike:
                            break;

                        case Data.DataType.ViewProfile:
                            break;

                        case Data.DataType.UpdateProfile:
                            break;
                    }


                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            //================================

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Storing data...");
            db.Save();
            Console.WriteLine("DONE");
            //================================
        }

        static int ReceiveCallback(Tuple<Socket, Data> msg)
        {
            Socket client = msg.Item1;
            Data data = msg.Item2;

            // TODO (vincent) when you receive a request,
            // react accordindly here
            Console.WriteLine("The server received : " + data.Text);

            // TODO (vincent) response
            Data response = new Data() { Text = "response" };
            server.Send(client, response);
            //server.Broadcast("response"); // you can also broadcast

            return 0;
        }
    }
}
