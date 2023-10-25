using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface ILoaiMonHocDALService
    {
        List<LoaiMonHoc> LayDSLoaiMonHoc();
        XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc);
        SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien);
        ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, int soTiet, decimal soTien);
    }
}
