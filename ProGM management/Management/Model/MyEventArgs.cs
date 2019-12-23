using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model
{
    class MyEventArgs : EventArgs
    {
        private TcpClient sock;
        public TcpClient clientSock
        {
            get { return sock; }
            set { sock = value; }
        }

        public MyEventArgs(TcpClient tcpClient)
        {
            sock = tcpClient;
        }


    }
}
