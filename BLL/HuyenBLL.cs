using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class HuyenBLL
    {
        public static List<CT_Huyen> LayDSHuyen()
        {
            return HuyenDAL.LayDSHuyen();
        }

        public static SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            if (tenHuyen.Equals(""))
            {
                return SuaHuyenMessage.EmptyTenHuyen;
            }

            return HuyenDAL.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);
        }

        public static ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh)
        {
            if (tenHuyen.Equals(""))
            {
                return ThemHuyenMessage.EmptyTenHuyen;
            }

            return HuyenDAL.ThemHuyen(tenHuyen, vungUT, maTinh);
        }

        public static XoaHuyenMessage XoaHuyen(int maHuyen)
        {
            return HuyenDAL.XoaHuyen(maHuyen);
        }
    }
}
