using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuDKHPBLL
    {
        public static List<PhieuDKHP> LayTTPhieuDKHP(string mssv, int maHocKy, int namHoc)
        {
            return PhieuDKHPDAL.LayTTPhieuDKHP(mssv, maHocKy, namHoc);
        }

        public static TimKiemPhieuDKHPMessage KtTimKiemPhieuDKHP(string namHoc)
        {
            if (namHoc == "")
            {
                return TimKiemPhieuDKHPMessage.EmptyNamHoc;
            }

            if (!int.TryParse(namHoc, out _))
            {
                return TimKiemPhieuDKHPMessage.InvalidNamHoc;
            }

            return TimKiemPhieuDKHPMessage.Sucess;
        }

        public static List<dynamic> LayDSMHThuocHP(int maPhieuDKHP)
        {
            return PhieuDKHPDAL.LayDSMHThuocHP(maPhieuDKHP);
        }

        public static int TinhHocPhi(int maPhieuDKHP)
        {
            return PhieuDKHPDAL.TinhHocPhi(maPhieuDKHP);
        }

        public static float TinhHocPhiPhaiDong(int maPhieuDKHP)
        {
            return PhieuDKHPDAL.TinhHocPhiPhaiDong(maPhieuDKHP);
        }

        public static float TinhHocPhiDaDong(int maPhieuDKHP)
        {
            return PhieuDKHPDAL.TinhHocPhiDaDong(maPhieuDKHP);
        }

        public static float TinhHocPhiConThieu(int maPhieuDKHP)
        {
            return PhieuDKHPDAL.TinhHocPhiConThieu(maPhieuDKHP);
        }

        public static List<dynamic> LayDSMHThuocHP2(int maPhieuDKHP)
        {
            return PhieuDKHPDAL.LayDSMHThuocHP2(maPhieuDKHP);
        }

        public static bool TaoPhieuDKHP(string mssv, int hocKy, int namHoc)
        {
            return PhieuDKHPDAL.TaoPhieuDKHP(mssv, hocKy, namHoc);
        }

        public static int LayMaPhieuDKHP(int hocKy, int namHoc)
        {
            return PhieuDKHPDAL.LayMaPhieuDKHP(hocKy, namHoc);
        }

        public static List<PhieuDKHP> LayDanhSachDKHPDaXacNhan(string mssv)
        {
            return PhieuDKHPDAL.LayDanhSachDKHPDaXacNhan(mssv);
        }
    }
}
