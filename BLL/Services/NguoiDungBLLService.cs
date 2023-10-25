﻿using BLL.IServices;
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
			return _nguoiDungDALService.XoaTaiKhoan(tenDangNhap);
		}
		public DoiMatKhauMessage DoiMatKhau(string matKhauHT, string matKhauMoi, string matKhauNhapLai)
		{
			if(string.IsNullOrEmpty(matKhauHT))
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

			return _nguoiDungDALService.DoiMatKhau(matKhauHT,matKhauMoi);
		}
		public ThemTaiKhoanMessage ThemTaiKhoan(string tenDangNhap, string maNhom)
		{
			if(string.IsNullOrEmpty(tenDangNhap))
			{
				return ThemTaiKhoanMessage.EmptyTenDangNhap;
			}
			return _nguoiDungDALService.ThemTaiKhoan(tenDangNhap,maNhom);
		}
		public SuaTaiKhoanMessage SuaTaiKhoan(string tenDangNhapBD, string tenDangNhap, string maNhom)
		{
			if (string.IsNullOrEmpty(tenDangNhap))
			{
				return SuaTaiKhoanMessage.EmptyTenDangNhap;
			}
			return _nguoiDungDALService.SuaTaiKhoan(tenDangNhapBD, tenDangNhap, maNhom);
		}
		public ThemTaiKhoanSVMessage ThemTaiKhoanSV(IList<SinhVien> dssv)
		{
			return _nguoiDungDALService.ThemTaiKhoanSV(dssv);
		}
	}
}
