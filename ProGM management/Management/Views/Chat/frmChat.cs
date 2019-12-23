using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Sockets;
using Management.Controller;
using Newtonsoft.Json;

namespace Management.Views
{
    public partial class frmChat : DevExpress.XtraEditors.XtraForm
    {
        public delegate void UpdateTextBoxMethod(string text);
        public TcpClient clientSocket { set; get; }
        public frmChat()
        {
            InitializeComponent();
        }
        public void UpdateHistory(string text)
        {
            if (this.txtHistory.InvokeRequired)
            {
                UpdateTextBoxMethod del = new UpdateTextBoxMethod(UpdateHistory);
                this.Invoke(del, new object[] { text });
            }
            else
            {
                txtHistory.AppendText(text + Environment.NewLine);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMesseage.Text;
            if (!string.IsNullOrEmpty(msg))
            {
                dataSend ms = new dataSend();
                ms.from = "Linh";
                ms.name = "Linh";
                ms.msg = msg;
                ms.type = "CHAT";
                SocketBussiness.SendData(this.clientSocket, JsonConvert.SerializeObject(ms));
                txtHistory.AppendText("Me: " + msg + Environment.NewLine);
                txtMesseage.Text = "";

            }
        }

        private void txtMesseage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnSend.PerformClick();
            }
        }
    }
}