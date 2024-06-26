﻿using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace PL
{
    public partial class DangNhap : KryptonForm, IAdminRequester, IGVRequester, ISinhVienRequester
    {
        #region Register Services
        private readonly INguoiDungBLLService _nguoiDungBLLService 
            = new NguoiDungBLLService(
                new NguoiDungDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));
        private readonly IGlobalConfigBLLService _globalConfigBLLService 
            = new GlobalConfigBLLService(
                new GlobalConfigDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));
        #endregion

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

                    if (GlobalConfig.CurrNguoiDung.MaNhom == "gv" || GlobalConfig.CurrNguoiDung.MaNhom == "tv")
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
