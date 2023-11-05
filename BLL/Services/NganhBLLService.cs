using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class NganhBLLService : INganhBLLService
    {
        private readonly INganhDALService _nganhDALService;
        private readonly ISinhVienDALService _sinhVienDALService;
        private readonly IChuongTrinhHocDALService _chuongHocDALService;

        public NganhBLLService(INganhDALService nganhDALService, ISinhVienDALService sinhVienDALService, IChuongTrinhHocDALService chuongHocDALService)
        {
            _nganhDALService = nganhDALService;
            _sinhVienDALService = sinhVienDALService;
            _chuongHocDALService = chuongHocDALService;
        }

        public List<CT_Nganh> LayDSNganh()
        {
            return _nganhDALService.LayDSNganh();
        }

        public XoaNganhMessage XoaNganh(string maNganh)
        {
            return _nganhDALService.XoaNganh(maNganh);
        }

        public SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            if (string.IsNullOrEmpty(maNganhSua))
            {
                return SuaNganhMessage.EmptyMaNganh;
            }

            if (string.IsNullOrEmpty(tenNganhSua))
            {
                return SuaNganhMessage.EmptyTenNganh;
            }

            List<CT_Nganh> ct_Nganhs = _nganhDALService.LayDSNganh();
            CT_Nganh ct_Nganh = ct_Nganhs.Find(n => n.MaNganh == maNganhSua && n.MaNganh != maNganhBanDau);
            if (ct_Nganh != null)
            {
                return SuaNganhMessage.DuplicateMaNganh;
            }

            ct_Nganh = ct_Nganhs.Find(n => n.TenNganh == tenNganhSua && n.MaNganh != maNganhBanDau);
            if (ct_Nganh != null)
            {
                return SuaNganhMessage.DuplicateTenNganh;
            }

            List<CT_SinhVien> ct_SinhViens = _sinhVienDALService.LayDSSV();
            CT_SinhVien ct_SinhVien = ct_SinhViens.Find(sv => sv.MaNganh == maNganhBanDau);
            if (ct_SinhVien != null && maNganhBanDau != maNganhSua)
            {
                return SuaNganhMessage.UnableForSinhVien;
            }

            List<ChuongTrinhHoc> chuongTrinhHocs = _chuongHocDALService.GetAllCTHoc();
            ChuongTrinhHoc chuongTrinhHoc = chuongTrinhHocs.Find(cth => cth.MaNganh == maNganhBanDau);
            if (chuongTrinhHoc != null && maNganhBanDau != maNganhSua)
            {
                return SuaNganhMessage.UnableForChuongTrinhHoc;
            }

            return _nganhDALService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);
        }

        public ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            if (string.IsNullOrEmpty(maNganh))
            {
                return ThemNganhMessage.EmptyMaNganh;
            }

            if (string.IsNullOrEmpty(tenNganh))
            {
                return ThemNganhMessage.EmptyTenNganh;
            }

            List<CT_Nganh> ct_Nganhs = _nganhDALService.LayDSNganh();
            CT_Nganh ct_Nganh = ct_Nganhs.Find(n => n.MaNganh == maNganh);
            if (ct_Nganh != null)
            {
                return ThemNganhMessage.DuplicateMaNganh;
            }

            ct_Nganh = ct_Nganhs.Find(n => n.TenNganh == tenNganh);
            if (ct_Nganh != null)
            {
                return ThemNganhMessage.DuplicateTenNganh;
            }

            return _nganhDALService.ThemNganh(maNganh, tenNganh, maKhoa);
        }

        public List<Nganh> GetNganh(string MaKhoa)
        {
            return _nganhDALService.GetNganh(MaKhoa);
        }
    }
}
