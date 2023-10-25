using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PL
{
    public partial class QuanLySinhVien : KryptonForm, IThemSuaSinhVienRequester
    {

        private readonly IDoiTuongBLLService _doiTuongBLLService = new DoiTuongBLLService(new DoiTuongDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly ISinhVienBLLService _sinhVienBLLService = new SinhVienBLLService(new SinhVienDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        
        private readonly IDanhSachSinhVienRequester dssvRequester;
        private BindingList<CT_SinhVien> mSinhVien;
        private BindingList<DoiTuong> mDoiTuong;
        private BindingSource mSinhVienSource;
        private BindingSource mDoiTuongSource;

        private readonly string placeholderText = "🔎 Tìm kiếm";

        public QuanLySinhVien(IDanhSachSinhVienRequester requester)
        {
            InitializeComponent();

            dssvRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            // dgvDanhSachSinhVien
            dgvDanhSachSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachSinhVien.MultiSelect = false;
            dgvDanhSachSinhVien.ReadOnly = true;
            dgvDanhSachSinhVien.AllowUserToAddRows = false;
            dgvDanhSachSinhVien.AllowUserToDeleteRows = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (dssvRequester != null)
            {
                dssvRequester.OnDSSVClosing();
            }
        }

        private void DSSV_Load(object sender, EventArgs e)
        {
            mSinhVien = new BindingList<CT_SinhVien>(_sinhVienBLLService.LayDSSV());
            mSinhVienSource = new BindingSource(mSinhVien, null);
            dgvDanhSachSinhVien.DataSource = mSinhVienSource;

            dgvDanhSachSinhVien.Columns["MaSV"].HeaderText = "MSSV";
            dgvDanhSachSinhVien.Columns["MaSV"].Width = 300;

            dgvDanhSachSinhVien.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvDanhSachSinhVien.Columns["HoTen"].Width = 500;

            dgvDanhSachSinhVien.Columns["NgaySinh"].Visible = false;
            dgvDanhSachSinhVien.Columns["GioiTinh"].Visible = false;
            dgvDanhSachSinhVien.Columns["MaHuyen"].Visible = false;
            dgvDanhSachSinhVien.Columns["TenHuyen"].Visible = false;
            dgvDanhSachSinhVien.Columns["MaTinh"].Visible = false;
            dgvDanhSachSinhVien.Columns["TenTTP"].Visible = false;
            dgvDanhSachSinhVien.Columns["MaNganh"].Visible = false;
            dgvDanhSachSinhVien.Columns["TenNganh"].Visible = false;
            dgvDanhSachSinhVien.Columns["MaKhoa"].Visible = false;
            dgvDanhSachSinhVien.Columns["TenKhoa"].Visible = false;
            dgvDanhSachSinhVien.Columns["VungUT"].Visible = false;
        }

        private void dgvDanhSachSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachSinhVien.CurrentRow != null)
            {
                dgvDanhSachSinhVien.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                CT_SinhVien sinhVien = mSinhVien[dgvDanhSachSinhVien.CurrentRow.Index];
                if (sinhVien != null)
                {
                    txtMSSV.Text = sinhVien.MaSV;
                    txtHoTen.Text = sinhVien.HoTen;
                    txtNganh.Text = sinhVien.MaNganh + " - " + sinhVien.TenNganh;
                    txtNgaySinh.Text = sinhVien.NgaySinh.ToString("dd/MM/yyyy");
                    txtQueQuan.Text = sinhVien.TenHuyen + ", " + sinhVien.TenTTP;
                    txtKhoa.Text = sinhVien.MaKhoa + " - " + sinhVien.TenKhoa;
                    if (sinhVien.GioiTinh.Equals("Nam"))
                    {
                        rbtnNam.Checked = true;
                        rbtnNu.Checked = false;
                    }
                    else
                    {
                        rbtnNam.Checked = false;
                        rbtnNu.Checked = true;
                    }
                    mDoiTuong = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuongBangMaSV(sinhVien.MaSV));
                    mDoiTuongSource = new BindingSource(mDoiTuong, null);
                    lbDoiTuong.DataSource = mDoiTuongSource;
                    lbDoiTuong.DisplayMember = "TenDT";
                    lbDoiTuong.ValueMember = "MaDT";
                }
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Equals(placeholderText))
            {
                txtTimKiem.Text = "";
                txtTimKiem.Font = new Font(txtTimKiem.Font, FontStyle.Regular);
                txtTimKiem.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.Font = new Font(txtTimKiem.Font, FontStyle.Italic);
                txtTimKiem.ForeColor = SystemColors.GrayText;
            }
        }

        public void OnThemSuaSinhVienClosing()
        {
            mSinhVien = new BindingList<CT_SinhVien>(_sinhVienBLLService.LayDSSV());
            mSinhVienSource.DataSource = mSinhVien;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picLoc_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                BindingList<CT_SinhVien> filterList = new BindingList<CT_SinhVien>(mSinhVien.Where(d =>
                    d.MaSV.ToLower().Contains(searchQuery) ||
                    d.HoTen.ToLower().Contains(searchQuery)).ToList()
                );
                mSinhVienSource.DataSource = filterList;
            }
        }

        private void picBoLoc_Click(object sender, EventArgs e)
        {
            mSinhVienSource.DataSource = mSinhVien;
            txtTimKiem.Text = placeholderText;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaSinhVien themSuaSinhVien = new ThemSuaSinhVien(this);
            themSuaSinhVien.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa sinh viên đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maSV = dgvDanhSachSinhVien.CurrentRow.Cells["MaSV"].Value as string;
                CT_SinhVien sinhVien = mSinhVien[dgvDanhSachSinhVien.CurrentRow.Index];

                XoaSinhVienMessage message = _sinhVienBLLService.XoaSinhVien(maSV);
                switch (message)
                {
                    case XoaSinhVienMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case XoaSinhVienMessage.Success:
                        mSinhVien.Remove(sinhVien);
                        MessageBox.Show("Xóa sinh viên thành công!");
                        break;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CT_SinhVien sinhVien = mSinhVien[dgvDanhSachSinhVien.CurrentRow.Index];

            ThemSuaSinhVien themSuaSinhVien = new ThemSuaSinhVien(this, sinhVien);
            themSuaSinhVien.Show();
        }
    }
}
