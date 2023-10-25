using DTO;
using System;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IPhieuThuHPDALService
	{
		DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP);
		bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP);
		List<PhieuThuHP> GetPhieuThuHP(int MaTinhTrang);
		MessagePhieuThuHPUpdateTinhTrang PhieuThuHPUpdateTinhTrang(int MaPhieuThuHP, int MaTinhTrang);

	}
}
