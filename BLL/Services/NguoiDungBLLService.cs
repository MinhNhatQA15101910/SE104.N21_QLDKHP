using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class NguoiDungBLLService : INguoiDungBLLService
	{
		private readonly INguoiDungDALService _nguoiDungDALService;

		public NguoiDungBLLService(INguoiDungDALService nguoiDungDALService)
		{
			_nguoiDungDALService = nguoiDungDALService;
		}

		public List<CT_NguoiDung> LayDSNguoiDung()
		{
			return _nguoiDungDALService.LayDSNguoiDung();
		}

		public DangNhapMessage DangNhap(string tenDangNhap, string matKhau)
		{
			if (string.IsNullOrEmpty(tenDangNhap))
			{
				return DangNhapMessage.EmptyTenDangNhap;
			}

			if (string.IsNullOrEmpty(matKhau))
			{
				return DangNhapMessage.EmptyMatKhau;
			}

			return _nguoiDungDALService.DangNhap(tenDangNhap, matKhau);
		}

		public XoaTaiKhoanMessage XoaTaiKhoan(string tenDangNhap)
		{
			if (tenDangNhap == GlobalConfig.CurrNguoiDung.TenDangNhap)
			{
				return XoaTaiKhoanMessage.Unable;
			}

			return _nguoiDungDALService.XoaTaiKhoan(tenDangNhap);
		}

		public DoiMatKhauMessage DoiMatKhau(string tenDangNhap, string matKhauHT, string matKhauMoi, string matKhauNhapLai)
		{
			if (string.IsNullOrEmpty(matKhauHT))
			{
				return DoiMatKhauMessage.EmptyMatKhauHT;
			}

			if (string.IsNullOrEmpty(matKhauMoi))
			{
				return DoiMatKhauMessage.EmptyMatKhauMoi;
			}

			if (string.IsNullOrEmpty(matKhauNhapLai))
			{
				return DoiMatKhauMessage.EmptyMatKhauNhapLai;
			}

			if (!matKhauMoi.Equals(matKhauNhapLai))
			{
				return DoiMatKhauMessage.InvalidNewPassword;
			}

			return _nguoiDungDALService.DoiMatKhau(tenDangNhap, matKhauHT, matKhauMoi);
		}

		public ThemTaiKhoanMessage ThemTaiKhoan(string tenDangNhap, string maNhom)
		{
			if (string.IsNullOrEmpty(tenDangNhap))
			{
				return ThemTaiKhoanMessage.EmptyTenDangNhap;
			}

            List<CT_NguoiDung> nguoiDungList = _nguoiDungDALService.LayDSNguoiDung();
            CT_NguoiDung nguoiDung = nguoiDungList.Find(nd => nd.TenDangNhap == tenDangNhap);
            if (nguoiDung != null)
            {
                return ThemTaiKhoanMessage.DuplicateTenDangNhap;
            }

            return _nguoiDungDALService.ThemTaiKhoan(tenDangNhap,maNhom);
		}

		public SuaTaiKhoanMessage SuaTaiKhoan(string tenDangNhapBD, string tenDangNhap, string maNhom)
		{
			if (string.IsNullOrEmpty(tenDangNhap))
			{
				return SuaTaiKhoanMessage.EmptyTenDangNhap;
			}

			List<CT_NguoiDung> nguoiDungList = _nguoiDungDALService.LayDSNguoiDung();
			CT_NguoiDung nguoiDung = nguoiDungList.Find(nd => nd.TenDangNhap == tenDangNhap && nd.TenDangNhap != tenDangNhapBD);
            if (nguoiDung != null)
            {
				return SuaTaiKhoanMessage.DuplicateTenDangNhap;
            }

            return _nguoiDungDALService.SuaTaiKhoan(tenDangNhapBD, tenDangNhap, maNhom);
		}
		public ThemTaiKhoanSVMessage ThemTaiKhoanSV(IList<SinhVien> dssv)
		{
			if (dssv == null || dssv.Count <= 0)
			{
				return ThemTaiKhoanSVMessage.Unable;
			}

			return _nguoiDungDALService.ThemTaiKhoanSV(dssv);
		}
	}
}
