using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PL
{
    public partial class QuanLyNganh : KryptonForm, IThemSuaNganhRequester
    {
        private INganhRequester nganhRequester;
        private BindingList<CT_Nganh> mNganh;
        private BindingSource mNganhSource;

        private string placeholderText = "🔎 Tìm kiếm";

        public QuanLyNganh(INganhRequester requester)
        {
            InitializeComponent();
            SettingProperties();

            nganhRequester = requester;
        }

        private void SettingProperties()
        {
            // dgvDanhSachNganh
            dgvDanhSachNganh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachNganh.MultiSelect = false;
            dgvDanhSachNganh.ReadOnly = true;
            dgvDanhSachNganh.AllowUserToAddRows = false;
            dgvDanhSachNganh.AllowUserToDeleteRows = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (nganhRequester != null)
            {
                nganhRequester.OnNganhClosing();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Nganh_Load(object sender, EventArgs e)
        {
            mNganh = new BindingList<CT_Nganh>(NganhBLL.LayDSNganh());
            mNganhSource = new BindingSource(mNganh, null);
            dgvDanhSachNganh.DataSource = mNganhSource;

            dgvDanhSachNganh.Columns["MaNganh"].HeaderText = "Mã ngành";
            dgvDanhSachNganh.Columns["MaNganh"].Width = 100;

            dgvDanhSachNganh.Columns["TenNganh"].HeaderText = "Tên ngành";
            dgvDanhSachNganh.Columns["TenNganh"].Width = 250;

            dgvDanhSachNganh.Columns["TenKhoa"].HeaderText = "Khoa";
            dgvDanhSachNganh.Columns["TenKhoa"].Width = 273;

            dgvDanhSachNganh.Columns["MaKhoa"].Visible = false;
        }

        private void dgvDanhSachNganh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachNganh.CurrentRow != null)
            {
                dgvDanhSachNganh.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                CT_Nganh nganh = mNganh[dgvDanhSachNganh.CurrentRow.Index];
                if (nganh != null)
                {
                    txtMaNganh.Text = nganh.MaNganh;
                    txtTenNganh.Text = nganh.TenNganh;
                    txtKhoa.Text = nganh.TenKhoa;
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

        public void OnThemSuaNganhClosing()
        {
            mNganh = new BindingList<CT_Nganh>(NganhBLL.LayDSNganh());
            mNganhSource.DataSource = mNganh;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaNganh themSuaNganh = new ThemSuaNganh(this);
            themSuaNganh.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CT_Nganh nganh = mNganh[dgvDanhSachNganh.CurrentRow.Index];

            ThemSuaNganh themSuaNganh = new ThemSuaNganh(this, nganh);
            themSuaNganh.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa ngành đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maNganh = dgvDanhSachNganh.CurrentRow.Cells["MaNganh"].Value as string;
                CT_Nganh nganh = mNganh[dgvDanhSachNganh.CurrentRow.Index];

                XoaNganhMessage message = NganhBLL.XoaNganh(maNganh);
                switch (message)
                {
                    case XoaNganhMessage.Error:
                        MessageBox.Show("Không thể xóa ngành vì có sinh viên đang thuộc ngành hiện tại!");
                        break;
                    case XoaNganhMessage.Success:
                        mNganh.Remove(nganh);
                        MessageBox.Show("Xóa ngành thành công!");
                        break;
                }
            }
        }

        private void picLoc_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                BindingList<CT_Nganh> filterList = new BindingList<CT_Nganh>(mNganh.Where(d =>
                    d.MaNganh.ToLower().Contains(searchQuery) ||
                    d.TenNganh.ToLower().Contains(searchQuery) ||
                    d.TenKhoa.ToLower().Contains(searchQuery)).ToList()
                );
                mNganhSource.DataSource = filterList;
            }
        }

        private void picBoLoc_Click(object sender, EventArgs e)
        {
            mNganhSource.DataSource = mNganh;
            txtTimKiem.Text = placeholderText;
        }
    }
}
