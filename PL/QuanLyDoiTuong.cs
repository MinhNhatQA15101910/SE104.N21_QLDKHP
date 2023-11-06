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
    public partial class QuanLyDoiTuong : KryptonForm, IThemSuaDoiTuongRequester
    {
        private readonly IDoiTuongBLLService _doiTuongBLLService = new DoiTuongBLLService(
            new DoiTuongDALService(
                ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                new DapperWrapper()),
            new SinhVien_DoiTuongDALService(
                ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                new DapperWrapper()));

        private ICaiDatRequester caiDatRequester;
        private BindingList<DoiTuong> mDoiTuong;
        private BindingSource mDoiTuongSource;

        public QuanLyDoiTuong(ICaiDatRequester requester)
        {
            InitializeComponent();

            caiDatRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            dgvDSDoiTuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSDoiTuong.MultiSelect = false;
            dgvDSDoiTuong.ReadOnly = true;
            dgvDSDoiTuong.AllowUserToAddRows = false;
            dgvDSDoiTuong.AllowUserToDeleteRows = false;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuanLyDoiTuong_Load(object sender, EventArgs e)
        {
            mDoiTuong = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuong2());
            mDoiTuongSource = new BindingSource(mDoiTuong, null);
            dgvDSDoiTuong.DataSource = mDoiTuongSource;

            dgvDSDoiTuong.Columns["TenDT"].HeaderText = "Tên đối tượng";
            dgvDSDoiTuong.Columns["TenDT"].Width = 230;

            dgvDSDoiTuong.Columns["TiLeGiamHocPhi"].HeaderText = "Tỉ lệ giảm học phí";
            dgvDSDoiTuong.Columns["TiLeGiamHocPhi"].Width = 159;

            dgvDSDoiTuong.Columns["MaDT"].Visible = false;
        }

        private void dgvDSDoiTuong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSDoiTuong.CurrentRow != null)
            {
                dgvDSDoiTuong.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                DoiTuong doiTuong = mDoiTuong[dgvDSDoiTuong.CurrentRow.Index];
                if (doiTuong != null)
                {
                    txtTenDoiTuong.Text = doiTuong.TenDT;
                    txtTiLeGiamHocPhi.Text = doiTuong.TiLeGiamHocPhi.ToString();
                }
            }
        }

        private void QuanLyDoiTuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caiDatRequester != null)
            {
                caiDatRequester.OnCaiDatClosing();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaDoiTuong themSuaDoiTuong = new ThemSuaDoiTuong(this);
            themSuaDoiTuong.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DoiTuong doiTuong = mDoiTuong[dgvDSDoiTuong.CurrentRow.Index];
            ThemSuaDoiTuong themSuaDoiTuong = new ThemSuaDoiTuong(this, doiTuong);
            themSuaDoiTuong.Show();
        }

        public void OnThemSuaDoiTuongClosing()
        {
            mDoiTuong = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuong2());
            mDoiTuongSource.DataSource = mDoiTuong;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa đối tượng ưu tiên đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DoiTuong doiTuong = mDoiTuong[dgvDSDoiTuong.CurrentRow.Index];
                int maDT = mDoiTuong[dgvDSDoiTuong.CurrentRow.Index].MaDT;

                XoaDoiTuongMessage message = _doiTuongBLLService.XoaDoiTuong(maDT);
                switch (message)
                {
                    case XoaDoiTuongMessage.UnableToDeleteVungSauVungXa:
                        MessageBox.Show("Bạn không thể xóa đối tượng vùng sâu vùng xa!");
                        break;
                    case XoaDoiTuongMessage.Unable:
                        MessageBox.Show("Bạn không thể xóa đối tượng này vì đang có sinh viên thuộc đối tượng!");
                        break;
                    case XoaDoiTuongMessage.Success:
                        mDoiTuong.Remove(doiTuong);
                        MessageBox.Show("Xóa đối tượng thành công!");
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
