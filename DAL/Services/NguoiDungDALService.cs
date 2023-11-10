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
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public NguoiDungDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        private static string ConvertToSHA512(string source)
		{
			byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
			byte[] hashBytes = SHA512.Create().ComputeHash(sourceBytes);
			string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

			return hash;
		}

		public List<CT_NguoiDung> LayDSNguoiDung()
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<CT_NguoiDung>(connection, "spNGUOIDUNG_LayDSNguoiDung").ToList();
            }
        }

		public DangNhapMessage DangNhap(string tenDangNhap, string matKhau)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenDangNhap", tenDangNhap);
                p.Add("@MatKhau", ConvertToSHA512(matKhau));
                GlobalConfig.CurrNguoiDung = _dapperWrapper.QuerySingleOrDefault<NguoiDung>(connection, "spNGUOIDUNG_LayBangTenDangNhapVaMatKhau", p, commandType: CommandType.StoredProcedure);

                if (GlobalConfig.CurrNguoiDung == null)
                {
                    return DangNhapMessage.Failed;
                }

                return DangNhapMessage.Success;
            }
		}

		public XoaTaiKhoanMessage XoaTaiKhoan(string tenDangNhap)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenDangNhap", tenDangNhap);
                int result = _dapperWrapper.Execute(connection, "spNGUOIDUNG_XoaTaiKhoan", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? XoaTaiKhoanMessage.Success : XoaTaiKhoanMessage.Failed;
            }
		}

		public DoiMatKhauMessage DoiMatKhau(string tenDangNhap, string matKhauHT, string matKhauMoi)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenDangNhap", tenDangNhap);
                p.Add("@MatKhauHT", ConvertToSHA512(matKhauHT));
                p.Add("@MatKhauMoi", ConvertToSHA512(matKhauMoi));
                int rowsAffected = _dapperWrapper.Execute(connection, "spNGUOIDUNG_DoiMatKhau", p, commandType: CommandType.StoredProcedure);

                if (rowsAffected == 0)
                {
                    return DoiMatKhauMessage.Failed;
                }

                GlobalConfig.CurrNguoiDung.MatKhau = matKhauMoi;
                return DoiMatKhauMessage.Success;
            }
		}

		public ThemTaiKhoanMessage ThemTaiKhoan(string tenDangNhap, string maNhom)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenDangNhap", tenDangNhap);
                p.Add("@MaNhom", maNhom);
                int result = _dapperWrapper.Execute(connection, "spNGUOIDUNG_ThemTaiKhoan", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? ThemTaiKhoanMessage.Success : ThemTaiKhoanMessage.Failed;
            }
		}

		public SuaTaiKhoanMessage SuaTaiKhoan(string tenDangNhapBD, string tenDangNhap, string maNhom)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenDangNhapBD", tenDangNhapBD);
                p.Add("@TenDangNhap", tenDangNhap);
                p.Add("@MaNhom", maNhom);
                int result = _dapperWrapper.Execute(connection, "spNGUOIDUNG_SuaTaiKhoan", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaTaiKhoanMessage.Success : SuaTaiKhoanMessage.Failed;
            }
		}

		public ThemTaiKhoanSVMessage ThemTaiKhoanSV(IList<SinhVien> dssv)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                int rowsAffected = 0;

                foreach (SinhVien sinhVien in dssv)
                {
                    var p = new DynamicParameters();
                    p.Add("@MaSV", sinhVien.MaSV);
                    rowsAffected += _dapperWrapper.Execute(connection, "spNGUOIDUNG_ThemTaiKhoanSV", p, commandType: CommandType.StoredProcedure);
                }

                return (rowsAffected > 0) ? ThemTaiKhoanSVMessage.Success : ThemTaiKhoanSVMessage.Failed;
            }
		}
	}
}
