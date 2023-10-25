using DTO;

namespace DAL.IServices
{
    public interface IGlobalConfigDALService
    {
        int GetCurrNamHoc();
        int LaySoTinChiToiDa();
        int LaySoTinChiToiThieu();
        int GetCurrMaHocKy();
        SuaGioiHanTinChiMessage SuaGioiHanTinChi(int tinChiToiDa, int tinChiToiThieu);
        int LayKhoangTGDongHP(int hocKy, int namHoc);
        MessageKhoangTGDongHP KhoangTGDongHP(int MaHocKy, int NamHoc, int KhoangTG);
    }
}
