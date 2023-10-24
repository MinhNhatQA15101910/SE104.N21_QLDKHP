using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class DoiTuongDALService: IDoiTuongDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public DoiTuongDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }

        public List<DoiTuong> LayDSDoiTuong()
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString))
            {
                return _dapperService.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuong").ToList();
            }
        }

        public SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, float tiLeGiam)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaDT", maDTBanDau);
                    p.Add("@TenDT", tenDT);
                    p.Add("@TiLeGiamHocPhi", tiLeGiam);
                    _dapperService.Execute(connection, "spDOITUONG_SuaDoiTuong", p, CommandType.StoredProcedure);
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

        public ThemDoiTuongMessage ThemDoiTuong(string tenDT, float tiLeGiam)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@TenDT", tenDT);
                    p.Add("@TiLeGiamHocPhi", tiLeGiam);
                    _dapperService.Execute(connection, "spDOITUONG_ThemDoiTuong", p, CommandType.StoredProcedure);
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

        public List<DoiTuong> LayDSDoiTuong2()
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                return _dapperService.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuong").ToList();
            }
        }

        public List<DoiTuong> LayDSDoiTuongKhongThuocVeMaSV(string maSV)
        {

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);
                return _dapperService.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuongKhongThuocVeMaSV", p, CommandType.StoredProcedure).ToList();
            }
        }

        public List<DoiTuong> LayDSDoiTuongBangMaSV(string maSV)
        {
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);
                return _dapperService.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuongBangMaSV", p, CommandType.StoredProcedure).ToList();
            }
        }

        public XoaDoiTuongMessage XoaDoiTuong(int maDT)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaDT", maDT);
                    _dapperService.Execute(connection, "spDOITUONG_XoaDoiTuong", p, CommandType.StoredProcedure);
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
