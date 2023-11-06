using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class MonHocMoDALService : IMonHocMoDALService
    {
        private readonly IDbConnection _connection;

        public MonHocMoDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<HocKyNamHoc> GetAllHocKyNamHoc()
        {
            return _connection.Query<HocKyNamHoc>("spDANHSACHMONHOCMO_GetHocKyNamHoc").ToList();
        }

        public MessageAddMonHocMo AddMonHocMo(string MaMH, int MaHocKy, int NamHoc)
        {
            var p = new DynamicParameters();
            p.Add("@MaHocKy", MaHocKy);
            p.Add("@MaMH", MaMH);
            p.Add("@NamHoc", NamHoc);
            _connection.Execute("spDANHSACHMONHOCMO_AddMonHocMo", p, commandType: CommandType.StoredProcedure);

            return MessageAddMonHocMo.Success;
        }

        public List<int> GetAllNamHoc()
        {
            return _connection.Query<int>("spDANHSACHMONHOCMO_GetNam").ToList();
        }

        public MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int MaHocKy, int NamHoc)
        {
            var mhm = new DynamicParameters();
            mhm.Add("@MaHocKy", MaHocKy);
            mhm.Add("@NamHoc", NamHoc);
            _connection.Execute("spDANHSACHMONHOCMO_XoaDanhSach", mhm, commandType: CommandType.StoredProcedure);

            return MessageDeleteHocKyNamHocMHM.Success;
        }
    }
}
