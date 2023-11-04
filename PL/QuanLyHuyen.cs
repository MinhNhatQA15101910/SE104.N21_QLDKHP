using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class QuanLyHuyen : KryptonForm, IThemSuaHuyenRequester
    {
        #region Register Services
        private readonly IHuyenBLLService _huyenBLLService = new HuyenBLLService(new HuyenDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
        #endregion

        private ICaiDatRequester caiDatRequester;
        private BindingList<CT_Huyen> mHuyen;
        private BindingSource mHuyenSource;

        public QuanLyHuyen(ICaiDatRequester requester)
        {
            InitializeComponent();

            caiDatRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            dgvDSHuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSHuyen.MultiSelect = false;
            dgvDSHuyen.ReadOnly = true;
            dgvDSHuyen.AllowUserToAddRows = false;
            dgvDSHuyen.AllowUserToDeleteRows = false;
        }

        private void QuanLyHuyen_Load(object sender, EventArgs e)
        {
            mHuyen = new BindingList<CT_Huyen>(_huyenBLLService.LayDSHuyen());
            mHuyenSource = new BindingSource(mHuyen, null);
            dgvDSHuyen.DataSource = mHuyenSource;

            dgvDSHuyen.Columns["TenHuyen"].HeaderText = "Tên huyện";
            dgvDSHuyen.Columns["TenHuyen"].Width = 130;

            dgvDSHuyen.Columns["VungUT"].HeaderText = "Vùng ưu tiên";
            dgvDSHuyen.Columns["VungUT"].Width = 129;

            dgvDSHuyen.Columns["TenTTP"].HeaderText = "Tên tỉnh";
            dgvDSHuyen.Columns["TenTTP"].Width = 130;

            dgvDSHuyen.Columns["MaHuyen"].Visible = false;
            dgvDSHuyen.Columns["MaTinh"].Visible = false;
        }

        private void dgvDSTinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSHuyen.CurrentRow != null)
            {
                dgvDSHuyen.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                CT_Huyen huyen = mHuyen[dgvDSHuyen.CurrentRow.Index];
                if (huyen != null)
                {
                    txtTenHuyen.Text = huyen.TenHuyen;
                    txtVungUuTien.Text = huyen.VungUT.ToString();
                    txtTinh.Text = huyen.TenTTP;
                }
            }
        }

        private void QuanLyHuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caiDatRequester != null)
            {
                caiDatRequester.OnCaiDatClosing();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaHuyen themSuaHuyen = new ThemSuaHuyen(this);
            themSuaHuyen.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CT_Huyen ct_huyen = mHuyen[dgvDSHuyen.CurrentRow.Index];
            Huyen huyen = new Huyen{
                MaHuyen = ct_huyen.MaHuyen, 
                TenHuyen = ct_huyen.TenHuyen, 
                VungUT = ct_huyen.VungUT,
                MaTinh = ct_huyen.MaTinh
            };
            ThemSuaHuyen themSuaHuyen = new ThemSuaHuyen(this, huyen);
            themSuaHuyen.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa huyện đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CT_Huyen huyen = mHuyen[dgvDSHuyen.CurrentRow.Index];
                int maHuyen = mHuyen[dgvDSHuyen.CurrentRow.Index].MaHuyen;

                XoaHuyenMessage message = _huyenBLLService.XoaHuyen(maHuyen);
                switch (message)
                {
                    case XoaHuyenMessage.Success:
                        mHuyen.Remove(huyen);
                        MessageBox.Show("Xóa huyện thành công!");
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void OnThemSuaHuyenClosing()
        {
            mHuyen = new BindingList<CT_Huyen>(_huyenBLLService.LayDSHuyen());
            mHuyenSource.DataSource = mHuyen;
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            QuanLyTinh quanLyTinh = new QuanLyTinh(caiDatRequester);
            quanLyTinh.Show();
            Hide();
        }
    }
}
