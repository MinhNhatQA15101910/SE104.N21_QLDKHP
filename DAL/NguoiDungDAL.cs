using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NguoiDungDAL
    {
        private static string ConvertToSHA512(string source)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            byte[] hashBytes = SHA512.Create().ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            return hash;
        }

        public static DangNhapMessage DangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@TenDangNhap", tenDangNhap);
                    p.Add("@MatKhau", ConvertToSHA512(matKhau));
                    GlobalConfig.CurrNguoiDung = connection.QuerySingleOrDefault<NguoiDung>("spNGUOIDUNG_LayBangTenDangNhapVaMatKhau", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return DangNhapMessage.Error;
            }

            if (GlobalConfig.CurrNguoiDung == null)
            {
                return DangNhapMessage.Failed;
            }

            return DangNhapMessage.Success;
        }

        public static List<CT_NguoiDung> LayDSNguoiDung()
        {
            List<CT_NguoiDung> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<CT_NguoiDung>("spNGUOIDUNG_LayDSNguoiDung").ToList();
            }
            return output;
        }
    }
}
