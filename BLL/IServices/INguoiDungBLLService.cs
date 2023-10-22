using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
	public interface INguoiDungBLLService
	{
		List<CT_NguoiDung> LayDSNguoiDung();
		DangNhapMessage DangNhap(string tenDangNhap, string matKhau);
		XoaTaiKhoanMessage XoaTaiKhoan(string tenDangNhap);
		DoiMatKhauMessage DoiMatKhau(string matKhauHT, string matKhauMoi, string MatKhauNhapLai);
		ThemTaiKhoanMessage ThemTaiKhoan(string tenDangNhap, string maNhom);
		SuaTaiKhoanMessage SuaTaiKhoan(string tenDangNhapBD, string tenDangNhap, string maNhom);
		ThemTaiKhoanSVMessage ThemTaiKhoanSV(IList<SinhVien> dssv);
	}
}
