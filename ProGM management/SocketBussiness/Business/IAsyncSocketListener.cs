using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketBussiness.Business
{
    public interface IAsyncSocketListener : IDisposable
    {
        event MessageReceivedHandler MessageReceived;

        event MessageSubmittedHandler MessageSubmitted;
        event ClientDisconnectHandler ClientDisconnect;

        void StartListening();

        bool IsConnected(int id);

        void OnClientConnect(IAsyncResult result);
        void DisconnectCallBack(IAsyncResult result);

        void ReceiveCallback(IAsyncResult result);

        void Send(int id, string msg, bool close);

        void Close(int id);
    }
}
