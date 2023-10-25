using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IDanhSachMonHocMoDALService
    {
        List<string> LayDSMonHocMo();
        List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc);
        List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc);
    }
}
