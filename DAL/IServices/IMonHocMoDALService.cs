using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IMonHocMoDALService
    {
        List<HocKyNamHoc> GetAllHocKyNamHoc();

        MessageAddMonHocMo AddMonHocMo(string maMH, int maHocKy, int namHoc);

        List<int> GetAllNamHoc();

        MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int maHocKy, int namHoc);
    }
}
