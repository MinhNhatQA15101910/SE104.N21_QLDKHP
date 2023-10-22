using Dapper;
using DTO;
using DAL.IServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			DateTime output;

			using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@ma", maPhieuDKHP);
				output = connection.QueryFirstOrDefault<DateTime>("spPHIEUTHUHP_LayThoiGianDongHPGanNhat", parameters, commandType: CommandType.StoredProcedure);
			}

			return output;
		}

		public bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP)
		{
			int numRowsAffected;
			using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@soTienThu", soTienThu);
				parameters.Add("@maPhieuDKHP", soPhieuDKHP);
				numRowsAffected = connection.Execute("spPHIEUTHUHP_TaoPhieuThu_ChoXacNhan ", parameters, commandType: CommandType.StoredProcedure);
			}

			if (numRowsAffected > 0)
				return true;
			else
				return false;
		}

		public List<PhieuThuHP> GetPhieuThuHP(int MaTinhTrang)
		{
			List<PhieuThuHP> PhieuThuHP;
			using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
			{
				var p = new DynamicParameters();
				p.Add("@MaTinhTrang", MaTinhTrang);
				PhieuThuHP = connection.Query<PhieuThuHP>("spPHIEUTHUHP_GetPhieuThuHP", p, commandType: CommandType.StoredProcedure).ToList();
			}

			return PhieuThuHP;
		}

		public MessagePhieuThuHPUpdateTinhTrang PhieuThuHPUpdateTinhTrang(int MaPhieuThuHP, int MaTinhTrang)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
				{
					var p = new DynamicParameters();
					p.Add("@MaPhieuThuHP", MaPhieuThuHP);
					p.Add("@MaTinhTrang", MaTinhTrang);
					connection.Execute("spPHIEUTHUHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);
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
