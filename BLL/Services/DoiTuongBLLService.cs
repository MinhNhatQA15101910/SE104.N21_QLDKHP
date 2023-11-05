using BLL.IServices;
using DAL.IServices;
using DAL.Services;
using DTO;
using System.Collections.Generic;
using System.Configuration;

namespace BLL.Services
{
    public class DoiTuongBLLService : IDoiTuongBLLService
    {
        private readonly IDoiTuongDALService _doiTuongDALService;

        public DoiTuongBLLService(IDoiTuongDALService doiTuongDALService)
        {
            _doiTuongDALService = doiTuongDALService;
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

            ISinhVien_DoiTuongDALService sinhVien_DoiTuongDALService = new SinhVien_DoiTuongDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
            List<SinhVien_DoiTuong> sinhVien_DoiTuongs = sinhVien_DoiTuongDALService.GetSinhVien_DoiTuongs();
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
