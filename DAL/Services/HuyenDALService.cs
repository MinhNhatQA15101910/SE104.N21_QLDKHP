using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class HuyenDALService : IHuyenDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public HuyenDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<CT_Huyen> LayDSHuyen()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<CT_Huyen>(connection, "spHUYEN_LayDSHuyen").ToList();
            }
        }

        public SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaHuyen", maHuyen);
                p.Add("@TenHuyen", tenHuyen);
                p.Add("@VungUT", vungUT);
                p.Add("@MaTinh", maTinh);
                int result = _dapperWrapper.Execute(connection, "spHUYEN_SuaHuyen", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaHuyenMessage.Success : SuaHuyenMessage.Failed;
            }
        }

        public XoaHuyenMessage XoaHuyen(int maHuyen)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaHuyen", maHuyen);
                int result = _dapperWrapper.Execute(connection, "spHUYEN_XoaHuyen", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? XoaHuyenMessage.Success : XoaHuyenMessage.Failed;
            }
        }

        public ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenHuyen", tenHuyen);
                p.Add("@VungUT", vungUT);
                p.Add("@MaTinh", maTinh);
                int result = _dapperWrapper.Execute(connection, "spHUYEN_ThemHuyen", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? ThemHuyenMessage.Success : ThemHuyenMessage.Failed;
            }
        }
    }
}
