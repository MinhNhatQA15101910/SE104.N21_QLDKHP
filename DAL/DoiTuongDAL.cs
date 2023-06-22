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
    public class DoiTuongDAL
    {
        public static List<DoiTuong> LayDSDoiTuong()
        {
            List<DoiTuong> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<DoiTuong>("spDOITUONG_LayDSDoiTuong").ToList();
            }
            return output;
        }

        public static SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, float tiLeGiam)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaDT", maDTBanDau);
                    p.Add("@TenDT", tenDT);
                    p.Add("@TiLeGiamHocPhi", tiLeGiam);
                    connection.Execute("spDOITUONG_SuaDoiTuong", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_DOITUONG_TenDT"))
                    {
                        return SuaDoiTuongMessage.DuplicateTenDoiTuong;
                    }
                }
            }
            catch (Exception)
            {
                return SuaDoiTuongMessage.Error;
            }

            return SuaDoiTuongMessage.Success;
        }
    }
}
