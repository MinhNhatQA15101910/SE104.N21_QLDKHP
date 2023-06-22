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

        public static ThemTaiKhoanSVMessage ThemTaiKhoanSV(IList<SinhVien> dssv)
        {
            if (dssv.Count == 0)
            {
                return ThemTaiKhoanSVMessage.Unable;
            }

            return NguoiDungDAL.ThemTaiKhoanSV(dssv);
        }

        public static XoaTaiKhoanMessage XoaTaiKhoan(string tenDangNhap)
        {
            if (tenDangNhap == GlobalConfig.CurrNguoiDung.TenDangNhap)
            {
                return XoaTaiKhoanMessage.Unable;
            }

            return NguoiDungDAL.XoaTaiKhoan(tenDangNhap);
        }

        public static DoiMatKhauMessage DoiMatKhau(string matKhauHT, string matKhauMoi, string matKhauNhapLai)
        {
            if (matKhauHT == "")
            {
                return DoiMatKhauMessage.EmptyMatKhauHT;
            }

            if (matKhauMoi == "")
            {
                return DoiMatKhauMessage.EmptyMatKhauMoi;
            }

            if (matKhauNhapLai == "")
            {
                return DoiMatKhauMessage.EmptyMatKhauNhapLai;
            }

            if (matKhauNhapLai != matKhauMoi)
            {
                return DoiMatKhauMessage.InvalidNewPassword;
            }

            return NguoiDungDAL.DoiMatKhau(matKhauHT, matKhauMoi);
        }
    }
}
