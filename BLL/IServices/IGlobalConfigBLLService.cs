﻿using DTO;

namespace BLL.IServices
{
    public interface IGlobalConfigBLLService
    {
        int GetCurrNamHoc();
        int GetCurrMaHocKy(int namHoc);
        int LaySoTinChiToiDa();
        int LaySoTinChiToiThieu();
        SuaGioiHanTinChiMessage SuaGioiHanTinChi(string tinChiToiDa, string tinChiToiThieu);
        int LayKhoangTGDongHP(int hocKy, int namHoc);
        MessageKhoangTGDongHP KhoangTGDongHP(int maHocKy, int namHoc, int khoangTG);
    }
}
