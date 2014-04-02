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
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Server initiating...");

            //================================
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Fecthing data...");
            // TODO (roy) Load data from DB (JSON files)
            //  Load data from DB (XML files)
            string fileName = "Data.xml";
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            FileStream fs = new FileStream(fileName, FileMode.Open);
            List<GroupeDeData> gdd = new List<GroupeDeData>();

            DataContractSerializer serializer = new DataContractSerializer(gdd.GetType(), null,
                0x7FFF /*maxItemsInObjectGraph*/,
                false /*ignoreExtensionDataObject*/,
                true /*preserveObjectReferences : this is where the magic happens */,
                null /*dataContractSurrogate*/);
            //serializer.WriteObject(Console.OpenStandardOutput(), gdd);
            gdd = serializer.ReadObject(fs) as List<GroupeDeData>;
            fs.Close();
            Console.WriteLine("DONE");
            //================================

            //================================
            TCPServer tcp = new TCPServer(Receive);
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
            // Sauvegarde en XML les salles de discussions et les utilisateurs
            // TODO Getter les données du moment et les enregistrer
            fs = File.Open("Data.xml", FileMode.Create);
            Console.WriteLine("Testing for type: {0}", typeof(GroupeDeData));
            serializer.WriteObject(fs, gdd);
            fs.Close();
            Console.WriteLine("DONE");
            //================================
        }

        static int Receive(string msg)
        {
            // WHEN YOU RECEIVE SOMETHING, REACT HERE
            Console.WriteLine("The server receives : " + msg);
            return 0;
        }
    }
}
