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

namespace Management
{
    public partial class App : Form
    {
        public IAsyncSocketListener asyncSocketListener;
        public List<SocketClients> clients = new List<SocketClients>();
        public App()
        {
            InitializeComponent();
            asyncSocketListener = AsyncSocketListener.Instance;
            asyncSocketListener.MessageReceived += AsyncSocketListener_MessageReceived;
            asyncSocketListener.Disconnected += AsyncSocketListener_Disconnected;
        }
  
        #region socket event        
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
            new Thread(new ThreadStart(asyncSocketListener.StartListening)).Start();
            this.Hide();
            DangNhap frmlogin = new DangNhap(this);
            frmlogin.ShowDialog();
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
