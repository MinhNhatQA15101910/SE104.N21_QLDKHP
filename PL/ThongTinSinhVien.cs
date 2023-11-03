using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace PL
{
    public partial class ThongTinSinhVien : KryptonForm
    {
        private readonly IDoiTuongBLLService _doiTuongBLLService = new DoiTuongBLLService(new DoiTuongDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
        private readonly ISinhVienBLLService _sinhVienBLLService = new SinhVienBLLService(new SinhVienDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));

        private readonly IThongTinSinhVienRequester thongTinSinhVienRequester;

        public ThongTinSinhVien(IThongTinSinhVienRequester requester)
        {
            InitializeComponent();

            thongTinSinhVienRequester = requester;
        }

        private void ThongTinSinhVien_Load(object sender, EventArgs e)
        {
            LoadTTSV();
        }

        private void LoadTTSV()
        {
            List<dynamic> stu = _sinhVienBLLService.LayThongTinSV(GlobalConfig.CurrNguoiDung.TenDangNhap);
            if (stu.Count > 0)
            {
                dynamic tt = stu[0];
                if (tt != null)
                {
                    txtMssv.Text = GlobalConfig.CurrNguoiDung.TenDangNhap;
                    txtHoTen.Text = tt.HoTen;
                    txtNgaySinh.Text = tt.NgaySinh.ToString("dd/MM/yyyy");
                    txtQueQuan.Text = tt.TenHuyen + "-" + tt.TenTTP;
                    txtNganh.Text = tt.TenNganh;
                    txtKhoa.Text = tt.TenKhoa;

                    if (tt.GioiTinh == "Nam")
                    {
                        rbtnNam.Checked = true;
                        rbtnNu.Checked = false;
                    }
                    else
                    {
                        rbtnNu.Checked = true;
                        rbtnNam.Checked = false;
                    }

                    List<DoiTuong> dt = _doiTuongBLLService.LayDSDoiTuongBangMaSV(GlobalConfig.CurrNguoiDung.TenDangNhap);
                    foreach (var i in dt)
                    {
                        listDoiTuong.Items.Add(i.TenDT);
                    }
                }
            }
        }

        private void ThongTinSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thongTinSinhVienRequester != null)
            {
                thongTinSinhVienRequester.OnThongTinSinhVienClosing();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThongTinDKHP_Click(object sender, EventArgs e)
        {
            ThongTinDKHP ttdk = new ThongTinDKHP();
            ttdk.Show();
        }

        private void btnThongTinHocPhi_Click(object sender, EventArgs e)
        {
            ThongTinHocPhi t = new ThongTinHocPhi();
            t.Show();
        }
    }
}
