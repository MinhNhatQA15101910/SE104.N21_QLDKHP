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
    public class SinhVienDALService : ISinhVienDALService
	{
		private readonly IDapperService _dapperService;
		private readonly string _dbConnection;
		public SinhVienDALService(IDapperService dapperService, string dbConnection)
		{
			_dapperService = dapperService;
			_dbConnection = dbConnection;
		}
		public List<SinhVien> LayDSSVChuaCoTK()
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				return _dapperService.Query<SinhVien>(connection, "spSINHVIEN_LayDSSVChuaCoTK").ToList();
			}
		}

		public List<CT_SinhVien> LayDSSV()
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				return _dapperService.Query<CT_SinhVien>(connection, "spSINHVIEN_LayDSSV").ToList();
			}
		}

		public SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@MaSV", mssvBanDau);
					p.Add("@HoTen", hoTen);
					p.Add("@NgaySinh", ngaySinh);
					p.Add("@GioiTinh", gioiTinh);
					p.Add("@MaHuyen", maHuyen);
					p.Add("@MaNganh", maNganh);
					_dapperService.Execute(connection, "spSINHVIEN_SuaSinhVien", p, commandType: CommandType.StoredProcedure);

					p = new DynamicParameters();
					p.Add("@MaSV", mssvBanDau);
					_dapperService.Execute(connection, "spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

					foreach (int maDT in maDTList)
					{
						p = new DynamicParameters();
						p.Add("@MaSV", mssv);
						p.Add("@MaDT", maDT);
						_dapperService.Execute(connection, "spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
					}
				}
			}
			catch (Exception)
			{
				return SuaSinhVienMessage.Error;
			}

			return SuaSinhVienMessage.Success;
		}

		public ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@MaSV", mssv);
					p.Add("@HoTen", hoTen);
					p.Add("@NgaySinh", ngaySinh);
					p.Add("@GioiTinh", gioiTinh);
					p.Add("@MaHuyen", maHuyen);
					p.Add("@MaNganh", maNganh);
					_dapperService.Execute(connection, "spSINHVIEN_ThemSinhVien", p, commandType: CommandType.StoredProcedure);

					foreach (int maDT in maDTList)
					{
						p = new DynamicParameters();
						p.Add("@MaSV", mssv);
						p.Add("@MaDT", maDT);
						_dapperService.Execute(connection, "spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
					}
				}
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627)
				{
					if (ex.Message.Contains("PK_SINHVIEN"))
					{
						return ThemSinhVienMessage.DuplicateMaSV;
					}
				}
			}
			catch (Exception)
			{
				return ThemSinhVienMessage.Error;
			}

			return ThemSinhVienMessage.Success;
		}

		public XoaSinhVienMessage XoaSinhVien(string maSV)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@MaSV", maSV);
					_dapperService.Execute(connection, "spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
					_dapperService.Execute(connection, "spCT_PHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
					_dapperService.Execute(connection, "spPHIEUTHUHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
					_dapperService.Execute(connection, "spPHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
					_dapperService.Execute(connection, "spSINHVIEN_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

				}
			}
			catch (Exception)
			{
				return XoaSinhVienMessage.Error;
			}

			return XoaSinhVienMessage.Success;
		}

		public string LayTenSV(string mssv)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@mssv", mssv);
				return _dapperService.QueryFirstOrDefault<string>(connection, "spSINHVIEN_LayTenSV", parameters, commandType: CommandType.StoredProcedure).ToString();
			}
		}

		public List<dynamic> LayThongTinSV(string mssv)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@mssv", mssv);
				return _dapperService.Query<dynamic>(connection, "spSINHVIEN_LayThongTinSV", parameters, commandType: CommandType.StoredProcedure).ToList();
			}
		}

		public List<dynamic> BaoCaoSinhVienChuaDongHocPhi(int hocKy, int namHoc)
		{
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@hocKy", hocKy);
				parameters.Add("@namHoc", namHoc);

				return _dapperService.Query<dynamic>(connection, "spSINHVIEN_BaoCao", parameters, commandType: CommandType.StoredProcedure).ToList();
			}
		}
	}
}
