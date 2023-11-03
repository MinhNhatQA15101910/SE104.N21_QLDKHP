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
    public class LoaiMonHocDALService : ILoaiMonHocDALService
    {
        private readonly IDapperService _dapperService;

        public LoaiMonHocDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<LoaiMonHoc> LayDSLoaiMonHoc()
        {
            return _dapperService.Query<LoaiMonHoc>("spLOAIMONHOC_LayDSLoaiMonHoc").ToList();
        }

        public XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                _dapperService.Execute("spLOAIMONHOC_XoaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return XoaLoaiMonHocMessage.Error;
            }

            return XoaLoaiMonHocMessage.Success;
        }

        public SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                p.Add("@SoTien", soTien);
                _dapperService.Execute("spLOAIMONHOC_SuaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("UQ_LOAIMONHOC_TenLoaiMonHoc"))
                {
                    return SuaLoaiMonHocMessage.DuplicateTenLoaiMonHoc;
                }
            }
            catch (Exception)
            {
                return SuaLoaiMonHocMessage.Error;
            }

            return SuaLoaiMonHocMessage.Success;
        }

        public ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                p.Add("@SoTien", soTien);
                _dapperService.Execute("spLOAIMONHOC_ThemLoaiMonHoc", p, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("UQ_LOAIMONHOC_TenLoaiMonHoc"))
                {
                    return ThemLoaiMonHocMessage.DuplicateTenLoaiMonHoc;
                }
            }
            catch (Exception)
            {
                return ThemLoaiMonHocMessage.Error;
            }

            return ThemLoaiMonHocMessage.Success;
        }
    }
}
