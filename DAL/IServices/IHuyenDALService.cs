using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IHuyenDALService
    {
        List<CT_Huyen> LayDSHuyen();
        SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh);
        XoaHuyenMessage XoaHuyen(int maHuyen);
        ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh);
    }
}
