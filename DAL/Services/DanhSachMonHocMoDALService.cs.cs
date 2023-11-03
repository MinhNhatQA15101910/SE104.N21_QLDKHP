using DAL.IServices;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class DanhSachMonHocMoDALService: IDanhSachMonHocMoDALService
    {
        private readonly IDapperService _dapperService;

        public DanhSachMonHocMoDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<string> LayDSMonHocMo()
        {
            return _dapperService.Query<string>("spDANHSACHMONHOCMO_LayDSMonHocMo").ToList();
        }

        public List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@hocKy", hocKy);
            parameters.Add("@namHoc", namHoc);

            return _dapperService.Query<dynamic>("spDANHSACHMONHOCMO_LayDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@hocKy", hocKy);
            parameters.Add("@namHoc", namHoc);
            parameters.Add("@monHoc", monHoc);

            return _dapperService.Query<dynamic>("spDANHSACHMONHOCMO_TimKiemDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
