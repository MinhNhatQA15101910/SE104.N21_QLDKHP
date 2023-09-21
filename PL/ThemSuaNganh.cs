﻿using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaNganh : KryptonForm, IThemSuaKhoaRequester
    {
        private IThemSuaNganhRequester themSuaNganhRequester;
        private CT_Nganh nganh;
        private BindingList<DTO.Khoa> mKhoa;
        private BindingSource mKhoaSource;

        public ThemSuaNganh(IThemSuaNganhRequester requester, CT_Nganh nganh)
        {
            InitializeComponent();

            themSuaNganhRequester = requester;
            this.nganh = nganh;

            SettingProperties();
        }

        public ThemSuaNganh(IThemSuaNganhRequester requester)
        {
            InitializeComponent();

            themSuaNganhRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            if (nganh != null)
            {
                Text = "Sửa ngành";
                lblThemSuaNganh.Text = "SỬA NGÀNH";

                txtMaNganh.Text = nganh.MaNganh;
                txtTenNganh.Text = nganh.TenNganh;
            }
            else
            {
                Text = "Thêm ngành";
                lblThemSuaNganh.Text = "THÊM NGÀNH";
            }
        }

        public void OnThemSuaKhoaClosing()
        {
            mKhoa = new BindingList<DTO.Khoa>(KhoaBLL.LayDSKhoa());
            mKhoaSource.DataSource = mKhoa;
        }

        private void ThemSuaNganh_Load(object sender, EventArgs e)
        {
            mKhoa = new BindingList<DTO.Khoa>(KhoaBLL.LayDSKhoa());
            mKhoaSource = new BindingSource(mKhoa, null);
            cmbKhoa.DataSource = mKhoaSource;
            cmbKhoa.DisplayMember = "DisplayKhoa";
            cmbKhoa.ValueMember = "MaKhoa";

            if (nganh != null)
            {
                cmbKhoa.SelectedValue = nganh.MaKhoa;
                txtMaNganh.ReadOnly = true;
            }
            else
            {
                txtMaNganh.ReadOnly = false;
            }
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            ThemSuaKhoa themSuaKhoa = new ThemSuaKhoa(this);
            themSuaKhoa.ShowDialog();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaNganh.Clear();
            txtTenNganh.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (nganh != null)
            {
                string maNganhBanDau = nganh.MaNganh;
                string maNganhSua = txtMaNganh.Text.Trim();
                string tenNganhSua = txtTenNganh.Text.Trim();
                string maKhoaSua = cmbKhoa.Text.Trim().Split(' ')[0];

                SuaNganhMessage message = NganhBLL.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);
                switch (message)
                {
                    case SuaNganhMessage.EmptyMaNganh:
                        MessageBox.Show("Mã ngành không được để trống!");
                        break;
                    case SuaNganhMessage.EmptyTenNganh:
                        MessageBox.Show("Tên ngành không được để trống!");
                        break;
                    case SuaNganhMessage.DuplicateMaNganh:
                        MessageBox.Show("Mã ngành đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaNganhMessage.DuplicateTenNganh:
                        MessageBox.Show("Tên ngành đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaNganhMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case SuaNganhMessage.Success:
                        MessageBox.Show("Sửa ngành thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string maNganh = txtMaNganh.Text.Trim();
                string tenNganh = txtTenNganh.Text.Trim();
                string maKhoa = cmbKhoa.Text.Trim().Split(' ')[0];

                ThemNganhMessage message = NganhBLL.ThemNganh(maNganh, tenNganh, maKhoa);
                switch (message)
                {
                    case ThemNganhMessage.EmptyMaNganh:
                        MessageBox.Show("Mã ngành không được để trống!");
                        break;
                    case ThemNganhMessage.EmptyTenNganh:
                        MessageBox.Show("Tên ngành không được để trống!");
                        break;
                    case ThemNganhMessage.DuplicateMaNganh:
                        MessageBox.Show("Mã ngành đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemNganhMessage.DuplicateTenNganh:
                        MessageBox.Show("Tên ngành đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemNganhMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case ThemNganhMessage.Success:
                        if (themSuaNganhRequester != null)
                        {
                            themSuaNganhRequester.OnThemSuaNganhClosing();
                        }

                        MessageBox.Show("Thêm ngành thành công!");
                        break;
                }
            }
        }

        private void ThemSuaNganh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaNganhRequester != null)
            {
                themSuaNganhRequester.OnThemSuaNganhClosing();
            }
        }
    }
}
