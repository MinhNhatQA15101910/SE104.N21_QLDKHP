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
    public class KhoaDALService : IKhoaDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public KhoaDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }

        public List<Khoa> LayDSKhoa()
        {
            using (var connection = new SqlConnection(_dbConnection))
            {
                List<Khoa> result = _dapperService.Query<Khoa>(connection, "spKHOA_LayDSKhoa").ToList();
                return result;
            }
        }

        public SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            try
            {
                using (var connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoaBanDau", maKhoaBanDau);
                    p.Add("@MaKhoaSua", maKhoaSua);
                    p.Add("@TenKhoaSua", tenKhoaSua);
                    _dapperService.Execute(connection, "spKHOA_SuaKhoa", p, CommandType.StoredProcedure);
                }

                return SuaKhoaMessage.Success;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_KHOA_TenKhoa"))
                    {
                        return SuaKhoaMessage.DuplicateTenKhoa;
                    }
                       
                    return SuaKhoaMessage.DuplicateMaKhoa;
                }

                return SuaKhoaMessage.Error;
            }
        }

        public ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            try
            {
                using (var connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoa", maKhoa);
                    p.Add("@TenKhoa", tenKhoa);
                    _dapperService.Execute(connection, "spKHOA_ThemKhoa", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("PK_KHOA"))
                    {
                        return ThemKhoaMessage.DuplicateMaKhoa;
                    }
                    else if (ex.Message.Contains("UQ_KHOA_TenKhoa"))
                    {
                        return ThemKhoaMessage.DuplicateTenKhoa;
                    }
                }
            }
            catch (Exception)
            {
                return ThemKhoaMessage.Error;
            }

            return ThemKhoaMessage.Success;
        }

        public XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            try
            {
                using (var connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoa", maKhoa);
                    _dapperService.Execute(connection, "spKHOA_XoaKhoa", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaKhoaMessage.Error;
            }

            return XoaKhoaMessage.Success;
        }
    }
}
