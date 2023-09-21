using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class NhomNguoiDungBLL
    {
        public static List<NhomNguoiDung> LayDSNhomNguoiDung()
        {
            return NhomNguoiDungDAL.LayDSNhomNguoiDung();
        }
    }
}
