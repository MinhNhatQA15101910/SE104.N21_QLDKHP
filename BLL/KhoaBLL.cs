using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
