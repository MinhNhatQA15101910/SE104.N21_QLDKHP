using BLL.IServices;
using DAL.IServices;
using DAL.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
