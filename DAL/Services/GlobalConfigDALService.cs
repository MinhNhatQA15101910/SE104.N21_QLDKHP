using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class GlobalConfigDALService : IGlobalConfigDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public GlobalConfigDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }

        public int GetCurrNamHoc()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.QueryFirst<int>(connection, "spGLOBALCONFIG_LayNamHocHienTai");
            }
        }

        public int LaySoTinChiToiDa()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.QueryFirst<int>(connection, "spGLOBALCONFIG_LaySoTinChiToiDa");
            }
        }

        public int LaySoTinChiToiThieu()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.QueryFirst<int>(connection, "spGLOBALCONFIG_LaySoTinChiToiThieu");
            }
        }

        public int GetCurrMaHocKy()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                var p = new DynamicParameters();
                p.Add("@NamHocHienTai", GlobalConfig.CurrNamHoc);
                return _dapperService.QueryFirst<int>(connection, "spGLOBALCONFIG_LayMaHocKyHienTai", p, commandType: CommandType.StoredProcedure);
            }
        }

        public SuaGioiHanTinChiMessage SuaGioiHanTinChi(int tinChiToiDa, int tinChiToiThieu)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@SoTinChiToiDa", tinChiToiDa);
                    p.Add("@SoTinChiToiThieu", tinChiToiThieu);
                    _dapperService.Execute(connection, "spGLOBALCONFIG_SuaGioiHanTinChi", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return SuaGioiHanTinChiMessage.Error;
            }

            return SuaGioiHanTinChiMessage.Success;
        }

        public int LayKhoangTGDongHP(int hocKy, int namHoc)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                return _dapperService.QueryFirstOrDefault<int>(connection, "spGLOBALCONFIG_LayKhoangTGDongHP", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public MessageKhoangTGDongHP KhoangTGDongHP(int MaHocKy, int NamHoc, int KhoangTG)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaHocKy", MaHocKy);
                    p.Add("@NamHoc", NamHoc);
                    p.Add("@KhoangTG", KhoangTG);
                    _dapperService.Execute(connection, "spKHOANGTGDONGHP_Add", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageKhoangTGDongHP.Failed;
            }
            return MessageKhoangTGDongHP.Success;

        }
    }
}
