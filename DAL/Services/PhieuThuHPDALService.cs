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
    public class PhieuThuHPDALService : IPhieuThuHPDALService
	{
		private readonly IDapperService _dapperService;
		private readonly string _dbConnection;

		public PhieuThuHPDALService(IDapperService dapperService, string dbConnection)
		{
			_dapperService = dapperService;
			_dbConnection = dbConnection;
		}
		public DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@ma", maPhieuDKHP);
                return _dapperService.QueryFirstOrDefault<DateTime>(connection, "spPHIEUTHUHP_LayThoiGianDongHPGanNhat", parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP)
		{
			int numRowsAffected;
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@soTienThu", soTienThu);
				parameters.Add("@maPhieuDKHP", soPhieuDKHP);
				numRowsAffected = _dapperService.Execute(connection, "spPHIEUTHUHP_TaoPhieuThu_ChoXacNhan ", parameters, commandType: CommandType.StoredProcedure);
			}

			if (numRowsAffected > 0)
				return true;
			else
				return false;
		}

		public List<PhieuThuHP> GetPhieuThuHP(int MaTinhTrang)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var p = new DynamicParameters();
				p.Add("@MaTinhTrang", MaTinhTrang);
				return _dapperService.Query<PhieuThuHP>(connection, "spPHIEUTHUHP_GetPhieuThuHP", p, commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public MessagePhieuThuHPUpdateTinhTrang PhieuThuHPUpdateTinhTrang(int MaPhieuThuHP, int MaTinhTrang)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@MaPhieuThuHP", MaPhieuThuHP);
					p.Add("@MaTinhTrang", MaTinhTrang);
					_dapperService.Execute(connection, "spPHIEUTHUHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception)
			{
				return MessagePhieuThuHPUpdateTinhTrang.Failed;
			}
			return MessagePhieuThuHPUpdateTinhTrang.Success;
		}
	}
}
