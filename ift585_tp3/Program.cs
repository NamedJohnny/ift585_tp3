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
        public static TCPClient client;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            client = new TCPClient(Receive);
            //TCPClient c2 = new TCPClient();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        static int Receive(string msg)
        {
            // TODO when you receive something, react here

            return 0;
        }
    }
}
