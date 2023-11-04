using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class SinhVien_DoiTuongBLLService : ISinhVien_DoiTuongBLLService
    {
        private readonly ISinhVien_DoiTuongDALService _sinhVien_DoiTuongDALService;

        public SinhVien_DoiTuongBLLService(ISinhVien_DoiTuongDALService sinhVien_DoiTuongDALService)
        {
            _sinhVien_DoiTuongDALService = sinhVien_DoiTuongDALService;
        }

        public List<SinhVien_DoiTuong> GetSinhVien_DoiTuongs()
        {
            return _sinhVien_DoiTuongDALService.GetSinhVien_DoiTuongs();
        }
    }
}
