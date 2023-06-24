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
    public class PhieuThuHPDAL
    {
        public static DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP)
        {
            DateTime output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ma", maPhieuDKHP);
                output = connection.QueryFirstOrDefault<DateTime>("spPHIEUTHUHP_LayThoiGianDongHPGanNhat", parameters, commandType: CommandType.StoredProcedure);
            }

            return output;



        }
    }
}
