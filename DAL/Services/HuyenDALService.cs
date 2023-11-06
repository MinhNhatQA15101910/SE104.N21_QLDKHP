using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class HuyenDALService : IHuyenDALService
    {
        private readonly IDbConnection _connection;

        public HuyenDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<CT_Huyen> LayDSHuyen()
        {
            return _connection.Query<CT_Huyen>("spHUYEN_LayDSHuyen").ToList();
        }

        public SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            var p = new DynamicParameters();
            p.Add("@MaHuyen", maHuyen);
            p.Add("@TenHuyen", tenHuyen);
            p.Add("@VungUT", vungUT);
            p.Add("@MaTinh", maTinh);
            _connection.Execute("spHUYEN_SuaHuyen", p, commandType: CommandType.StoredProcedure);

            return SuaHuyenMessage.Success;
        }

        public XoaHuyenMessage XoaHuyen(int maHuyen)
        {
            var p = new DynamicParameters();
            p.Add("@MaHuyen", maHuyen);
            _connection.Execute("spHUYEN_XoaHuyen", p, commandType: CommandType.StoredProcedure);

            return XoaHuyenMessage.Success;
        }

        public ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh)
        {
            var p = new DynamicParameters();
            p.Add("@TenHuyen", tenHuyen);
            p.Add("@VungUT", vungUT);
            p.Add("@MaTinh", maTinh);
            _connection.Execute("spHUYEN_ThemHuyen", p, commandType: CommandType.StoredProcedure);

            return ThemHuyenMessage.Success;
        }
    }
}
