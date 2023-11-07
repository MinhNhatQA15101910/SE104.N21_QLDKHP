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
    public partial class QuanLyLoaiMonHoc : KryptonForm, IThemSuaLoaiMonHocRequester
    {
        #region Register Service
        private readonly IGlobalConfigBLLService _globalConfigBLLService 
            = new GlobalConfigBLLService(
                new GlobalConfigDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));
        private readonly ILoaiMonHocBLLService _loaiMonHocBLLService 
            = new LoaiMonHocBLLService(
                new LoaiMonHocDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()),
                new MonHocDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));
        #endregion

        private ICaiDatRequester caiDatRequester;
        private BindingList<LoaiMonHoc> mLoaiMonHoc;
        private BindingSource mLoaiMonHocSource;

        public QuanLyLoaiMonHoc(ICaiDatRequester requester)
        {
            InitializeComponent();

            caiDatRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            dgvDSLoaiMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSLoaiMon.MultiSelect = false;
            dgvDSLoaiMon.ReadOnly = true;
            dgvDSLoaiMon.AllowUserToAddRows = false;
            dgvDSLoaiMon.AllowUserToDeleteRows = false;
        }

        private void QuanLyLoaiMonHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caiDatRequester != null)
            {
                caiDatRequester.OnCaiDatClosing();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuanLyLoaiMonHoc_Load(object sender, EventArgs e)
        {
            mLoaiMonHoc = new BindingList<LoaiMonHoc>(_loaiMonHocBLLService.LayDSLoaiMonHoc());
            mLoaiMonHocSource = new BindingSource(mLoaiMonHoc, null);
            dgvDSLoaiMon.DataSource = mLoaiMonHocSource;

            dgvDSLoaiMon.Columns["TenLoaiMonHoc"].HeaderText = "Tên loại môn";
            dgvDSLoaiMon.Columns["TenLoaiMonHoc"].Width = 150;

            dgvDSLoaiMon.Columns["SoTiet"].HeaderText = "Số tiết";
            dgvDSLoaiMon.Columns["SoTiet"].Width = 100;

            dgvDSLoaiMon.Columns["SoTien"].HeaderText = "Số tiền";
            dgvDSLoaiMon.Columns["SoTien"].Width = 139;

            dgvDSLoaiMon.Columns["MaLoaiMonHoc"].Visible = false;


            txtTinChiToiDa.Text = _globalConfigBLLService.LaySoTinChiToiDa().ToString();
            txtTinChiToiThieu.Text = _globalConfigBLLService.LaySoTinChiToiThieu().ToString();
        }

        private void dgvDSLoaiMon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSLoaiMon.CurrentRow != null)
            {
                dgvDSLoaiMon.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                LoaiMonHoc loaiMonHoc = mLoaiMonHoc[dgvDSLoaiMon.CurrentRow.Index];
                if (loaiMonHoc != null)
                {
                    txtLoaiMon.Text = loaiMonHoc.TenLoaiMonHoc;
                    txtSoTiet.Text = loaiMonHoc.SoTiet.ToString();
                    txtSoTien.Text = loaiMonHoc.SoTien.ToString();
                }
            }
        }

        private void btnLuuGHTC_Click(object sender, EventArgs e)
        {
            string tinChiToiDa = txtTinChiToiDa.Text.Trim();
            string tinChiToiThieu = txtTinChiToiThieu.Text.Trim();

            SuaGioiHanTinChiMessage message = _globalConfigBLLService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);
            switch (message)
            {
                case SuaGioiHanTinChiMessage.TinChiToiDaRong:
                    MessageBox.Show("Tín chỉ tối đa không được để trống!");
                    break;
                case SuaGioiHanTinChiMessage.TinChiToiThieuRong:
                    MessageBox.Show("Tín chỉ tối thiểu không được để trống!");
                    break;
                case SuaGioiHanTinChiMessage.TinChiToiDaKhongHopLe:
                    MessageBox.Show("Tín chỉ tối đa không hợp lệ!");
                    break;
                case SuaGioiHanTinChiMessage.TinChiToiThieuKhongHopLe:
                    MessageBox.Show("Tín chỉ thiểu không hợp lệ!");
                    break;
                case SuaGioiHanTinChiMessage.Unable:
                    MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                    break;
                case SuaGioiHanTinChiMessage.Failed:
                    MessageBox.Show("Cập nhật giới hạn tín chỉ thất bại!");
                    break;
                case SuaGioiHanTinChiMessage.Success:
                    MessageBox.Show("Cập nhật giới hạn tín chỉ thành công!");
                    break;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa loại môn học đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoaiMonHoc loaiMonHoc = mLoaiMonHoc[dgvDSLoaiMon.CurrentRow.Index];
                int maLoaiMonHoc = mLoaiMonHoc[dgvDSLoaiMon.CurrentRow.Index].MaLoaiMonHoc;

                XoaLoaiMonHocMessage message = _loaiMonHocBLLService.XoaLoaiMonHoc(maLoaiMonHoc);
                switch (message)
                {
                    case XoaLoaiMonHocMessage.Unable:
                        MessageBox.Show("Không thể xóa loại môn học do có môn học đang thuộc loại này!");
                        break;
                    case XoaLoaiMonHocMessage.Failed:
                        MessageBox.Show("Xóa loại môn học thất bại!");
                        break;
                    case XoaLoaiMonHocMessage.Success:
                        mLoaiMonHoc.Remove(loaiMonHoc);
                        MessageBox.Show("Xóa loại môn học thành công!");
                        break;
                }
            }
        }

        private void btnSuaLoaiMon_Click(object sender, EventArgs e)
        {
            LoaiMonHoc loaiMonHoc = mLoaiMonHoc[dgvDSLoaiMon.CurrentRow.Index];
            ThemSuaLoaiMonHoc themSuaLoaiMonHoc = new ThemSuaLoaiMonHoc(this, loaiMonHoc);
            themSuaLoaiMonHoc.Show();
        }

        public void OnThemSuaLoaiMonHocClosing()
        {
            mLoaiMonHoc = new BindingList<LoaiMonHoc>(_loaiMonHocBLLService.LayDSLoaiMonHoc());
            mLoaiMonHocSource.DataSource = mLoaiMonHoc;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaLoaiMonHoc themSuaLoaiMonHoc = new ThemSuaLoaiMonHoc(this);
            themSuaLoaiMonHoc.Show();
        }

        private void btnDoiTuong_Click(object sender, EventArgs e)
        {
            QuanLyDoiTuong quanLyDoiTuong = new QuanLyDoiTuong(caiDatRequester);
            quanLyDoiTuong.Show();
            Hide();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            QuanLyTinh quanLyTinh = new QuanLyTinh(caiDatRequester);
            quanLyTinh.Show();
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
