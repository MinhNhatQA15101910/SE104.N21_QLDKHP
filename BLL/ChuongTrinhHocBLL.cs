using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChuongTrinhHocBLL
    {
        public static MessageDeleteListCTHoc DeleteListCTHoc(string MaNganh, int HocKy)
        {
            return ChuongTrinhHocDAL.DeleteListCTHoc(MaNganh, HocKy);
        }

        public static List<ChuongTrinhHoc> GetAllCTHoc()
        {
            return ChuongTrinhHocDAL.GetAllCTHoc();
        }

        public static MessageAddCTHoc AddCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            return ChuongTrinhHocDAL.AddCTHoc(MaMH, MaNganh, HocKy);
        }

        public static MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            return ChuongTrinhHocDAL.DeleteCTHoc(MaMH, MaNganh, HocKy);
        }
    }
}
