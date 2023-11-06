using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PL
{
    public partial class SinhVien : KryptonForm, IThongTinSinhVienRequester, IDangKyHocPhanRequester, IThanhToanHocPhiRequester
    {
		private readonly IPhieuDKHPBLLService _phieuDKHPBLLService = new PhieuDKHPBLLService(new PhieuDKHPDALService(new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
		private readonly ISinhVienBLLService _sinhVienBLLService = new SinhVienBLLService(new SinhVienDALService(new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));

		private readonly ISinhVienRequester sinhVienRequester;

        public SinhVien(ISinhVienRequester requester)
        {
            InitializeComponent();

            sinhVienRequester = requester;
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            lblMSSV.Text = GlobalConfig.CurrNguoiDung.TenDangNhap;
            lblHoTen.Text = "Xin chào " + _sinhVienBLLService.LayTenSV(GlobalConfig.CurrNguoiDung.TenDangNhap).Trim() + " !!!";
        }

        private void imgDangXuat_Click(object sender, EventArgs e)
        {
            pnlDangXuat.Visible = !pnlDangXuat.Visible;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.Show();
        }

        private void SinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (sinhVienRequester != null)
                {
                    sinhVienRequester.OnSinhVienClosing();
                }

                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnTTSV_Click(object sender, EventArgs e)
        {
            ThongTinSinhVien t = new ThongTinSinhVien(this);
            t.Show();
            Hide();
        }

        private void btnDKHP_Click(object sender, EventArgs e)
        {
            List<PhieuDKHP> list = _phieuDKHPBLLService.LayTTPhieuDKHP(GlobalConfig.CurrNguoiDung.TenDangNhap, GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc);
            if (list.Count > 0 && list[0].MaTinhTrang != 1)
            {
                MessageBox.Show("Bạn đã đăng kí học phần cho kì học này rồi.");
            }
            else
            {
                DangKyHocPhan dkhp = new DangKyHocPhan(this);
                dkhp.Show();
                Hide();
            }
        }

        private void btnThanhToanHP_Click(object sender, EventArgs e)
        {
            ThanhToanHocPhi t = new ThanhToanHocPhi(this);
            t.Show();
            Hide();
        }

        public void OnThongTinSinhVienClosing()
        {
            Show();
        }

        public void OnDKHPClosing()
        {
            Show();
        }

        public void OnThanhToanHocPhiClosing()
        {
            Show();
        }
    }
}
