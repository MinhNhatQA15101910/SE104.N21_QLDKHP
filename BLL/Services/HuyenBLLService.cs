using BLL.IServices;
using DAL.IServices;
using DAL.Services;
using DTO;
using System.Collections.Generic;
using System.Configuration;

namespace BLL.Services
{
    public class HuyenBLLService : IHuyenBLLService
    {
        private readonly IHuyenDALService _huyenDALService;

        public HuyenBLLService(IHuyenDALService huyenDALService)
        {
            _huyenDALService = huyenDALService;
        }

        public List<CT_Huyen> LayDSHuyen()
        {
            return _huyenDALService.LayDSHuyen();
        }

        public SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            if (string.IsNullOrEmpty(tenHuyen))
            {
                return SuaHuyenMessage.EmptyTenHuyen;
            }

            List<CT_Huyen> ct_Huyens = _huyenDALService.LayDSHuyen();
            CT_Huyen ct_Huyen = ct_Huyens.Find(h => h.TenHuyen == tenHuyen && h.MaTinh == maTinh && h.MaHuyen != maHuyen);
            if (ct_Huyen != null)
            {
                return SuaHuyenMessage.DuplicateTenHuyen;
            }

            return _huyenDALService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);
        }

        public ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh)
        {
            if (string.IsNullOrEmpty(tenHuyen))
            {
                return ThemHuyenMessage.EmptyTenHuyen;
            }

            List<CT_Huyen> ct_Huyens = _huyenDALService.LayDSHuyen();
            CT_Huyen ct_Huyen = ct_Huyens.Find(h => h.TenHuyen == tenHuyen && h.MaTinh == maTinh);
            if (ct_Huyen != null)
            {
                return ThemHuyenMessage.DuplicateTenHuyen;
            }

            return _huyenDALService.ThemHuyen(tenHuyen, vungUT, maTinh);
        }

        public XoaHuyenMessage XoaHuyen(int maHuyen)
        {
            ISinhVienBLLService sinhVienBLLService = new SinhVienBLLService(new SinhVienDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
            List<CT_SinhVien> ct_SinhViens = sinhVienBLLService.LayDSSV();
            CT_SinhVien ct_SinhVien = ct_SinhViens.Find(sv => sv.MaHuyen == maHuyen);
            if (ct_SinhVien != null)
            {
                return XoaHuyenMessage.Unable;
            }

            return _huyenDALService.XoaHuyen(maHuyen);
        }
    }
}
