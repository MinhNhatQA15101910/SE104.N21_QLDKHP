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

            if (maDTBanDau == 2 && tenDT != "Vùng sâu vùng xa")
            {
                return SuaDoiTuongMessage.Unable;
            }

            return DoiTuongDAL.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiamValue);
        }

        public static ThemDoiTuongMessage ThemDoiTuong(string tenDT, string tiLeGiam)
        {
            if (tenDT.Equals(""))
            {
                return ThemDoiTuongMessage.EmptyTenDoiTuong;
            }

            if (tiLeGiam.Equals(""))
            {
                return ThemDoiTuongMessage.EmptyTiLeGiam;
            }

            float tiLeGiamValue;
            if (!float.TryParse(tiLeGiam, out tiLeGiamValue))
            {
                return ThemDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            if (tiLeGiamValue > 1 || tiLeGiamValue <= 0)
            {
                return ThemDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            return DoiTuongDAL.ThemDoiTuong(tenDT, tiLeGiamValue);
        }

        public static XoaDoiTuongMessage XoaDoiTuong(int maDT)
        {
            if (maDT == 2)
            {
                return XoaDoiTuongMessage.Unable;
            }

            return DoiTuongDAL.XoaDoiTuong(maDT);
        }
    }
}
