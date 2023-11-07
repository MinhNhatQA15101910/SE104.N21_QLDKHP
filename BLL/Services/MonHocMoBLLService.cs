using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class MonHocMoBLLService : IMonHocMoBLLService
    {
        private readonly IMonHocMoDALService _monHocMoDALService;

        public MonHocMoBLLService(IMonHocMoDALService monHocMoDALService)
        {
            _monHocMoDALService = monHocMoDALService;
        }

        public List<HocKyNamHoc> GetAllHocKyNamHoc()
        {
            return _monHocMoDALService.GetAllHocKyNamHoc();
        }

        public MessageAddMonHocMo AddMonHocMo(string maMH, int maHocKy, int namHoc)
        {
            return _monHocMoDALService.AddMonHocMo(maMH, maHocKy, namHoc);
        }

        public List<int> GetAllNamHoc()
        {
            return _monHocMoDALService.GetAllNamHoc();
        }

        public MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int maHocKy, int namHoc)
        {
            return _monHocMoDALService.DeleteHocKyNamHocMHM(maHocKy, namHoc);
        }
    }
}
