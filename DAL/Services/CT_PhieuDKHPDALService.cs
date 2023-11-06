using DAL.IServices;
using Dapper;
using DTO;
using System.Data;
using System.Data.SqlClient;

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

        public void TaoCT_PhieuDKHP(CT_PhieuDKHP ct_PhieuDKHP)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", ct_PhieuDKHP.MaPhieuDKHP);
                parameters.Add("@maMH", ct_PhieuDKHP.MaMH);
                _dapperWrapper.Execute(connection, "spPHIEUDKHP_TaoCT_PhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void XoaDSMHDKHP(int maPhieu)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieu);
                _dapperWrapper.Execute(connection, "spPHIEUDKHP_XoaCT_PhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
