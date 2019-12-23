using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGMClient.Business
{
    class SocketClient
    {
        public static Socket socket;

        public static void ConectServer()
        {
            socket = IO.Socket("http://127.0.0.1:8000");
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                socket.Emit("SEND_DATA", "Helllo_admin");
                socket.Emit("SEND_MESSAGE", "message =12msdsahdsajk");
            });

            socket.On("disconnect", (data) =>
            {

            });
            socket.On("error", (error) =>
            {

            });
        }
    }
}
