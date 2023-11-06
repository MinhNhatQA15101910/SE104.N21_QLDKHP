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
    public class PhieuThuHPDALService : IPhieuThuHPDALService
	{
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public PhieuThuHPDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ma", maPhieuDKHP);
                return _dapperWrapper.QueryFirstOrDefault<DateTime>(connection, "spPHIEUTHUHP_LayThoiGianDongHPGanNhat", parameters, commandType: CommandType.StoredProcedure);
            }
        }

		public bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@soTienThu", soTienThu);
                parameters.Add("@maPhieuDKHP", soPhieuDKHP);
                int numRowsAffected = _dapperWrapper.Execute(connection, "spPHIEUTHUHP_TaoPhieuThu_ChoXacNhan ", parameters, commandType: CommandType.StoredProcedure);

                if (numRowsAffected > 0)
                    return true;
                else
                    return false;
            }
		}

		public List<PhieuThuHP> GetPhieuThuHP(int MaTinhTrang)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaTinhTrang", MaTinhTrang);
                return _dapperWrapper.Query<PhieuThuHP>(connection, "spPHIEUTHUHP_GetPhieuThuHP", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		public MessagePhieuThuHPUpdateTinhTrang PhieuThuHPUpdateTinhTrang(int MaPhieuThuHP, int MaTinhTrang)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaPhieuThuHP", MaPhieuThuHP);
                p.Add("@MaTinhTrang", MaTinhTrang);
                int result = _dapperWrapper.Execute(connection, "spPHIEUTHUHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? MessagePhieuThuHPUpdateTinhTrang.Success : MessagePhieuThuHPUpdateTinhTrang.Failed;
            }
		}
	}
}
