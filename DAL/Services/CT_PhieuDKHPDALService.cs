using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class CT_PhieuDKHPDALService : ICT_PhieuDKHPDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public CT_PhieuDKHPDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<CT_PhieuDKHP> GetCT_PhieuDKHPs()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<CT_PhieuDKHP>(connection, "spCT_PHIEUDKHP_GetCT_PhieuDKHPs").ToList();
            }
        }

        public int TaoCT_PhieuDKHP(CT_PhieuDKHP ct_PhieuDKHP)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", ct_PhieuDKHP.MaPhieuDKHP);
                parameters.Add("@maMH", ct_PhieuDKHP.MaMH);
                return _dapperWrapper.Execute(connection, "spPHIEUDKHP_TaoCT_PhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int XoaDSMHDKHP(int maPhieu)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieu);
                return _dapperWrapper.Execute(connection, "spPHIEUDKHP_XoaCT_PhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
