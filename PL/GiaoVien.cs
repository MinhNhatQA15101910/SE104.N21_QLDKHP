using ComponentFactory.Krypton.Toolkit;
using Microsoft.Extensions.DependencyInjection;
using PL.Interfaces;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class GiaoVien :
        KryptonForm,
        ICaiDatRequester,
        IMonHocMoRequester,
        IXacNhanDKHPRequester,
        INganhRequester,
        IKhoaRequester,
        IChuongTrinhHocRequester,
        IMonHocRequester,
        IDanhSachSinhVienRequester,
        IXacNhanHocPhiRequester,
        IBaoCaoRequester,
        IThanhToanHocPhiRequester
    {
        private readonly IGVRequester gvRequester;

        public GiaoVien (IGVRequester requester)
        {
            InitializeComponent();

            gvRequester = requester;
        }

        public void OnBaoCaoClosing()
        {
            Show();
        }

        public void OnCaiDatClosing()
        {
            Show();
        }

        public void OnChuongTrinhHocClosing()
        {
            Show();
        }

        public void OnDSSVClosing()
        {
            Show();
        }

        public void OnKhoaClosing()
        {
            Show();
        }

        public void OnMonHocClosing()
        {
            Show();
        }

        public void OnMonHocMoClosing()
        {
            Show();
        }

        public void OnNganhClosing()
        {
            Show();
        }

        public void OnThanhToanHocPhiClosing()
        {
            Show();
        }

        public void OnXacNhanDKHPClosing()
        {
            Show();
        }

        public void OnXacNhanHocPhiClosing()
        {
            Show();
        }

        private void GV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                if (gvRequester != null)
                {
                    gvRequester.OnGVClosing();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void picCaiDat_Click(object sender, EventArgs e)
        {
            QuanLyLoaiMonHoc quanLyLoaiMonHoc = Program.ServiceProvider.GetRequiredService<QuanLyLoaiMonHoc>();
            quanLyLoaiMonHoc.Show();
            Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = Program.ServiceProvider.GetRequiredService<DoiMatKhau>();
            doiMatKhau.Show();
        }

        private void imgDangXuat_Click(object sender, EventArgs e)
        {
            pnlDangXuat.Visible = !pnlDangXuat.Visible;
        }

        private void btnNganh_Click(object sender, EventArgs e)
        {
            QuanLyNganh quanLyNganh = Program.ServiceProvider.GetRequiredService<QuanLyNganh>();
            quanLyNganh.Show();
            Hide();
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            QuanLyKhoa quanLyKhoa = Program.ServiceProvider.GetRequiredService<QuanLyKhoa>();
            quanLyKhoa.Show();
            Hide();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc quanLyMonHoc = Program.ServiceProvider.GetRequiredService<QuanLyMonHoc>();
            quanLyMonHoc.Show();
            Hide();
        }

        private void btnDSSV_Click(object sender, EventArgs e)
        {
            QuanLySinhVien quanLySinhVien = Program.ServiceProvider.GetRequiredService<QuanLySinhVien>();
            quanLySinhVien.Show();
            Hide();
        }

        private void picBaoCao_Click(object sender, EventArgs e)
        {
            BaoCao baoCao = Program.ServiceProvider.GetRequiredService<BaoCao>();
            baoCao.Show();
            Hide();
        }

        private void btnQuanLyMonHocMo_Click(object sender, EventArgs e)
        {
            QuanLyMonHocMo quanLyMonHocMo = Program.ServiceProvider.GetRequiredService<QuanLyMonHocMo>();
            quanLyMonHocMo.Show();
            Hide();
        }

        private void btnChuongTrinhHoc_Click(object sender, EventArgs e)
        {
            QuanLyChuongTrinhHoc quanLyChuongTrinhHoc = Program.ServiceProvider.GetRequiredService<QuanLyChuongTrinhHoc>();
            quanLyChuongTrinhHoc.Show();
            Hide();
        }

        private void btnXacNhanDKHP_Click(object sender, EventArgs e)
        {
            XacNhanDKHP xacNhanDKHP = Program.ServiceProvider.GetRequiredService<XacNhanDKHP>();
            xacNhanDKHP.Show();
            Hide();
        }

        private void btnXacNhanThanhToanHP_Click(object sender, EventArgs e)
        {
            XacNhanHocPhi xacNhanHocPhi = Program.ServiceProvider.GetRequiredService<XacNhanHocPhi>();
            xacNhanHocPhi.Show();
            Hide();
        }
    }
}
