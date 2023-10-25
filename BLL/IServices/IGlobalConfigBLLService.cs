using DTO;

namespace BLL.IServices
{
    public interface IGlobalConfigBLLService
    {
        int GetCurrNamHoc();
        int GetCurrMaHocKy();
        int LaySoTinChiToiDa();
        int LaySoTinChiToiThieu();
        SuaGioiHanTinChiMessage SuaGioiHanTinChi(string tinChiToiDa, string tinChiToiThieu);
        int LayKhoangTGDongHP(int hocKy, int namHoc);
        MessageKhoangTGDongHP KhoangTGDongHP(int MaHocKy, int NamHoc, int KhoangTG);
    }
}
