using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class MonHocMoDALService : IMonHocMoDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public MonHocMoDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<HocKyNamHoc> GetAllHocKyNamHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<HocKyNamHoc>(connection, "spDANHSACHMONHOCMO_GetHocKyNamHoc").ToList();
            }
        }

        public MessageAddMonHocMo AddMonHocMo(string MaMH, int MaHocKy, int NamHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", MaHocKy);
                p.Add("@MaMH", MaMH);
                p.Add("@NamHoc", NamHoc);
                int result = _dapperWrapper.Execute(connection, "spDANHSACHMONHOCMO_AddMonHocMo", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessageAddMonHocMo.Success : MessageAddMonHocMo.Failed;
            }
        }

        public List<int> GetAllNamHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<int>(connection, "spDANHSACHMONHOCMO_GetNam").ToList();
            }
        }

        public MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int MaHocKy, int NamHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var mhm = new DynamicParameters();
                mhm.Add("@MaHocKy", MaHocKy);
                mhm.Add("@NamHoc", NamHoc);
                int result = _dapperWrapper.Execute(connection, "spDANHSACHMONHOCMO_XoaDanhSach", mhm, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessageDeleteHocKyNamHocMHM.Success : MessageDeleteHocKyNamHocMHM.Failed;
            }
        }
    }
}
