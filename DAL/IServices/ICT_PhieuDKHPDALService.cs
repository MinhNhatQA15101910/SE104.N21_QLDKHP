using DTO;

namespace DAL.IServices
{
    public interface ICT_PhieuDKHPDALService
    {
        void TaoCT_PhieuDKHP(CT_PhieuDKHP ct_PhieuDKHP);
        void XoaDSMHDKHP(int maPhieu);
    }
}
