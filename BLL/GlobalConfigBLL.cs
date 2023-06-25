using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GlobalConfigBLL
    {
        public static int GetCurrNamHoc()
        {
            return GlobalConfigDAL.GetCurrNamHoc();
        }

        public static int GetCurrMaHocKy()
        {
            return GlobalConfigDAL.GetCurrMaHocKy();
        }

        public static int LaySoTinChiToiDa()
        {
            return GlobalConfigDAL.LaySoTinChiToiDa();
        }

        public static int LaySoTinChiToiThieu()
        {
            return GlobalConfigDAL.LaySoTinChiToiThieu();
        }

        public static SuaGioiHanTinChiMessage SuaGioiHanTinChi(string tinChiToiDa, string tinChiToiThieu)
        {
            if (tinChiToiDa == "")
            {
                return SuaGioiHanTinChiMessage.TinChiToiDaRong;
            }

            if (tinChiToiThieu == "")
            {
                return SuaGioiHanTinChiMessage.TinChiToiThieuRong;
            }

            int tinChiToiDaValue;
            if (!int.TryParse(tinChiToiDa, out tinChiToiDaValue))
            {
                return SuaGioiHanTinChiMessage.TinChiToiDaKhongHopLe;
            }

            if (tinChiToiDaValue <= 0)
            {
                return SuaGioiHanTinChiMessage.TinChiToiDaKhongHopLe;
            }

            int tinChiToiThieuValue;
            if (!int.TryParse(tinChiToiThieu, out tinChiToiThieuValue))
            {
                return SuaGioiHanTinChiMessage.TinChiToiThieuKhongHopLe;
            }

            if (tinChiToiThieuValue <= 0)
            {
                return SuaGioiHanTinChiMessage.TinChiToiThieuKhongHopLe;
            }

            if (tinChiToiThieuValue >= tinChiToiDaValue)
            {
                return SuaGioiHanTinChiMessage.Unable;
            }

            return GlobalConfigDAL.SuaGioiHanTinChi(tinChiToiDaValue, tinChiToiThieuValue);
        }

        public static int LayKhoangTGDongHP(int hocKy, int namHoc)
        {
            return GlobalConfigDAL.LayKhoangTGDongHP(hocKy, namHoc);
        }

        public static MessageKhoangTGDongHP KhoangTGDongHP(int MaHocKy, int NamHoc, int KhoangTG)
        {
            return GlobalConfigDAL.KhoangTGDongHP(MaHocKy, NamHoc, KhoangTG);
        }
    }
}
