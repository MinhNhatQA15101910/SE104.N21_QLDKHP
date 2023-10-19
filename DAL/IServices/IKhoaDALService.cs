using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IKhoaDALService
    {
        List<Khoa> LayDSKhoa();
        SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua);
        ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa);
        XoaKhoaMessage XoaKhoa(string maKhoa);
    }
}
