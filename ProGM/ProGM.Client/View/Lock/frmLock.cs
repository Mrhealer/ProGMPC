using Management.FormState;
using Newtonsoft.Json;
using ProGM.Business;
using ProGM.Client.View.Chat;
using ProGM.Client.View.Login;
using ProGM.Business.SocketBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ProGM.Client
{
    public partial class frmLock : DevExpress.XtraEditors.XtraForm
    {
        FormState frmMax;
        App app_controller;
        public frmLock(App _app)
        {
            this.app_controller = _app;
            InitializeComponent();
            frmMax = new FormState();
            frmMax.Maximize(this);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap(frmMax, this, this.app_controller);
            frmDangNhap.KeyPreview = true;
            frmDangNhap.ShowDialog();
        }
    }
}
