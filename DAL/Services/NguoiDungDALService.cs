using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace DAL.Services
{
	public class NguoiDungDALService : INguoiDungDALService
	{
		private readonly IDapperService _dapperService;
		private readonly string _dbConnection;
		private static string ConvertToSHA512(string source)
		{
			byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
			byte[] hashBytes = SHA512.Create().ComputeHash(sourceBytes);
			string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

			return hash;
		}
		public NguoiDungDALService(IDapperService dapperService, string dbConnection)
		{
			_dapperService = dapperService;
			_dbConnection = dbConnection;
		}
		public List<CT_NguoiDung> LayDSNguoiDung()
		{
			List<CT_NguoiDung> output;
			using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
			{
				output = connection.Query<CT_NguoiDung>("spNGUOIDUNG_LayDSNguoiDung").ToList();
			}
			return output;
		}

		public DangNhapMessage DangNhap(string tenDangNhap, string matKhau)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", tenDangNhap);
					p.Add("@MatKhau", ConvertToSHA512(matKhau));
					GlobalConfig.CurrNguoiDung = connection.QuerySingleOrDefault<NguoiDung>("spNGUOIDUNG_LayBangTenDangNhapVaMatKhau", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception)
			{
				return DangNhapMessage.Error;
			}

			if (GlobalConfig.CurrNguoiDung == null)
			{
				return DangNhapMessage.Failed;
			}

			return DangNhapMessage.Success;
		}
		public XoaTaiKhoanMessage XoaTaiKhoan(string tenDangNhap)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", tenDangNhap);
					connection.Execute("spNGUOIDUNG_XoaTaiKhoan", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception)
			{
				return XoaTaiKhoanMessage.Error;
			}

			return XoaTaiKhoanMessage.Success;
		}

		public DoiMatKhauMessage DoiMatKhau(string matKhauHT, string matKhauMoi)
		{
			int rowsAffected = 0;

			try
			{
				using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", GlobalConfig.CurrNguoiDung.TenDangNhap);
					p.Add("@MatKhauHT", ConvertToSHA512(matKhauHT));
					p.Add("@MatKhauMoi", ConvertToSHA512(matKhauMoi));
					rowsAffected = connection.Execute("spNGUOIDUNG_DoiMatKhau", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception)
			{
				return DoiMatKhauMessage.Error;
			}

			if (rowsAffected == 0)
			{
				return DoiMatKhauMessage.Failed;
			}

			GlobalConfig.CurrNguoiDung.MatKhau = matKhauMoi;
			return DoiMatKhauMessage.Success;
		}

		public ThemTaiKhoanMessage ThemTaiKhoan(string tenDangNhap, string maNhom)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", tenDangNhap);
					p.Add("@MaNhom", maNhom);
					connection.Execute("spNGUOIDUNG_ThemTaiKhoan", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627)
				{
					if (ex.Message.Contains("PK_NGUOIDUNG"))
					{
						return ThemTaiKhoanMessage.DuplicateTenDangNhap;
					}
				}
			}
			catch (Exception)
			{
				return ThemTaiKhoanMessage.Error;
			}

			return ThemTaiKhoanMessage.Success;
		}

		public SuaTaiKhoanMessage SuaTaiKhoan(string tenDangNhapBD, string tenDangNhap, string maNhom)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhapBD", tenDangNhapBD);
					p.Add("@TenDangNhap", tenDangNhap);
					p.Add("@MaNhom", maNhom);
					connection.Execute("spNGUOIDUNG_SuaTaiKhoan", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627)
				{
					if (ex.Message.Contains("PK_NGUOIDUNG"))
					{
						return SuaTaiKhoanMessage.DuplicateTenDangNhap;
					}
				}
			}
			catch (Exception)
			{
				return SuaTaiKhoanMessage.Error;
			}

			return SuaTaiKhoanMessage.Success;
		}

		public ThemTaiKhoanSVMessage ThemTaiKhoanSV(IList<SinhVien> dssv)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
				{
					foreach (SinhVien sinhVien in dssv)
					{
						var p = new DynamicParameters();
						p.Add("@MaSV", sinhVien.MaSV);
						connection.Execute("spNGUOIDUNG_ThemTaiKhoanSV", p, commandType: CommandType.StoredProcedure);
					}
				}
			}
			catch (Exception)
			{
				return ThemTaiKhoanSVMessage.Error;
			}

			return ThemTaiKhoanSVMessage.Success;
		}
	}
}
