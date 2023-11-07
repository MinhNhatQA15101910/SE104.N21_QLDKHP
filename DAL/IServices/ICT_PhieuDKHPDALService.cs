using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface ICT_PhieuDKHPDALService
    {
        int TaoCT_PhieuDKHP(CT_PhieuDKHP ct_PhieuDKHP);
        int XoaDSMHDKHP(int maPhieu);
        List<CT_PhieuDKHP> GetCT_PhieuDKHPs();
    }
}
