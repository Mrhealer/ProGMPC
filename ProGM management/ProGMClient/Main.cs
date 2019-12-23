using Management.FormState;
using Newtonsoft.Json;
using ProGMClient.Business;
using ProGMClient.View.Chat;
using ProGMClient.View.Login;
using SocketBussiness.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ProGMClient
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        FormState frmMax;
        AsyncClient asyncClient;
        public Main()
        {
            InitializeComponent();
            frmMax = new FormState();
            frmMax.Maximize(this);
            asyncClient = new AsyncClient();
            asyncClient.StartClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap(frmMax, this);
            frmDangNhap.KeyPreview = true;
            asyncClient.Send("Xin chào", false);
            frmDangNhap.ShowDialog();
        }
    }
}
