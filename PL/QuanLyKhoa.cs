using BLL;
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
    public partial class QuanLyKhoa : KryptonForm, IThemSuaKhoaRequester
    {
        private readonly IKhoaBLLService _khoaBLLService = new KhoaBLLService(new KhoaDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));

        private IKhoaRequester khoaRequester;
        private BindingList<Khoa> mKhoa;
        private BindingSource mKhoaSource;

        private string placeholderText = "🔎 Tìm kiếm";

        public QuanLyKhoa(IKhoaRequester requester)
        {
            InitializeComponent();

            khoaRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            // dgvDanhSachKhoa
            dgvDanhSachKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachKhoa.MultiSelect = false;
            dgvDanhSachKhoa.ReadOnly = true;
            dgvDanhSachKhoa.AllowUserToAddRows = false;
            dgvDanhSachKhoa.AllowUserToDeleteRows = false;
        }

        public void OnThemSuaKhoaClosing()
        {
            mKhoa = new BindingList<Khoa>(_khoaBLLService.LayDSKhoa());
            mKhoaSource.DataSource = mKhoa;
        }

        private void Khoa_Load(object sender, EventArgs e)
        {
            mKhoa = new BindingList<Khoa>(_khoaBLLService.LayDSKhoa());
            mKhoaSource = new BindingSource(mKhoa, null);
            dgvDanhSachKhoa.DataSource = mKhoaSource;

            dgvDanhSachKhoa.Columns["MaKhoa"].HeaderText = "Mã khoa";
            dgvDanhSachKhoa.Columns["MaKhoa"].Width = 150;

            dgvDanhSachKhoa.Columns["TenKhoa"].HeaderText = "Tên khoa";
            dgvDanhSachKhoa.Columns["TenKhoa"].Width = 473;
        }

        private void dgvDanhSachKhoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachKhoa.CurrentRow != null)
            {
                dgvDanhSachKhoa.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                Khoa khoa = mKhoa[dgvDanhSachKhoa.CurrentRow.Index];
                if (khoa != null)
                {
                    txtMaKhoa.Text = khoa.MaKhoa;
                    txtTenKhoa.Text = khoa.TenKhoa;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaKhoa themSuaKhoa = new ThemSuaKhoa(this);
            themSuaKhoa.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Khoa khoa = mKhoa[dgvDanhSachKhoa.CurrentRow.Index];

            ThemSuaKhoa themSuaKhoa = new ThemSuaKhoa(this, khoa);
            themSuaKhoa.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa khoa đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maKhoa = dgvDanhSachKhoa.CurrentRow.Cells["MaKhoa"].Value as string;
                Khoa khoa = mKhoa[dgvDanhSachKhoa.CurrentRow.Index];

                XoaKhoaMessage message = _khoaBLLService.XoaKhoa(maKhoa);
                switch (message)
                {
                    case XoaKhoaMessage.Error:
                        MessageBox.Show("Không thể xóa khoa vì có ngành đang thuộc khoa hiện tại!");
                        break;
                    case XoaKhoaMessage.Success:
                        mKhoa.Remove(khoa);
                        MessageBox.Show("Xóa khoa thành công!");
                        break;
                }
            }
        }

        private void picLoc_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                BindingList<Khoa> filterList = new BindingList<Khoa>(mKhoa.Where(d =>
                    d.MaKhoa.ToLower().Contains(searchQuery) ||
                    d.TenKhoa.ToLower().Contains(searchQuery)).ToList()
                );
                mKhoaSource.DataSource = filterList;
            }
        }

        private void picBoLoc_Click(object sender, EventArgs e)
        {
            mKhoaSource.DataSource = mKhoa;
            txtTimKiem.Text = placeholderText;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuanLyKhoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (khoaRequester != null)
            {
                khoaRequester.OnKhoaClosing();
            }
        }
    }
}
