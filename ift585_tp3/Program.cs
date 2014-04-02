using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets; 

namespace ift585_tp3
{
    static class Program
    {
        const string IP = "localhost";
        const int PORT = 1337;

        public static TCPClient client = new TCPClient(IP, PORT, Receive);

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        static int Receive(Tuple<Socket, string> msg)
        {
            Socket server = msg.Item1;
            string data = msg.Item2;

            // If you want, you can send somthing to the server
            // when he sends you something
            // client.Send("something else");

            return 0;
        }
    }
}
