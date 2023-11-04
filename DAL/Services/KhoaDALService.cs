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
            var p = new DynamicParameters();
            p.Add("@MaKhoaBanDau", maKhoaBanDau);
            p.Add("@MaKhoaSua", maKhoaSua);
            p.Add("@TenKhoaSua", tenKhoaSua);
            _dapperService.Execute("spKHOA_SuaKhoa", p, CommandType.StoredProcedure);

            return SuaKhoaMessage.Success;
        }

        public ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            var p = new DynamicParameters();
            p.Add("@MaKhoa", maKhoa);
            p.Add("@TenKhoa", tenKhoa);
            _dapperService.Execute("spKHOA_ThemKhoa", p, commandType: CommandType.StoredProcedure);

            return ThemKhoaMessage.Success;
        }

        public XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            var p = new DynamicParameters();
            p.Add("@MaKhoa", maKhoa);
            _dapperService.Execute("spKHOA_XoaKhoa", p, commandType: CommandType.StoredProcedure);

            return XoaKhoaMessage.Success;
        }
    }
}
