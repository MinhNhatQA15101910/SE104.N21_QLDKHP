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
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public HocKyDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<HocKy> LayDanhSachHK()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<HocKy>(connection, "spHOCKY_LayDanhSachHK").ToList();
            }
        }

        public string LayHKByMaHK(int currMaHocKy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", currMaHocKy);
                return _dapperWrapper.Query<string>(connection, "spHOCKY_LayHKByMaHK", p, commandType: CommandType.StoredProcedure).ToString();
            }
        }
    }
}
