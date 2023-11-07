using BLL.IServices;
using DAL.IServices;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PhieuThuHPBLLService : IPhieuThuHPBLLService
	{
		private readonly IPhieuThuHPDALService _phieuThuHPDALService;

		public PhieuThuHPBLLService(IPhieuThuHPDALService phieuThuHPDALService)
		{
			_phieuThuHPDALService = phieuThuHPDALService;
		}

		public TimKiemTTHocPhiMessage KtTimKiemTTHocPhi(string namHoc)
		{
			if (string.IsNullOrEmpty(namHoc))
			{
				return TimKiemTTHocPhiMessage.EmptyNamHoc;
			}

			if (!int.TryParse(namHoc, out int namHocValue) || namHocValue < 0)
			{
				return TimKiemTTHocPhiMessage.InvalidNamHoc;
			}

			return TimKiemTTHocPhiMessage.Sucess;
		}

		public DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP)
		{
			return _phieuThuHPDALService.LayThoiGianDongHPGanNhat(maPhieuDKHP);
		}

		public TimKiemPhieuDKHPMessage KtTimKiemSoTienThu(string t)
		{
			if (t == "")
			{
				return TimKiemPhieuDKHPMessage.EmptyNamHoc;
			}
			int kq;
			if (!int.TryParse(t, out kq))
			{
				return TimKiemPhieuDKHPMessage.InvalidNamHoc;
			}
			return TimKiemPhieuDKHPMessage.Sucess;
		}

		public bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP)
		{
			return _phieuThuHPDALService.TaoPhieuThu_ChoXacNhan(soTienThu, soPhieuDKHP);
		}

		public List<DTO.PhieuThuHP> GetPhieuThuHP(int MaTinhTrang)
		{
			return _phieuThuHPDALService.GetPhieuThuHP(MaTinhTrang);
		}

		public MessagePhieuThuHPUpdateTinhTrang PhieuThuHPUpdateTinhTrang(int MaPhieuThuHP, int MaTinhTrang)
		{
			return _phieuThuHPDALService.PhieuThuHPUpdateTinhTrang(MaPhieuThuHP, MaTinhTrang);
		}
	}
}
