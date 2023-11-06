using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DAL.Services
{
    public class KhoaDALService : IKhoaDALService
    {
        // LayDSKhoa
        private const string LayDSKhoaSP = "spKHOA_LayDSKhoa";
        private const string SuaKhoaSP = "spKHOA_SuaKhoa";

        private readonly IDbConnection _connection;
        private DynamicParameters dynamicParameters = new DynamicParameters();

        public KhoaDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<Khoa> LayDSKhoa()
        {
            return _connection.Query<Khoa>(LayDSKhoaSP).ToList();
        }

        public SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            AssignDynamicParametersForSuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            var result = _connection.Execute(SuaKhoaSP, dynamicParameters, commandType: CommandType.StoredProcedure);

            return (result > 0) ? SuaKhoaMessage.Success : SuaKhoaMessage.Failed;
        }

        public ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            var p = new DynamicParameters();
            p.Add("@MaKhoa", maKhoa);
            p.Add("@TenKhoa", tenKhoa);
            _connection.Execute("spKHOA_ThemKhoa", p, commandType: CommandType.StoredProcedure);

            return ThemKhoaMessage.Success;
        }

        public XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            var p = new DynamicParameters();
            p.Add("@MaKhoa", maKhoa);
            _connection.Execute("spKHOA_XoaKhoa", p, commandType: CommandType.StoredProcedure);

            return XoaKhoaMessage.Success;
        }

        [ExcludeFromCodeCoverage]
        private void AssignDynamicParametersForSuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@MaKhoaBanDau", maKhoaBanDau);
            dynamicParameters.Add("@MaKhoaSua", maKhoaSua);
            dynamicParameters.Add("@TenKhoaSua", tenKhoaSua);
        }
    }
}
