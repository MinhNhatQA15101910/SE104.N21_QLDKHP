using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


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
			using (IDbConnection connection = new SqlConnection(_dbConnection))
			{
				return _dapperService.Query<CT_NguoiDung>(connection, "spNGUOIDUNG_LayDSNguoiDung").ToList();
			}
		}

		public DangNhapMessage DangNhap(string tenDangNhap, string matKhau)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", tenDangNhap);
					p.Add("@MatKhau", ConvertToSHA512(matKhau));
					GlobalConfig.CurrNguoiDung = _dapperService.QuerySingleOrDefault<NguoiDung>(connection, "spNGUOIDUNG_LayBangTenDangNhapVaMatKhau", p, commandType: CommandType.StoredProcedure);
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
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", tenDangNhap);
					_dapperService.Execute(connection, "spNGUOIDUNG_XoaTaiKhoan", p, commandType: CommandType.StoredProcedure);
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
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", GlobalConfig.CurrNguoiDung.TenDangNhap);
					p.Add("@MatKhauHT", ConvertToSHA512(matKhauHT));
					p.Add("@MatKhauMoi", ConvertToSHA512(matKhauMoi));
					rowsAffected = _dapperService.Execute(connection, "spNGUOIDUNG_DoiMatKhau", p, commandType: CommandType.StoredProcedure);
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
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhap", tenDangNhap);
					p.Add("@MaNhom", maNhom);
					_dapperService.Execute(connection, "spNGUOIDUNG_ThemTaiKhoan", p, commandType: CommandType.StoredProcedure);
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
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					var p = new DynamicParameters();
					p.Add("@TenDangNhapBD", tenDangNhapBD);
					p.Add("@TenDangNhap", tenDangNhap);
					p.Add("@MaNhom", maNhom);
					_dapperService.Execute(connection, "spNGUOIDUNG_SuaTaiKhoan", p, commandType: CommandType.StoredProcedure);
				}
			}
			catch (SqlException ex)
			{
                if (ex.Number == 2627 && ex.Message.Contains("PK_NGUOIDUNG"))
                {
                    return SuaTaiKhoanMessage.DuplicateTenDangNhap;
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
				using (IDbConnection connection = new SqlConnection(_dbConnection))
				{
					foreach (SinhVien sinhVien in dssv)
					{
						var p = new DynamicParameters();
						p.Add("@MaSV", sinhVien.MaSV);
						_dapperService.Execute(connection, "spNGUOIDUNG_ThemTaiKhoanSV", p, commandType: CommandType.StoredProcedure);
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
