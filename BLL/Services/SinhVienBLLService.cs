using System;
using BLL.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using DAL.IServices;

namespace BLL.Services
{
	public class SinhVienBLLService : ISinhVienBLLService
	{
		private readonly ISinhVienDALService _sinhVienDALService;
		public SinhVienBLLService(ISinhVienDALService sinhVienDALService)
		{
			_sinhVienDALService = sinhVienDALService;
		}
		public List<SinhVien> LayDSSVChuaCoTK()
		{
			return _sinhVienDALService.LayDSSVChuaCoTK();
		}

		public List<CT_SinhVien> LayDSSV()
		{
			return _sinhVienDALService.LayDSSV();
		}

		public SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
			if (mssv.Equals(""))
			{
				return SuaSinhVienMessage.EmptyMaSV;
			}

			if (hoTen.Equals(""))
			{
				return SuaSinhVienMessage.EmptyTenSV;
			}

			return _sinhVienDALService.SuaSinhVien(mssvBanDau, mssv, hoTen, ngaySinh, gioiTinh, maHuyen, maNganh, maDTList);
		}

		public ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
			if (mssv.Equals(""))
			{
				return ThemSinhVienMessage.EmptyMaSV;
			}

			if (hoTen.Equals(""))
			{
				return ThemSinhVienMessage.EmptyTenSV;
			}

			return _sinhVienDALService.ThemSinhVien(mssv, hoTen, ngaySinh, gioiTinh, maHuyen, maNganh, maDTList);
		}

		public XoaSinhVienMessage XoaSinhVien(string maSV)
		{
			return _sinhVienDALService.XoaSinhVien(maSV);
		}

		public string LayTenSV(string mssv)
		{
			return _sinhVienDALService.LayTenSV(mssv);
		}

		public List<dynamic> LayThongTinSV(string mssv)
		{
			return _sinhVienDALService.LayThongTinSV(mssv);
		}

		public List<dynamic> BaoCaoSinhVienChuaDongHocPhi(int hocKy, int namHoc)
		{
			return _sinhVienDALService.BaoCaoSinhVienChuaDongHocPhi(hocKy, namHoc);
		}
	}
}
