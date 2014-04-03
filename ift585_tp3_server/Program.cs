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

         static List<User> users = new List<User>();
         static List<DiscussionRoom> rooms = new List<DiscussionRoom>();

        static TCPServer server;
	
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server initiating...");

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Ftecthing data...");
            //XMLDatabase db = new XMLDatabase();
            //Pour ajouter de nouveau clients/salles
            //db.Add();
            XMLData xmlData = XMLDatabase.Load();
          
            foreach (DiscussionRoom room in xmlData.rooms)
            {
                rooms.Add(room);
            }
            foreach (User user in xmlData.users)
            {
                users.Add(user);
            }

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
                    // TODO What?

                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            //================================

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Storing data...");
            xmlData = new XMLData(rooms, users);
            XMLDatabase.Save(xmlData);
            Console.WriteLine("DONE");
            //================================
        }

        static int ReceiveCallback(Tuple<Socket, Data> msg)
        {
            Socket client = msg.Item1;
            Data received = msg.Item2;
            Data response = new Data() { Text = "response" };

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

            db.Save();
            xmlData = new XMLData(rooms, users);
            XMLDatabase.Save(xmlData);
            // TODO (vincent) when you receive a request,
            // react accordindly here
            Console.WriteLine("The server received : " + received.Text);

            // TODO (vincent) response
            
            server.Send(client, response);
            //server.Broadcast("response"); // you can also broadcast

            return 0;
        }
    }
}
