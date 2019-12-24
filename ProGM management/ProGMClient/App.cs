using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProGMClient.Business;
using ProGMClient.View.Chat;
using SocketBussiness.Business;
using SocketBussiness.Model;

namespace ProGMClient
{
    public partial class App : Form
    {
        public IAsyncClient asyncClient;
        public frmChat  frmChat;
        public App()
        {
            InitializeComponent();
            asyncClient = new AsyncClient();
            asyncClient.Connected += AsyncClient_Connected;
            asyncClient.MessageReceived += AsyncClient_MessageReceived;
            asyncClient.MessageSubmitted += AsyncClient_MessageSubmitted;
            asyncClient.StartClient();
        }
        #region event socket
        private void AsyncClient_MessageSubmitted(IAsyncClient a, bool close)
        {
            //throw new NotImplementedException();
        }

        private void AsyncClient_MessageReceived(IAsyncClient a, string msg)
        {
            asyncClient.Receive();
            //throw new NotImplementedException();
        }

        private void AsyncClient_Connected(IAsyncClient a)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region form event

        private void App_Load(object sender, EventArgs e)
        {
            resgisterMac();
            this.Hide();
            Main frmMain = new Main(this);
            frmMain.ShowDialog();
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            asyncClient.Send("Tạm Biệt", true);
        }
        #endregion

        #region  other method

        public void resgisterMac()
        {
            string macaddress = PCExtention.GetMacId();
            SocketReceivedData ms = new SocketReceivedData();
            ms.msgFrom = "Linh";
            ms.msgTo = "SERVER";
            ms.macAddressFrom = macaddress;
            ms.type = "AUTHORIZE";
            this.asyncClient.Send(JsonConvert.SerializeObject(ms), false);
        }
        #endregion
    }
}
