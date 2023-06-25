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
    public class GlobalConfigDAL
    {
        public static int GetCurrNamHoc()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LayNamHocHienTai");
            }
            return output;
        }

        public static int LaySoTinChiToiDa()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LaySoTinChiToiDa");
            }
            return output;
        }

        public static int LaySoTinChiToiThieu()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LaySoTinChiToiThieu");
            }
            return output;
        }

        public static int GetCurrMaHocKy()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@NamHocHienTai", GlobalConfig.CurrNamHoc);
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LayMaHocKyHienTai", p, commandType: CommandType.StoredProcedure);
            }
            return output;
        }

        public static SuaGioiHanTinChiMessage SuaGioiHanTinChi(int tinChiToiDa, int tinChiToiThieu)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@SoTinChiToiDa", tinChiToiDa);
                    p.Add("@SoTinChiToiThieu", tinChiToiThieu);
                    connection.Execute("spGLOBALCONFIG_SuaGioiHanTinChi", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return SuaGioiHanTinChiMessage.Error;
            }

            return SuaGioiHanTinChiMessage.Success;
        }

        public static int LayKhoangTGDongHP(int hocKy, int namHoc)
        {
            int output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);

                output = connection.QueryFirstOrDefault<int>("spGLOBALCONFIG_LayKhoangTGDongHP", parameters, commandType: CommandType.StoredProcedure);
            }

            return output;
        }

        public static MessageKhoangTGDongHP KhoangTGDongHP(int MaHocKy, int NamHoc, int KhoangTG)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaHocKy", MaHocKy);
                    p.Add("@NamHoc", NamHoc);
                    p.Add("@KhoangTG", KhoangTG);
                    connection.Execute("spKHOANGTGDONGHP_Add", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageKhoangTGDongHP.Failed;
            }
            return MessageKhoangTGDongHP.Success;

        }
    }
}
