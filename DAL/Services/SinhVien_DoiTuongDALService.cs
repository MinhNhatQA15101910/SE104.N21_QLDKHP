using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class SinhVien_DoiTuongDALService : ISinhVien_DoiTuongDALService
    {
        private readonly IDbConnection _connection;

        public SinhVien_DoiTuongDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<SinhVien_DoiTuong> GetSinhVien_DoiTuongs()
        {
            return _connection.Query<SinhVien_DoiTuong>("spSINHVIEN_DOITUONG_GetSinhVien_DoiTuongs").ToList();
        }
    }
}
