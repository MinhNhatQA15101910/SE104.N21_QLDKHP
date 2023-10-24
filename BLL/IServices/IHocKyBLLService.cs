using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IHocKyBLLService
    {
        List<HocKy> LayDanhSachHK();
        string LayHKByMaHK(int currMaHocKy);
    }
}
