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
    public class PhieuDKHPDALService : IPhieuDKHPDALService
	{
		private readonly IDapperService _dapperService;
		private readonly string _dbConnection;
		public PhieuDKHPDALService(IDapperService dapperService, string dbConnection)
		{
			_dapperService = dapperService;
			_dbConnection = dbConnection;
		}
		public List<PhieuDKHP> LayTTPhieuDKHP(string mssv, int maHocKy, int namHoc)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@mssv", mssv);
				parameters.Add("@MaHocKy", maHocKy);
				parameters.Add("@NamHoc", namHoc);
                return _dapperService.Query<PhieuDKHP>(connection, "spPHIEUDKHP_LayTTPhieuDKHP", parameters, commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public List<dynamic> LayDSMHThuocHP(int maPhieuDKHP)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@ma", maPhieuDKHP);

				return _dapperService.Query<dynamic>(connection, "spPHIEUDKHP_LayDSMHThuocHP", parameters, commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public int TinhHocPhi(int maPhieuDKHP)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@maPhieuDKHP", maPhieuDKHP);
				return _dapperService.QueryFirstOrDefault<int>(connection, "spPHIEUDKHP_TinhHocPhi", parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public float TinhHocPhiPhaiDong(int maPhieuDKHP)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@maPhieuDKHP", maPhieuDKHP);
				return _dapperService.QueryFirstOrDefault<float>(connection, "spPHIEUDKHP_TinhHocPhiPhaiDong", parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public float TinhHocPhiDaDong(int maPhieuDKHP)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@maPhieuDKHP", maPhieuDKHP);
				return _dapperService.QueryFirstOrDefault<float>(connection, "spPHIEUDKHP_TinhHocPhiDaDong", parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public float TinhHocPhiConThieu(int maPhieuDKHP)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@maPhieuDKHP", maPhieuDKHP);
				return _dapperService.QueryFirstOrDefault<float>(connection, "spPHIEUDKHP_TinhHocPhiConThieu", parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public List<dynamic> LayDSMHThuocHP2(int maPhieuDKHP)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@ma", maPhieuDKHP);

				return _dapperService.Query<dynamic>(connection, "spPHIEUDKHP_layDSMHThuocHP2", parameters, commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public bool TaoPhieuDKHP(string mssv, int hocKy, int namHoc)
		{
			int numRowsAffected;
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@maSV", mssv);
				parameters.Add("@hocKy", hocKy);
				parameters.Add("@namHoc", namHoc);
                numRowsAffected = _dapperService.Execute(connection, "spPHIEUDKHP_TaoPhieuDKHP ", parameters, commandType: CommandType.StoredProcedure);
			}

			if (numRowsAffected > 0)
				return true;
			else
				return false;
		}

		public int LayMaPhieuDKHP(int hocKy, int namHoc)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@maHocKy", hocKy);
				parameters.Add("@namHoc", namHoc);
				return _dapperService.QueryFirstOrDefault<int>(connection, "spPHIEUDKHP_LayMaPhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public List<PhieuDKHP> LayDanhSachDKHPDaXacNhan(string mssv)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@mssv", mssv);

				return _dapperService.Query<PhieuDKHP>(connection, "spPHIEUDKHP_LayDanhSachDKHPChoThanhToan", parameters, commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public List<PhieuDKHP> GetPhieuDKHP(int MaHocKy, int NamHoc, int MaTinhTrang)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var p = new DynamicParameters();
				p.Add("@MaHocKy", MaHocKy);
				p.Add("@NamHoc", NamHoc);
				p.Add("@MaTinhTrang", MaTinhTrang);
				return _dapperService.Query<PhieuDKHP>(connection, "spPHIEUDKHP_GetPhieuDKHP", p, commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public MessagePhieuDKHPUpdateTinhTrang PhieuDKHPUpdateTinhTrang(int MaPhieuDKHP, int MaTinhTrang)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@MaPhieuDKHP", MaPhieuDKHP);
					p.Add("@MaTinhTrang", MaTinhTrang);
					_dapperService.Execute(connection, "spPHIEUDKHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);
				}

				return MessagePhieuDKHPUpdateTinhTrang.Success;
			}
			catch (Exception)
			{
				return MessagePhieuDKHPUpdateTinhTrang.Failed;
			}
		}

		public List<PhieuDKHP> GetAllPhieuDKHP()
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				return _dapperService.Query<PhieuDKHP>(connection, "spPHIEUDKHP_GetAllPhieuDKHP").ToList();
			}
		}
	}
}
