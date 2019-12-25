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
    public partial class frmNKSuDung : DevExpress.XtraEditors.XtraForm
    {
        public frmNKSuDung()
        {
            InitializeComponent();
        }

        private void frmNKSuDung_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("May");
            dt.Columns.Add("IP");
            dt.Columns.Add("NgayBatDau");
            dt.Columns.Add("ThoiDiemBatDau");
            dt.Columns.Add("ThoiGianKetThuc");
            dt.Columns.Add("ThoiGianDaDung");
            dt.Columns.Add("SoTienDaDung");
            for (int i = 1; i <= 24; i++)
            {
                dt.Rows.Add("MAY15", "192.168.1.2", "10-10-2019", "10:20", "20:20", "10:00", "200.000");
            }
            grdNKSuDung.DataSource = dt;
        }

        private void grdTaiKhoan_Click(object sender, EventArgs e)
        {

        }

       
    }
}