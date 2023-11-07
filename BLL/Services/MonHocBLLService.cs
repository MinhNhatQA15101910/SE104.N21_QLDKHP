using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class MonHocBLLService : IMonHocBLLService
    {
        private readonly IMonHocDALService _monHocDALService;
        private readonly IDanhSachMonHocMoDALService _danhSachMonHocMoDALService;
        private readonly ICT_PhieuDKHPDALService _ct_PhieuDKHPDALService;
        private readonly IChuongTrinhHocDALService _chuongTrinhHocDALService;

        public MonHocBLLService(IMonHocDALService monHocDALService, IDanhSachMonHocMoDALService danhSachMonHocMoDALService, ICT_PhieuDKHPDALService ct_PhieuDKHPDALService, IChuongTrinhHocDALService chuongTrinhHocDALService)
        {
            _monHocDALService = monHocDALService;
            _danhSachMonHocMoDALService = danhSachMonHocMoDALService;
            _ct_PhieuDKHPDALService = ct_PhieuDKHPDALService;
            _chuongTrinhHocDALService = chuongTrinhHocDALService;
        }

        public List<CT_MonHoc> LayDSMonHoc()
        {
            return _monHocDALService.LayDSMonHoc();
        }

        public XoaMonHocMessage XoaMonHoc(string maMH)
        {
            var danhSachMonHocMos = _danhSachMonHocMoDALService.LayDSMonHocMo();
            var danhSachMonHocMo = danhSachMonHocMos.Find(dsmhm => dsmhm == maMH);
            if (danhSachMonHocMo != null)
            {
                return XoaMonHocMessage.UnableForDanhSachMonHocMo;
            }

            var ct_PhieuDKHPs = _ct_PhieuDKHPDALService.GetCT_PhieuDKHPs();
            var ct_PhieuDKHP = ct_PhieuDKHPs.Find(ct_pdkhp => ct_pdkhp.MaMH == maMH);
            if (ct_PhieuDKHP != null)
            {
                return XoaMonHocMessage.UnableForCT_PhieuDKHP;
            }

            var chuongTrinhHocs = _chuongTrinhHocDALService.GetAllCTHoc();
            var chuongTrinhHoc = chuongTrinhHocs.Find(cth => cth.MaMH == maMH);
            if (chuongTrinhHoc != null)
            {
                return XoaMonHocMessage.UnableForChuongTrinhHoc;
            }

            return _monHocDALService.XoaMonHoc(maMH);
        }

        public SuaMonHocMessage SuaMonHoc(string maMHBanDau, string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon)
        {
            if (string.IsNullOrEmpty(maMH))
            {
                return SuaMonHocMessage.EmptyMaMH;
            }

            if (string.IsNullOrEmpty(tenMH))
            {
                return SuaMonHocMessage.EmptyTenMH;
            }

            if (string.IsNullOrEmpty(soTiet))
            {
                return SuaMonHocMessage.EmptySoTiet;
            }

            if (!int.TryParse(soTiet, out int soTietValue) || soTietValue < 0 || soTietValue % soTietLoaiMon != 0)
            {
                return SuaMonHocMessage.InvalidSoTiet;
            }

            var monHocs = _monHocDALService.LayDSMonHoc();
            var monHoc = monHocs.Find(mh => mh.MaMH == maMH && mh.MaMH != maMHBanDau);
            if (monHoc != null)
            {
                return SuaMonHocMessage.DuplicateMaMH;
            }

            var danhSachMonHocMos = _danhSachMonHocMoDALService.LayDSMonHocMo();
            var danhSachMonHocMo = danhSachMonHocMos.Find(dsmhm => dsmhm == maMH && dsmhm != maMHBanDau);
            if (danhSachMonHocMo != null)
            {
                return SuaMonHocMessage.UnableForDanhSachMonHocMo;
            }

            var ct_PhieuDKHPs = _ct_PhieuDKHPDALService.GetCT_PhieuDKHPs();
            var ct_PhieuDKHP = ct_PhieuDKHPs.Find(ct_pdkhp => ct_pdkhp.MaMH == maMH && ct_pdkhp.MaMH != maMHBanDau);
            if (ct_PhieuDKHP != null)
            {
                return SuaMonHocMessage.UnableForCT_PhieuDKHP;
            }

            var chuongTrinhHocs = _chuongTrinhHocDALService.GetAllCTHoc();
            var chuongTrinhHoc = chuongTrinhHocs.Find(cth => cth.MaMH == maMH && cth.MaMH != maMHBanDau);
            if (chuongTrinhHoc != null)
            {
                return SuaMonHocMessage.UnableForChuongTrinhHoc;
            }

            return _monHocDALService.SuaMonHoc(maMHBanDau, tenMH, maLoaiMonHoc, soTietValue);
        }

        public ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon)
        {
            if (string.IsNullOrEmpty(maMH))
            {
                return ThemMonHocMessage.EmptyMaMH;
            }

            if (string.IsNullOrEmpty(tenMH))
            {
                return ThemMonHocMessage.EmptyTenMH;
            }

            if (string.IsNullOrEmpty(soTiet))
            {
                return ThemMonHocMessage.EmptySoTiet;
            }

            if (!int.TryParse(soTiet, out int soTietValue) || soTietValue < 0 || soTietValue % soTietLoaiMon != 0)
            {
                return ThemMonHocMessage.InvalidSoTiet;
            }

            var monHocs = _monHocDALService.LayDSMonHoc();
            var monHoc = monHocs.Find(mh => mh.MaMH == maMH);
            if (monHoc != null)
            {
                return ThemMonHocMessage.DuplicateMaMH;
            }

            return _monHocDALService.ThemMonHoc(maMH, tenMH, maLoaiMonHoc, soTietValue);
        }

        public List<MonHoc> GetTermMonHoc(int hocKy)
        {
            return _monHocDALService.GetTermMonHoc(hocKy);
        }

        public List<MonHoc> GetTermMonHocMo(int hocKy, int namHoc)
        {
            return _monHocDALService.GetTermMonHocMo(hocKy, namHoc);
        }

        public List<MonHoc> GetChuongTrinhHoc(string nganh, int hocKy)
        {
            return _monHocDALService.GetChuongTrinhHoc(nganh, hocKy);
        }

        public List<MonHoc> LayDSMonHoc2()
        {
            return _monHocDALService.LayDSMonHoc2();
        }

        public List<MonHoc> GetMonHocPhieuDKHP(int maPhieuDKHP)
        {
            return _monHocDALService.GetMonHocPhieuDKHP(maPhieuDKHP);
        }
    }
}
