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
using Quobject.SocketIoClientDotNet.Client;
namespace Management.Views.DangNhap
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        private App appMain;
        public DangNhap(App app)
        {
            this.appMain = app;
            InitializeComponent();
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "quoctv" || txtMatKhau.Text == "123456789")
            {
                this.Hide();
                Menu main = new Menu();
                main.ShowDialog();
            }
        }

    }
}