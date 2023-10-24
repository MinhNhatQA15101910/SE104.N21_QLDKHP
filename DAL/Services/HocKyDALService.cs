using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class HocKyDALService: IHocKyDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public HocKyDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }


        public List<HocKy> LayDanhSachHK()
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                return _dapperService.Query<HocKy>(connection, "spHOCKY_LayDanhSachHK").ToList();
            }
        }

        public string LayHKByMaHK(int currMaHocKy)
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", currMaHocKy);
                return _dapperService.Query<string>(connection, "spHOCKY_LayHKByMaHK", p, commandType: CommandType.StoredProcedure).ToString();
            }
        }
    }
}
