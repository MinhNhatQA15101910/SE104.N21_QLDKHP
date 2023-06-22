using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
