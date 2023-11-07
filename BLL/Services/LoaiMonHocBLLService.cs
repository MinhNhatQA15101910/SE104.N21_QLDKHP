using BLL.IServices;
using DAL.IServices;
using DAL.Services;
using DTO;
using System.Collections.Generic;
using System.Configuration;

namespace BLL.Services
{
    public class LoaiMonHocBLLService : ILoaiMonHocBLLService
    {
        private readonly ILoaiMonHocDALService _loaiMonHocDALService;
        private readonly IMonHocDALService _monHocDALService;

        public LoaiMonHocBLLService(ILoaiMonHocDALService loaiMonHocDALService, IMonHocDALService monHocDALService)
        {
            _loaiMonHocDALService = loaiMonHocDALService;
            _monHocDALService = monHocDALService;
        }

        public List<LoaiMonHoc> LayDSLoaiMonHoc()
        {
            return _loaiMonHocDALService.LayDSLoaiMonHoc();
        }

        public XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc)
        {
            List<CT_MonHoc> ct_MonHocs = _monHocDALService.LayDSMonHoc();
            CT_MonHoc ct_MonHoc = ct_MonHocs.Find(mh => mh.MaLoaiMonHoc == maLoaiMonHoc);
            if (ct_MonHoc != null)
            {
                return XoaLoaiMonHocMessage.Unable;
            }

            return _loaiMonHocDALService.XoaLoaiMonHoc(maLoaiMonHoc);
        }

        public SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            if (string.IsNullOrEmpty(tenLoaiMonHoc))
            {
                return SuaLoaiMonHocMessage.EmptyTenLoaiMonHoc;
            }

            if (string.IsNullOrEmpty(soTiet))
            {
                return SuaLoaiMonHocMessage.EmptySoTiet;
            }

            if (string.IsNullOrEmpty(soTien))
            {
                return SuaLoaiMonHocMessage.EmptySoTien;
            }

            if (!int.TryParse(soTiet, out int soTietValue) || soTietValue < 0)
            {
                return SuaLoaiMonHocMessage.SoTietKhongHopLe;
            }

            if (!decimal.TryParse(soTien, out decimal soTienValue) || soTienValue < 0)
            {
                return SuaLoaiMonHocMessage.SoTienKhongHopLe;
            }

            List<LoaiMonHoc> loaiMonHocs = _loaiMonHocDALService.LayDSLoaiMonHoc();
            LoaiMonHoc loaiMonHoc = loaiMonHocs.Find(lmh => lmh.TenLoaiMonHoc == tenLoaiMonHoc && lmh.MaLoaiMonHoc != maLoaiMonHoc);
            if (loaiMonHoc != null)
            {
                return SuaLoaiMonHocMessage.DuplicateTenLoaiMonHoc;
            }

            return _loaiMonHocDALService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTietValue, soTienValue);
        }

        public ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            if (string.IsNullOrEmpty(tenLoaiMonHoc))
            {
                return ThemLoaiMonHocMessage.EmptyTenLoaiMonHoc;
            }

            if (string.IsNullOrEmpty(soTiet))
            {
                return ThemLoaiMonHocMessage.EmptySoTiet;
            }

            if (string.IsNullOrEmpty(soTien))
            {
                return ThemLoaiMonHocMessage.EmptySoTien;
            }

            if (!int.TryParse(soTiet, out int soTietValue) || soTietValue < 0)
            {
                return ThemLoaiMonHocMessage.SoTietKhongHopLe;
            }

            if (!decimal.TryParse(soTien, out decimal soTienValue) || soTienValue < 0)
            {
                return ThemLoaiMonHocMessage.SoTienKhongHopLe;
            }

            List<LoaiMonHoc> loaiMonHocs = _loaiMonHocDALService.LayDSLoaiMonHoc();
            LoaiMonHoc loaiMonHoc = loaiMonHocs.Find(lmh => lmh.TenLoaiMonHoc == tenLoaiMonHoc);
            if (loaiMonHoc != null)
            {
                return ThemLoaiMonHocMessage.DuplicateTenLoaiMonHoc;
            }

            return _loaiMonHocDALService.ThemLoaiMonHoc(tenLoaiMonHoc, soTietValue, soTienValue);
        }
    }
}
