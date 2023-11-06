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
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public SinhVienDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<SinhVien> LayDSSVChuaCoTK()
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<SinhVien>(connection, "spSINHVIEN_LayDSSVChuaCoTK").ToList();
            }
        }

		public List<CT_SinhVien> LayDSSV()
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<CT_SinhVien>(connection, "spSINHVIEN_LayDSSV").ToList();
            }
        }

		public SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", mssvBanDau);
                p.Add("@HoTen", hoTen);
                p.Add("@NgaySinh", ngaySinh);
                p.Add("@GioiTinh", gioiTinh);
                p.Add("@MaHuyen", maHuyen);
                p.Add("@MaNganh", maNganh);
                _dapperWrapper.Execute(connection, "spSINHVIEN_SuaSinhVien", p, commandType: CommandType.StoredProcedure);

                p = new DynamicParameters();
                p.Add("@MaSV", mssvBanDau);
                _dapperWrapper.Execute(connection, "spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

                foreach (int maDT in maDTList)
                {
                    p = new DynamicParameters();
                    p.Add("@MaSV", mssv);
                    p.Add("@MaDT", maDT);
                    _dapperWrapper.Execute(connection, "spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
                }

                return SuaSinhVienMessage.Success;
            }
		}

		public ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", mssv);
                p.Add("@HoTen", hoTen);
                p.Add("@NgaySinh", ngaySinh);
                p.Add("@GioiTinh", gioiTinh);
                p.Add("@MaHuyen", maHuyen);
                p.Add("@MaNganh", maNganh);
                _dapperWrapper.Execute(connection, "spSINHVIEN_ThemSinhVien", p, commandType: CommandType.StoredProcedure);

                foreach (int maDT in maDTList)
                {
                    p = new DynamicParameters();
                    p.Add("@MaSV", mssv);
                    p.Add("@MaDT", maDT);
                    _dapperWrapper.Execute(connection, "spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
                }

                return ThemSinhVienMessage.Success;
            }
		}

		public XoaSinhVienMessage XoaSinhVien(string maSV)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);
                _dapperWrapper.Execute(connection, "spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperWrapper.Execute(connection, "spCT_PHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperWrapper.Execute(connection, "spPHIEUTHUHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperWrapper.Execute(connection, "spPHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperWrapper.Execute(connection, "spSINHVIEN_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

                return XoaSinhVienMessage.Success;
            }
		}

		public string LayTenSV(string mssv)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);
                return _dapperWrapper.QueryFirstOrDefault<string>(connection, "spSINHVIEN_LayTenSV", parameters, commandType: CommandType.StoredProcedure).ToString();
            }
        }

		public List<dynamic> LayThongTinSV(string mssv)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);
                return _dapperWrapper.Query<dynamic>(connection, "spSINHVIEN_LayThongTinSV", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		public List<dynamic> BaoCaoSinhVienChuaDongHocPhi(int hocKy, int namHoc)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);

                return _dapperWrapper.Query<dynamic>(connection, "spSINHVIEN_BaoCao", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
	}
}
