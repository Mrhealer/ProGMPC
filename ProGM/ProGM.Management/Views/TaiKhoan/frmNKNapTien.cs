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

namespace ProGM.Management.Views.TaiKhoan
{
    public partial class frmNKNapTien : DevExpress.XtraEditors.XtraForm
    {
        public frmNKNapTien()
        {
            InitializeComponent();
        }

        private void frmNKNapTien_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ngay");
            dt.Columns.Add("Gio");
            dt.Columns.Add("SoTien");
            dt.Columns.Add("NhanVien");
            for (int i = 1; i <= 24; i++)
            {
                dt.Rows.Add("12-02-2019", "11:20:20", "200.000", "LanNT");
            }
            grdNKSuDung.DataSource = dt;
        }
    }
}