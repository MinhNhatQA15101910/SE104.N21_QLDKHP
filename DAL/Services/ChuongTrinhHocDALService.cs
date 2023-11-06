using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class ChuongTrinhHocDALService : IChuongTrinhHocDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public ChuongTrinhHocDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public MessageDeleteListCTHoc DeleteListCTHoc(string maNganh, int hocKy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var mhm = new DynamicParameters();
                mhm.Add("@MaNganh", maNganh);
                mhm.Add("@HocKy", hocKy);
                int result = _dapperWrapper.Execute(connection, "spCHUONGTRINHHOC_DeleteListCTHoc", mhm, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessageDeleteListCTHoc.Success : MessageDeleteListCTHoc.Failed;
            }
        }

        public List<ChuongTrinhHoc> GetAllCTHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<ChuongTrinhHoc>(connection, "spCHUONGTRINHHOC_GetAll").ToList();
            }
        }

        public MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var mhm = new DynamicParameters();
                mhm.Add("@MaMH", MaMH);
                mhm.Add("@MaNganh", MaNganh);
                mhm.Add("@HocKy", HocKy);
                int result = _dapperWrapper.Execute(connection, "spCHUONGTRINHHOC_DeleteCTHoc", mhm, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessageDeleteCTHoc.Success : MessageDeleteCTHoc.Failed;
            }
        }

        public MessageAddCTHoc AddCTHoc(ChuongTrinhHoc chuongTrinhHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var mhm = new DynamicParameters();
                mhm.Add("@MaMH", chuongTrinhHoc.MaMH);
                mhm.Add("@MaNganh", chuongTrinhHoc.MaNganh);
                mhm.Add("@HocKy", chuongTrinhHoc.HocKy);

                int result = _dapperWrapper.Execute(connection, "spCHUONGTRINHHOC_AddCTHoc", mhm, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessageAddCTHoc.Success : MessageAddCTHoc.Failed;
            }
        }
    }
}
