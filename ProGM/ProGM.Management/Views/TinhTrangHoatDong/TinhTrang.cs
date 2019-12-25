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
using RestSharp;
using Newtonsoft.Json;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using ProGM.Business.Model;

namespace ProGM.Management.Views.TinhTrangHoatDong
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
            dt.Columns.Add("Status");
            dt.Columns.Add("timeLogin");

            var client = new RestClient("http://40.74.77.139/api/?key=computerList&companyId=cf09c7b5-254e-11ea-b536-005056b97a5d&groupId=ALL");
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

                int countOffline = 0;
                int countOnline = 0;
                int countReady = 0;
                foreach (var item in responseData.computerList)
                {
                    var pc = this.app_controller.clients.Where(n => n.macaddress.Equals(item.strMacAddress)).SingleOrDefault();
                    int status = 0;
                    if (pc != null)
                    {
                        if (pc.timerStart != null && pc.timerStart != DateTime.MinValue)
                        {
                            status = 2;
                            countOnline++;
                        }
                        else
                        {
                            status = 1;
                            countReady++;
                        }
                    }
                    else
                    {
                        countOffline++;
                    }
                    dt.Rows.Add(item.strName, item.strName, item.strGroupName, item.iPrice, item.strMacAddress, status,"00:00:00");
                }
                lbCountOffline.Text = countOffline.ToString();
                lbCountOnline.Text = countOnline.ToString();
                lbCountReady.Text = countReady.ToString();


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
            TileView view = sender as TileView;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            System.Drawing.Point p2 = Control.MousePosition;
            int rowStatus = int.Parse(string.Format("{0}", tileView1.GetFocusedRowCellValue("Status")));
            bool isShowpopupmenu = true;
            switch (rowStatus)
            {
                case PCStatus.OFFLINE:
                    isShowpopupmenu = false;
                    MessageBox.Show("Vui lòng bật máy trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case PCStatus.READY:
                    btnOpenPC.Enabled = true;
                    menuAddMoney.Enabled = false;
                    menuBlockPC.Enabled = false;
                    menuShowChat.Enabled = false;
                    break;
                case PCStatus.ONLINE:
                    btnOpenPC.Enabled = false;
                    menuAddMoney.Enabled = true;
                    menuBlockPC.Enabled = true;
                    menuShowChat.Enabled = true;
                    break;
                default:
                    break;
            }
            if (isShowpopupmenu)
            {
                popupMenuPC.ShowPopup(p2);
            }


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNapTien napTien = new frmNapTien();
            napTien.Show();
        }

        private void menuShowChat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = tileView1.GetFocusedRowCellValue("MacID");
        }


        private void btnOpenPC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mac = tileView1.GetFocusedRowCellValue("MacID").ToString();
           // mac = "60:03:08:99:0a:fe";
            var client = this.app_controller.clients.Where(n => n.macaddress.Equals(mac)).SingleOrDefault();
            if (client != null)
            {
                SocketReceivedData ms = new SocketReceivedData();
                ms.type = "OPEN";
                this.app_controller.asyncSocketListener.Send(client.id, JsonConvert.SerializeObject(ms), false);
            }

        }

        private void menuBlockPC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mac = tileView1.GetFocusedRowCellValue("MacID").ToString();
            mac = "60:03:08:99:0a:fe";
            var client = this.app_controller.clients.Where(n => n.macaddress.Equals(mac)).SingleOrDefault();
            if (client != null)
            {
                SocketReceivedData ms = new SocketReceivedData();
                ms.type = "CLOSE";
                this.app_controller.asyncSocketListener.Send(client.id, JsonConvert.SerializeObject(ms), false);
            }
        }

        private void tileView1_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            TileView view = sender as TileView;
            int status = int.Parse(string.Format("{0}", view.GetRowCellValue(e.RowHandle, "Status")));
            switch (status)
            {
                case PCStatus.OFFLINE:
                    e.Item.Elements[1].Image = Properties.Resources.offile;
                    break;
                case PCStatus.READY:
                    e.Item.Elements[1].Image = Properties.Resources.vang;
                    break;
                case PCStatus.ONLINE:
                    e.Item.Elements[1].Image = Properties.Resources.online;
                    break;
                default:
                    break;
            }
        }

        #region orther method
        public void UpdateStatusPC(string mac, int status, string time)
        {
            DataTable dtTable = ((DataView)tileView1.DataSource).Table;
            int indexRow = 0;
            int indexRowHandle = 0;
            foreach (DataRow dtRow in dtTable.Rows)
            {
                string macID = dtRow["MacID"].ToString();
                if (macID == mac)
                {
                    dtRow["Status"] = status;
                    if (status==2)
                    {
                        dtRow["timeLogin"] = time;
                    }
                    indexRowHandle = indexRow;
                }

                indexRow++;
            }
          

            //grdTinhTrang.DataSource = null;
            //tileView1.Columns.Clear();
    

            tileView1.RefreshRow(indexRowHandle);


        }
        #endregion
    }
}
