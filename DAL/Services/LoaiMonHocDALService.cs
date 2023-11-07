using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class LoaiMonHocDALService : ILoaiMonHocDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public LoaiMonHocDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<LoaiMonHoc> LayDSLoaiMonHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<LoaiMonHoc>(connection, "spLOAIMONHOC_LayDSLoaiMonHoc").ToList();
            }
        }

        public XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                int result = _dapperWrapper.Execute(connection, "spLOAIMONHOC_XoaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? XoaLoaiMonHocMessage.Success : XoaLoaiMonHocMessage.Failed;
            }
        }

        public SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                p.Add("@SoTien", soTien);
                int result = _dapperWrapper.Execute(connection, "spLOAIMONHOC_SuaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaLoaiMonHocMessage.Success : SuaLoaiMonHocMessage.Failed;
            }
        }

        public ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                p.Add("@SoTien", soTien);
                int result = _dapperWrapper.Execute(connection, "spLOAIMONHOC_ThemLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? ThemLoaiMonHocMessage.Success : ThemLoaiMonHocMessage.Failed;
            }
        }
    }
}
