using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoiTuongBLL
    {
        public static List<DoiTuong> LayDSDoiTuong()
        {
            return DoiTuongDAL.LayDSDoiTuong();
        }

        public static SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            if (tenDT.Equals(""))
            {
                return SuaDoiTuongMessage.EmptyTenDoiTuong;
            }

            if (tiLeGiam.Equals(""))
            {
                return SuaDoiTuongMessage.EmptyTiLeGiam;
            }

            float tiLeGiamValue;
            if (!float.TryParse(tiLeGiam, out tiLeGiamValue))
            {
                return SuaDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            if (tiLeGiamValue > 1 || tiLeGiamValue <= 0)
            {
                return SuaDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            return DoiTuongDAL.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiamValue);
        }
    }
}
