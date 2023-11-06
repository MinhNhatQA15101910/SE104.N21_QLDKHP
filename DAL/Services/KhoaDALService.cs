using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class KhoaDALService : IKhoaDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public KhoaDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<Khoa> LayDSKhoa()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<Khoa>(connection, "spKHOA_LayDSKhoa").ToList();
            }
        }

        public SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaKhoaBanDau", maKhoaBanDau);
                p.Add("@MaKhoaSua", maKhoaSua);
                p.Add("@TenKhoaSua", tenKhoaSua);
                var result = _dapperWrapper.Execute(connection, "spKHOA_SuaKhoa", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaKhoaMessage.Success : SuaKhoaMessage.Failed;
            }
        }

        public ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaKhoa", maKhoa);
                p.Add("@TenKhoa", tenKhoa);
                int result = _dapperWrapper.Execute(connection, "spKHOA_ThemKhoa", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? ThemKhoaMessage.Success : ThemKhoaMessage.Failed;
            }
        }

        public XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaKhoa", maKhoa);
                int result = _dapperWrapper.Execute(connection, "spKHOA_XoaKhoa", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? XoaKhoaMessage.Success : XoaKhoaMessage.Failed;
            }
        }
    }
}
