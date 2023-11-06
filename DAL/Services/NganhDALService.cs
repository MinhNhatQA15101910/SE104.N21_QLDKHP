using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class NganhDALService : INganhDALService
    {
        private readonly IDbConnection _connection;

        public NganhDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<CT_Nganh> LayDSNganh()
        {
            return _connection.Query<CT_Nganh>("spNGANH_LayDSNganh").ToList();
        }

        public XoaNganhMessage XoaNganh(string maNganh)
        {
            var p = new DynamicParameters();
            p.Add("@MaNganh", maNganh);
            _connection.Execute("spNGANH_XoaNganh", p, commandType: CommandType.StoredProcedure);

            return XoaNganhMessage.Success;
        }

        public SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            var p = new DynamicParameters();
            p.Add("@MaNganhBanDau", maNganhBanDau);
            p.Add("@MaNganh", maNganhSua);
            p.Add("@TenNganh", tenNganhSua);
            p.Add("@MaKhoa", maKhoaSua);
            _connection.Execute("spNGANH_SuaNganh", p, commandType: CommandType.StoredProcedure);

            return SuaNganhMessage.Success;
        }

        public ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            var p = new DynamicParameters();
            p.Add("@MaNganh", maNganh);
            p.Add("@TenNganh", tenNganh);
            p.Add("@MaKhoa", maKhoa);
            _connection.Execute("spNGANH_ThemNganh", p, commandType: CommandType.StoredProcedure);

            return ThemNganhMessage.Success;
        }

        public List<Nganh> GetNganh(string maKhoa)
        {
            if (maKhoa != null)
            {
                var p = new DynamicParameters();
                p.Add("@MaKhoa", maKhoa);
                return _connection.Query<Nganh>("spNGANH_LayNganhBangMaKhoa", p, commandType: CommandType.StoredProcedure).ToList();
            }
            else
            {
                return _connection.Query<Nganh>("spNGANH_LayDSNganh").ToList();
            }

        }
    }
}
