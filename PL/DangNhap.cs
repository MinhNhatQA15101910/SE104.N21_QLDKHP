using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;

namespace PL
{
    public partial class DangNhap : KryptonForm, IAdminRequester, IGVRequester, ISinhVienRequester
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        public void OnAdminClosing()
        {
            GlobalConfig.CurrNguoiDung = null;
            GlobalConfig.CurrMaHocKy = 0;
            GlobalConfig.CurrNamHoc = 0;

            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            Show();
        }

        public void OnGVClosing()
        {
            GlobalConfig.CurrNguoiDung = null;
            GlobalConfig.CurrMaHocKy = 0;
            GlobalConfig.CurrNamHoc = 0;

            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            Show();
        }

        public void OnSinhVienClosing()
        {
            GlobalConfig.CurrNguoiDung = null;
            GlobalConfig.CurrMaHocKy = 0;
            GlobalConfig.CurrNamHoc = 0;

            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            DangNhapMessage message = NguoiDungBLL.DangNhap(tenDangNhap, matKhau);
            switch (message)
            {
                case DangNhapMessage.EmptyTenDangNhap:
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                    break;
                case DangNhapMessage.EmptyMatKhau:
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                    break;
                case DangNhapMessage.Error:
                    MessageBox.Show("Đã có lỗi xảy ra!");
                    break;
                case DangNhapMessage.Failed:
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
                    break;
                case DangNhapMessage.Success:
                    GlobalConfig.CurrNamHoc = GlobalConfigBLL.GetCurrNamHoc();
                    GlobalConfig.CurrMaHocKy = GlobalConfigBLL.GetCurrMaHocKy();

                    MessageBox.Show("Đăng nhập thành công!");

                    if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
                    {
                        GiaoVien gv = new GiaoVien(this);
                        gv.Show();
                        Hide();
                    }
                    else if (GlobalConfig.CurrNguoiDung.MaNhom == "ad")
                    {
                        Admin admin = new Admin(this);
                        admin.Show();
                        Hide();
                    }
                    else if (GlobalConfig.CurrNguoiDung.MaNhom == "sv")
                    {
                        SinhVien sinhVien = new SinhVien(this);
                        sinhVien.Show();
                        Hide();
                    }

                    break;
            }
        }
    }
}
