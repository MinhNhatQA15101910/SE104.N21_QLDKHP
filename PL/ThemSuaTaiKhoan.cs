﻿using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaTaiKhoan : KryptonForm
    {
        private IThemSuaTaiKhoanRequester themSuaTaiKhoanRequester;
        private CT_NguoiDung nguoiDung;

        private BindingList<NhomNguoiDung> mNhomNguoiDung;
        private BindingSource mNhomNguoiDungSource;

        public ThemSuaTaiKhoan(IThemSuaTaiKhoanRequester requester, CT_NguoiDung nguoiDung)
        {
            InitializeComponent();

            themSuaTaiKhoanRequester = requester;
            this.nguoiDung = nguoiDung;

            SettingProperties();
        }

        public ThemSuaTaiKhoan(IThemSuaTaiKhoanRequester requester)
        {
            InitializeComponent();

            themSuaTaiKhoanRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            if (nguoiDung != null)
            {
                Text = "Sửa tài khoản";
                lblThemSuaTaiKhoan.Text = "SỬA TÀI KHOẢN";

                txtTenDangNhap.Text = nguoiDung.TenDangNhap;
            }
            else
            {
                Text = "Thêm tài khoản";
                lblThemSuaTaiKhoan.Text = "THÊM TÀI KHOẢN";
            }
        }

        private void ThemSuaTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaTaiKhoanRequester != null)
            {
                themSuaTaiKhoanRequester.OnThemSuaTaiKhoanClosing();
            }
        }

        private void ThemSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            mNhomNguoiDung = new BindingList<NhomNguoiDung>(NhomNguoiDungBLL.LayDSNhomNguoiDung());
            mNhomNguoiDungSource = new BindingSource(mNhomNguoiDung, null);
            cmbLoaiTaiKhoan.DataSource = mNhomNguoiDungSource;
            cmbLoaiTaiKhoan.DisplayMember = "TenNhom";
            cmbLoaiTaiKhoan.ValueMember = "MaNhom";

            if (nguoiDung != null)
            {
                cmbLoaiTaiKhoan.SelectedValue = nguoiDung.MaNhom;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            mNhomNguoiDung = new BindingList<NhomNguoiDung>(NhomNguoiDungBLL.LayDSNhomNguoiDung());
            mNhomNguoiDungSource.DataSource = mNhomNguoiDung;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (nguoiDung != null)
            {
                string tenDangNhapBD = nguoiDung.TenDangNhap;
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string maNhom = (string)cmbLoaiTaiKhoan.SelectedValue;

                SuaTaiKhoanMessage message = NguoiDungBLL.SuaTaiKhoan(tenDangNhapBD, tenDangNhap, maNhom);
                switch (message)
                {
                    case SuaTaiKhoanMessage.EmptyTenDangNhap:
                        MessageBox.Show("Tên đăng nhập không được để trống!");
                        break;
                    case SuaTaiKhoanMessage.DuplicateTenDangNhap:
                        MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaTaiKhoanMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case SuaTaiKhoanMessage.Success:
                        MessageBox.Show("Cập nhật tài khoản thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string maNhom = (string)cmbLoaiTaiKhoan.SelectedValue;

                ThemTaiKhoanMessage message = NguoiDungBLL.ThemTaiKhoan(tenDangNhap, maNhom);
                switch (message)
                {
                    case ThemTaiKhoanMessage.EmptyTenDangNhap:
                        MessageBox.Show("Tên đăng nhập không được để trống!");
                        break;
                    case ThemTaiKhoanMessage.DuplicateTenDangNhap:
                        MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemTaiKhoanMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case ThemTaiKhoanMessage.Success:
                        if (themSuaTaiKhoanRequester != null)
                        {
                            themSuaTaiKhoanRequester.OnThemSuaTaiKhoanClosing();
                        }

                        MessageBox.Show("Thêm tài khoản thành công!");

                        break;
                }
            }
        }
    }
}
