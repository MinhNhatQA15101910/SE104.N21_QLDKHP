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
    }
}
