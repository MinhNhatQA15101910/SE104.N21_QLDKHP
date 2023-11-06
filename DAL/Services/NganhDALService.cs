using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class NganhDALService : INganhDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public NganhDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<CT_Nganh> LayDSNganh()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<CT_Nganh>(connection, "spNGANH_LayDSNganh").ToList();
            }
        }

        public XoaNganhMessage XoaNganh(string maNganh)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaNganh", maNganh);
                int result = _dapperWrapper.Execute(connection, "spNGANH_XoaNganh", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? XoaNganhMessage.Success : XoaNganhMessage.Failed;
            }
        }

        public SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaNganhBanDau", maNganhBanDau);
                p.Add("@MaNganh", maNganhSua);
                p.Add("@TenNganh", tenNganhSua);
                p.Add("@MaKhoa", maKhoaSua);
                int result = _dapperWrapper.Execute(connection, "spNGANH_SuaNganh", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaNganhMessage.Success : SuaNganhMessage.Failed;
            }
        }

        public ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaNganh", maNganh);
                p.Add("@TenNganh", tenNganh);
                p.Add("@MaKhoa", maKhoa);
                int result = _dapperWrapper.Execute(connection, "spNGANH_ThemNganh", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? ThemNganhMessage.Success : ThemNganhMessage.Failed;
            }
        }

        public List<Nganh> GetNganh(string maKhoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                if (maKhoa != null)
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoa", maKhoa);
                    return _dapperWrapper.Query<Nganh>(connection, "spNGANH_LayNganhBangMaKhoa", p, commandType: CommandType.StoredProcedure).ToList();
                }
                else
                {
                    return _dapperWrapper.Query<Nganh>(connection, "spNGANH_LayDSNganh").ToList();
                }
            }
        }
    }
}
