using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MonHocBLL
    {
        public static List<CT_MonHoc> LayDSMonHoc()
        {
            return MonHocDAL.LayDSMonHoc();
        }

        public static XoaMonHocMessage XoaMonHoc(string maMH)
        {
            return MonHocDAL.XoaMonHoc(maMH);
        }

        public static SuaMonHocMessage SuaMonHoc(string maMHBanDau, string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon)
        {
            List<string> currMonHocMoList = DanhSachMonHocMoDAL.LayDSMonHocMo();
            if (currMonHocMoList.Contains(maMHBanDau))
            {
                return SuaMonHocMessage.Unable;
            }

            if (maMH.Equals(""))
            {
                return SuaMonHocMessage.EmptyMaMH;
            }

            if (tenMH.Equals(""))
            {
                return SuaMonHocMessage.EmptyTenMH;
            }

            if (soTiet.Equals(""))
            {
                return SuaMonHocMessage.EmptySoTiet;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return SuaMonHocMessage.InvalidSoTiet;
            }

            if (soTietValue < 0)
            {
                return SuaMonHocMessage.InvalidSoTiet;
            }
            
            if (soTietValue % soTietLoaiMon != 0)
            {
                return SuaMonHocMessage.InvalidSoTiet;
            }

            return MonHocDAL.SuaMonHoc(maMHBanDau, tenMH, maLoaiMonHoc, soTietValue);
        }

        public static ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon)
        {
            if (maMH.Equals(""))
            {
                return ThemMonHocMessage.EmptyMaMH;
            }

            if (tenMH.Equals(""))
            {
                return ThemMonHocMessage.EmptyTenMH;
            }

            if (soTiet.Equals(""))
            {
                return ThemMonHocMessage.EmptySoTiet;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return ThemMonHocMessage.InvalidSoTiet;
            }

            if (soTietValue % soTietLoaiMon != 0)
            {
                return ThemMonHocMessage.InvalidSoTiet;
            }

            return MonHocDAL.ThemMonHoc(maMH, tenMH, maLoaiMonHoc, soTietValue);
        }

        public static List<MonHoc> GetTermMonHoc(int HocKy)
        {
            return MonHocDAL.GetTermMonHoc(HocKy);
        }

        public static List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc)
        {
            return MonHocDAL.GetTermMonHocMo(HocKy, NamHoc);
        }

        public static List<MonHoc> GetChuongTrinhHoc(string Nganh, int HocKy)
        {
            return MonHocDAL.GetChuongTrinhHoc(Nganh, HocKy);
        }

        public static List<MonHoc> LayDSMonHoc2()
        {
            return MonHocDAL.LayDSMonHoc2();
        }

        public static List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP)
        {
            return MonHocDAL.GetMonHocPhieuDKHP(MaPhieuDKHP);
        }
    }
}
