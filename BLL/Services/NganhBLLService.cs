using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class NganhBLLService : INganhBLLService
    {
        private readonly INganhDALService _nganhDALService;

        public NganhBLLService(INganhDALService nganhDALService)
        {
            _nganhDALService = nganhDALService;
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

            return _nganhDALService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);
        }

        public ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            if (maNganh.Equals(""))
            {
                return ThemNganhMessage.EmptyMaNganh;
            }

            if (tenNganh.Equals(""))
            {
                return ThemNganhMessage.EmptyTenNganh;
            }

            return _nganhDALService.ThemNganh(maNganh, tenNganh, maKhoa);
        }

        public List<Nganh> GetNganh(string MaKhoa)
        {
            return _nganhDALService.GetNganh(MaKhoa);
        }
    }
}
