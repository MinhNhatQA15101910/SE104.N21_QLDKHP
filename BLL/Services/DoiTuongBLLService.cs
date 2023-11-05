using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DoiTuongBLLService : IDoiTuongBLLService
    {
        private readonly IDoiTuongDALService _doiTuongDALService;
        private readonly ISinhVien_DoiTuongDALService _doiTuong_SinhVienDALService;

        public DoiTuongBLLService(IDoiTuongDALService doiTuongDALService, ISinhVien_DoiTuongDALService doiTuong_SinhVienDALService)
        {
            _doiTuongDALService = doiTuongDALService;
            _doiTuong_SinhVienDALService = doiTuong_SinhVienDALService;
        }

        public List<DoiTuong> LayDSDoiTuong()
        {
            return _doiTuongDALService.LayDSDoiTuong();
        }

        public SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            if (string.IsNullOrEmpty(tenDT))
            {
                return SuaDoiTuongMessage.EmptyTenDoiTuong;
            }

            if (string.IsNullOrEmpty(tiLeGiam))
            {
                return SuaDoiTuongMessage.EmptyTiLeGiam;
            }

            if (!float.TryParse(tiLeGiam, out float tiLeGiamValue) || tiLeGiamValue > 1 || tiLeGiamValue <= 0)
            {
                return SuaDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            if (maDTBanDau == 2)
            {
                return SuaDoiTuongMessage.Unable;
            }

            List<DoiTuong> doiTuongList = _doiTuongDALService.LayDSDoiTuong();
            DoiTuong doiTuong = doiTuongList.Find(dt => dt.TenDT == tenDT && dt.MaDT != maDTBanDau);
            if (doiTuong != null)
            {
                return SuaDoiTuongMessage.DuplicateTenDoiTuong;
            }

            return _doiTuongDALService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiamValue);
        }

        public ThemDoiTuongMessage ThemDoiTuong(string tenDT, string tiLeGiam)
        {
            if (string.IsNullOrEmpty(tenDT))
            {
                return ThemDoiTuongMessage.EmptyTenDoiTuong;
            }

            if (string.IsNullOrEmpty(tiLeGiam))
            {
                return ThemDoiTuongMessage.EmptyTiLeGiam;
            }

            if (!float.TryParse(tiLeGiam, out float tiLeGiamValue) || tiLeGiamValue > 1 || tiLeGiamValue <= 0)
            {
                return ThemDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            List<DoiTuong> doiTuongList = _doiTuongDALService.LayDSDoiTuong();
            DoiTuong doiTuong = doiTuongList.Find(dt => dt.TenDT == tenDT);
            if (doiTuong != null)
            {
                return ThemDoiTuongMessage.DuplicateTenDoiTuong;
            }

            return _doiTuongDALService.ThemDoiTuong(tenDT, tiLeGiamValue);
        }

        public XoaDoiTuongMessage XoaDoiTuong(int maDT)
        {
            if (maDT == 2)
            {
                return XoaDoiTuongMessage.UnableToDeleteVungSauVungXa;
            }

            List<SinhVien_DoiTuong> sinhVien_DoiTuongs = _doiTuong_SinhVienDALService.GetSinhVien_DoiTuongs();
            SinhVien_DoiTuong sinhVien_DoiTuong = sinhVien_DoiTuongs.Find(dt => dt.MaDT ==  maDT);
            if (sinhVien_DoiTuong != null)
            {
                return XoaDoiTuongMessage.Unable;
            }

            return _doiTuongDALService.XoaDoiTuong(maDT);
        }

        public List<DoiTuong> LayDSDoiTuongBangMaSV(string maSV)
        {
            return _doiTuongDALService.LayDSDoiTuongBangMaSV(maSV);
        }

        public List<DoiTuong> LayDSDoiTuongKhongThuocVeMaSV(string maSV)
        {
            return _doiTuongDALService.LayDSDoiTuongKhongThuocVeMaSV(maSV);
        }

        public List<DoiTuong> LayDSDoiTuong2()
        {
            return _doiTuongDALService.LayDSDoiTuong2();
        }
    }
}
