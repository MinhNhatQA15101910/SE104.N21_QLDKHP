using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PL
{
    public partial class Admin : KryptonForm, IThemSuaTaiKhoanRequester
    {
		private readonly INguoiDungBLLService _nguoiDungBLLService = new NguoiDungBLLService(new NguoiDungDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
		private readonly ISinhVienBLLService _sinhVienBLLService = new SinhVienBLLService(new SinhVienDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));

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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                if (adminRequester != null)
                {
                    adminRequester.OnAdminClosing();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            mSinhVienChuaCoTK = new BindingList<DTO.SinhVien>(_sinhVienBLLService.LayDSSVChuaCoTK());
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


            mNguoiDung = new BindingList<CT_NguoiDung>(_nguoiDungBLLService.LayDSNguoiDung());
            mNguoiDungSource = new BindingSource(mNguoiDung, null);
            dgvDSTK.DataSource = mNguoiDungSource;

            dgvDSTK.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dgvDSTK.Columns["TenDangNhap"].Width = 223;

            dgvDSTK.Columns["TenNhom"].HeaderText = "Loại tài khoản";
            dgvDSTK.Columns["TenNhom"].Width = 223;

            dgvDSTK.Columns["MatKhau"].Visible = false;
            dgvDSTK.Columns["MaNhom"].Visible = false;
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

                CT_NguoiDung nguoiDung = mNguoiDung[dgvDSTK.CurrentRow.Index];
                if (nguoiDung != null)
                {
                    txtTenDangNhap.Text = nguoiDung.TenDangNhap;
                    txtLoaiTK.Text = nguoiDung.TenNhom;
                }
            }
        }

        private void picChon_Click(object sender, EventArgs e)
        {
            DTO.SinhVien sinhVien = mSinhVienChuaCoTK[dgvDSSVChuaCoTK.CurrentRow.Index];
            if (sinhVien != null)
            {
                mSinhVienChuaCoTKSelected.Add(sinhVien);
                mSinhVienChuaCoTK.Remove(sinhVien);
            }
            mSinhVienChuaCoTKSource.DataSource = mSinhVienChuaCoTK;
            mSinhVienChuaCoTKSelectedSource.DataSource = mSinhVienChuaCoTKSelected;
        }

        private void picBoChon_Click(object sender, EventArgs e)
        {
            DTO.SinhVien sinhVien = mSinhVienChuaCoTKSelected[dgvDSSVDaChon.CurrentRow.Index];
            if (sinhVien != null)
            {
                mSinhVienChuaCoTK.Add(sinhVien);
                mSinhVienChuaCoTKSelected.Remove(sinhVien);
            }
            mSinhVienChuaCoTKSource.DataSource = mSinhVienChuaCoTK;
            mSinhVienChuaCoTKSelectedSource.DataSource = mSinhVienChuaCoTKSelected;
        }

        private void txtTimKiemSinhVien_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemSinhVien.Text.Equals(placeholderText))
            {
                txtTimKiemSinhVien.Text = "";
                txtTimKiemSinhVien.Font = new Font(txtTimKiemSinhVien.Font, FontStyle.Regular);
                txtTimKiemSinhVien.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtTimKiemSinhVien_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiemSinhVien.Text.Trim()))
            {
                txtTimKiemSinhVien.Text = placeholderText;
                txtTimKiemSinhVien.Font = new Font(txtTimKiemSinhVien.Font, FontStyle.Italic);
                txtTimKiemSinhVien.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtTimKiemTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemTaiKhoan.Text.Equals(placeholderText))
            {
                txtTimKiemTaiKhoan.Text = "";
                txtTimKiemTaiKhoan.Font = new Font(txtTimKiemTaiKhoan.Font, FontStyle.Regular);
                txtTimKiemTaiKhoan.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtTimKiemTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiemTaiKhoan.Text.Trim()))
            {
                txtTimKiemTaiKhoan.Text = placeholderText;
                txtTimKiemTaiKhoan.Font = new Font(txtTimKiemTaiKhoan.Font, FontStyle.Italic);
                txtTimKiemTaiKhoan.ForeColor = SystemColors.GrayText;
            }
        }

        private void picLocTaiKhoan_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiemTaiKhoan.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                BindingList<CT_NguoiDung> mDSTimKiem = new BindingList<CT_NguoiDung>(mNguoiDung.Where(d =>
                    d.TenDangNhap.ToLower().Contains(searchQuery) ||
                    d.TenNhom.ToLower().Contains(searchQuery)).ToList()
                );
                mNguoiDungSource.DataSource = mDSTimKiem;
            }
        }

        private void picBoLocTaiKhoan_Click(object sender, EventArgs e)
        {
            mNguoiDungSource.DataSource = mNguoiDung;
            txtTimKiemTaiKhoan.Text = placeholderText;
        }

        private void picLocSinhVien_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiemSinhVien.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                BindingList<DTO.SinhVien> mDSTimKiem = new BindingList<DTO.SinhVien>(mSinhVienChuaCoTK.Where(d =>
                    d.MaSV.ToLower().Contains(searchQuery) ||
                    d.HoTen.ToLower().Contains(searchQuery)).ToList()
                );
                mSinhVienChuaCoTKSource.DataSource = mDSTimKiem;
            }
        }

        private void picBoLocSinhVien_Click(object sender, EventArgs e)
        {
            mSinhVienChuaCoTKSource.DataSource = mSinhVienChuaCoTK;
            txtTimKiemSinhVien.Text = placeholderText;
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            IList<DTO.SinhVien> dssv = mSinhVienChuaCoTKSelected;
            ThemTaiKhoanSVMessage message = _nguoiDungBLLService.ThemTaiKhoanSV(dssv);
            switch (message)
            {
                case ThemTaiKhoanSVMessage.Unable:
                    MessageBox.Show("Vui lòng chọn sinh viên để thêm tài khoản!");
                    break;
                case ThemTaiKhoanSVMessage.Success:
                    MessageBox.Show("Thêm tài khoản sinh viên thành công!");

                    mSinhVienChuaCoTKSelected.Clear();
                    mNguoiDung = new BindingList<CT_NguoiDung>(_nguoiDungBLLService.LayDSNguoiDung());
                    mNguoiDungSource.DataSource = mNguoiDung;

                    break;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa tài khoản đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                XoaTaiKhoanMessage message = _nguoiDungBLLService.XoaTaiKhoan(tenDangNhap);
                switch (message)
                {
                    case XoaTaiKhoanMessage.Unable:
                        MessageBox.Show("Không thể xóa tài khoản hiện tại!");
                        break;
                    case XoaTaiKhoanMessage.Success:
                        mNguoiDung = new BindingList<CT_NguoiDung>(_nguoiDungBLLService.LayDSNguoiDung());
                        mNguoiDungSource.DataSource = mNguoiDung;

                        mSinhVienChuaCoTK = new BindingList<DTO.SinhVien>(_sinhVienBLLService.LayDSSVChuaCoTK());
                        mSinhVienChuaCoTKSource.DataSource = mSinhVienChuaCoTK;

                        MessageBox.Show("Xóa tài khoản thành công!");

                        break;
                }
            }
        }

        private void imgDangXuat1_Click(object sender, EventArgs e)
        {
            pnlDangXuat1.Visible = !pnlDangXuat1.Visible;
        }

        private void picDangXuat2_Click(object sender, EventArgs e)
        {
            pnlDangXuat2.Visible = !pnlDangXuat2.Visible;
        }

        private void btnDangXuat2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDangXuat1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoiMatKhau1_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.Show();
        }

        private void btnDoiMatKhau2_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.Show();
        }

        public void OnThemSuaTaiKhoanClosing()
        {
            // Reload DSTK
            mNguoiDung = new BindingList<CT_NguoiDung>(_nguoiDungBLLService.LayDSNguoiDung());
            mNguoiDungSource.DataSource = mNguoiDung;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaTaiKhoan themSuaTaiKhoan = new ThemSuaTaiKhoan(this);
            themSuaTaiKhoan.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CT_NguoiDung nguoiDung = mNguoiDung[dgvDSTK.CurrentRow.Index];

            if (nguoiDung.MaNhom == "sv")
            {
                MessageBox.Show("Không thể sửa đổi tài khoản sinh viên!");
                return;
            }

            if (nguoiDung.TenDangNhap == GlobalConfig.CurrNguoiDung.TenDangNhap)
            {
                MessageBox.Show("Không thể sửa đổi tài khoản admin đang đăng nhập!");
                return;
            }

            ThemSuaTaiKhoan themSuaTaiKhoan = new ThemSuaTaiKhoan(this, nguoiDung);
            themSuaTaiKhoan.Show();
        }

        private void picQuayLai1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picQuayLai2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
