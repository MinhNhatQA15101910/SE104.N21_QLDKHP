using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface ILoaiMonHocBLLService
    {
        List<LoaiMonHoc> LayDSLoaiMonHoc();
        XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc);
        SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien);
        ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, string soTiet, string soTien);
    }
}
