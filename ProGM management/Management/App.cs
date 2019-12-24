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
using SocketBussiness.Model;
using Newtonsoft.Json;
using Management.Views;
using System.Threading;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using Management.FormState;
using DevExpress.Utils.Svg;
using Management.Model;
using Management.Views.TinhTrangHoatDong;
using Management.Views.TaiKhoan;
using Management.Views.NhatKyHeThong;
using Management.Views.NhatKySuDung;
using Management.Views.NhomNguoiDung;
using Management.Views.NhomMay;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using Management.Controller;

namespace Management
{
    public partial class App : DevExpress.XtraEditors.XtraForm
    {
        MenuObject objMenu = new MenuObject();
        TinhTrang userTinhTrang;


        public IAsyncSocketListener asyncSocketListener;
        public List<SocketClients> clients = new List<SocketClients>();


        public bool isVerifyAccount = false;
        public App()
        {
            InitializeComponent();
            userTinhTrang = new TinhTrang(objMenu, this);
            SocketEventRegistration();
          
          
        }

        #region socket event  

        private void SocketEventRegistration()
        {
            asyncSocketListener = AsyncSocketListener.Instance;
            asyncSocketListener.MessageReceived += AsyncSocketListener_MessageReceived;
            asyncSocketListener.Disconnected += AsyncSocketListener_Disconnected;
            new Thread(new ThreadStart(asyncSocketListener.StartListening)).Start();
        }
        private void AsyncSocketListener_Disconnected(int id)
        {
            MessageBox.Show("Client ID: " + id + "  vừa mất kết nối", "Thông báo");
        }
        private void AsyncSocketListener_MessageReceived(int id, string msg)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<SocketReceivedData>(msg);
                if (obj.type.Equals("AUTHORIZE"))
                {
                    SocketClients client = new SocketClients();
                    client.id = id;
                    client.macaddress = obj.macAddressFrom;
                    clients.Add(client);
                }
                else if (obj.type.Equals("CHAT"))
                {
                    var client = clients.Where(c => c.macaddress == obj.macAddressFrom).SingleOrDefault();
                    if (client != null)
                    {
                        if (client.frmChat == null || (client.frmChat != null && client.frmChat.Disposing))
                        {
                            client.frmChat = new frmChat(id, this);

                        }
                        this.Invoke((Action)delegate
                        {
                            client.frmChat.Text = obj.msgFrom;
                            client.frmChat.UpdateHistory(obj.msgFrom+" Say: "+ obj.msg +DateTime.Now.ToString("     HH:ss dd/MM/yyyy"));
                            client.frmChat.Show();
                        });
                    }
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
            UpdateLayoutMenu();
            if (!isVerifyAccount)
            {
                this.Hide();
                DangNhap frmlogin = new DangNhap(this);
                frmlogin.ShowDialog();
            }
        }
        #endregion

        #region Orther Method
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
