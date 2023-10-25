using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace PL
{
    public partial class CT_ThanhToanHocPhi : KryptonForm
    {
        private readonly IPhieuThuHPBLLService _phieuThuHPBLLService = new PhieuThuHPBLLService(new PhieuThuHPDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));

        private int maPhieuDKHP;

        public CT_ThanhToanHocPhi(int maPhieuDKHP)
        {
            InitializeComponent();

            this.maPhieuDKHP = maPhieuDKHP;

        }
        public CT_ThanhToanHocPhi()
        {
            InitializeComponent();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            TimKiemPhieuDKHPMessage message = _phieuThuHPBLLService.KtTimKiemSoTienThu(txtTienThu.Text.Trim());
            if (message == TimKiemPhieuDKHPMessage.EmptyNamHoc)
            {
                MessageBox.Show("Vui lòng nhập số tiền");

            }
            else if (message == TimKiemPhieuDKHPMessage.InvalidNamHoc)
            {
                MessageBox.Show("Số tiền không hợp lệ");
            }
            else
            {
                int soTienThu = int.Parse(txtTienThu.Text.Trim());
                DialogResult result =
                MessageBox.Show("Bạn có chắc muốn thanh toán cho mã học phần " + maPhieuDKHP + " ?\nSố tiền: " + soTienThu.ToString("c", cultureInfo), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (_phieuThuHPBLLService.TaoPhieuThu_ChoXacNhan(soTienThu, maPhieuDKHP))
                    {
                        MessageBox.Show("Thanh toán thành công và chờ xác nhận");
                        Close();
                    }
                    else
                        MessageBox.Show("Thanh toán không thành công và chờ xác nhận");
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
