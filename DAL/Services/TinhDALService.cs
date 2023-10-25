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
    public class TinhDALService : ITinhDALService
	{
		private readonly IDapperService _dapperService;
		private readonly string _dbConnection;

		public TinhDALService(IDapperService dapperService, string dbConnection)
		{
			_dapperService = dapperService;
			_dbConnection = dbConnection;
		}
		public List<Tinh> LayDSTinh()
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				return _dapperService.Query<Tinh>(connection, "spTINH_LayDSTinh").ToList();
			}
		}

		public SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@MaTinh", maTinh);
					p.Add("@TenTinh", tenTinh);
                    _dapperService.Execute(connection, "spTINH_SuaTinh", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627 && ex.Message.Contains("UQ_TINH_TenTinh"))
				{
					return SuaTinhMessage.DuplicateTenTinh;
				}
			}
			catch (Exception)
			{
				return SuaTinhMessage.Error;
			}

			return SuaTinhMessage.Success;
		}

		public XoaTinhMessage XoaTinh(int maTinh)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@MaTinh", maTinh);
                    _dapperService.Execute(connection, "spTINH_XoaTinh", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception)
			{
				return XoaTinhMessage.Error;
			}

			return XoaTinhMessage.Success;
		}

		public ThemTinhMessage ThemTinh(string tenTinh)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@TenTinh", tenTinh);
					_dapperService.Execute(connection, "spTINH_ThemTinh", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627 && ex.Message.Contains("UQ_TINH_TenTTP"))
				{
					return ThemTinhMessage.DuplicateTenTinh;
				}
			}
			catch (Exception)
			{
				return ThemTinhMessage.Error;
			}

			return ThemTinhMessage.Success;
		}
	}
}
