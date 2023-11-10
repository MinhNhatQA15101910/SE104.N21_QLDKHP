using DTO;

namespace DAL.IServices
{
    public interface IGlobalConfigDALService
    {
        int GetCurrNamHoc();
        int LaySoTinChiToiDa();
        int LaySoTinChiToiThieu();
        int GetCurrMaHocKy(int namHoc);
        SuaGioiHanTinChiMessage SuaGioiHanTinChi(int tinChiToiDa, int tinChiToiThieu);
        int LayKhoangTGDongHP(int hocKy, int namHoc);
        MessageKhoangTGDongHP KhoangTGDongHP(int maHocKy, int namHoc, int khoangTG);
    }
}
