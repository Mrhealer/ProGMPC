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

namespace ProGM.Management.Views.NhatKySuDung
{
    public partial class NhatKySuDung : DevExpress.XtraEditors.XtraUserControl
    {
        public NhatKySuDung(MenuObject obj)
        {
            InitializeComponent();
            ConfigLayout.UpdateLayout(this, panelTaiKhoan, grdTaiKhoan, obj);
            InitData();
        }
        public void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NguoiDung");
            dt.Columns.Add("NgayThanhToan");
            dt.Columns.Add("GioThanhToan");
            dt.Columns.Add("SoTien");
            dt.Columns.Add("ThoiGianTT");
            dt.Columns.Add("NhanVien");
            for (int i = 1; i <= 24; i++)
            {
                dt.Rows.Add("0987947752", "09-06-2019", "10:20:05", "25.000", "02:00", "LanNT");
            }
            grdTaiKhoan.DataSource = dt;
        }
    }
}
