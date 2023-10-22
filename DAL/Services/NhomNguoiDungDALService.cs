using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
			List<NhomNguoiDung> output;
			using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
			{
				output = connection.Query<NhomNguoiDung>("spNHOMNGUOIDUNG_LayDSNhomNguoiDung").ToList();
			}
			return output;
		}
	}
}
