using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class LoaiMonHocDAL
    {
        public static List<LoaiMonHoc> LayDSLoaiMonHoc()
        {
            List<LoaiMonHoc> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<LoaiMonHoc>("spLOAIMONHOC_LayDSLoaiMonHoc").ToList();
            }
            return output;
        }

        public static XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                    connection.Execute("spLOAIMONHOC_XoaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaLoaiMonHocMessage.Error;
            }

            return XoaLoaiMonHocMessage.Success;
        }

        public static SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                    p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
                    p.Add("@SoTiet", soTiet);
                    p.Add("@SoTien", soTien);
                    connection.Execute("spLOAIMONHOC_SuaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_LOAIMONHOC_TenLoaiMonHoc"))
                    {
                        return SuaLoaiMonHocMessage.DuplicateTenLoaiMonHoc;
                    }
                }
            }
            catch (Exception)
            {
                return SuaLoaiMonHocMessage.Error;
            }

            return SuaLoaiMonHocMessage.Success;
        }

        public static ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
                    p.Add("@SoTiet", soTiet);
                    p.Add("@SoTien", soTien);
                    connection.Execute("spLOAIMONHOC_ThemLoaiMonHoc", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_LOAIMONHOC_TenLoaiMonHoc"))
                    {
                        return ThemLoaiMonHocMessage.DuplicateTenLoaiMonHoc;
                    }
                }
            }
            catch (Exception)
            {
                return ThemLoaiMonHocMessage.Error;
            }

            return ThemLoaiMonHocMessage.Success;
        }
    }
}
