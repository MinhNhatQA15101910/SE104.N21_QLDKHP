﻿using DAL.IServices;
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

        public NganhDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<CT_Nganh> LayDSNganh()
        {
            return _dapperService.Query<CT_Nganh>("spNGANH_LayDSNganh").ToList();
        }

        public XoaNganhMessage XoaNganh(string maNganh)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaNganh", maNganh);
                _dapperService.Execute("spNGANH_XoaNganh", p, CommandType.StoredProcedure);
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
                var p = new DynamicParameters();
                p.Add("@MaNganhBanDau", maNganhBanDau);
                p.Add("@MaNganh", maNganhSua);
                p.Add("@TenNganh", tenNganhSua);
                p.Add("@MaKhoa", maKhoaSua);
                _dapperService.Execute("spNGANH_SuaNganh", p, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("UQ_NGANH_TenNganh"))
                {
                    return SuaNganhMessage.DuplicateTenNganh;
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
                var p = new DynamicParameters();
                p.Add("@MaNganh", maNganh);
                p.Add("@TenNganh", tenNganh);
                p.Add("@MaKhoa", maKhoa);
                _dapperService.Execute("spNGANH_ThemNganh", p, commandType: CommandType.StoredProcedure);
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
                var p = new DynamicParameters();
                p.Add("@MaKhoa", MaKhoa);
                return _dapperService.Query<Nganh>("spNGANH_LayNganhBangMaKhoa", p, commandType: CommandType.StoredProcedure).ToList();
            }
            else
            {
                return _dapperService.Query<Nganh>("spNGANH_LayDSNganh").ToList();
            }

        }
    }
}
