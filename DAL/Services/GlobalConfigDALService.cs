﻿using DAL.IServices;
using Dapper;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class GlobalConfigDALService : IGlobalConfigDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public GlobalConfigDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public int GetCurrNamHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.QueryFirst<int>(connection, "spGLOBALCONFIG_LayNamHocHienTai");
            }
        }

        public int LaySoTinChiToiDa()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.QueryFirst<int>(connection, "spGLOBALCONFIG_LaySoTinChiToiDa");
            }
        }

        public int LaySoTinChiToiThieu()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.QueryFirst<int>(connection, "spGLOBALCONFIG_LaySoTinChiToiThieu");
            }
        }

        public int GetCurrMaHocKy(int namHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@NamHocHienTai", namHoc);
                return _dapperWrapper.QueryFirst<int>(connection, "spGLOBALCONFIG_LayMaHocKyHienTai", p, commandType: CommandType.StoredProcedure);
            }
        }

        public SuaGioiHanTinChiMessage SuaGioiHanTinChi(int tinChiToiDa, int tinChiToiThieu)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@SoTinChiToiDa", tinChiToiDa);
                p.Add("@SoTinChiToiThieu", tinChiToiThieu);
                int result = _dapperWrapper.Execute(connection, "spGLOBALCONFIG_SuaGioiHanTinChi", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaGioiHanTinChiMessage.Success : SuaGioiHanTinChiMessage.Failed;
            }
        }

        public int LayKhoangTGDongHP(int hocKy, int namHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                return _dapperWrapper.QueryFirstOrDefault<int>(connection, "spGLOBALCONFIG_LayKhoangTGDongHP", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public MessageKhoangTGDongHP KhoangTGDongHP(int maHocKy, int namHoc, int khoangTG)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", maHocKy);
                p.Add("@NamHoc", namHoc);
                p.Add("@KhoangTG", khoangTG);
                int result = _dapperWrapper.Execute(connection, "spKHOANGTGDONGHP_Add", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessageKhoangTGDongHP.Success : MessageKhoangTGDongHP.Failed;
            }
        }
    }
}
