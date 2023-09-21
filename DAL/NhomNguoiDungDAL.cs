using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class NhomNguoiDungDAL
    {
        public static List<NhomNguoiDung> LayDSNhomNguoiDung()
        {
            List<NhomNguoiDung> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<NhomNguoiDung>("spNHOMNGUOIDUNG_LayDSNhomNguoiDung").ToList();
            }
            return output;
        }
    }
}
