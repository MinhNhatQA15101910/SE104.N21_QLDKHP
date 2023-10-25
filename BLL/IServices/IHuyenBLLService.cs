using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IHuyenBLLService
    {
        List<CT_Huyen> LayDSHuyen();
        SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh);
        ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh);
        XoaHuyenMessage XoaHuyen(int maHuyen);
    }
}
