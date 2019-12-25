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

namespace ProGM.Management.Views.NhatKyHeThong
{
    public partial class NhatKyHeThong : DevExpress.XtraEditors.XtraUserControl
    {
        public NhatKyHeThong(MenuObject obj)
        {
            InitializeComponent();
            ConfigLayout.UpdateLayout(this, panelTaiKhoan, grdTaiKhoan, obj);
            InitData();
        }
        public void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("May");
            dt.Columns.Add("NguoiDung");
            dt.Columns.Add("Ngay");
            dt.Columns.Add("ThoiGian");
            dt.Columns.Add("TinhTrang");
            dt.Columns.Add("DaDung");
            for (int i = 1; i <= 24; i++)
            {
                dt.Rows.Add("May 01", "Tran Anh Quoc", "10-11-2019", "10:20:01", "Đang chơi", "03:00");
            }
            grdTaiKhoan.DataSource = dt;
        }

        private void grdTaiKhoan_Click(object sender, EventArgs e)
        {

        }
    }
}
