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
    public class NganhDALService : INganhDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public NganhDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }

        public List<CT_Nganh> LayDSNganh()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.Query<CT_Nganh>(connection, "spNGANH_LayDSNganh").ToList();
            }
        }

        public XoaNganhMessage XoaNganh(string maNganh)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", maNganh);
                    _dapperService.Execute(connection, "spNGANH_XoaNganh", p, CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaNganhMessage.Error;
            }

            return XoaNganhMessage.Success;
        }

        public SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganhBanDau", maNganhBanDau);
                    p.Add("@MaNganh", maNganhSua);
                    p.Add("@TenNganh", tenNganhSua);
                    p.Add("@MaKhoa", maKhoaSua);
                    _dapperService.Execute(connection, "spNGANH_SuaNganh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_NGANH_TenNganh"))
                    {
                        return SuaNganhMessage.DuplicateTenNganh;
                    }
                }
            }
            catch (Exception)
            {
                return SuaNganhMessage.Error;
            }

            return SuaNganhMessage.Success;
        }

        public ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", maNganh);
                    p.Add("@TenNganh", tenNganh);
                    p.Add("@MaKhoa", maKhoa);
                    _dapperService.Execute(connection, "spNGANH_ThemNganh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("PK_NGANH"))
                    {
                        return ThemNganhMessage.DuplicateMaNganh;
                    }
                    else if (ex.Message.Contains("UQ_NGANH_TenNganh"))
                    {
                        return ThemNganhMessage.DuplicateTenNganh;
                    }
                }
            }
            catch (Exception)
            {
                return ThemNganhMessage.Error;
            }

            return ThemNganhMessage.Success;
        }

        public List<Nganh> GetNganh(string MaKhoa)
        {
            if (MaKhoa != null)
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoa", MaKhoa);
                    return _dapperService.Query<Nganh>(connection, "spNGANH_LayNganhBangMaKhoa", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            else
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    return _dapperService.Query<Nganh>(connection, "spNGANH_LayDSNganh").ToList();
                }
            }

        }
    }
}
