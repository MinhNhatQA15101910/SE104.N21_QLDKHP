using DAL.IServices;
using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class NhomNguoiDungDALService : INhomNguoiDungDALService
	{
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public NhomNguoiDungDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<NhomNguoiDung> LayDSNhomNguoiDung()
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<NhomNguoiDung>(connection, "spNHOMNGUOIDUNG_LayDSNhomNguoiDung").ToList();
            }
        }
	}
}
