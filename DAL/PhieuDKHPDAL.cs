using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class PhieuDKHPDAL
    {
        public static List<PhieuDKHP> LayTTPhieuDKHP(string mssv, int maHocKy, int namHoc)
        {
            List<PhieuDKHP> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);
                parameters.Add("@MaHocKy", maHocKy);
                parameters.Add("@NamHoc", namHoc);
                output = connection.Query<PhieuDKHP>("spPHIEUDKHP_LayTTPhieuDKHP", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public static List<dynamic> LayDSMHThuocHP(int maPhieuDKHP)
        {
            List<dynamic> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ma", maPhieuDKHP);

                output = connection.Query<dynamic>("spPHIEUDKHP_LayDSMHThuocHP", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        public static int TinhHocPhi(int maPhieuDKHP)
        {
            int output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);
                output = connection.QueryFirstOrDefault<int>("spPHIEUDKHP_TinhHocPhi", parameters, commandType: CommandType.StoredProcedure);
            }

            return output;
        }

        public static float TinhHocPhiPhaiDong(int maPhieuDKHP)
        {
            float output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);
                output = connection.QueryFirstOrDefault<float>("spPHIEUDKHP_TinhHocPhiPhaiDong", parameters, commandType: CommandType.StoredProcedure);
            }

            return output;
        }

        public static float TinhHocPhiDaDong(int maPhieuDKHP)
        {
            float output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);
                output = connection.QueryFirstOrDefault<float>("spPHIEUDKHP_TinhHocPhiDaDong", parameters, commandType: CommandType.StoredProcedure);
            }

            return output;
        }

        public static float TinhHocPhiConThieu(int maPhieuDKHP)
        {
            float output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);
                output = connection.QueryFirstOrDefault<float>("spPHIEUDKHP_TinhHocPhiConThieu", parameters, commandType: CommandType.StoredProcedure);
            }
            return output;
        }

        public static List<dynamic> LayDSMHThuocHP2(int maPhieuDKHP)
        {
            List<dynamic> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ma", maPhieuDKHP);

                output = connection.Query<dynamic>("spPHIEUDKHP_layDSMHThuocHP2", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public static bool TaoPhieuDKHP(string mssv, int hocKy, int namHoc)
        {
            int numRowsAffected;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maSV", mssv);
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                numRowsAffected = connection.Execute("spPHIEUDKHP_TaoPhieuDKHP ", parameters, commandType: CommandType.StoredProcedure);
            }
            if (numRowsAffected > 0)
                return true;
            else
                return false;
        }

        public static int LayMaPhieuDKHP(int hocKy, int namHoc)
        {
            int output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maHocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                output = connection.QueryFirstOrDefault<int>("spPHIEUDKHP_LayMaPhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
            }

            return output;
        }

        public static List<PhieuDKHP> LayDanhSachDKHPDaXacNhan(string mssv)
        {
            List<PhieuDKHP> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);

                output = connection.Query<PhieuDKHP>("spPHIEUDKHP_LayDanhSachDKHPChoThanhToan", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public static List<PhieuDKHP> GetPhieuDKHP(int MaHocKy, int NamHoc, int MaTinhTrang)
        {
            List<PhieuDKHP> ListPhieuDKHP;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", MaHocKy);
                p.Add("@NamHoc", NamHoc);
                p.Add("@MaTinhTrang", MaTinhTrang);
                ListPhieuDKHP = connection.Query<PhieuDKHP>("spPHIEUDKHP_GetPhieuDKHP", p, commandType: CommandType.StoredProcedure).ToList();
            }

            return ListPhieuDKHP;
        }

        public static MessagePhieuDKHPUpdateTinhTrang PhieuDKHPUpdateTinhTrang(int MaPhieuDKHP, int MaTinhTrang)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaPhieuDKHP", MaPhieuDKHP);
                    p.Add("@MaTinhTrang", MaTinhTrang);
                    connection.Execute("spPHIEUDKHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);
                }

                return MessagePhieuDKHPUpdateTinhTrang.Success;
            }
            catch (Exception)
            {
                return MessagePhieuDKHPUpdateTinhTrang.Failed;
            }
        }

        public static List<PhieuDKHP> GetAllPhieuDKHP()
        {
            List<PhieuDKHP> ListPhieuDKHP;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                ListPhieuDKHP = connection.Query<PhieuDKHP>("spPHIEUDKHP_GetAllPhieuDKHP").ToList();
            }
            return ListPhieuDKHP;
        }
    }
}
