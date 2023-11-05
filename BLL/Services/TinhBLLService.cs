using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class TinhBLLService : ITinhBLLService
	{
		private readonly ITinhDALService _tinhDALService;
		private readonly IHuyenDALService _huyenDALService;

		public TinhBLLService(ITinhDALService tinhDALService, IHuyenDALService huyenDALService)
		{
			_tinhDALService = tinhDALService;
			_huyenDALService = huyenDALService;
		}
		public List<Tinh> LayDSTinh()
		{
			return _tinhDALService.LayDSTinh();
		}

		public SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
		{
			if (string.IsNullOrEmpty(tenTinh))
			{
				return SuaTinhMessage.EmptyTenTinh;
			}

			List<Tinh> tinhs = _tinhDALService.LayDSTinh();
			Tinh tinh = tinhs.Find(t => t.TenTTP == tenTinh && t.MaTinh != maTinh);
			if (tinh != null)
			{
				return SuaTinhMessage.DuplicateTenTinh;
			}

			return _tinhDALService.SuaTinh(maTinh, tenTinh);
		}

		public ThemTinhMessage ThemTinh(string tenTinh)
		{
			if (string.IsNullOrEmpty(tenTinh))
			{
				return ThemTinhMessage.EmptyTenTinh;
			}

            List<Tinh> tinhs = _tinhDALService.LayDSTinh();
            Tinh tinh = tinhs.Find(t => t.TenTTP == tenTinh);
            if (tinh != null)
            {
                return ThemTinhMessage.DuplicateTenTinh;
            }

            return _tinhDALService.ThemTinh(tenTinh);
		}

		public XoaTinhMessage XoaTinh(int maTinh)
		{
			List<CT_Huyen> ct_Huyens = _huyenDALService.LayDSHuyen();
			CT_Huyen ct_Huyen = ct_Huyens.Find(h => h.MaTinh == maTinh);
			if (ct_Huyen != null)
			{
				return XoaTinhMessage.Unable;
			}

			return _tinhDALService.XoaTinh(maTinh);
		}
	}
}
