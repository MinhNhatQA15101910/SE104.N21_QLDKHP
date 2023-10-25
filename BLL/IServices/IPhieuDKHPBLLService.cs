using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface IPhieuDKHPBLLService
	{
		List<PhieuDKHP> LayTTPhieuDKHP(string mssv, int maHocKy, int namHoc);
		List<dynamic> LayDSMHThuocHP(int maPhieuDKHP);
		int TinhHocPhi(int maPhieuDKHP);
		float TinhHocPhiPhaiDong(int maPhieuDKHP);
		float TinhHocPhiDaDong(int maPhieuDKHP);
		float TinhHocPhiConThieu(int maPhieuDKHP);
		List<dynamic> LayDSMHThuocHP2(int maPhieuDKHP);
		bool TaoPhieuDKHP(string mssv, int hocKy, int namHoc);
		int LayMaPhieuDKHP(int hocKy, int namHoc);
		List<PhieuDKHP> LayDanhSachDKHPDaXacNhan(string mssv);
		List<PhieuDKHP> GetPhieuDKHP(int MaHocKy, int NamHoc, int MaTinhTrang);
		MessagePhieuDKHPUpdateTinhTrang PhieuDKHPUpdateTinhTrang(int MaPhieuDKHP, int MaTinhTrang);
		List<PhieuDKHP> GetAllPhieuDKHP();
		TimKiemPhieuDKHPMessage KtTimKiemPhieuDKHP(string namHoc);

	}
}
