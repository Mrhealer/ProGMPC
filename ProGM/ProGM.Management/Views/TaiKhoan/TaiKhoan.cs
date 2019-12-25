using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProGM.Management.Model;
using ProGM.Management.Controller;

namespace ProGM.Management.Views.TaiKhoan
{
    public partial class TaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public TaiKhoan(MenuObject obj)
        {
            InitializeComponent();
            ConfigLayout.UpdateLayout(this, panelTaiKhoan, grdTaiKhoan, obj);
            InitData();
        }
        public void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenUser");
            dt.Columns.Add("HoVaTen");
            dt.Columns.Add("SoDu");
            dt.Columns.Add("HoiVien");
            for (int i = 1; i <= 24; i++)
            {
                dt.Rows.Add("0987947752", "Tran Van Quoc", "2000000", "VIP");
            }
            grdTaiKhoan.DataSource = dt;
        }

        private void btnNapTien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmNapTien napTien = new frmNapTien();
            napTien.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmThemMoi frmThem = new frmThemMoi();
            frmThem.Show();
        }

        private void btnSua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmSua sua = new frmSua();
            sua.Show();
        }

        private void grdTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnNhatKySD_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmNKSuDung frmSuDung = new frmNKSuDung();
            frmSuDung.Show();
        }

        private void btnNhatKyNapTien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmNKNapTien frmNapTien = new frmNKNapTien();
            frmNapTien.Show();
        }

       

    }
}
