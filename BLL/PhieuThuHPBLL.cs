using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuThuHPBLL
    {
        public static TimKiemTTHocPhiMessage KtTimKiemTTHocPhi(string namHoc)
        {
            if (namHoc == "")
            {
                return TimKiemTTHocPhiMessage.EmptyNamHoc;
            }

            if (!int.TryParse(namHoc, out _))
            {
                return TimKiemTTHocPhiMessage.InvalidNamHoc;
            }
            return TimKiemTTHocPhiMessage.Sucess;
        }

        public static DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP)
        {
            return PhieuThuHPDAL.LayThoiGianDongHPGanNhat(maPhieuDKHP);
        }

        public static TimKiemPhieuDKHPMessage KtTimKiemSoTienThu(string t)
        {
            if (t == "")
            {
                return TimKiemPhieuDKHPMessage.EmptyNamHoc;
            }
            int kq;
            if (!int.TryParse(t, out kq))
            {
                return TimKiemPhieuDKHPMessage.InvalidNamHoc;
            }
            return TimKiemPhieuDKHPMessage.Sucess;
        }

        public static bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP)
        {
            return PhieuThuHPDAL.TaoPhieuThu_ChoXacNhan(soTienThu, soPhieuDKHP);
        }
    }
}
