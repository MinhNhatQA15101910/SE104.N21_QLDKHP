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
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public DanhSachMonHocMoDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }

        public List<string> LayDSMonHocMo()
        {

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                return _dapperService.Query<string>(connection, "spDANHSACHMONHOCMO_LayDSMonHocMo").ToList();
            }
        }

        public List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc)
        {

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);

                return _dapperService.Query<dynamic>(connection, "spDANHSACHMONHOCMO_LayDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc)
        {

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                parameters.Add("@monHoc", monHoc);


                return _dapperService.Query<dynamic>(connection, "spDANHSACHMONHOCMO_TimKiemDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
