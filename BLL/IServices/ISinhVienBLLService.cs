using DTO;
using System;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface ISinhVienBLLService
	{
		List<SinhVien> LayDSSVChuaCoTK();
		List<CT_SinhVien> LayDSSV();
		SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList);
		ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList);
		XoaSinhVienMessage XoaSinhVien(string maSV);
		string LayTenSV(string mssv);
		List<dynamic> LayThongTinSV(string mssv);
		List<dynamic> BaoCaoSinhVienChuaDongHocPhi(int hocKy, int namHoc);
	}
}
