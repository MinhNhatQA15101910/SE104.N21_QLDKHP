﻿using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaTinh : KryptonForm
    {
        private IThemSuaTinhRequester themSuaTinhRequester;
        private Tinh tinh;

        public ThemSuaTinh(IThemSuaTinhRequester requester, Tinh tinh)
        {
            InitializeComponent();

            themSuaTinhRequester = requester;
            this.tinh = tinh;

            SettingProperties();
        }

        public ThemSuaTinh(IThemSuaTinhRequester requester)
        {
            InitializeComponent();

            themSuaTinhRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            if (tinh != null)
            {
                Text = "Sửa tỉnh";
                lblThemSuaTinh.Text = "SỬA TỈNH";

                txtTenTinh.Text = tinh.TenTTP;
            }
            else
            {
                Text = "Thêm tỉnh";
                lblThemSuaTinh.Text = "THÊM TỈNH";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenTinh.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (tinh != null)
            {
                int maTinh = tinh.MaTinh;
                string tenTinh = txtTenTinh.Text.Trim();

                SuaTinhMessage message = TinhBLL.SuaTinh(maTinh, tenTinh);
                switch (message)
                {
                    case SuaTinhMessage.EmptyTenTinh:
                        MessageBox.Show("Tên tỉnh không được để trống!");
                        break;
                    case SuaTinhMessage.DuplicateTenTinh:
                        MessageBox.Show("Tên tỉnh đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaTinhMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case SuaTinhMessage.Success:
                        MessageBox.Show("Sửa tỉnh thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string tenTinh = txtTenTinh.Text.Trim();

                ThemTinhMessage message = TinhBLL.ThemTinh(tenTinh);
                switch (message)
                {
                    case ThemTinhMessage.EmptyTenTinh:
                        MessageBox.Show("Tên tỉnh không được để trống!");
                        break;
                    case ThemTinhMessage.DuplicateTenTinh:
                        MessageBox.Show("Tên tỉnh đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemTinhMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case ThemTinhMessage.Success:
                        if (themSuaTinhRequester != null)
                        {
                            themSuaTinhRequester.OnThemSuaTinhClosing();
                        }

                        MessageBox.Show("Thêm tỉnh thành công!");
                        break;
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThemSuaTinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaTinhRequester != null)
            {
                themSuaTinhRequester.OnThemSuaTinhClosing();
            }
        }
    }
}
