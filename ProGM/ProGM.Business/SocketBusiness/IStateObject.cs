using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ProGM.Business.SocketBusiness
{
    public interface IStateObject
    {
        DateTime TimeAccept { get; }
        int BufferSize { get; }

        int Id { get; }

        bool Close { get; set; }

        byte[] Buffer { get; }

        Socket Listener { get; }

        string Text { get; }

        void Append(string text);

        void Reset();
    }
}
