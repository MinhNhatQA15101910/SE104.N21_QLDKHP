using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
