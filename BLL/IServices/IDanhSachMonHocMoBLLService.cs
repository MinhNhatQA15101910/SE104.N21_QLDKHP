using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IDanhSachMonHocMoBLLService
    {
        List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc);
        List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc);
    }
}
