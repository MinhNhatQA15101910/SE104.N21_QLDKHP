using DTO;

namespace BLL.IServices
{
    public interface ICT_PhieuDKHPBLLService
    {
        void TaoCT_PhieuDKHP(CT_PhieuDKHP ct_phieuDKHP);
        void XoaDSMHDKHP(int maPhieu);
    }
}
