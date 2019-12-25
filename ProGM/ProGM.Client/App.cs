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
using ProGM.Business.SocketBusiness;
using ProGM.Client.View.Chat;
using ProGM.Client.View.Login;
using ProGM.Client.View.TinhTien;
using ProGM.Business.Model;

namespace ProGM.Client
{
    public partial class App : DevExpress.XtraEditors.XtraForm {
        public IAsyncClient asyncClient;
        public frmChat frmChat;
        public frmDangNhap frmDangNhap;
        public frmTinhTien frmTinhTien;
        public frmLock frmLock;
        bool isVerifyAccount = false;
        bool isConnectServer = false;
        public App()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, //should be (0,0)
                          Screen.PrimaryScreen.Bounds.Y);
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            // kết nối tới máy trạm
            asyncClient = new AsyncClient();
            asyncClient.Connected += AsyncClient_Connected;
            asyncClient.MessageReceived += AsyncClient_MessageReceived;
            asyncClient.MessageSubmitted += AsyncClient_MessageSubmitted;
            new Thread(new ThreadStart(asyncClient.StartClient)).Start();

        }
        #region event socket
        private void AsyncClient_MessageSubmitted(IAsyncClient a, bool close)
        {
            //throw new NotImplementedException();
        }
        private void AsyncClient_Connected(IAsyncClient a)
        {
            isConnectServer = true;
            resgisterMac();
            asyncClient.Receive();
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
                            this.Invoke((Action)delegate
                            {
                                this.Show();
                                if (this.frmDangNhap != null)
                                {
                                    this.frmDangNhap.Hide();
                                }
                                if (this.frmLock != null)
                                {
                                    this.frmLock.Hide();
                                }
                            });
                        break;
                    case "CLOSE":
             
                            this.Invoke((Action)delegate
                            {
                                this.Hide();
                                if (this.frmDangNhap != null)
                                {
                                    this.frmDangNhap.Show();
                                }
                                if (this.frmLock != null)
                                {
                                    this.frmLock.Show();
                                }
                            });

                      
                        break;
                    case "LOGIN_SUCCESS":
                        this.Invoke((Action)delegate
                        {
                            this.Show();
                            if (this.frmDangNhap != null)
                            {
                                this.frmDangNhap.Hide();
                            }
                            if (this.frmLock != null)
                            {
                                this.frmLock.Hide();
                            }
                        });
                        break;
                    case "LOGIN_FALSED":
                        MessageBox.Show(obj.msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                        break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {


            }
        }

       
        #endregion

        #region form event

        private void App_Load(object sender, EventArgs e)
        {

            this.frmLock = new frmLock(this);
            this.Hide();
            this.frmLock.ShowDialog();
        }
        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            this.frmChat = (frmChat)Application.OpenForms["frmChat"];
            if (this.frmChat == null)
            {
                this.frmChat = new frmChat(this);
            }
            this.frmChat.TopMost = true;
            this.frmChat.Show();
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
