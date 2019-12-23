using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Management.Views.DangNhap;
using SocketBussiness.Business;

namespace Management
{
    public partial class App : Form
    {
       IAsyncSocketListener asyncSocketListener;
        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            asyncSocketListener = AsyncSocketListener.Instance;
            asyncSocketListener.MessageReceived += AsyncSocketListener_MessageReceived;
            asyncSocketListener.ClientDisconnect += AsyncSocketListener_ClientDisconnect;
            backgroundWorker1.RunWorkerAsync();
         //   this.Hide();
            DangNhap frmlogin = new DangNhap();
            frmlogin.ShowDialog();
        }

        private void AsyncSocketListener_ClientDisconnect(int id)
        {
            throw new NotImplementedException();
        }

        private void AsyncSocketListener_MessageReceived(int id, string msg)
        {
       
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            asyncSocketListener.StartListening();
        }
    }
}
