using BLL;
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
            else
            {
                cmbLoaiTaiKhoan.SelectedIndex = -1;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            cmbLoaiTaiKhoan.SelectedIndex = -1;
        }
    }
}
