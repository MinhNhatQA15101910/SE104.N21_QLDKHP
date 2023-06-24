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

        public static ThemDoiTuongMessage ThemDoiTuong(string tenDT, float tiLeGiam)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@TenDT", tenDT);
                    p.Add("@TiLeGiamHocPhi", tiLeGiam);
                    connection.Execute("spDOITUONG_ThemDoiTuong", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_DOITUONG_TenDT"))
                    {
                        return ThemDoiTuongMessage.DuplicateTenDoiTuong;
                    }
                }
            }
            catch (Exception)
            {
                return ThemDoiTuongMessage.Error;
            }

            return ThemDoiTuongMessage.Success;
        }

        public static List<DoiTuong> LayDSDoiTuong2()
        {
            List<DoiTuong> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<DoiTuong>("spDOITUONG_LayDSDoiTuong2").ToList();
            }
            return output;
        }

        public static List<DoiTuong> LayDSDoiTuongKhongThuocVeMaSV(string maSV)
        {
            List<DoiTuong> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);
                output = connection.Query<DoiTuong>("spDOITUONG_LayDSDoiTuongKhongThuocVeMaSV", p, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public static List<DoiTuong> LayDSDoiTuongBangMaSV(string maSV)
        {
            List<DoiTuong> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);
                output = connection.Query<DoiTuong>("spDOITUONG_LayDSDoiTuongBangMaSV", p, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public static XoaDoiTuongMessage XoaDoiTuong(int maDT)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaDT", maDT);
                    connection.Execute("spDOITUONG_XoaDoiTuong", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaDoiTuongMessage.Error;
            }

            return XoaDoiTuongMessage.Success;
        }
    }
}
