using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IKhoaBLLService
    {
        List<Khoa> LayDSKhoa();
        SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua);
        ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa);
        XoaKhoaMessage XoaKhoa(string maKhoa);
    }
}
