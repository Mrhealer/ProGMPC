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
using RestSharp;
using Newtonsoft.Json;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace Management.Views.TinhTrangHoatDong
{
    public partial class TinhTrang : DevExpress.XtraEditors.XtraUserControl
    {
        App app_controller;
        public TinhTrang(MenuObject obj, App app)
        {
            this.app_controller = app;
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
            dt.Columns.Add("Price");
            dt.Columns.Add("MacID");
            dt.Columns.Add("IsOnline");

            var client = new RestClient("http://40.74.77.139/api/?key=computerList&startItem=0&endItem=100&branchId=3a5ba8d1-1fbe-11ea-83f9-001e67bb704a");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Host", "40.74.77.139");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Authorization", "Basic d2ViOjEyMw==");
            IRestResponse response = client.Execute(request);
            if (!string.IsNullOrEmpty(response.Content))
            {
                responseListPC responseData = JsonConvert.DeserializeObject<responseListPC>(response.Content);
                foreach (var item in responseData.listComputerbyOfficeId)
                {
                    dt.Rows.Add(item.pcName,item.pcCode, item.pcGroupName,item.pcPrice, item.pcMacAddress, false);
                }
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
            var xx =   grdTinhTrang.GetViewAt(Control.MousePosition);

      
            var x = e.Item.Elements[1];
            TileView view = sender as TileView;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            TileViewHitInfo hitInfo = view.CalcHitInfo(pt);
            if (hitInfo.ItemInfo != null)
            {
                //TileItemElementViewInfo elementInfo = hitInfo.ItemInfo.Cells.FirstOrDefault(t => t.EntireElementBounds.Contains(pt));
                //if (elementInfo != null)
                //{
                //    string text = elementInfo.Element.Text;
                //}
            }

            // var data = e.BindableControls["Address"] as TextEdit;;
            //var x = grdTinhTrang.getr(e.Item.RowHandle) as;
            System.Drawing.Point p2 = Control.MousePosition;
            popupMenuPC.ShowPopup(p2);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNapTien napTien = new frmNapTien();
            napTien.Show();
        }

        private void menuShowChat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          var id =   tileView1.GetFocusedRowCellValue("MacID");
        }

        private void tileView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //var Id = tileView1.GetFocusedRowCellValue("MacID");
            //MessageBox.Show(Id.ToString(),"Thoong bao");

        }
    }
}
