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
using ProGM.Management.Controller;
using ProGM.Management.Model;

namespace ProGM.Management.Views.NhomNguoiDung
{
    public partial class NhomNguoiDung : DevExpress.XtraEditors.XtraUserControl
    {
        public NhomNguoiDung(MenuObject obj)
        {
            InitializeComponent();
            ConfigLayout.UpdateLayout(this, panelTaiKhoan, grdTaiKhoan, obj);
            InitData();
        }
        public void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenNhom");
            dt.Columns.Add("GiaMacDinh");
            dt.Columns.Add("Nhom1");
            dt.Columns.Add("Nhom2");
            dt.Columns.Add("Nhom3");
            dt.Columns.Add("Nhom4");
            for (int i = 1; i <= 5; i++)
            {
                dt.Rows.Add("Hội viên", "10.000", "20.000", "30.0000", "40.000", "40.000");
            }
            grdTaiKhoan.DataSource = dt;
        }
    }
}
