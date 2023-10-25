using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class TinhBLLService : ITinhBLLService
	{
		private readonly ITinhDALService _tinhDALService;
		public TinhBLLService(ITinhDALService tinhDALService)
		{
			_tinhDALService = tinhDALService;
		}
		public List<Tinh> LayDSTinh()
		{
			return _tinhDALService.LayDSTinh();
		}

		public SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
		{
			if (tenTinh.Equals(""))
			{
				return SuaTinhMessage.EmptyTenTinh;
			}

			return _tinhDALService.SuaTinh(maTinh, tenTinh);
		}

		public ThemTinhMessage ThemTinh(string tenTinh)
		{
			if (tenTinh.Equals(""))
			{
				return ThemTinhMessage.EmptyTenTinh;
			}

			return _tinhDALService.ThemTinh(tenTinh);
		}

		public XoaTinhMessage XoaTinh(int maTinh)
		{
			return _tinhDALService.XoaTinh(maTinh);
		}
	}
}
