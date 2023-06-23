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
    public partial class QuanLyTinh : KryptonForm, IThemSuaTinhRequester
    {
        private ICaiDatRequester caiDatRequester;
        private BindingList<Tinh> mTinh;
        private BindingSource mTinhSource;

        public QuanLyTinh(ICaiDatRequester requester)
        {
            InitializeComponent();

            caiDatRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            dgvDSTinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSTinh.MultiSelect = false;
            dgvDSTinh.ReadOnly = true;
            dgvDSTinh.AllowUserToAddRows = false;
            dgvDSTinh.AllowUserToDeleteRows = false;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuanLyTinh_Load(object sender, EventArgs e)
        {
            mTinh = new BindingList<Tinh>(TinhBLL.LayDSTinh());
            mTinhSource = new BindingSource(mTinh, null);
            dgvDSTinh.DataSource = mTinhSource;

            dgvDSTinh.Columns["MaTinh"].HeaderText = "Mã tỉnh";
            dgvDSTinh.Columns["MaTinh"].Width = 150;

            dgvDSTinh.Columns["TenTTP"].HeaderText = "Tên tỉnh";
            dgvDSTinh.Columns["TenTTP"].Width = 239;
        }

        private void dgvDSTinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSTinh.CurrentRow != null)
            {
                dgvDSTinh.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                Tinh tinh = mTinh[dgvDSTinh.CurrentRow.Index];
                if (tinh != null)
                {
                    txtMaTinh.Text = tinh.MaTinh.ToString();
                    txtTenTinh.Text = tinh.TenTTP;
                }
            }
        }

        private void QuanLyTinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caiDatRequester != null)
            {
                caiDatRequester.OnCaiDatClosing();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaTinh themSuaTinh = new ThemSuaTinh(this);
            themSuaTinh.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Tinh tinh = mTinh[dgvDSTinh.CurrentRow.Index];
            ThemSuaTinh themSuaTinh = new ThemSuaTinh(this, tinh);
            themSuaTinh.Show();
        }

        public void OnThemSuaTinhClosing()
        {
            mTinh = new BindingList<Tinh>(TinhBLL.LayDSTinh());
            mTinhSource.DataSource = mTinh;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa tỉnh đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Tinh tinh = mTinh[dgvDSTinh.CurrentRow.Index];
                int maTinh = mTinh[dgvDSTinh.CurrentRow.Index].MaTinh;

                XoaTinhMessage message = TinhBLL.XoaTinh(maTinh);
                switch (message)
                {
                    case XoaTinhMessage.Error:
                        MessageBox.Show("Bạn không thể xóa tỉnh này do có huyện đang thuộc tỉnh!");
                        break;
                    case XoaTinhMessage.Success:
                        mTinh.Remove(tinh);
                        MessageBox.Show("Xóa tỉnh thành công!");
                        break;
                }
            }
        }

        private void btnLoaiMon_Click(object sender, EventArgs e)
        {
            QuanLyLoaiMonHoc quanLyLoaiMonHoc = new QuanLyLoaiMonHoc(caiDatRequester);
            quanLyLoaiMonHoc.Show();
            Hide();
        }

        private void btnDoiTuong_Click(object sender, EventArgs e)
        {
            QuanLyDoiTuong quanLyDoiTuong = new QuanLyDoiTuong(caiDatRequester);
            quanLyDoiTuong.Show();
            Hide();
        }

        private void btnHuyen_Click(object sender, EventArgs e)
        {
            QuanLyHuyen quanLyHuyen = new QuanLyHuyen(caiDatRequester);
            quanLyHuyen.Show();
            Hide();
        }
    }
}
