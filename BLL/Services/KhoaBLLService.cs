using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class KhoaBLLService : IKhoaBLLService
    {
        private readonly IKhoaDALService _khoaDALService;
        private readonly INganhDALService _nganhDALService;

        public KhoaBLLService(IKhoaDALService khoaDALService, INganhDALService nganhDALService)
        {
            _khoaDALService = khoaDALService;
            _nganhDALService = nganhDALService;
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

            var khoas = _khoaDALService.LayDSKhoa();
            var khoa = khoas.Find(k => k.MaKhoa == maKhoaSua && k.MaKhoa != maKhoaBanDau);
            if (khoa != null)
            {
                return SuaKhoaMessage.DuplicateMaKhoa;
            }

            khoas = _khoaDALService.LayDSKhoa();
            khoa = khoas.Find(k => k.TenKhoa == tenKhoaSua && k.MaKhoa != maKhoaBanDau);
            if (khoa != null)
            {
                return SuaKhoaMessage.DuplicateTenKhoa;
            }

            var nganhs = _nganhDALService.LayDSNganh();
            var nganh = nganhs.Find(n => n.MaKhoa == maKhoaBanDau);
            if (nganh != null && maKhoaBanDau != maKhoaSua)
            {
                return SuaKhoaMessage.Unable;
            }

            return _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);
        }

        public ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            if (string.IsNullOrEmpty(maKhoa))
            {
                return ThemKhoaMessage.EmptyMaKhoa;
            }

            if (string.IsNullOrEmpty(tenKhoa))
            {
                return ThemKhoaMessage.EmptyTenKhoa;
            }

            var khoas = _khoaDALService.LayDSKhoa();
            var khoa = khoas.Find(k => k.MaKhoa == maKhoa);
            if (khoa != null)
            {
                return ThemKhoaMessage.DuplicateMaKhoa;
            }

            khoas = _khoaDALService.LayDSKhoa();
            khoa = khoas.Find(k => k.TenKhoa == tenKhoa);
            if (khoa != null)
            {
                return ThemKhoaMessage.DuplicateTenKhoa;
            }

            return _khoaDALService.ThemKhoa(maKhoa, tenKhoa);
        }

        public XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            var nganhs = _nganhDALService.LayDSNganh();
            var nganh = nganhs.Find(n => n.MaKhoa == maKhoa);
            if (nganh != null)
            {
                return XoaKhoaMessage.Unable;
            }

            return _khoaDALService.XoaKhoa(maKhoa);
        }
    }
}
