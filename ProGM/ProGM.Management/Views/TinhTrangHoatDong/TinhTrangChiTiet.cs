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
using ProGM.Management.Views.TaiKhoan;
using DevExpress.XtraBars;
using DevExpress.Utils.Menu;
using System.Web.UI.WebControls;

namespace ProGM.Management.Views.TinhTrangHoatDong
{
    public partial class TinhTrangChiTiet : DevExpress.XtraEditors.XtraUserControl
    {

        public TinhTrangChiTiet(MenuObject obj)
        {
            InitializeComponent();
            ConfigLayout.UpdateLayout(this, panelTinhTrang, grdTinhTrangChiTiet, obj);
            InitData();
        }
        private void ItemEdit_Click(object sender, System.EventArgs e)
        {
            gridView1.ShowEditor();
        }
        private void ItemDelete_Click(object sender, System.EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        public void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenMay");
            dt.Columns.Add("TrangThai");
            dt.Columns.Add("NguoiChoi");
            dt.Columns.Add("BatDau");
            dt.Columns.Add("DaDung");
            dt.Columns.Add("ConLai");
            dt.Columns.Add("SoTien");
            dt.Columns.Add("NhomMay");
            for (int i = 1; i < 21; i++)
            {
                dt.Rows.Add("MÁY " + i, "Đang chơi", "0987947752", "10:10:00", "02:05", "00:05", "40.000", "KHU A");
            }
           
            grdTinhTrangChiTiet.DataSource = dt;
        }

        private void btnNapTien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmNapTien napTien = new frmNapTien();
            napTien.Show();
        }

        private void popupMenu1_Popup(object sender, EventArgs e)
        {

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            
            if (e.HitInfo.InRow)
            {
                System.Drawing.Point p2 = Control.MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNapTien napTien = new frmNapTien();
            napTien.Show();
        }
    }
}
