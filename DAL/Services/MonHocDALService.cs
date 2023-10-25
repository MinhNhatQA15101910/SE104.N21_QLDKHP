using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class MonHocDALService: IMonHocDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public MonHocDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }

        public List<CT_MonHoc> LayDSMonHoc()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.Query<CT_MonHoc>(connection, "spMONHOC_LayDSMonHoc").ToList();
            }
        }

        public  XoaMonHocMessage XoaMonHoc(string maMH)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaMH", maMH);
                    _dapperService.Execute(connection, "spMONHOC_XoaMonHoc", p, CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaMonHocMessage.Error;
            }

            return XoaMonHocMessage.Success;
        }

        public  SuaMonHocMessage SuaMonHoc(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaMH", maMHBanDau);
                    p.Add("@TenMH", tenMH);
                    p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                    p.Add("@SoTiet", soTiet);
                    _dapperService.Execute(connection, "spMONHOC_SuaMonHoc", p, CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return SuaMonHocMessage.Error;
            }

            return SuaMonHocMessage.Success;
        }

        public  ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaMH", maMH);
                    p.Add("@TenMH", tenMH);
                    p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                    p.Add("@SoTiet", soTiet);
                    _dapperService.Execute(connection, "spMONHOC_ThemMonHoc", p, CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("PK_MONHOC"))
                    {
                        return ThemMonHocMessage.DuplicateMaMH;
                    }
                }
            }
            catch (Exception)
            {
                return ThemMonHocMessage.Error;
            }

            return ThemMonHocMessage.Success;
        }

        public  List<MonHoc> LayDSMonHoc2()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.Query<MonHoc>(connection, "spMONHOC_LayDSMonHoc2").ToList();
            }
        }

        public  List<MonHoc> GetTermMonHoc(int HocKy)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                if (HocKy == 1)
                {
                    return _dapperService.Query<MonHoc>(connection, "spMONHOC_GetOddCTMonHoc").ToList();
                }
                else if (HocKy == 2)
                {
                    return _dapperService.Query<MonHoc>(connection, "spMONHOC_GetEvenCTMonHoc").ToList();
                }
                else 
                    return _dapperService.Query<MonHoc>(connection, "spMONHOC_GetAllCTMonHoc").ToList();
            }
        }

        public  List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                var p = new DynamicParameters();
                p.Add("@HocKy", HocKy);
                p.Add("@NamHoc", NamHoc);
                return _dapperService.Query<MonHoc>(connection, "spMONHOC_GetTermMonHocMo", p, CommandType.StoredProcedure).ToList();
            }
        }

        public  List<MonHoc> GetChuongTrinhHoc(string MaNganh, int HocKy)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                if (HocKy != 0)
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", MaNganh);
                    p.Add("@HocKy", HocKy);
                    return _dapperService.Query<MonHoc>(connection, "spMONHOC_GetCTHHocKy", p, CommandType.StoredProcedure).ToList();
                }
                else
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", MaNganh);
                    return _dapperService.Query<MonHoc>(connection, "spMONHOC_GetCTHHocKy", p, CommandType.StoredProcedure).ToList();
                }

            }
        }

        public  List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                var p = new DynamicParameters();
                p.Add("@MaPhieuDKHP", MaPhieuDKHP);
                return _dapperService.Query<MonHoc>(connection, "spMONHOC_GetMonHocPhieuDKHP", p, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
