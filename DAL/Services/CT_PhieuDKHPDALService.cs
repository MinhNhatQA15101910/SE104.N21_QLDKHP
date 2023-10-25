using DAL.IServices;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class CT_PhieuDKHPDALService: ICT_PhieuDKHPDALService
    {
        public readonly IDapperService _dapperService;
        public readonly string _dbConnection;

        public CT_PhieuDKHPDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }
        public void TaoCT_PhieuDKHP(int maPhieu, List<string> list)
        {
            foreach (var i in list)
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@maPhieuDKHP", maPhieu);
                    parameters.Add("@maMH", i);
                    _dapperService.Execute(connection, "spPHIEUDKHP_TaoCT_PhieuDKHP", parameters, CommandType.StoredProcedure);                  
                }
            }
        }

        public void XoaDSMHDKHP(int maPhieu)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieu);
                _dapperService.Execute(connection, "spPHIEUDKHP_XoaCT_PhieuDKHP", parameters, CommandType.StoredProcedure);
            }
        }
    }
}
