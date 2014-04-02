using ift585_tp3;
using ift585_tp3_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server initiating...");

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Fecthing data...");
            // TODO (roy) Load data from DB (JSON files)
            // Ex data:
            User user1 = new User();
            ///...
            //var json = new JavaScriptSerializer().Serialize(thing);
            Console.WriteLine("DONE");
            //================================

            //================================
            TCPServer tcp = new TCPServer();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Server ready.");
            //================================

            //================================
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(">Press ESC to stop server.");
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Storing data...");
            // TODO (roy) Store data into DB (JSON files)
            Console.WriteLine("DONE");
            //================================
        }
    }
}
