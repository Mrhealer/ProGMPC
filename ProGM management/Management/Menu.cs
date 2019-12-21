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
using DevExpress.XtraBars.Navigation;
using Management.FormState;
using DevExpress.Utils.Svg;
using Management.Model;
using Management.Views.TinhTrangHoatDong;
using Management.Views.TaiKhoan;
using Management.Views.NhatKyHeThong;
using Management.Views.NhatKySuDung;
using Management.Views.NhomNguoiDung;
using Management.Views.NhomMay;
using System.Web.UI.WebControls;
using Management.Views.DangNhap;

namespace Management
{
    public partial class Menu : DevExpress.XtraEditors.XtraForm
    {
        MenuObject objMenu = new MenuObject();
        TinhTrang userTinhTrang;
        public Menu()
        {
            InitializeComponent();
            userTinhTrang = new TinhTrang(objMenu);
            
        }      
 
        private void tileNavPane1_TileClick(object sender, NavElementEventArgs e)
        {
            string itemTag = e.Element.Name;
            switch (itemTag)
            {
                //Tình trạng hoạt động
                case "mTinhTrang":
                    ngPage1.Controls.Add(userTinhTrang);
                    ngFrameMenu.SelectedPage = ngPage1;
                    break;
                //Tài khoản
                case "mTaiKhoan":
                    TaiKhoan userTaiKhoan = new TaiKhoan(objMenu);
                    ngPage2.Controls.Add(userTaiKhoan);
                    ngFrameMenu.SelectedPage = ngPage2;
                    break;
                //Nhật ký hệ thống
                case "mNhatKyHeThong":
                    NhatKyHeThong userNKHeThong = new NhatKyHeThong(objMenu);
                    ngPage3.Controls.Add(userNKHeThong);
                    ngFrameMenu.SelectedPage = ngPage3;
                    break;
                //Nhật ký giao dịch
                case "mNhatKyGiaoDich":
                    NhatKySuDung userNhatKySuDung = new NhatKySuDung(objMenu);
                    ngPage4.Controls.Add(userNhatKySuDung);
                    ngFrameMenu.SelectedPage = ngPage4;
                    break;
                //Nhóm người dùng
                case "mNhomNguoiDung":
                    NhomNguoiDung userNhomNguoiDung = new NhomNguoiDung(objMenu);
                    ngPage5.Controls.Add(userNhomNguoiDung);
                    ngFrameMenu.SelectedPage = ngPage5;
                    break;
                //Nhóm máy
                case "mNhomMay":
                    NhomMay userNhomMay = new NhomMay(objMenu);
                    ngPage6.Controls.Add(userNhomMay);
                    ngFrameMenu.SelectedPage = ngPage6;
                    break;
                //Dịch vụ
                case "mDichVu":
                    break;
                default:
                    break;
            }
        }
        public void UpdateLayoutMenu()
        {
            ngFrameMenu.Width = this.Width;
            ngFrameMenu.Height = this.Height;
            ngPage1.Width = this.Width;
            ngPage1.Height = this.Height;

            objMenu = new MenuObject();
            objMenu.frmHeight = this.Height;
            objMenu.frmWidth = this.Width;
            objMenu.frmMenuHeight = tileNavPaneMenu.Height;
            objMenu.frmMenuWidth = tileNavPaneMenu.Width;
            TinhTrang usTinhTrang = new TinhTrang(objMenu);
            ngPage1.Controls.Add(usTinhTrang);

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UpdateLayoutMenu();
            DangNhap frmLogin = new DangNhap();
            frmLogin.ShowDialog();
        }

        private void navButton5_ElementClick(object sender, NavElementEventArgs e)
        {
            if (navChiTiet.Tag == "detail")
            {
                ngPage1.Controls.Clear();
                TinhTrangChiTiet userTinhTrangCT = new TinhTrangChiTiet(objMenu);
                ngPage1.Controls.Add(userTinhTrangCT);
                ngFrameMenu.SelectedPage = ngPage1;
                navChiTiet.SuperTip.Items.Clear();
                navChiTiet.SuperTip.Items.AddTitle("Hiển thị thông tin theo định dạng lưới");
                navChiTiet.Tag = "big";
            }
            else
            {
                if (navChiTiet.Tag == "big")
                {
                    ngPage1.Controls.Clear();
                    TinhTrang userTinhTrang = new TinhTrang(objMenu);
                    ngPage1.Controls.Add(userTinhTrang);
                    ngFrameMenu.SelectedPage = ngPage1;
                    navChiTiet.SuperTip.Items.Clear();
                    navChiTiet.SuperTip.Items.AddTitle("Hiển thị thông tin theo định dạng lưới");
                    navChiTiet.Tag = "detail";
                }
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}