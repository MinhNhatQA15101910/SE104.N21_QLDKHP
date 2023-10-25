using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class NhomNguoiDungBLLService : INhomNguoiDungBLLService
	{
		private readonly INhomNguoiDungDALService _nhomNguoiDungDALService;
		public NhomNguoiDungBLLService(INhomNguoiDungDALService nhomNguoiDungDALService)
		{
			_nhomNguoiDungDALService = nhomNguoiDungDALService;
		}
		public List<NhomNguoiDung> LayDSNhomNguoiDung()
		{
			return _nhomNguoiDungDALService.LayDSNhomNguoiDung();
		}

	}
}
