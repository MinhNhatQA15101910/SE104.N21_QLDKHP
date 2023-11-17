using BLL.IServices;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using Microsoft.Extensions.DependencyInjection;
using PL.Interfaces;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class DangNhap : KryptonForm, IAdminRequester, IGVRequester, ISinhVienRequester
    {
        #region Register Services
        private readonly INguoiDungBLLService _nguoiDungBLLService;
        private readonly IGlobalConfigBLLService _globalConfigBLLService;
        #endregion

        public DangNhap(INguoiDungBLLService nguoiDungBLLService, IGlobalConfigBLLService globalConfigBLLService)
        {
            InitializeComponent();
            _nguoiDungBLLService = nguoiDungBLLService;
            _globalConfigBLLService = globalConfigBLLService;
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

            DangNhapMessage message = _nguoiDungBLLService.DangNhap(tenDangNhap, matKhau);
            switch (message)
            {
                case DangNhapMessage.EmptyTenDangNhap:
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                    break;
                case DangNhapMessage.EmptyMatKhau:
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                    break;
                case DangNhapMessage.Failed:
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
                    break;
                case DangNhapMessage.Success:
                    GlobalConfig.CurrNamHoc = _globalConfigBLLService.GetCurrNamHoc();
                    GlobalConfig.CurrMaHocKy = _globalConfigBLLService.GetCurrMaHocKy(GlobalConfig.CurrNamHoc);

                    MessageBox.Show("Đăng nhập thành công!");

                    if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
                    {
                        GiaoVien gv = Program.ServiceProvider.GetRequiredService<GiaoVien>();
                        gv.Show();
                        Hide();
                    }
                    else if (GlobalConfig.CurrNguoiDung.MaNhom == "ad")
                    {
                        Admin admin = Program.ServiceProvider.GetRequiredService<Admin>();
                        admin.Show();
                        Hide();
                    }
                    else if (GlobalConfig.CurrNguoiDung.MaNhom == "sv")
                    {
                        SinhVien sinhVien = Program.ServiceProvider.GetRequiredService<SinhVien>();
                        sinhVien.Show();
                        Hide();
                    }

                    break;
            }
        }
    }
}
