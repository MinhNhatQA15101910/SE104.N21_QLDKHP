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

		private static string ConvertToSHA512(string source)
		{
			byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
			byte[] hashBytes = SHA512.Create().ComputeHash(sourceBytes);
			string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

			return hash;
		}

		public NguoiDungDALService(IDapperService dapperService)
		{
			_dapperService = dapperService;
		}

		public List<CT_NguoiDung> LayDSNguoiDung()
		{
            return _dapperService.Query<CT_NguoiDung>("spNGUOIDUNG_LayDSNguoiDung").ToList();
        }

		public DangNhapMessage DangNhap(string tenDangNhap, string matKhau)
		{
            var p = new DynamicParameters();
            p.Add("@TenDangNhap", tenDangNhap);
            p.Add("@MatKhau", ConvertToSHA512(matKhau));
            GlobalConfig.CurrNguoiDung = _dapperService.QuerySingleOrDefault<NguoiDung>("spNGUOIDUNG_LayBangTenDangNhapVaMatKhau", p, commandType: CommandType.StoredProcedure);

            if (GlobalConfig.CurrNguoiDung == null)
			{
				return DangNhapMessage.Failed;
			}

			return DangNhapMessage.Success;
		}

		public XoaTaiKhoanMessage XoaTaiKhoan(string tenDangNhap)
		{
            var p = new DynamicParameters();
            p.Add("@TenDangNhap", tenDangNhap);
            _dapperService.Execute("spNGUOIDUNG_XoaTaiKhoan", p, commandType: CommandType.StoredProcedure);

            return XoaTaiKhoanMessage.Success;
		}

		public DoiMatKhauMessage DoiMatKhau(string matKhauHT, string matKhauMoi)
		{
			int rowsAffected;

            var p = new DynamicParameters();
            p.Add("@TenDangNhap", GlobalConfig.CurrNguoiDung.TenDangNhap);
            p.Add("@MatKhauHT", ConvertToSHA512(matKhauHT));
            p.Add("@MatKhauMoi", ConvertToSHA512(matKhauMoi));
            rowsAffected = _dapperService.Execute("spNGUOIDUNG_DoiMatKhau", p, commandType: CommandType.StoredProcedure);

            if (rowsAffected == 0)
			{
				return DoiMatKhauMessage.Failed;
			}

			GlobalConfig.CurrNguoiDung.MatKhau = matKhauMoi;
			return DoiMatKhauMessage.Success;
		}

		public ThemTaiKhoanMessage ThemTaiKhoan(string tenDangNhap, string maNhom)
		{
            var p = new DynamicParameters();
            p.Add("@TenDangNhap", tenDangNhap);
            p.Add("@MaNhom", maNhom);
            _dapperService.Execute("spNGUOIDUNG_ThemTaiKhoan", p, commandType: CommandType.StoredProcedure);

            return ThemTaiKhoanMessage.Success;
		}

		public SuaTaiKhoanMessage SuaTaiKhoan(string tenDangNhapBD, string tenDangNhap, string maNhom)
		{
            var p = new DynamicParameters();
            p.Add("@TenDangNhapBD", tenDangNhapBD);
            p.Add("@TenDangNhap", tenDangNhap);
            p.Add("@MaNhom", maNhom);
            _dapperService.Execute("spNGUOIDUNG_SuaTaiKhoan", p, commandType: CommandType.StoredProcedure);

            return SuaTaiKhoanMessage.Success;
		}

		public ThemTaiKhoanSVMessage ThemTaiKhoanSV(IList<SinhVien> dssv)
		{
            foreach (SinhVien sinhVien in dssv)
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", sinhVien.MaSV);
                _dapperService.Execute("spNGUOIDUNG_ThemTaiKhoanSV", p, commandType: CommandType.StoredProcedure);
            }

            return ThemTaiKhoanSVMessage.Success;
		}
	}
}
