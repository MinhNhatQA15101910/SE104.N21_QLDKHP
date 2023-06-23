using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NganhBLL
    {
        public static List<CT_Nganh> LayDSNganh()
        {
            return NganhDAL.LayDSNganh();
        }

        public static XoaNganhMessage XoaNganh(string maNganh)
        {
            return NganhDAL.XoaNganh(maNganh);
        }

        public static SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            if (maNganhSua.Equals(""))
            {
                return SuaNganhMessage.EmptyMaNganh;
            }

            if (tenNganhSua.Equals(""))
            {
                return SuaNganhMessage.EmptyTenNganh;
            }

            return NganhDAL.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);
        }

        public static ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            if (maNganh.Equals(""))
            {
                return ThemNganhMessage.EmptyMaNganh;
            }

            if (tenNganh.Equals(""))
            {
                return ThemNganhMessage.EmptyTenNganh;
            }

            return NganhDAL.ThemNganh(maNganh, tenNganh, maKhoa);
        }
    }
}
