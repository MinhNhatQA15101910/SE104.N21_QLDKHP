using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

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
            DoiTuong doiTuong = doiTuongList.Find(dt => dt.TenDT == tenDT);
            if (doiTuong != null)
            {
                return SuaDoiTuongMessage.DuplicateTenDoiTuong;
            }

            return _doiTuongDALService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiamValue);
        }

        public ThemDoiTuongMessage ThemDoiTuong(string tenDT, string tiLeGiam)
        {
            if (tenDT.Equals(""))
            {
                return ThemDoiTuongMessage.EmptyTenDoiTuong;
            }

            if (tiLeGiam.Equals(""))
            {
                return ThemDoiTuongMessage.EmptyTiLeGiam;
            }

            float tiLeGiamValue;
            if (!float.TryParse(tiLeGiam, out tiLeGiamValue))
            {
                return ThemDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            if (tiLeGiamValue > 1 || tiLeGiamValue <= 0)
            {
                return ThemDoiTuongMessage.TiLeGiamKhongHopLe;
            }

            return _doiTuongDALService.ThemDoiTuong(tenDT, tiLeGiamValue);
        }

        public XoaDoiTuongMessage XoaDoiTuong(int maDT)
        {
            if (maDT == 2)
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
