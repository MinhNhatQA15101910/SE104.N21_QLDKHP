using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IDoiTuongBLLService
    {
        List<DoiTuong> LayDSDoiTuong();
        SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, string tiLeGiam);
        ThemDoiTuongMessage ThemDoiTuong(string tenDT, string tiLeGiam);
        XoaDoiTuongMessage XoaDoiTuong(int maDT);
        List<DoiTuong> LayDSDoiTuongBangMaSV(string maSV);
        List<DoiTuong> LayDSDoiTuongKhongThuocVeMaSV(string maSV);
        List<DoiTuong> LayDSDoiTuong2();
    }
}
