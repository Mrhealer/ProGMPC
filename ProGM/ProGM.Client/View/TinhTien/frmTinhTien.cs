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
using ProGM.Client.View.Chat;
using ProGM.Business.SocketBusiness;

namespace ProGM.Client.View.TinhTien
{
    public partial class frmTinhTien : DevExpress.XtraEditors.XtraForm
    {
        App app_controller;
        public frmTinhTien(App _app)
        {
            this.app_controller = _app;
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, //should be (0,0)
                          Screen.PrimaryScreen.Bounds.Y);
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
        }

        private void frmTinhTien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            app_controller.frmChat = (frmChat)Application.OpenForms["frmChat"];
            if (app_controller.frmChat == null)
            {
                app_controller.frmChat = new frmChat(app_controller);
            }
            app_controller.frmChat.TopMost = true;
            app_controller.frmChat.Show();
        }
    }
}