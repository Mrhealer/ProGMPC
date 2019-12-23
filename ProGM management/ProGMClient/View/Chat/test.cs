using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;
using Quobject.SocketIoClientDotNet.Client;

namespace ProGMClient.View.Chat
{
    public partial class test : Form
    {
        Socket socket;
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            socket = IO.Socket("http://127.0.0.1:8000");
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                //Dispatcher.Invoke(() =>
                //{
                //    socket.Emit("VeryToken", "gekkki");
                //});
                socket.Emit("VeryToken", "gekkki");
            });

            socket.On("disconnect", (data) =>
            {
                MessageBox.Show("server disconnect");
            });
            socket.On(Socket.EVENT_ERROR, (error) =>
            {
                MessageBox.Show("Connect Eror");
            });

            socket.On(Socket.EVENT_CONNECT_TIMEOUT, () =>
            {
                MessageBox.Show("EVENT_CONNECT_TIMEOUT");
            });
        }
    }
}
