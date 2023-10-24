using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IDoiTuongDALService
    {
        List<DoiTuong> LayDSDoiTuong();
        SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, float tiLeGiam);
        ThemDoiTuongMessage ThemDoiTuong(string tenDT, float tiLeGiam);
        List<DoiTuong> LayDSDoiTuong2();
        List<DoiTuong> LayDSDoiTuongKhongThuocVeMaSV(string maSV);
        List<DoiTuong> LayDSDoiTuongBangMaSV(string maSV);
        XoaDoiTuongMessage XoaDoiTuong(int maDT);
    }
}
