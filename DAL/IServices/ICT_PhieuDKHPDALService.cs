using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface ICT_PhieuDKHPDALService
    {
        void TaoCT_PhieuDKHP(CT_PhieuDKHP ct_PhieuDKHP);
        void XoaDSMHDKHP(int maPhieu);
        List<CT_PhieuDKHP> GetCT_PhieuDKHPs();
    }
}
