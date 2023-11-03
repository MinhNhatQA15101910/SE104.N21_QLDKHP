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

        public KhoaDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<Khoa> LayDSKhoa()
        {
            return _dapperService.Query<Khoa>("spKHOA_LayDSKhoa").ToList();
        }

        public SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaKhoaBanDau", maKhoaBanDau);
                p.Add("@MaKhoaSua", maKhoaSua);
                p.Add("@TenKhoaSua", tenKhoaSua);
                _dapperService.Execute("spKHOA_SuaKhoa", p, CommandType.StoredProcedure);

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
                var p = new DynamicParameters();
                p.Add("@MaKhoa", maKhoa);
                p.Add("@TenKhoa", tenKhoa);
                _dapperService.Execute("spKHOA_ThemKhoa", p, commandType: CommandType.StoredProcedure);
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
                var p = new DynamicParameters();
                p.Add("@MaKhoa", maKhoa);
                _dapperService.Execute("spKHOA_XoaKhoa", p, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return XoaKhoaMessage.Error;
            }

            return XoaKhoaMessage.Success;
        }
    }
}
