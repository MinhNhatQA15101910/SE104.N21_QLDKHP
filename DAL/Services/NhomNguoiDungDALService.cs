using DAL.IServices;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class NhomNguoiDungDALService : INhomNguoiDungDALService
	{
		private readonly IDapperService _dapperService;
		private readonly string _dbConnection;

		public NhomNguoiDungDALService(IDapperService dapperService, string dbConnection)
		{
			_dapperService = dapperService;
			_dbConnection = dbConnection;
		}
		public List<NhomNguoiDung> LayDSNhomNguoiDung()
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				return _dapperService.Query<NhomNguoiDung>(connection, "spNHOMNGUOIDUNG_LayDSNhomNguoiDung").ToList();
			}
		}
	}
}
