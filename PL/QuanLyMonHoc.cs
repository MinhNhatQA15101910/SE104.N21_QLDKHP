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
    public partial class QuanLyMonHoc : KryptonForm, IThemSuaMonHocRequester
    {
        private readonly IMonHocBLLService _monHocBLLService = new MonHocBLLService(new MonHocDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
        
        private IMonHocRequester monHocRequester;
        private BindingList<CT_MonHoc> mMonHoc;
        private BindingSource mMonHocSource;

        private string placeholderText = "🔎 Tìm kiếm";

        public QuanLyMonHoc(IMonHocRequester requester)
        {
            InitializeComponent();

            monHocRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            // dgvDanhSachMonHoc
            dgvDanhSachMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachMonHoc.MultiSelect = false;
            dgvDanhSachMonHoc.ReadOnly = true;
            dgvDanhSachMonHoc.AllowUserToAddRows = false;
            dgvDanhSachMonHoc.AllowUserToDeleteRows = false;
        }

        private void MonHoc_Load(object sender, EventArgs e)
        {
            mMonHoc = new BindingList<CT_MonHoc>(_monHocBLLService.LayDSMonHoc());
            mMonHocSource = new BindingSource(mMonHoc, null);
            dgvDanhSachMonHoc.DataSource = mMonHocSource;

            dgvDanhSachMonHoc.Columns["MaMH"].HeaderText = "Mã môn học";
            dgvDanhSachMonHoc.Columns["MaMH"].Width = 100;

            dgvDanhSachMonHoc.Columns["TenMH"].HeaderText = "Tên môn học";
            dgvDanhSachMonHoc.Columns["TenMH"].Width = 330;

            dgvDanhSachMonHoc.Columns["TenLoaiMonHoc"].HeaderText = "Loại môn";
            dgvDanhSachMonHoc.Columns["TenLoaiMonHoc"].Width = 100;

            dgvDanhSachMonHoc.Columns["SoTiet"].HeaderText = "Số tiết";
            dgvDanhSachMonHoc.Columns["SoTiet"].Width = 73;

            dgvDanhSachMonHoc.Columns["MaLoaiMonHoc"].Visible = false;
            dgvDanhSachMonHoc.Columns["SoTietLoaiMon"].Visible = false;
            dgvDanhSachMonHoc.Columns["SoTien"].Visible = false;
        }

        private void dgvDanhSachMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachMonHoc.CurrentRow != null)
            {
                dgvDanhSachMonHoc.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                CT_MonHoc monHoc = mMonHoc[dgvDanhSachMonHoc.CurrentRow.Index];
                if (monHoc != null)
                {
                    txtMaMonHoc.Text = monHoc.MaMH;
                    txtTenMonHoc.Text = monHoc.TenMH;
                    txtLoaiMon.Text = monHoc.TenLoaiMonHoc;
                    txtSoTiet.Text = monHoc.SoTiet.ToString();
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

        public void OnThemSuaMonHocClosing()
        {
            mMonHoc = new BindingList<CT_MonHoc>(_monHocBLLService.LayDSMonHoc());
            mMonHocSource.DataSource = mMonHoc;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaMonHoc themSuaMonHoc = new ThemSuaMonHoc(this);
            themSuaMonHoc.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CT_MonHoc monHoc = mMonHoc[dgvDanhSachMonHoc.CurrentRow.Index];

            ThemSuaMonHoc themSuaMonHoc = new ThemSuaMonHoc(this, monHoc);
            themSuaMonHoc.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa môn học đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maMH = dgvDanhSachMonHoc.CurrentRow.Cells["MaMH"].Value as string;
                CT_MonHoc monHoc = mMonHoc[dgvDanhSachMonHoc.CurrentRow.Index];

                XoaMonHocMessage message = _monHocBLLService.XoaMonHoc(maMH);
                switch (message)
                {
                    case XoaMonHocMessage.Error:
                        MessageBox.Show("Không thể xóa môn học này vì có chương trình học chứa môn học hoặc môn học có trong danh sách môn học mở!");
                        break;
                    case XoaMonHocMessage.Success:
                        mMonHoc.Remove(monHoc);
                        MessageBox.Show("Xóa môn học thành công!");
                        break;
                }
            }
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
                BindingList<CT_MonHoc> filterList = new BindingList<CT_MonHoc>(mMonHoc.Where(d =>
                    d.MaMH.ToLower().Contains(searchQuery) ||
                    d.TenMH.ToLower().Contains(searchQuery) ||
                    d.TenLoaiMonHoc.ToLower().Contains(searchQuery) ||
                    d.SoTiet.ToString().Contains(searchQuery)).ToList()
                );
                mMonHocSource.DataSource = filterList;
            }
        }

        private void picBoLoc_Click(object sender, EventArgs e)
        {
            mMonHocSource.DataSource = mMonHoc;
            txtTimKiem.Text = placeholderText;
        }

        private void MonHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (monHocRequester != null)
            {
                monHocRequester.OnMonHocClosing();
            }
        }
    }
}
