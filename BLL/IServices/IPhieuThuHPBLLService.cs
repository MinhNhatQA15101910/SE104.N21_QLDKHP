using DTO;
using System;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IPhieuThuHPBLLService
	{
		TimKiemTTHocPhiMessage KtTimKiemTTHocPhi(string namHoc);
		DateTime LayThoiGianDongHPGanNhat(int maPhieuDKHP);
		TimKiemPhieuDKHPMessage KtTimKiemSoTienThu(string t);
		bool TaoPhieuThu_ChoXacNhan(int soTienThu, int soPhieuDKHP);
		List<DTO.PhieuThuHP> GetPhieuThuHP(int MaTinhTrang);
		MessagePhieuThuHPUpdateTinhTrang PhieuThuHPUpdateTinhTrang(int MaPhieuThuHP, int MaTinhTrang);
	}
}
