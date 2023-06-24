using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CT_PhieuDKHPDAL
    {
        public static void TaoCT_PhieuDKHP(int maPhieu, List<string> list)
        {
            foreach (var i in list)
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@maPhieuDKHP", maPhieu);
                    parameters.Add("@maMH", i);
                    connection.Execute("spPHIEUDKHP_TaoCT_PhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public static void XoaDSMHDKHP(int maPhieu)
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieu);
                connection.Execute("spPHIEUDKHP_XoaCT_PhieuDKHP ", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
