using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ift585_tp3_server
{
    public class Client
    {
        public TcpClient socket;

        public Client(TcpClient _socket)
        {
            socket = _socket;
        }
    }
}
