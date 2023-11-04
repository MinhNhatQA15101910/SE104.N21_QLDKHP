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

        public LoaiMonHocBLLService(ILoaiMonHocDALService loaiMonHocDALService)
        {
            _loaiMonHocDALService = loaiMonHocDALService;
        }

        public List<LoaiMonHoc> LayDSLoaiMonHoc()
        {
            return _loaiMonHocDALService.LayDSLoaiMonHoc();
        }

        public XoaLoaiMonHocMessage XoaLoaiMonHoc(int maLoaiMonHoc)
        {
            IMonHocBLLService monHocBLLService = new MonHocBLLService(new MonHocDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
            List<CT_MonHoc> ct_MonHocs = monHocBLLService.LayDSMonHoc();
            CT_MonHoc ct_MonHoc = ct_MonHocs.Find(mh => mh.MaLoaiMonHoc == maLoaiMonHoc);
            if (ct_MonHoc != null)
            {
                return XoaLoaiMonHocMessage.Unable;
            }

            return _loaiMonHocDALService.XoaLoaiMonHoc(maLoaiMonHoc);
        }

        public SuaLoaiMonHocMessage SuaLoaiMonHoc(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            if (tenLoaiMonHoc.Equals(""))
            {
                return SuaLoaiMonHocMessage.EmptyTenLoaiMonHoc;
            }

            if (soTiet.Equals(""))
            {
                return SuaLoaiMonHocMessage.EmptySoTiet;
            }

            if (soTien.Equals(""))
            {
                return SuaLoaiMonHocMessage.EmptySoTien;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return SuaLoaiMonHocMessage.SoTietKhongHopLe;
            }

            if (soTietValue < 0)
            {
                return SuaLoaiMonHocMessage.SoTietKhongHopLe;
            }

            decimal soTienValue;
            if (!decimal.TryParse(soTien, out soTienValue))
            {
                return SuaLoaiMonHocMessage.SoTienKhongHopLe;
            }

            if (soTienValue < 0)
            {
                return SuaLoaiMonHocMessage.SoTienKhongHopLe;
            }

            return _loaiMonHocDALService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTietValue, soTienValue);
        }

        public ThemLoaiMonHocMessage ThemLoaiMonHoc(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            if (tenLoaiMonHoc.Equals(""))
            {
                return ThemLoaiMonHocMessage.EmptyTenLoaiMonHoc;
            }

            if (soTiet.Equals(""))
            {
                return ThemLoaiMonHocMessage.EmptySoTiet;
            }

            if (soTien.Equals(""))
            {
                return ThemLoaiMonHocMessage.EmptySoTien;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return ThemLoaiMonHocMessage.SoTietKhongHopLe;
            }

            if (soTietValue < 0)
            {
                return ThemLoaiMonHocMessage.SoTietKhongHopLe;
            }

            decimal soTienValue;
            if (!decimal.TryParse(soTien, out soTienValue))
            {
                return ThemLoaiMonHocMessage.SoTienKhongHopLe;
            }

            if (soTienValue < 0)
            {
                return ThemLoaiMonHocMessage.SoTienKhongHopLe;
            }

            return _loaiMonHocDALService.ThemLoaiMonHoc(tenLoaiMonHoc, soTietValue, soTienValue);
        }
    }
}
