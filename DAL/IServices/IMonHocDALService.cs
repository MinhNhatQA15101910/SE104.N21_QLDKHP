using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IMonHocDALService
    {
        List<CT_MonHoc> LayDSMonHoc();
        XoaMonHocMessage XoaMonHoc(string maMH);
        SuaMonHocMessage SuaMonHoc(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet);
        ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, int soTiet);
        List<MonHoc> LayDSMonHoc2();
        List<MonHoc> GetTermMonHoc(int HocKy);
        List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc);
        List<MonHoc> GetChuongTrinhHoc(string MaNganh, int HocKy);
        List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP);
    }
}
