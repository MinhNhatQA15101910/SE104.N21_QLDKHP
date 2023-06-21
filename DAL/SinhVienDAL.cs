using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SinhVienDAL
    {
        public static List<SinhVien> LayDSSVChuaCoTK()
        {
            List<SinhVien> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<SinhVien>("spSINHVIEN_LayDSSVChuaCoTK").ToList();
            }
            return output;
        }
    }
}
