using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
