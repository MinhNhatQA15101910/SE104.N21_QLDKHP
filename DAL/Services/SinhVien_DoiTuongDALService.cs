using DAL.IServices;
using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class SinhVien_DoiTuongDALService : ISinhVien_DoiTuongDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public SinhVien_DoiTuongDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<SinhVien_DoiTuong> GetSinhVien_DoiTuongs()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<SinhVien_DoiTuong>(connection, "spSINHVIEN_DOITUONG_GetSinhVien_DoiTuongs").ToList();
            }
        }
    }
}
