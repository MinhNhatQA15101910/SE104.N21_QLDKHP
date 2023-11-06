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
        private readonly IDbConnection _connection;

        public SinhVienDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<SinhVien> LayDSSVChuaCoTK()
		{
            return _connection.Query<SinhVien>("spSINHVIEN_LayDSSVChuaCoTK").ToList();
        }

		public List<CT_SinhVien> LayDSSV()
		{
            return _connection.Query<CT_SinhVien>("spSINHVIEN_LayDSSV").ToList();
        }

		public SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
            var p = new DynamicParameters();
            p.Add("@MaSV", mssvBanDau);
            p.Add("@HoTen", hoTen);
            p.Add("@NgaySinh", ngaySinh);
            p.Add("@GioiTinh", gioiTinh);
            p.Add("@MaHuyen", maHuyen);
            p.Add("@MaNganh", maNganh);
            _connection.Execute("spSINHVIEN_SuaSinhVien", p, commandType: CommandType.StoredProcedure);

            p = new DynamicParameters();
            p.Add("@MaSV", mssvBanDau);
            _connection.Execute("spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

            foreach (int maDT in maDTList)
            {
                p = new DynamicParameters();
                p.Add("@MaSV", mssv);
                p.Add("@MaDT", maDT);
                _connection.Execute("spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
            }

            return SuaSinhVienMessage.Success;
		}

		public ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
            var p = new DynamicParameters();
            p.Add("@MaSV", mssv);
            p.Add("@HoTen", hoTen);
            p.Add("@NgaySinh", ngaySinh);
            p.Add("@GioiTinh", gioiTinh);
            p.Add("@MaHuyen", maHuyen);
            p.Add("@MaNganh", maNganh);
            _connection.Execute("spSINHVIEN_ThemSinhVien", p, commandType: CommandType.StoredProcedure);

            foreach (int maDT in maDTList)
            {
                p = new DynamicParameters();
                p.Add("@MaSV", mssv);
                p.Add("@MaDT", maDT);
                _connection.Execute("spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
            }

            return ThemSinhVienMessage.Success;
		}

		public XoaSinhVienMessage XoaSinhVien(string maSV)
		{
            var p = new DynamicParameters();
            p.Add("@MaSV", maSV);
            _connection.Execute("spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
            _connection.Execute("spCT_PHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
            _connection.Execute("spPHIEUTHUHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
            _connection.Execute("spPHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
            _connection.Execute("spSINHVIEN_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

            return XoaSinhVienMessage.Success;
		}

		public string LayTenSV(string mssv)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@mssv", mssv);
            return _connection.QueryFirstOrDefault<string>("spSINHVIEN_LayTenSV", parameters, commandType: CommandType.StoredProcedure).ToString();
        }

		public List<dynamic> LayThongTinSV(string mssv)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@mssv", mssv);
            return _connection.Query<dynamic>("spSINHVIEN_LayThongTinSV", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

		public List<dynamic> BaoCaoSinhVienChuaDongHocPhi(int hocKy, int namHoc)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@hocKy", hocKy);
            parameters.Add("@namHoc", namHoc);

            return _connection.Query<dynamic>("spSINHVIEN_BaoCao", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
	}
}
