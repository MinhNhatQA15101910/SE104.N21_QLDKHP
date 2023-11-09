using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class PhieuDKHPDALService : IPhieuDKHPDALService
	{
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public PhieuDKHPDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<PhieuDKHP> LayTTPhieuDKHP(string mssv, int maHocKy, int namHoc)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);
                parameters.Add("@MaHocKy", maHocKy);
                parameters.Add("@NamHoc", namHoc);

                return _dapperWrapper.Query<PhieuDKHP>(connection, "spPHIEUDKHP_LayTTPhieuDKHP", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		public List<dynamic> LayDSMHThuocHP(int maPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ma", maPhieuDKHP);

                return _dapperWrapper.Query<dynamic>(connection, "spPHIEUDKHP_LayDSMHThuocHP", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		public int TinhHocPhi(int maPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);

                return _dapperWrapper.QueryFirstOrDefault<int>(connection, "spPHIEUDKHP_TinhHocPhi", parameters, commandType: CommandType.StoredProcedure);
            }
        }

		public float TinhHocPhiPhaiDong(int maPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);

                return _dapperWrapper.QueryFirstOrDefault<float>(connection, "spPHIEUDKHP_TinhHocPhiPhaiDong", parameters, commandType: CommandType.StoredProcedure);
            }
        }

		public float TinhHocPhiDaDong(int maPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);

                return _dapperWrapper.QueryFirstOrDefault<float>(connection, "spPHIEUDKHP_TinhHocPhiDaDong", parameters, commandType: CommandType.StoredProcedure);
            }
        }

		public float TinhHocPhiConThieu(int maPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieuDKHP);

                return _dapperWrapper.QueryFirstOrDefault<float>(connection, "spPHIEUDKHP_TinhHocPhiConThieu", parameters, commandType: CommandType.StoredProcedure);
            }
        }

		public List<dynamic> LayDSMHThuocHP2(int maPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ma", maPhieuDKHP);

                return _dapperWrapper.Query<dynamic>(connection, "spPHIEUDKHP_layDSMHThuocHP2", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		public bool TaoPhieuDKHP(string mssv, int hocKy, int namHoc)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maSV", mssv); 
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                int numRowsAffected = _dapperWrapper.Execute(connection, "spPHIEUDKHP_TaoPhieuDKHP", parameters, commandType: CommandType.StoredProcedure);

                return (numRowsAffected > 0);
            }
		}

		public int LayMaPhieuDKHP(int hocKy, int namHoc)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maHocKy", hocKy);
                parameters.Add("@namHoc", namHoc);

                return _dapperWrapper.QueryFirstOrDefault<int>(connection, "spPHIEUDKHP_LayMaPhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
            }
        }

		public List<PhieuDKHP> LayDanhSachDKHPDaXacNhan(string mssv)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@mssv", mssv);

                return _dapperWrapper.Query<PhieuDKHP>(connection, "spPHIEUDKHP_LayDanhSachDKHPChoThanhToan", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		public List<PhieuDKHP> GetPhieuDKHP(int maHocKy, int namHoc, int maTinhTrang)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", maHocKy);
                p.Add("@NamHoc", namHoc);
                p.Add("@MaTinhTrang", maTinhTrang);

                return _dapperWrapper.Query<PhieuDKHP>(connection, "spPHIEUDKHP_GetPhieuDKHP", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		public MessagePhieuDKHPUpdateTinhTrang PhieuDKHPUpdateTinhTrang(int maPhieuDKHP, int maTinhTrang)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaPhieuDKHP", maPhieuDKHP);
                p.Add("@MaTinhTrang", maTinhTrang);

                int result = _dapperWrapper.Execute(connection, "spPHIEUDKHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessagePhieuDKHPUpdateTinhTrang.Success : MessagePhieuDKHPUpdateTinhTrang.Failed;
            }
        }

		public List<PhieuDKHP> GetAllPhieuDKHP()
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<PhieuDKHP>(connection, "spPHIEUDKHP_GetAllPhieuDKHP").ToList();
            }
        }
	}
}
