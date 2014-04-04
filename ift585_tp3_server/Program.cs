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
            Data response = new Data();

            User user;
            DiscussionRoom room;
            User updatedUser;

            switch (received.Command)
            {
                case Data.DataType.Login:
                    user = users.FirstOrDefault(x => x.UserName == received.Text 
                                                      && x.Password == (string)received.Other);
                    if (user != null)
                    {
                        response.Command = Data.DataType.AcceptLogin;
                        user.IsConnected = true;
                        response.User = user;
                    }
                    else
                    {
                        response.Command = Data.DataType.DeclineLogin;
                    }
                    break;

                case Data.DataType.Logout:
                    break;

                case Data.DataType.SendMessage:
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    room = rooms.FirstOrDefault(x => x.ClientList.Any(y => y.UserName == user.UserName && y.IsConnected));
                    room.MessageList.Add(received);
                    room.LastModified = DateTime.Now;
                    user.NumMessages++;
                    break;

                case Data.DataType.GetDiscussionRoom:
                    response.Command = Data.DataType.GetDiscussionRoom;
                    user = users.FirstOrDefault(x => x.UserName == received.Text);
                    room = rooms.FirstOrDefault(x => x.ClientList.Any(y => y.UserName == user.UserName && y.IsConnected));
                    // TODO Temp IsConnected to get the right room, since some have DC people.
                    if(room.LastModified > received.Date)
                    {
                        response.Other = room;
                    }
                    break;

                case Data.DataType.Like:
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    user.LikeNum++;
                    break;

                case Data.DataType.Dislike:
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    user.DislikeNum++;
                    break;

                case Data.DataType.ViewProfile:
                    response.Command = Data.DataType.ViewProfile;
                    response.Other = users.FirstOrDefault(x => x.UserName == received.Text);
                    break;

                case Data.DataType.UpdateProfile:
                    user = users.FirstOrDefault(x => x.UserName == received.Text);
                    updatedUser = received.User;
                    user.FirstName = updatedUser.FirstName;
                    user.LastName = updatedUser.LastName;
                    user.UserName = updatedUser.UserName;
                    user.Avatar = updatedUser.Avatar;
                    break;

                case Data.DataType.ListClientOnline:
                    response.Command = Data.DataType.ListClientOnline;
                    response.Other = users.Where(x => x.IsConnected).ToList();
                    break;

                case Data.DataType.ListDiscussionRoom:
                    response.Command = Data.DataType.ListDiscussionRoom;
                    response.Other = rooms;
                    break;

                case Data.DataType.EnterRoom:
                    response.Command = Data.DataType.EnterRoom;
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    room = rooms.FirstOrDefault(x => x.Name == received.Text);
                    room.ClientList.Add(user);
                    response.Other = room;
                    break;

                case Data.DataType.AddRoom:
                    room = (DiscussionRoom)received.Other;
                    rooms.Add(room);
                    break;
            }

            Console.WriteLine("The server received : " + received.Text);

            if (response.Command != Data.DataType.Invalid)
            {
                server.Send(client, response);
            }

            return 0;
        }
    }
}
