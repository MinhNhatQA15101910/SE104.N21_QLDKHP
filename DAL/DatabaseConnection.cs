using System.Configuration;

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
