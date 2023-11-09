using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class HocKyBLLService: IHocKyBLLService
    {
        private readonly IHocKyDALService _hockyDALService;

        public HocKyBLLService(IHocKyDALService hockyDALService)
        {
            _hockyDALService = hockyDALService;
        }

        public List<HocKy> LayDanhSachHK()
        {
            return _hockyDALService.LayDanhSachHK();
        }

        public string LayHKByMaHK(int currMaHocKy)
        {
            return _hockyDALService.LayHKByMaHK(currMaHocKy);
        }
    }
}
