using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using ift585_tp3_library; 

namespace ift585_tp3
{
    static class Program
    {
        const string IP = "localhost";
        const int PORT = 1337;

        public static TCPClient client = new TCPClient(IP, PORT, ReceiveCallback);
        public delegate int CallBackFunction(Data data);
        public static Queue<CallBackFunction> callBackOnReceive = new Queue<CallBackFunction>();

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            // When closing application
            client.Close();
        }

        static int ReceiveCallback(Tuple<Socket, Data> msg)
        {
            Socket server = msg.Item1;
            Data data = msg.Item2;

            CallBackFunction toCall = callBackOnReceive.Dequeue();
            toCall.BeginInvoke(data, null, null);

            return 0;
        }
    }
}
