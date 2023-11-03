using DAL.IServices;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Services
{
    public class NhomNguoiDungDALService : INhomNguoiDungDALService
	{
		private readonly IDapperService _dapperService;

		public NhomNguoiDungDALService(IDapperService dapperService)
		{
			_dapperService = dapperService;
		}

		public List<NhomNguoiDung> LayDSNhomNguoiDung()
		{
            return _dapperService.Query<NhomNguoiDung>("spNHOMNGUOIDUNG_LayDSNhomNguoiDung").ToList();
        }
	}
}
