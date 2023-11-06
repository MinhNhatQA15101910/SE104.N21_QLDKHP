using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class PhieuDKHPDALService : IPhieuDKHPDALService
	{
        private readonly IDbConnection _connection;

        public PhieuDKHPDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<PhieuDKHP> LayTTPhieuDKHP(string mssv, int maHocKy, int namHoc)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@mssv", mssv);
            parameters.Add("@MaHocKy", maHocKy);
            parameters.Add("@NamHoc", namHoc);

            return _connection.Query<PhieuDKHP>("spPHIEUDKHP_LayTTPhieuDKHP", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

		public List<dynamic> LayDSMHThuocHP(int maPhieuDKHP)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@ma", maPhieuDKHP);

            return _connection.Query<dynamic>("spPHIEUDKHP_LayDSMHThuocHP", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

		public int TinhHocPhi(int maPhieuDKHP)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@maPhieuDKHP", maPhieuDKHP);

            return _connection.QueryFirstOrDefault<int>("spPHIEUDKHP_TinhHocPhi", parameters, commandType: CommandType.StoredProcedure);
        }

		public float TinhHocPhiPhaiDong(int maPhieuDKHP)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@maPhieuDKHP", maPhieuDKHP);

            return _connection.QueryFirstOrDefault<float>("spPHIEUDKHP_TinhHocPhiPhaiDong", parameters, commandType: CommandType.StoredProcedure);
        }

		public float TinhHocPhiDaDong(int maPhieuDKHP)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@maPhieuDKHP", maPhieuDKHP);

            return _connection.QueryFirstOrDefault<float>("spPHIEUDKHP_TinhHocPhiDaDong", parameters, commandType: CommandType.StoredProcedure);
        }

		public float TinhHocPhiConThieu(int maPhieuDKHP)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@maPhieuDKHP", maPhieuDKHP);

            return _connection.QueryFirstOrDefault<float>("spPHIEUDKHP_TinhHocPhiConThieu", parameters, commandType: CommandType.StoredProcedure);
        }

		public List<dynamic> LayDSMHThuocHP2(int maPhieuDKHP)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@ma", maPhieuDKHP);

            return _connection.Query<dynamic>("spPHIEUDKHP_layDSMHThuocHP2", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

		public bool TaoPhieuDKHP(string mssv, int hocKy, int namHoc)
		{
			int numRowsAffected;
            var parameters = new DynamicParameters();
            parameters.Add("@maSV", mssv);
            parameters.Add("@hocKy", hocKy);
            parameters.Add("@namHoc", namHoc);
            numRowsAffected = _connection.Execute("spPHIEUDKHP_TaoPhieuDKHP ", parameters, commandType: CommandType.StoredProcedure);

            if (numRowsAffected > 0)
				return true;
			else
				return false;
		}

		public int LayMaPhieuDKHP(int hocKy, int namHoc)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@maHocKy", hocKy);
            parameters.Add("@namHoc", namHoc);

            return _connection.QueryFirstOrDefault<int>("spPHIEUDKHP_LayMaPhieuDKHP", parameters, commandType: CommandType.StoredProcedure);
        }

		public List<PhieuDKHP> LayDanhSachDKHPDaXacNhan(string mssv)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@mssv", mssv);

            return _connection.Query<PhieuDKHP>("spPHIEUDKHP_LayDanhSachDKHPChoThanhToan", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

		public List<PhieuDKHP> GetPhieuDKHP(int MaHocKy, int NamHoc, int MaTinhTrang)
		{
            var p = new DynamicParameters();
            p.Add("@MaHocKy", MaHocKy);
            p.Add("@NamHoc", NamHoc);
            p.Add("@MaTinhTrang", MaTinhTrang);

            return _connection.Query<PhieuDKHP>("spPHIEUDKHP_GetPhieuDKHP", p, commandType: CommandType.StoredProcedure).ToList();
        }

		public MessagePhieuDKHPUpdateTinhTrang PhieuDKHPUpdateTinhTrang(int MaPhieuDKHP, int MaTinhTrang)
		{
            var p = new DynamicParameters();
            p.Add("@MaPhieuDKHP", MaPhieuDKHP);
            p.Add("@MaTinhTrang", MaTinhTrang);

            _connection.Execute("spPHIEUDKHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);

            return MessagePhieuDKHPUpdateTinhTrang.Success;
        }

		public List<PhieuDKHP> GetAllPhieuDKHP()
		{
            return _connection.Query<PhieuDKHP>("spPHIEUDKHP_GetAllPhieuDKHP").ToList();
        }
	}
}
