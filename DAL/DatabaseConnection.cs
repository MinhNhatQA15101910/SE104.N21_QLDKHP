using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseConnection
    {
        public static string CnnString()
        {
            return ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString;
        }
    }
}
