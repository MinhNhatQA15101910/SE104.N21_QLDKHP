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
        List<MonHoc> GetTermMonHoc(int hocKy);
        List<MonHoc> GetTermMonHocMo(int hocKy, int namHoc);
        List<MonHoc> GetChuongTrinhHoc(string maNganh, int hocKy);
        List<MonHoc> GetMonHocPhieuDKHP(int maPhieuDKHP);
    }
}
