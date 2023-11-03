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
    public class HuyenDALService : IHuyenDALService
    {
        private readonly IDapperService _dapperService;

        public HuyenDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<CT_Huyen> LayDSHuyen()
        {
            return _dapperService.Query<CT_Huyen>("spHUYEN_LayDSHuyen").ToList();
        }

        public SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaHuyen", maHuyen);
                p.Add("@TenHuyen", tenHuyen);
                p.Add("@VungUT", vungUT);
                p.Add("@MaTinh", maTinh);
                _dapperService.Execute("spHUYEN_SuaHuyen", p, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("UQ_HUYEN_TenHuyen"))
                {
                    return SuaHuyenMessage.DuplicateTenHuyen;
                }
            }
            catch (Exception)
            {
                return SuaHuyenMessage.Error;
            }

            return SuaHuyenMessage.Success;
        }

        public XoaHuyenMessage XoaHuyen(int maHuyen)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaHuyen", maHuyen);
                _dapperService.Execute("spHUYEN_XoaHuyen", p, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return XoaHuyenMessage.Error;
            }

            return XoaHuyenMessage.Success;
        }

        public ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@TenHuyen", tenHuyen);
                p.Add("@VungUT", vungUT);
                p.Add("@MaTinh", maTinh);
                _dapperService.Execute("spHUYEN_ThemHuyen", p, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("UQ_HUYEN_TenHuyen"))
                {
                    return ThemHuyenMessage.DuplicateTenHuyen;
                }
            }
            catch (Exception)
            {
                return ThemHuyenMessage.Error;
            }

            return ThemHuyenMessage.Success;
        }
    }
}
