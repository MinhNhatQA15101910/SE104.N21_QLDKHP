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
            var p = new DynamicParameters();
            p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
            _dapperService.Execute("spLOAIMONHOC_XoaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

            return XoaLoaiMonHocMessage.Success;
        }

        public SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            var p = new DynamicParameters();
            p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
            p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
            p.Add("@SoTiet", soTiet);
            p.Add("@SoTien", soTien);
            _dapperService.Execute("spLOAIMONHOC_SuaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

            return SuaLoaiMonHocMessage.Success;
        }

        public ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            var p = new DynamicParameters();
            p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
            p.Add("@SoTiet", soTiet);
            p.Add("@SoTien", soTien);
            _dapperService.Execute("spLOAIMONHOC_ThemLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

            return ThemLoaiMonHocMessage.Success;
        }
    }
}
