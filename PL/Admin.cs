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
    public partial class Admin :  KryptonForm
    {
        private IAdminRequester adminRequester;

        private BindingList<DTO.SinhVien> mSinhVienChuaCoTK;
        private BindingList<DTO.SinhVien> mSinhVienChuaCoTKSelected;
        private BindingList<CT_NguoiDung> mNguoiDung;

        private BindingSource mSinhVienChuaCoTKSource;
        private BindingSource mSinhVienChuaCoTKSelectedSource;
        private BindingSource mNguoiDungSource;

        private string placeholderText = "🔎 Tìm kiếm";

        public Admin(IAdminRequester requester)
        {
            InitializeComponent();

            adminRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            dgvDSSVChuaCoTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSSVChuaCoTK.MultiSelect = false;
            dgvDSSVChuaCoTK.ReadOnly = true;
            dgvDSSVChuaCoTK.AllowUserToAddRows = false;
            dgvDSSVChuaCoTK.AllowUserToDeleteRows = false;

            dgvDSSVDaChon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSSVDaChon.MultiSelect = false;
            dgvDSSVDaChon.ReadOnly = true;
            dgvDSSVDaChon.AllowUserToAddRows = false;
            dgvDSSVDaChon.AllowUserToDeleteRows = false;

            dgvDSTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSTK.MultiSelect = false;
            dgvDSTK.ReadOnly = true;
            dgvDSTK.AllowUserToAddRows = false;
            dgvDSTK.AllowUserToDeleteRows = false;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (adminRequester != null)
            {
                adminRequester.OnAdminClosing();
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            mSinhVienChuaCoTK = new BindingList<DTO.SinhVien>(SinhVienBLL.LayDSSVChuaCoTK());
            mSinhVienChuaCoTKSource = new BindingSource(mSinhVienChuaCoTK, null);
            dgvDSSVChuaCoTK.DataSource = mSinhVienChuaCoTKSource;

            dgvDSSVChuaCoTK.Columns["MaSV"].HeaderText = "MSSV";
            dgvDSSVChuaCoTK.Columns["MaSV"].Width = 200;

            dgvDSSVChuaCoTK.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvDSSVChuaCoTK.Columns["HoTen"].Width = 225;

            dgvDSSVChuaCoTK.Columns["NgaySinh"].Visible = false;
            dgvDSSVChuaCoTK.Columns["GioiTinh"].Visible = false;
            dgvDSSVChuaCoTK.Columns["MaHuyen"].Visible = false;
            dgvDSSVChuaCoTK.Columns["MaNganh"].Visible = false;


            mSinhVienChuaCoTKSelected = new BindingList<DTO.SinhVien>();
            mSinhVienChuaCoTKSelectedSource = new BindingSource(mSinhVienChuaCoTKSelected, null);
            dgvDSSVDaChon.DataSource = mSinhVienChuaCoTKSelectedSource;

            dgvDSSVDaChon.Columns["MaSV"].HeaderText = "MSSV";
            dgvDSSVDaChon.Columns["MaSV"].Width = 200;

            dgvDSSVDaChon.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvDSSVDaChon.Columns["HoTen"].Width = 234;

            dgvDSSVDaChon.Columns["NgaySinh"].Visible = false;
            dgvDSSVDaChon.Columns["GioiTinh"].Visible = false;
            dgvDSSVDaChon.Columns["MaHuyen"].Visible = false;
            dgvDSSVDaChon.Columns["MaNganh"].Visible = false;


            mNguoiDung = new BindingList<CT_NguoiDung>(NguoiDungBLL.LayDSNguoiDung());
            mNguoiDungSource = new BindingSource(mNguoiDung, null);
            dgvDSTK.DataSource = mNguoiDungSource;

            dgvDSTK.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dgvDSTK.Columns["TenDangNhap"].Width = 223;

            dgvDSTK.Columns["TenNhom"].HeaderText = "Loại tài khoản";
            dgvDSTK.Columns["TenNhom"].Width = 223;

            dgvDSTK.Columns["MatKhau"].Visible = false;
            dgvDSTK.Columns["MaNhom"].Visible = false;
        }

        private void btnQuayLai2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuayLai1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDSSVChuaCoTK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSSVChuaCoTK.CurrentRow != null)
            {
                dgvDSSVChuaCoTK.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void dgvDSSVDaChon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSSVDaChon.CurrentRow != null)
            {
                dgvDSSVDaChon.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void dgvDSTK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSTK.CurrentRow != null)
            {
                dgvDSTK.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }
    }
}
