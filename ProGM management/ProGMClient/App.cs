using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProGMClient.Business;
using ProGMClient.View.Chat;
using ProGMClient.View.Login;
using ProGMClient.View.TinhTien;
using SocketBussiness.Business;
using SocketBussiness.Model;

namespace ProGMClient
{
    public partial class App : Form
    {
        public IAsyncClient asyncClient;
        public frmChat frmChat;
        public frmDangNhap frmDangNhap;
        public frmTinhTien frmTinhTien;
        public frmLock frmLock;
        
        public App()
        {
            InitializeComponent();
            asyncClient = new AsyncClient();
            asyncClient.Connected += AsyncClient_Connected;
            asyncClient.MessageReceived += AsyncClient_MessageReceived;
            asyncClient.MessageSubmitted += AsyncClient_MessageSubmitted;

        }
        #region event socket
        private void AsyncClient_MessageSubmitted(IAsyncClient a, bool close)
        {
            //throw new NotImplementedException();
        }

        private void AsyncClient_MessageReceived(IAsyncClient a, string msg)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<SocketReceivedData>(msg);

                switch (obj.type)
                {
                    case "AUTHORIZE":
                        break;
                    case "CHAT":
                        if (this.frmChat == null || (this.frmChat != null && this.frmChat.Disposing))
                        {
                            this.frmChat = new frmChat(this);

                        }
                        this.Invoke((Action)delegate
                        {
                            this.frmChat.UpdateHistory(obj.msgFrom + " Say: " + obj.msg + DateTime.Now.ToString("     HH:ss dd/MM/yyyy"));
                            this.frmChat.Show();
                        });
                        break;
                    case "OPEN":
                        if (this.frmTinhTien==null)
                        {
                            this.Invoke((Action)delegate
                            {
                                this.Hide();
                                if (this.frmDangNhap != null)
                                {
                                    this.frmDangNhap.Hide();
                                }
                                if (this.frmLock != null)
                                {
                                    this.frmLock.Hide();
                                }
                                this.frmTinhTien = new frmTinhTien(this);
                                this.frmTinhTien.Show();
                            });
                           
                        }
                        else if(this.frmTinhTien!=null && !this.frmTinhTien.Disposing)
                        {

                        }
                        break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {


            }
        }

        private void AsyncClient_Connected(IAsyncClient a)
        {
            resgisterMac();
            asyncClient.Receive();
        }
        #endregion

        #region form event

        private void App_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(asyncClient.StartClient)).Start();
      
            this.Hide();
            this.frmLock  = new frmLock(this);
            this.frmLock.ShowDialog();
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
