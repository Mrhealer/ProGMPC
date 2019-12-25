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

namespace ProGM.Management.Views.NhomMay
{
    public partial class NhomMay : DevExpress.XtraEditors.XtraUserControl
    {
        public NhomMay(MenuObject obj)
        {
            InitializeComponent();
            ConfigLayout.UpdateLayout(this, panelTaiKhoan, grdTaiKhoan, obj);
            InitData();
        }
        public void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenNhomMay");
            dt.Columns.Add("MoTa");
            for (int i = 1; i <= 5; i++)
            {
                dt.Rows.Add("Mặc định", "Nhóm máy mặc định");
            }
            grdTaiKhoan.DataSource = dt;
        }
    }
}
