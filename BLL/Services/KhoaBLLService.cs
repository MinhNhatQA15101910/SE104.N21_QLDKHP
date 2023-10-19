using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class KhoaBLLService : IKhoaBLLService
    {
        private readonly IKhoaDALService _khoaDALService;

        public KhoaBLLService(IKhoaDALService khoaDALService)
        {
            _khoaDALService = khoaDALService;
        }

        public List<Khoa> LayDSKhoa()
        {
            return _khoaDALService.LayDSKhoa();
        }

        public SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            if (string.IsNullOrEmpty(maKhoaSua))
            {
                return SuaKhoaMessage.EmptyMaKhoa;
            }

            if (string.IsNullOrEmpty(tenKhoaSua))
            {
                return SuaKhoaMessage.EmptyTenKhoa;
            }

            return _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);
        }

        public ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            if (maKhoa.Equals(""))
            {
                return ThemKhoaMessage.EmptyMaKhoa;
            }

            if (tenKhoa.Equals(""))
            {
                return ThemKhoaMessage.EmptyTenKhoa;
            }

            return _khoaDALService.ThemKhoa(maKhoa, tenKhoa);
        }

        public XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            return _khoaDALService.XoaKhoa(maKhoa);
        }
    }
}
