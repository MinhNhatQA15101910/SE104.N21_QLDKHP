using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class HocKyBLLService: IHocKyBLLService
    {
        private readonly IHocKyDALService _hockiDALService;

        public HocKyBLLService(IHocKyDALService hockiDALService)
        {
            _hockiDALService = hockiDALService;
        }

        public List<HocKy> LayDanhSachHK()
        {
            return _hockiDALService.LayDanhSachHK();
        }

        public string LayHKByMaHK(int currMaHocKy)
        {
            return _hockiDALService.LayHKByMaHK(currMaHocKy);
        }
    }
}
