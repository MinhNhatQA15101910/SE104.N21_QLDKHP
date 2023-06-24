using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SinhVienBLL
    {
        public static List<SinhVien> LayDSSVChuaCoTK()
        {
            return SinhVienDAL.LayDSSVChuaCoTK();
        }

        public static List<CT_SinhVien> LayDSSV()
        {
            return SinhVienDAL.LayDSSV();
        }

        public static SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
        {
            if (mssv.Equals(""))
            {
                return SuaSinhVienMessage.EmptyMaSV;
            }

            if (hoTen.Equals(""))
            {
                return SuaSinhVienMessage.EmptyTenSV;
            }

            return SinhVienDAL.SuaSinhVien(mssvBanDau, mssv, hoTen, ngaySinh, gioiTinh, maHuyen, maNganh, maDTList);
        }

        public static ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
        {
            if (mssv.Equals(""))
            {
                return ThemSinhVienMessage.EmptyMaSV;
            }

            if (hoTen.Equals(""))
            {
                return ThemSinhVienMessage.EmptyTenSV;
            }

            return SinhVienDAL.ThemSinhVien(mssv, hoTen, ngaySinh, gioiTinh, maHuyen, maNganh, maDTList);
        }

        public static XoaSinhVienMessage XoaSinhVien(string maSV)
        {
            return SinhVienDAL.XoaSinhVien(maSV);
        }

        public static string LayTenSV(string mssv)
        {
            return SinhVienDAL.LayTenSV(mssv);
        }

        public static List<dynamic> LayThongTinSV(string mssv)
        {
            return SinhVienDAL.LayThongTinSV(mssv);
        }
    }
}
