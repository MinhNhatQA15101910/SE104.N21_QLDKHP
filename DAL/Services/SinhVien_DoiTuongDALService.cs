using DAL.IServices;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Services
{
    public class SinhVien_DoiTuongDALService : ISinhVien_DoiTuongDALService
    {
        private readonly IDapperService _dapperService;

        public SinhVien_DoiTuongDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<SinhVien_DoiTuong> GetSinhVien_DoiTuongs()
        {
            return _dapperService.Query<SinhVien_DoiTuong>("spSINHVIEN_DOITUONG_GetSinhVien_DoiTuongs").ToList();
        }
    }
}
