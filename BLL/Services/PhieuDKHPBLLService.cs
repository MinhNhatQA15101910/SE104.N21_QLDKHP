using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PhieuDKHPBLLService : IPhieuDKHPBLLService
	{
		private readonly IPhieuDKHPDALService _phieuDKHPDALService;

		public PhieuDKHPBLLService(IPhieuDKHPDALService phieuDKHPDALService)
		{
			_phieuDKHPDALService = phieuDKHPDALService;
		}

		public List<PhieuDKHP> LayTTPhieuDKHP(string mssv, int maHocKy, int namHoc)
		{
			return _phieuDKHPDALService.LayTTPhieuDKHP(mssv,maHocKy, namHoc);
		}

		public List<dynamic> LayDSMHThuocHP(int maPhieuDKHP)
		{
			return _phieuDKHPDALService.LayDSMHThuocHP(maPhieuDKHP);
		}

		public int TinhHocPhi(int maPhieuDKHP)
		{
			return _phieuDKHPDALService.TinhHocPhi(maPhieuDKHP);
		}

		public float TinhHocPhiPhaiDong(int maPhieuDKHP)
		{
			return _phieuDKHPDALService.TinhHocPhiPhaiDong(maPhieuDKHP);
		}

		public float TinhHocPhiDaDong(int maPhieuDKHP)
		{
			return _phieuDKHPDALService.TinhHocPhiDaDong(maPhieuDKHP);
		}

		public float TinhHocPhiConThieu(int maPhieuDKHP)
		{
			return _phieuDKHPDALService.TinhHocPhiConThieu(maPhieuDKHP);
		}

		public List<dynamic> LayDSMHThuocHP2(int maPhieuDKHP)
		{
			return _phieuDKHPDALService.LayDSMHThuocHP2(maPhieuDKHP);
		}

		public bool TaoPhieuDKHP(string mssv, int hocKy, int namHoc)
		{
			return _phieuDKHPDALService.TaoPhieuDKHP(mssv, hocKy, namHoc);
		}

		public int LayMaPhieuDKHP(int hocKy, int namHoc)
		{
			return _phieuDKHPDALService.LayMaPhieuDKHP(hocKy,namHoc);
		}

		public List<PhieuDKHP> LayDanhSachDKHPDaXacNhan(string mssv)
		{
			return _phieuDKHPDALService.LayDanhSachDKHPDaXacNhan(mssv);
		}

		public List<PhieuDKHP> GetPhieuDKHP(int MaHocKy, int NamHoc, int MaTinhTrang)
		{
			return _phieuDKHPDALService.GetPhieuDKHP(MaHocKy, NamHoc, MaTinhTrang);
		}

		public MessagePhieuDKHPUpdateTinhTrang PhieuDKHPUpdateTinhTrang(int MaPhieuDKHP, int MaTinhTrang)
		{
			return _phieuDKHPDALService.PhieuDKHPUpdateTinhTrang(MaPhieuDKHP,MaTinhTrang);
		}

		public List<PhieuDKHP> GetAllPhieuDKHP()
		{
			return _phieuDKHPDALService.GetAllPhieuDKHP();
		}

		public TimKiemPhieuDKHPMessage KtTimKiemPhieuDKHP(string namHoc)
		{
			if(string.IsNullOrEmpty(namHoc))
			{
				return TimKiemPhieuDKHPMessage.EmptyNamHoc;
			}

			if (!int.TryParse(namHoc, out int namHocValue) || namHocValue < 0)
			{
				return TimKiemPhieuDKHPMessage.InvalidNamHoc;
			}

			return TimKiemPhieuDKHPMessage.Sucess;
		}
	}
}
