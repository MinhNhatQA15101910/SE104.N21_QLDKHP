﻿using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class SinhVienDAL
    {
        public static List<SinhVien> LayDSSVChuaCoTK()
        {
            List<SinhVien> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<SinhVien>("spSINHVIEN_LayDSSVChuaCoTK").ToList();
            }
            return output;
        }

        public static List<CT_SinhVien> LayDSSV()
        {
            List<CT_SinhVien> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<CT_SinhVien>("spSINHVIEN_LayDSSV").ToList();
            }
            return output;
        }

        public static SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaSV", mssvBanDau);
                    p.Add("@HoTen", hoTen);
                    p.Add("@NgaySinh", ngaySinh);
                    p.Add("@GioiTinh", gioiTinh);
                    p.Add("@MaHuyen", maHuyen);
                    p.Add("@MaNganh", maNganh);
                    connection.Execute("spSINHVIEN_SuaSinhVien", p, commandType: CommandType.StoredProcedure);

                    p = new DynamicParameters();
                    p.Add("@MaSV", mssvBanDau);
                    connection.Execute("spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

                    foreach (int maDT in maDTList)
                    {
                        p = new DynamicParameters();
                        p.Add("@MaSV", mssv);
                        p.Add("@MaDT", maDT);
                        connection.Execute("spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception)
            {
                return SuaSinhVienMessage.Error;
            }

            return SuaSinhVienMessage.Success;
        }

        public static ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaSV", mssv);
                    p.Add("@HoTen", hoTen);
                    p.Add("@NgaySinh", ngaySinh);
                    p.Add("@GioiTinh", gioiTinh);
                    p.Add("@MaHuyen", maHuyen);
                    p.Add("@MaNganh", maNganh);
                    connection.Execute("spSINHVIEN_ThemSinhVien", p, commandType: CommandType.StoredProcedure);

                    foreach (int maDT in maDTList)
                    {
                        p = new DynamicParameters();
                        p.Add("@MaSV", mssv);
                        p.Add("@MaDT", maDT);
                        connection.Execute("spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("PK_SINHVIEN"))
                    {
                        return ThemSinhVienMessage.DuplicateMaSV;
                    }
                }
            }
            catch (Exception)
            {
                return ThemSinhVienMessage.Error;
            }

            return ThemSinhVienMessage.Success;
        }

        public static XoaSinhVienMessage XoaSinhVien(string maSV)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaSV", maSV);
                    connection.Execute("spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                    connection.Execute("spCT_PHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                    connection.Execute("spPHIEUTHUHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                    connection.Execute("spPHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                    connection.Execute("spSINHVIEN_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception)
            {
                return XoaSinhVienMessage.Error;
            }

            return XoaSinhVienMessage.Success;
        }

        public static string LayTenSV(string mssv)
        {
            string output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);
                output = connection.QueryFirstOrDefault<string>("spSINHVIEN_LayTenSV", parameters, commandType: CommandType.StoredProcedure).ToString();
            }

            return output;
        }

        public static List<dynamic> LayThongTinSV(string mssv)
        {
            List<dynamic> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);
                output = connection.Query<dynamic>("spSINHVIEN_LayThongTinSV", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public static List<dynamic> BaoCaoSinhVienChuaDongHocPhi(int hocKy, int namHoc)
        {
            List<dynamic> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);

                output = connection.Query<dynamic>("spSINHVIEN_BaoCao", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }
    }
}
