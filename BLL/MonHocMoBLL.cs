using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class MonHocMoBLL
    {
        public static List<HocKyNamHoc> GetAllHocKyNamHoc()
        {
            return MonHocMoDAL.GetAllHocKyNamHoc();
        }

        public static MessageAddMonHocMo AddMonHocMo(string MaMH, int MaHocKy, int NamHoc)
        {
            return MonHocMoDAL.AddMonHocMo(MaMH, MaHocKy, NamHoc);
        }

        public static List<int> GetAllNamHoc()
        {
            return MonHocMoDAL.GetAllNamHoc();
        }

        public static MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int MaHocKy, int NamHoc)
        {
            return MonHocMoDAL.DeleteHocKyNamHocMHM(MaHocKy, NamHoc);
        }
    }
}
