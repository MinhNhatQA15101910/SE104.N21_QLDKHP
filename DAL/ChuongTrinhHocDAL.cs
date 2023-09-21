using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class ChuongTrinhHocDAL
    {
        public static MessageDeleteListCTHoc DeleteListCTHoc(string MaNganh, int HocKy)
        {
            ChuongTrinhHoc CTHoc = new ChuongTrinhHoc();
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaNganh", MaNganh);
                    mhm.Add("@HocKy", HocKy);
                    connection.Execute("spCHUONGTRINHHOC_DeleteListCTHoc", mhm, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageDeleteListCTHoc.Failed;
            }
            if (CTHoc == null) return MessageDeleteListCTHoc.ErrorData;
            return MessageDeleteListCTHoc.Success;
        }

        public static List<ChuongTrinhHoc> GetAllCTHoc()
        {
            List<ChuongTrinhHoc> ListChuongTrinhHoc;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                ListChuongTrinhHoc = connection.Query<ChuongTrinhHoc>("spCHUONGTRINHHOC_GetAll").ToList();
            }

            return ListChuongTrinhHoc;
        }

        public static MessageAddCTHoc AddCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            ChuongTrinhHoc CTHoc = new ChuongTrinhHoc();
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaMH", MaMH);
                    mhm.Add("@MaNganh", MaNganh);
                    mhm.Add("@HocKy", HocKy);
                    connection.Execute("spCHUONGTRINHHOC_AddCTHoc", mhm, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageAddCTHoc.Failed;
            }
            if (CTHoc == null) return MessageAddCTHoc.ErrorData;
            return MessageAddCTHoc.Success;
        }

        public static MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            ChuongTrinhHoc CTHoc = new ChuongTrinhHoc();
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaMH", MaMH);
                    mhm.Add("@MaNganh", MaNganh);
                    mhm.Add("@HocKy", HocKy);
                    connection.Execute("spCHUONGTRINHHOC_DeleteCTHoc", mhm, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageDeleteCTHoc.Failed;
            }
            if (CTHoc == null) return MessageDeleteCTHoc.ErrorData;
            return MessageDeleteCTHoc.Success;
        }
    }
}
