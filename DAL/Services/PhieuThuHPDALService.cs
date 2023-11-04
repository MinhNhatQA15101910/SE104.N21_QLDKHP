using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class PhieuThuHPDALService : IPhieuThuHPDALService
	{
		private readonly IDapperService _dapperService;

		public PhieuThuHPDALService(IDapperService dapperService)
		{
			_dapperService = dapperService;
		}
		public DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@ma", maPhieuDKHP);
            return _dapperService.QueryFirstOrDefault<DateTime>("spPHIEUTHUHP_LayThoiGianDongHPGanNhat", parameters, commandType: CommandType.StoredProcedure);
        }

		public bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP)
		{
			int numRowsAffected;

            var parameters = new DynamicParameters();
            parameters.Add("@soTienThu", soTienThu);
            parameters.Add("@maPhieuDKHP", soPhieuDKHP);
            numRowsAffected = _dapperService.Execute("spPHIEUTHUHP_TaoPhieuThu_ChoXacNhan ", parameters, commandType: CommandType.StoredProcedure);

            if (numRowsAffected > 0)
				return true;
			else
				return false;
		}

		public List<PhieuThuHP> GetPhieuThuHP(int MaTinhTrang)
		{
            var p = new DynamicParameters();
            p.Add("@MaTinhTrang", MaTinhTrang);
            return _dapperService.Query<PhieuThuHP>("spPHIEUTHUHP_GetPhieuThuHP", p, commandType: CommandType.StoredProcedure).ToList();
        }

		public MessagePhieuThuHPUpdateTinhTrang PhieuThuHPUpdateTinhTrang(int MaPhieuThuHP, int MaTinhTrang)
		{
            var p = new DynamicParameters();
            p.Add("@MaPhieuThuHP", MaPhieuThuHP);
            p.Add("@MaTinhTrang", MaTinhTrang);
            _dapperService.Execute("spPHIEUTHUHP_UpdateTinhTrang", p, commandType: CommandType.StoredProcedure);

            return MessagePhieuThuHPUpdateTinhTrang.Success;
		}
	}
}
