using BLL.IServices;
using DAL.IServices;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DanhSachMonHocMoBLLService: IDanhSachMonHocMoBLLService
    {
        private readonly IDanhSachMonHocMoDALService _danhSachMonHocMoDALService;

        public DanhSachMonHocMoBLLService(IDanhSachMonHocMoDALService danhSachMonHocMoDAL)
        {
            _danhSachMonHocMoDALService = danhSachMonHocMoDAL;
        }
        public List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc)
        {
            return _danhSachMonHocMoDALService.LayDanhSachMonHocMo(hocKy, namHoc);
        }

        public List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc)
        {
            return _danhSachMonHocMoDALService.TimKiemDanhSachMonHocMo(hocKy, namHoc, monHoc);
        }
    }
}
