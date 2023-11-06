using DAL.IServices;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class DanhSachMonHocMoDALService: IDanhSachMonHocMoDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public DanhSachMonHocMoDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<string> LayDSMonHocMo()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<string>(connection, "spDANHSACHMONHOCMO_LayDSMonHocMo").ToList();
            }
        }

        public List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);

                return _dapperWrapper.Query<dynamic>(connection, "spDANHSACHMONHOCMO_LayDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                parameters.Add("@monHoc", monHoc);

                return _dapperWrapper.Query<dynamic>(connection, "spDANHSACHMONHOCMO_TimKiemDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
