using BLL.IServices;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using Microsoft.Extensions.DependencyInjection;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class QuanLyDoiTuong : KryptonForm, IThemSuaDoiTuongRequester
    {
        private readonly IDoiTuongBLLService _doiTuongBLLService;

        private ICaiDatRequester caiDatRequester;
        private BindingList<DoiTuong> mDoiTuong;
        private BindingSource mDoiTuongSource;

        public QuanLyDoiTuong(ICaiDatRequester requester, IDoiTuongBLLService doiTuongBLLService)
        {
            InitializeComponent();

            caiDatRequester = requester;
            _doiTuongBLLService = doiTuongBLLService;

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
            ThemSuaDoiTuong themSuaDoiTuong = new ThemSuaDoiTuong(this, _doiTuongBLLService);
            themSuaDoiTuong.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DoiTuong doiTuong = mDoiTuong[dgvDSDoiTuong.CurrentRow.Index];
            ThemSuaDoiTuong themSuaDoiTuong = new ThemSuaDoiTuong(this, _doiTuongBLLService, doiTuong);
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
                    case XoaDoiTuongMessage.Failed:
                        MessageBox.Show("Xóa đối tượng thất bại!");
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
            QuanLyLoaiMonHoc quanLyLoaiMonHoc = Program.ServiceProvider.GetRequiredService<QuanLyLoaiMonHoc>();
            quanLyLoaiMonHoc.Show();
            Hide();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            QuanLyTinh quanLyTinh = Program.ServiceProvider.GetRequiredService<QuanLyTinh>();
            quanLyTinh.Show();
            Hide();
        }

        private void btnHuyen_Click(object sender, EventArgs e)
        {
            QuanLyHuyen quanLyHuyen = Program.ServiceProvider.GetRequiredService<QuanLyHuyen>();
            quanLyHuyen.Show();
            Hide();
        }
    }
}
