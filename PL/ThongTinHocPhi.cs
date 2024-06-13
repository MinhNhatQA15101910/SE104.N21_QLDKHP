using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;


namespace PL
{
    public partial class ThongTinHocPhi : KryptonForm
    {
        private readonly IDoiTuongBLLService _doiTuongBLLService 
            = new DoiTuongBLLService(
                new DoiTuongDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()), 
                new SinhVien_DoiTuongDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));
        private readonly IHocKyBLLService _hocKyBLLService 
            = new HocKyBLLService(
                new HocKyDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));
        private readonly IPhieuDKHPBLLService _phieuDKHPBLLService 
            = new PhieuDKHPBLLService(
                new PhieuDKHPDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));
        private readonly IPhieuThuHPBLLService _phieuThuHPBLLService 
            = new PhieuThuHPBLLService(
                new PhieuThuHPDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));

        CultureInfo cultureInfo = new CultureInfo("vi-VN");

        public ThongTinHocPhi()
        {
            InitializeComponent();
        }

        private void ThongTinHocPhi_Load(object sender, EventArgs e)
        {
            LoadCmbHK();
        }

        private void LoadCmbHK()
        {
            List<HocKy> ds = _hocKyBLLService.LayDanhSachHK();
            cmbHocKy.DisplayMember = "TenHocKy";
            cmbHocKy.ValueMember = "MaHocKy";
            cmbHocKy.DataSource = ds;
        }

        private void HienThiTinhTrang(int maTinhTrang)
        {
            if (maTinhTrang == 1)
            {
                lblTinhTrang.Text = "- CHỜ XÁC NHẬN -";
            }
            else if (maTinhTrang == 2)
            {
                lblTinhTrang.Text = "- ĐÃ XÁC NHẬN -";
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgTimKiem_Click(object sender, EventArgs e)
        {
            lblTinhTrang.Text = "";
            txtSoPhieuDKHP.Text = "";
            txtHocPhi.Text = "";
            txtHocPhiPhaiDong.Text = "";
            txtHocPhiDaDong.Text = "";
            txtConNo.Text = "";
            txtTGDongGanNhat.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblTyLeGiam.Text = "(Học phí được giảm xxxxđ - theo đối tượng x)";
            if (cmbHocKy.SelectedItem != null)
            {
                string namHocS = txtNamHoc.Text.Trim();
                TimKiemTTHocPhiMessage message = _phieuThuHPBLLService.KtTimKiemTTHocPhi(namHocS);
                switch (message)
                {
                    case TimKiemTTHocPhiMessage.EmptyNamHoc:
                        MessageBox.Show("Vui lòng nhập năm học");
                        break;
                    case TimKiemTTHocPhiMessage.InvalidNamHoc:
                        MessageBox.Show("Năm học không hợp lệ");
                        break;
                    case TimKiemTTHocPhiMessage.Sucess:
                        int namHoc = int.Parse(txtNamHoc.Text.Trim());
                        int hocKy = int.Parse(cmbHocKy.SelectedValue.ToString());
                        List<PhieuDKHP> ds = _phieuDKHPBLLService.LayTTPhieuDKHP(GlobalConfig.CurrNguoiDung.TenDangNhap, hocKy, namHoc);
                        if (ds.Count > 0 && ds[0] != null)
                        {
                            PhieuDKHP kq = ds[0];
                            int maPhieuDKHP = int.Parse(kq.MaPhieuDKHP.ToString().Trim());
                            int hocPhi = _phieuDKHPBLLService.TinhHocPhi(maPhieuDKHP);
                            float hocPhiPhaiDong = _phieuDKHPBLLService.TinhHocPhiPhaiDong(maPhieuDKHP);
                            txtSoPhieuDKHP.Text = maPhieuDKHP.ToString();
                            txtTGDongGanNhat.Text = _phieuThuHPBLLService.LayThoiGianDongHPGanNhat(maPhieuDKHP).ToString("dd/MM/yyyy"); // lấy tgian đóng gần nhất 


                            txtHocPhi.Text = hocPhi.ToString("c", cultureInfo);
                            txtHocPhiPhaiDong.Text = hocPhiPhaiDong.ToString("c", cultureInfo);
                            txtHocPhiDaDong.Text = _phieuDKHPBLLService.TinhHocPhiDaDong(maPhieuDKHP).ToString("c", cultureInfo);
                            txtConNo.Text = _phieuDKHPBLLService.TinhHocPhiConThieu(maPhieuDKHP).ToString("c", cultureInfo);
                            HienThiTinhTrang(kq.MaTinhTrang);
                            List<DoiTuong> dt = _doiTuongBLLService.LayDSDoiTuongBangMaSV(GlobalConfig.CurrNguoiDung.TenDangNhap);
                            DoiTuong dt1 = dt[0];
                            lblTyLeGiam.Text = "(Đối tượng" + dt1.TenDT + " được giảm học phí " + dt1.TiLeGiamHocPhi;
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Không tồn tại thông tin học phí");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chọn học kì");
            }
        }
    }
}
