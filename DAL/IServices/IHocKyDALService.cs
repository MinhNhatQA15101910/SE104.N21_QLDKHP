using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IHocKyDALService
    {
        List<HocKy> LayDanhSachHK();
        string LayHKByMaHK(int currMaHocKy);
    }
}
