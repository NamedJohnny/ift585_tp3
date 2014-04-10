using ift585_tp3;
using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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

        private static bool isclosing = false;

        static void Main(string[] args)
        {
            SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);

            StartChatServer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            
            while (!isclosing);
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
                    response.Command = Data.DataType.Login;
                    user = users.FirstOrDefault(x => x.UserName == received.Text 
                                                && x.Password == (string)received.Other);
                    if (user != null)
                    {
                        if (!user.IsConnected)
                        {
                            user.IsConnected = true;
                            response.Text = "200";
                            response.User = user;
                            Console.WriteLine("User " + user.UserName + " logged in.");
                        }
                        else
                        {
                            // User already connected
                            response.Text = "401";
                            response.User = user;
                            Console.WriteLine("User " + user.UserName + " is already logged in.");
                        }
                    }
                    else
                    {
                        // Could not find user according to username + pwd
                        response.Text = "404";
                        Console.WriteLine("User " + received.Text + " doesn't exist with provided password.");
                    }
                    break;

                case Data.DataType.Logout:
                    //response.Command = Data.DataType.Logout;
                    user = users.FirstOrDefault(x => x.UserName == received.Text);
                    if (user != null)
                    {
                        foreach (DiscussionRoom r in rooms)
                            if (r.ClientList.Contains(user))
                                r.ClientList.Remove(user);
                        user.IsConnected = false;
                        Console.WriteLine("User " + user.UserName + " logged out.");
                        //response.Text = "ok";
                        //response.User = user;
                    }
                    //else
                    //{
                    //    response.Text = "reject";
                    //}
                    break;

                case Data.DataType.SendMessage:
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    room = rooms.FirstOrDefault(x => x.ClientList.Any(y => y.UserName == user.UserName));
                    room.MessageList.Add(received);
                    room.LastModified = DateTime.Now;
                    user.NumMessages++;
                    Console.WriteLine("User " + user.UserName + " sent a message.");
                    break;

                case Data.DataType.GetDiscussionRoom:
                    response.Command = Data.DataType.GetDiscussionRoom;
                    user = users.FirstOrDefault(x => x.UserName == received.Text);
                    room = rooms.FirstOrDefault(x => x.ClientList.Any(y => y.UserName == user.UserName));
                    if(room.LastModified > received.Date)
                    {
                        response.Other = room;
                    }
                    break;

                case Data.DataType.Like:
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    user.LikeNum++;
                    Console.WriteLine("User " + user.UserName + " gets a Like.");
                    break;

                case Data.DataType.Dislike:
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    user.DislikeNum++;
                    Console.WriteLine("User " + user.UserName + " gets a Dislike.");
                    break;

                case Data.DataType.ViewProfile:
                    response.Command = Data.DataType.ViewProfile;
                    response.Other = users.FirstOrDefault(x => x.UserName == received.Text);
                    Console.WriteLine("GET " + received.Text + "'s profile.");
                    break;

                case Data.DataType.UpdateProfile:
                    response.Command = Data.DataType.UpdateProfile;
                    user = users.FirstOrDefault(x => x.UserName == received.Text);
                    updatedUser = received.User;
                    if (user.UserName != updatedUser.UserName
                        && users.Any(x => x.UserName == updatedUser.UserName))
                    {
                        response.Text = "401";
                        Console.WriteLine("User " + user.UserName + " profile modification refused.");
                    }
                    else
                    {
                        user.FirstName = updatedUser.FirstName;
                        user.LastName = updatedUser.LastName;
                        user.UserName = updatedUser.UserName;
                        user.Avatar = updatedUser.Avatar;
                        response.Text = "200";
                        Console.WriteLine("User " + user.UserName + "'s profile updated.");
                    }
                    break;

                case Data.DataType.ListClient:
                    response.Command = Data.DataType.ListClient;
                    response.Other = users;
                    Console.WriteLine("GET users list.");
                    break;

                case Data.DataType.ListDiscussionRoom:
                    response.Command = Data.DataType.ListDiscussionRoom;
                    response.Other = rooms;
                    Console.WriteLine("GET rooms list.");
                    break;

                case Data.DataType.EnterRoom:
                    response.Command = Data.DataType.EnterRoom;
                    user = users.FirstOrDefault(x => x.UserName == received.ClientUserName);
                    room = rooms.FirstOrDefault(x => x.Name == received.Text);
                    room.ClientList.Add(user);
                    response.Other = room;
                    room.LastModified = DateTime.Now;
                    Console.WriteLine("User " + user.UserName + " enters a room.");
                    break;

                case Data.DataType.AddRoom:
                    response.Command = Data.DataType.AddRoom;
                    room = (DiscussionRoom)received.Other;
                    if (rooms.Any(x => x.Name == room.Name))
                    {
                        response.Text = "400";
                        Console.WriteLine("Room creation canceled.");
                    }
                    else
                    {
                        response.Text = "201";
                        rooms.Add(room);
                        Console.WriteLine("Room '" + room.Name + "' created.");
                    }
                    break;

                case Data.DataType.LeaveRoom:
                    user = users.FirstOrDefault(x => x.UserName == received.Text);
                    room = rooms.FirstOrDefault(x => x.ClientList.Any(y => y.UserName == user.UserName));
                    room.ClientList.Remove(user);
                    room.LastModified = DateTime.Now;
                    Console.WriteLine("User " + user.UserName + " leaves room.");
                    break;

                case Data.DataType.DeleteMessage:
                    user = users.FirstOrDefault(x => x.UserName == received.Text);
                    room = rooms.FirstOrDefault(x => x.ClientList.Any(y => y.UserName == user.UserName));
                    room.MessageList.RemoveAll(x => x.Id == (int)received.Other);
                    room.LastModified = DateTime.Now;
                    Console.WriteLine("User " + user.UserName + " deletes a message.");
                    break;
            }

            if (response.Command != Data.DataType.Invalid)
            {
                server.Send(client, response);
            }

            return 0;
        }

        static void StartChatServer()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server initiating...");

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Fetcthing data...");
            //XMLDatabase.Add(); // Uncomment to reset XML (Debug purpose)
            XMLData xmlData = XMLDatabase.Load();
            xmlData.rooms.ForEach(x => rooms.Add(x));
            xmlData.users.ForEach(x => users.Add(x));
            Console.WriteLine("DONE");
            //================================

            //================================
            Console.Write("Opening port ...");
            server = new TCPServer(PORT, ReceiveCallback);
            Console.WriteLine("DONE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server ready.");
            //================================
        }

        static void CloseChatServer()
        {
            // Disconnect all users and clear users from rooms
            users.ForEach(x => x.IsConnected = false);
            rooms.ForEach(x => x.ClientList.Clear());

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Storing data...");
            XMLDatabase.Save(new XMLData(rooms, users));
            Console.WriteLine("DONE");
            //================================

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server closed.");
            System.Threading.Thread.Sleep(1000);
        }

        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            switch (ctrlType)
            {
                case CtrlTypes.CTRL_CLOSE_EVENT:
                    isclosing = true;
                    CloseChatServer();
                    break;
            }
            return true;
        }

        #region unmanaged
        // When pressing console X button
        // http://stackoverflow.com/questions/9897247/run-code-on-console-close
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
        #endregion
    }
}
