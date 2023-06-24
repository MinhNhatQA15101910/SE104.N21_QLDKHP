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
    public class DanhSachMonHocMoDAL
    {
        public static List<string> LayDSMonHocMo()
        {
            List<string> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<string>("spDANHSACHMONHOCMO_LayDSMonHocMo").ToList();
            }

            return output;
        }
    }
}
