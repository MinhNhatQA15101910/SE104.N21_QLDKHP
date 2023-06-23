using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiMonHocBLL
    {
        public static List<LoaiMonHoc> LayDSLoaiMonHoc()
        {
            return LoaiMonHocDAL.LayDSLoaiMonHoc();
        }

        public static XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc)
        {
            return LoaiMonHocDAL.XoaLoaiMonHoc(maLoaiMonHoc);
        }

        public static SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            if (tenLoaiMonHoc.Equals(""))
            {
                return SuaLoaiMonHocMessage.EmptyTenLoaiMonHoc;
            }

            if (soTiet.Equals(""))
            {
                return SuaLoaiMonHocMessage.EmptySoTiet;
            }

            if (soTien.Equals(""))
            {
                return SuaLoaiMonHocMessage.EmptySoTien;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return SuaLoaiMonHocMessage.SoTietKhongHopLe;
            }

            if (soTietValue < 0)
            {
                return SuaLoaiMonHocMessage.SoTietKhongHopLe;
            }

            decimal soTienValue;
            if (!decimal.TryParse(soTien, out soTienValue))
            {
                return SuaLoaiMonHocMessage.SoTienKhongHopLe;
            }

            if (soTienValue < 0)
            {
                return SuaLoaiMonHocMessage.SoTienKhongHopLe;
            }

            return LoaiMonHocDAL.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTietValue, soTienValue);
        }

        public static ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            if (tenLoaiMonHoc.Equals(""))
            {
                return ThemLoaiMonHocMessage.EmptyTenLoaiMonHoc;
            }

            if (soTiet.Equals(""))
            {
                return ThemLoaiMonHocMessage.EmptySoTiet;
            }

            if (soTien.Equals(""))
            {
                return ThemLoaiMonHocMessage.EmptySoTien;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return ThemLoaiMonHocMessage.SoTietKhongHopLe;
            }

            if (soTietValue < 0)
            {
                return ThemLoaiMonHocMessage.SoTietKhongHopLe;
            }

            decimal soTienValue;
            if (!decimal.TryParse(soTien, out soTienValue))
            {
                return ThemLoaiMonHocMessage.SoTienKhongHopLe;
            }

            if (soTienValue < 0)
            {
                return ThemLoaiMonHocMessage.SoTienKhongHopLe;
            }

            return LoaiMonHocDAL.ThemLoaiMonHoc(tenLoaiMonHoc, soTietValue, soTienValue);

        }
    }
}
