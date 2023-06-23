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
    public partial class QuanLyLoaiMonHoc : KryptonForm, IThemSuaLoaiMonHocRequester
    {
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
            mLoaiMonHoc = new BindingList<LoaiMonHoc>(LoaiMonHocBLL.LayDSLoaiMonHoc());
            mLoaiMonHocSource = new BindingSource(mLoaiMonHoc, null);
            dgvDSLoaiMon.DataSource = mLoaiMonHocSource;

            dgvDSLoaiMon.Columns["TenLoaiMonHoc"].HeaderText = "Tên loại môn";
            dgvDSLoaiMon.Columns["TenLoaiMonHoc"].Width = 150;

            dgvDSLoaiMon.Columns["SoTiet"].HeaderText = "Số tiết";
            dgvDSLoaiMon.Columns["SoTiet"].Width = 100;

            dgvDSLoaiMon.Columns["SoTien"].HeaderText = "Số tiền";
            dgvDSLoaiMon.Columns["SoTien"].Width = 139;

            dgvDSLoaiMon.Columns["MaLoaiMonHoc"].Visible = false;


            txtTinChiToiDa.Text = GlobalConfigBLL.LaySoTinChiToiDa().ToString();
            txtTinChiToiThieu.Text = GlobalConfigBLL.LaySoTinChiToiThieu().ToString();
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

            SuaGioiHanTinChiMessage message = GlobalConfigBLL.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);
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
                case SuaGioiHanTinChiMessage.Error:
                    MessageBox.Show("Đã có lỗi xảy ra!");
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

                XoaLoaiMonHocMessage message = LoaiMonHocBLL.XoaLoaiMonHoc(maLoaiMonHoc);
                switch (message)
                {
                    case XoaLoaiMonHocMessage.Error:
                        MessageBox.Show("Bạn không thể xóa loại môn học này vì có môn học đang thuộc về loại môn học!");
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
            mLoaiMonHoc = new BindingList<LoaiMonHoc>(LoaiMonHocBLL.LayDSLoaiMonHoc());
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
