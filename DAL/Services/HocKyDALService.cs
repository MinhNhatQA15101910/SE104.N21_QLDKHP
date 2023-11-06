using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class HocKyDALService: IHocKyDALService
    {
        private readonly IDbConnection _connection;

        public HocKyDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<HocKy> LayDanhSachHK()
        {
            return _connection.Query<HocKy>("spHOCKY_LayDanhSachHK").ToList();
        }

        public string LayHKByMaHK(int currMaHocKy)
        {
            var p = new DynamicParameters();
            p.Add("@MaHocKy", currMaHocKy);
            return _connection.Query<string>("spHOCKY_LayHKByMaHK", p, commandType: CommandType.StoredProcedure).ToString();
        }
    }
}
