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
    public class MonHocMoDALService : IMonHocMoDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public MonHocMoDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }

        public List<HocKyNamHoc> GetAllHocKyNamHoc()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.Query<HocKyNamHoc>(connection, "spDANHSACHMONHOCMO_GetHocKyNamHoc").ToList();
            }
        }

        public MessageAddMonHocMo AddMonHocMo(string MaMH, int MaHocKy, int NamHoc)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaHocKy", MaHocKy);
                    p.Add("@MaMH", MaMH);
                    p.Add("@NamHoc", NamHoc);
                    _dapperService.Execute(connection, "spDANHSACHMONHOCMO_AddMonHocMo", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageAddMonHocMo.Failed;
            }
            return MessageAddMonHocMo.Success;
        }

        public List<int> GetAllNamHoc()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.Query<int>(connection, "spDANHSACHMONHOCMO_GetNam").ToList();
            }
        }

        public MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int MaHocKy, int NamHoc)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaHocKy", MaHocKy);
                    mhm.Add("@NamHoc", NamHoc);
                    _dapperService.Execute(connection, "spDANHSACHMONHOCMO_XoaDanhSach", mhm, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageDeleteHocKyNamHocMHM.Failed;
            }
            return MessageDeleteHocKyNamHocMHM.Success;
        }
    }
}
