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
using ProGM.Management.Controller;
using Newtonsoft.Json;
using ProGM.Management.Model;
using ProGM.Business.Model;

namespace ProGM.Management.Views.Chat
{
    public partial class frmChat : DevExpress.XtraEditors.XtraForm
    {
        public delegate void UpdateTextBoxMethod(string text);
        App app_controller;
        int IdClient;
        public frmChat(int idClient, App app)
        {
            this.IdClient = idClient;
            this.app_controller = app;
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
                SocketReceivedData ms = new SocketReceivedData();
                ms.msgFrom = "Nhân viên:";
                ms.msg = msg;
                ms.type = "CHAT";
                this.app_controller.asyncSocketListener.Send(this.IdClient,JsonConvert.SerializeObject(ms), false);
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