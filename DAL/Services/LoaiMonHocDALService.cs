using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class LoaiMonHocDALService : ILoaiMonHocDALService
    {
        private readonly IDbConnection _connection;

        public LoaiMonHocDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<LoaiMonHoc> LayDSLoaiMonHoc()
        {
            return _connection.Query<LoaiMonHoc>("spLOAIMONHOC_LayDSLoaiMonHoc").ToList();
        }

        public XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc)
        {
            var p = new DynamicParameters();
            p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
            _connection.Execute("spLOAIMONHOC_XoaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

            return XoaLoaiMonHocMessage.Success;
        }

        public SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            var p = new DynamicParameters();
            p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
            p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
            p.Add("@SoTiet", soTiet);
            p.Add("@SoTien", soTien);
            _connection.Execute("spLOAIMONHOC_SuaLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

            return SuaLoaiMonHocMessage.Success;
        }

        public ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            var p = new DynamicParameters();
            p.Add("@TenLoaiMonHoc", tenLoaiMonHoc);
            p.Add("@SoTiet", soTiet);
            p.Add("@SoTien", soTien);
            _connection.Execute("spLOAIMONHOC_ThemLoaiMonHoc", p, commandType: CommandType.StoredProcedure);

            return ThemLoaiMonHocMessage.Success;
        }
    }
}
