using System.Configuration;

namespace DAL
{
    public static class DatabaseConnection
    {
        public static string CnnString()
        {
            return ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString;
        }
    }
}
