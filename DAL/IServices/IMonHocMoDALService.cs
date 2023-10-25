using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IMonHocMoDALService
    {
        List<HocKyNamHoc> GetAllHocKyNamHoc();

        MessageAddMonHocMo AddMonHocMo(string MaMH, int MaHocKy, int NamHoc);

        List<int> GetAllNamHoc();

        MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int MaHocKy, int NamHoc);
    }
}
