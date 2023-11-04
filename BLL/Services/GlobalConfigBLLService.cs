﻿using BLL.IServices;
using DAL.IServices;
using DTO;

namespace BLL.Services
{
    public class GlobalConfigBLLService : IGlobalConfigBLLService
    {
        private readonly IGlobalConfigDALService _globalConfigDALService;

        public GlobalConfigBLLService(IGlobalConfigDALService globalConfigDALService)
        {
            _globalConfigDALService = globalConfigDALService;
        }

        public int GetCurrNamHoc()
        {
            return _globalConfigDALService.GetCurrNamHoc();
        }

        public int GetCurrMaHocKy()
        {
            return _globalConfigDALService.GetCurrMaHocKy();
        }

        public int LaySoTinChiToiDa()
        {
            return _globalConfigDALService.LaySoTinChiToiDa();
        }

        public int LaySoTinChiToiThieu()
        {
            return _globalConfigDALService.LaySoTinChiToiThieu();
        }

        public SuaGioiHanTinChiMessage SuaGioiHanTinChi(string tinChiToiDa, string tinChiToiThieu)
        {
            if (string.IsNullOrEmpty(tinChiToiDa))
            {
                return SuaGioiHanTinChiMessage.TinChiToiDaRong;
            }

            if (string.IsNullOrEmpty(tinChiToiThieu))
            {
                return SuaGioiHanTinChiMessage.TinChiToiThieuRong;
            }

            if (!int.TryParse(tinChiToiDa, out int tinChiToiDaValue) || tinChiToiDaValue <= 0)
            {
                return SuaGioiHanTinChiMessage.TinChiToiDaKhongHopLe;
            }

            if (!int.TryParse(tinChiToiThieu, out int tinChiToiThieuValue) || tinChiToiThieuValue <= 0)
            {
                return SuaGioiHanTinChiMessage.TinChiToiThieuKhongHopLe;
            }

            if (tinChiToiThieuValue >= tinChiToiDaValue)
            {
                return SuaGioiHanTinChiMessage.Unable;
            }

            return _globalConfigDALService.SuaGioiHanTinChi(tinChiToiDaValue, tinChiToiThieuValue);
        }

        public int LayKhoangTGDongHP(int hocKy, int namHoc)
        {
            return _globalConfigDALService.LayKhoangTGDongHP(hocKy, namHoc);
        }

        public MessageKhoangTGDongHP KhoangTGDongHP(int MaHocKy, int NamHoc, int KhoangTG)
        {
            return _globalConfigDALService.KhoangTGDongHP(MaHocKy, NamHoc, KhoangTG);
        }
    }
}
