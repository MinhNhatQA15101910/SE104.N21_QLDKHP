using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class KhoaBLL
    {
        public static List<Khoa> LayDSKhoa()
        {
            return KhoaDAL.LayDSKhoa();
        }

        public static SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            if (maKhoaSua.Equals(""))
            {
                return SuaKhoaMessage.EmptyMaKhoa;
            }

            if (tenKhoaSua.Equals(""))
            {
                return SuaKhoaMessage.EmptyTenKhoa;
            }

            return KhoaDAL.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);
        }

        public static ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            if (maKhoa.Equals(""))
            {
                return ThemKhoaMessage.EmptyMaKhoa;
            }

            if (tenKhoa.Equals(""))
            {
                return ThemKhoaMessage.EmptyTenKhoa;
            }

            return KhoaDAL.ThemKhoa(maKhoa, tenKhoa);
        }

        public static XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            return KhoaDAL.XoaKhoa(maKhoa);
        }
    }
}
