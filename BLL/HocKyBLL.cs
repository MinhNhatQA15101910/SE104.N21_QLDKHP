using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class HocKyBLL
    {
        public static List<HocKy> LayDanhSachHK()
        {
            return HocKyDAL.LayDanhSachHK();
        }

        public static string LayHKByMaHK(int currMaHocKy)
        {
            return HocKyDAL.LayHKByMaHK(currMaHocKy);
        }
    }
}
