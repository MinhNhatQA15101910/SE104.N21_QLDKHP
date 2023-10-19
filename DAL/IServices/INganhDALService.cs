using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface INganhDALService
    {
        List<CT_Nganh> LayDSNganh();
        XoaNganhMessage XoaNganh(string maNganh);
        SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua);
        ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa);
        List<Nganh> GetNganh(string MaKhoa);
    }
}
