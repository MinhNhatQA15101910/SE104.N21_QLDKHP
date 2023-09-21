using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


namespace PL
{
    public partial class ThongTinHocPhi : KryptonForm
    {
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
            List<HocKy> ds = HocKyBLL.LayDanhSachHK();
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
                TimKiemTTHocPhiMessage message = PhieuThuHPBLL.KtTimKiemTTHocPhi(namHocS);
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
                        List<PhieuDKHP> ds = PhieuDKHPBLL.LayTTPhieuDKHP(GlobalConfig.CurrNguoiDung.TenDangNhap, hocKy, namHoc);
                        if (ds.Count > 0 && ds[0] != null)
                        {
                            PhieuDKHP kq = ds[0];
                            int maPhieuDKHP = int.Parse(kq.MaPhieuDKHP.ToString().Trim());
                            if (kq != null)
                            {
                                int hocPhi = PhieuDKHPBLL.TinhHocPhi(maPhieuDKHP);
                                float hocPhiPhaiDong = PhieuDKHPBLL.TinhHocPhiPhaiDong(maPhieuDKHP);
                                txtSoPhieuDKHP.Text = maPhieuDKHP.ToString();
                                txtTGDongGanNhat.Text = PhieuThuHPBLL.LayThoiGianDongHPGanNhat(maPhieuDKHP).ToString("dd/MM/yyyy"); // lấy tgian đóng gần nhất 


                                txtHocPhi.Text = hocPhi.ToString("c", cultureInfo);
                                txtHocPhiPhaiDong.Text = hocPhiPhaiDong.ToString("c", cultureInfo);
                                txtHocPhiDaDong.Text = PhieuDKHPBLL.TinhHocPhiDaDong(maPhieuDKHP).ToString("c", cultureInfo);
                                txtConNo.Text = PhieuDKHPBLL.TinhHocPhiConThieu(maPhieuDKHP).ToString("c", cultureInfo);
                                HienThiTinhTrang(kq.MaTinhTrang);
                                List<DoiTuong> dt = DoiTuongBLL.LayDSDoiTuongBangMaSV(GlobalConfig.CurrNguoiDung.TenDangNhap);
                                DoiTuong dt1 = dt[0];
                                lblTyLeGiam.Text = "(Học phí được giảm " + (hocPhi - hocPhiPhaiDong).ToString("c", cultureInfo) + " - theo đối tượng " + dt1.TenDT + " )";


                            }

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
