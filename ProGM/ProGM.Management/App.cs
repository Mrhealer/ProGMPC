using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProGM.Management.Views.DangNhap;
using ProGM.Business.SocketBusiness;
using ProGM.Business.Model;
using Newtonsoft.Json;
using ProGM.Management.Views;
using System.Threading;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using ProGM.Management.FormState;
using DevExpress.Utils.Svg;
using ProGM.Management.Model;
using ProGM.Management.Views.TinhTrangHoatDong;
using ProGM.Management.Views.TaiKhoan;
using ProGM.Management.Views.NhatKyHeThong;
using ProGM.Management.Views.NhatKySuDung;
using ProGM.Management.Views.NhomNguoiDung;
using ProGM.Management.Views.NhomMay;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using ProGM.Management.Controller;
using RestSharp;
using ProGM.Management.Views.Chat;

namespace ProGM.Management
{
    public partial class App : DevExpress.XtraEditors.XtraForm
    {
        MenuObject objMenu = new MenuObject();
        TinhTrang userTinhTrang;


        public IAsyncSocketListener asyncSocketListener;
        public List<SocketClients> clients = new List<SocketClients>();

        Thread threadListen;
        public bool isVerifyAccount = false;
        public App()
        {
            InitializeComponent();
            SocketEventRegistration();
        }

        #region socket event  

        private void SocketEventRegistration()
        {
            asyncSocketListener = AsyncSocketListener.Instance;
            asyncSocketListener.MessageReceived += AsyncSocketListener_MessageReceived;
            asyncSocketListener.Disconnected += AsyncSocketListener_Disconnected;
            threadListen = new Thread(new ThreadStart(asyncSocketListener.StartListening));
            threadListen.Start();
        }
        private void AsyncSocketListener_Disconnected(int id)
        {
            this.asyncSocketListener.Close(id);
            this.clients = this.clients.Where(n => n.id != id).ToList();

        }
        private void AsyncSocketListener_MessageReceived(int id, string msg)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<SocketReceivedData>(msg);
                switch (obj.type)
                {
                    case "AUTHORIZE":
                        SocketClients client = new SocketClients();
                        client.id = id;
                        client.macaddress = obj.macAddressFrom;
                        clients.Add(client);
                        this.Invoke((Action)delegate
                        {
                            this.userTinhTrang.UpdateStatusPC(obj.macAddressFrom, 1, null);
                        });
                        break;
                    case "CHAT":
                        var _client = clients.Where(c => c.macaddress == obj.macAddressFrom).SingleOrDefault();
                        if (_client != null)
                        {
                            if (_client.frmChat == null || (_client.frmChat != null && _client.frmChat.Disposing))
                            {
                                _client.frmChat = new frmChat(id, this);

                            }
                            this.Invoke((Action)delegate
                            {
                                _client.frmChat.Text = obj.msgFrom;
                                _client.frmChat.UpdateHistory(obj.msgFrom + " Say: " + obj.msg + DateTime.Now.ToString("     HH:ss dd/MM/yyyy"));
                                _client.frmChat.Show();
                            });
                        }
                        break;
                    case "LOGIN":
                        var restClient = new RestClient("http://40.74.77.139/api");
                        restClient.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "Basic d2ViOjEyMw==");
                        request.AddHeader("Content-Type", "multipart/form-data");
                        request.AlwaysMultipartFormData = true;
                        request.AddParameter("key", "login");
                        request.AddParameter("accountName", obj.username);
                        request.AddParameter("password", obj.password);
                        IRestResponse response = restClient.Execute(request);
                        LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);
                        if (loginResponse != null)
                        {
                            SocketReceivedData ms = new SocketReceivedData();
                            if (loginResponse.result[0].status == "SUCCESS")
                            {
                                // update datasouce 
                                var _clientsk = clients.Where(c => c.macaddress == obj.macAddressFrom).SingleOrDefault();
                                if (_clientsk != null)
                                {
                                    _clientsk.timerStart = DateTime.Now;
                                }
                                ms.type = "LOGIN_SUCCESS";
                                this.Invoke((Action)delegate
                                {
                                    this.userTinhTrang.UpdateStatusPC(obj.macAddressFrom, 2, string.Format("{0:HH:ss:mm}", _clientsk.timerStart));
                                });
                            }
                            else if (loginResponse.result[0].status == "FALSED")
                            {
                                ms.type = "LOGIN_FALSED";
                                ms.msg = "Đăng nhập thất bại";
                            }

                            this.asyncSocketListener.Send(id, JsonConvert.SerializeObject(ms), false);
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
        #endregion

        #region form event
        private void App_Load(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frmlogin = new DangNhap(this);
            frmlogin.ShowDialog();
        }


        #endregion

        #region Orther Method

        public void UpdateGui()
        {
            userTinhTrang = new TinhTrang(objMenu, this);
            UpdateLayoutMenu();
        }
        public void UpdateLayoutMenu()
        {
            ngFrameMenu.Width = this.Width;
            ngFrameMenu.Height = this.Height;
            ngPage1.Width = this.Width;
            ngPage1.Height = this.Height;

            objMenu = new MenuObject();
            objMenu.frmHeight = this.Height;
            objMenu.frmWidth = this.Width;
            objMenu.frmMenuHeight = tileNavPaneMenu.Height;
            objMenu.frmMenuWidth = tileNavPaneMenu.Width;
            TinhTrang usTinhTrang = new TinhTrang(objMenu, this);
            ngPage1.Controls.Add(usTinhTrang);

        }


        #endregion

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.asyncSocketListener.Dispose();
            this.threadListen.Abort();
        }
    }

    public class SocketClients
    {
        public int id { set; get; }
        public int userLogin { set; get; }
        public string macaddress { set; get; }
        public frmChat frmChat { set; get; }
        public DateTime timerStart { set; get; }
    }
}
