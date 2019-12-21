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
using Management.Model;
using Management.Controller;
using Management.Views.TaiKhoan;

namespace Management.Views.TinhTrangHoatDong
{
    public partial class TinhTrang : DevExpress.XtraEditors.XtraUserControl
    {

        public TinhTrang(MenuObject obj)
        {

            InitializeComponent();
            ConfigLayout.UpdateLayout(this, panelTinhTrang, grdTinhTrang, obj);
            InitData();

        }
        public void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NamePC");
            dt.Columns.Add("Old");
            dt.Columns.Add("Group");
            for (int i = 1; i < 21; i++)
            {
                dt.Rows.Add("MÁY " + i, "19", "NHÓM A");
            }
            for (int i = 21; i < 41; i++)
            {
                dt.Rows.Add("MÁY " + i, "19", "NHÓM B");
            }
            for (int i = 41; i < 61; i++)
            {
                dt.Rows.Add("MÁY " + i, "19", "NHÓM C");
            }
            for (int i = 61; i < 81; i++)
            {
                dt.Rows.Add("MÁY " + i, "19", "NHÓM D");
            }
            grdTinhTrang.DataSource = dt;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("111");
        }

        private void PopupMenuShowing(object sender, EventArgs e)
        {

        }

        private void tileView1_ShowingPopupEditForm(object sender, DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {
            MessageBox.Show("22");
        }

        private void tileView1_ItemRightClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {

            System.Drawing.Point p2 = Control.MousePosition;
            popupMenu1.ShowPopup(p2);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNapTien napTien = new frmNapTien();
            napTien.Show();
        }

    }
}
