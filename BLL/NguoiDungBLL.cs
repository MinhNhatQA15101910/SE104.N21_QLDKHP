using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguoiDungBLL
    {
        public static DangNhapMessage DangNhap(string tenDangNhap, string matKhau)
        {
            if (tenDangNhap.Equals(""))
            {
                return DangNhapMessage.EmptyTenDangNhap;
            }

            if (matKhau.Equals(""))
            {
                return DangNhapMessage.EmptyMatKhau;
            }

            return NguoiDungDAL.DangNhap(tenDangNhap, matKhau);
        }

        public static List<CT_NguoiDung> LayDSNguoiDung()
        {
            return NguoiDungDAL.LayDSNguoiDung();
        }
    }
}
