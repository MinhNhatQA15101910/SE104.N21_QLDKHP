using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class DanhSachMonHocMoBLL
    {
        public static List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc)
        {
            return DanhSachMonHocMoDAL.LayDanhSachMonHocMo(hocKy, namHoc);
        }

        public static List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc)
        {
            return DanhSachMonHocMoDAL.TimKiemDanhSachMonHocMo(hocKy, namHoc, monHoc);
        }
    }
}
