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
    public class ChuongTrinhHocDALService: IChuongTrinhHocDALService
    {
        private readonly IDapperService _dapperService;
        private readonly string _dbConnection;

        public ChuongTrinhHocDALService(IDapperService dapperService, string dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }
        public MessageDeleteListCTHoc DeleteListCTHoc(string MaNganh, int HocKy)
        {
            ChuongTrinhHoc CTHoc = new ChuongTrinhHoc();
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaNganh", MaNganh);
                    mhm.Add("@HocKy", HocKy);
                    _dapperService.Execute(connection, "spCHUONGTRINHHOC_DeleteListCTHoc", mhm, CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageDeleteListCTHoc.Failed;
            }
            if (CTHoc == null) return MessageDeleteListCTHoc.ErrorData;
            return MessageDeleteListCTHoc.Success;
        }

        public List<ChuongTrinhHoc> GetAllCTHoc()
        {

            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                return _dapperService.Query<ChuongTrinhHoc>(connection, "spCHUONGTRINHHOC_GetAll").ToList();    
            }

        }

        public MessageAddCTHoc AddCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            ChuongTrinhHoc CTHoc = new ChuongTrinhHoc();
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaMH", MaMH);
                    mhm.Add("@MaNganh", MaNganh);
                    mhm.Add("@HocKy", HocKy);
                    _dapperService.Execute(connection, "spCHUONGTRINHHOC_AddCTHoc", mhm, CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageAddCTHoc.Failed;
            }
            if (CTHoc == null) return MessageAddCTHoc.ErrorData;
            return MessageAddCTHoc.Success;
        }

        public MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            ChuongTrinhHoc CTHoc = new ChuongTrinhHoc();
            try
            {
                using (IDbConnection connection = new SqlConnection(_dbConnection))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaMH", MaMH);
                    mhm.Add("@MaNganh", MaNganh);
                    mhm.Add("@HocKy", HocKy);
                    _dapperService.Execute(connection, "spCHUONGTRINHHOC_DeleteCTHoc", mhm, CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageDeleteCTHoc.Failed;
            }
            if (CTHoc == null) return MessageDeleteCTHoc.ErrorData;
            return MessageDeleteCTHoc.Success;
        }
    }
}
