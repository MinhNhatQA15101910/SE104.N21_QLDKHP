using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IMonHocBLLService
    {
        List<CT_MonHoc> LayDSMonHoc();
        XoaMonHocMessage XoaMonHoc(string maMH);
        SuaMonHocMessage SuaMonHoc(string maMHBanDau, string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon);
        ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon);
        List<MonHoc> GetTermMonHoc(int HocKy);
        List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc);
        List<MonHoc> GetChuongTrinhHoc(string Nganh, int HocKy);
        List<MonHoc> LayDSMonHoc2();
        List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP);
    }
}
