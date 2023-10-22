using BLL;
using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace PL
{
    public partial class DoiMatKhau : KryptonForm
    {
		private readonly INguoiDungBLLService _nguoiDungBLLService = new NguoiDungBLLService(new NguoiDungDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));

		public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = GlobalConfig.CurrNguoiDung.TenDangNhap;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhauHT = txtMatKhauHT.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string matKhauNhapLai = txtMatKhauNhapLai.Text.Trim();

            errProv1.Clear();
            DoiMatKhauMessage message = _nguoiDungBLLService.DoiMatKhau(matKhauHT, matKhauMoi, matKhauNhapLai);
            switch (message)
            {
                case DoiMatKhauMessage.EmptyMatKhauHT:
                    errProv1.SetError(txtMatKhauHT, "Dữ liệu không được rỗng!");
                    txtMatKhauHT.Focus();
                    break;
                case DoiMatKhauMessage.EmptyMatKhauMoi:
                    errProv1.SetError(txtMatKhauMoi, "Dữ liệu không được rỗng!");
                    txtMatKhauMoi.Focus();
                    break;
                case DoiMatKhauMessage.EmptyMatKhauNhapLai:
                    errProv1.SetError(txtMatKhauNhapLai, "Dữ liệu không được rỗng!");
                    txtMatKhauNhapLai.Focus();
                    break;
                case DoiMatKhauMessage.InvalidNewPassword:
                    errProv1.SetError(txtMatKhauNhapLai, "Mật khẩu mới không khớp!");
                    txtMatKhauNhapLai.Focus();
                    break;
                case DoiMatKhauMessage.Failed:
                    errProv1.SetError(txtMatKhauHT, "Mật khẩu hiện tại không chính xác");
                    txtMatKhauHT.Focus();
                    break;
                case DoiMatKhauMessage.Error:
                    MessageBox.Show("Đã có lỗi xảy ra!");
                    break;
                case DoiMatKhauMessage.Success:
                    MessageBox.Show("Đổi mật khẩu thành công");

                    txtMatKhauHT.Clear();
                    txtMatKhauMoi.Clear();
                    txtMatKhauNhapLai.Clear();

                    Close();

                    break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
