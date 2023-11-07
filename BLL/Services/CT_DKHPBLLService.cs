using BLL.IServices;
using DAL.IServices;
using DTO;

namespace BLL.Services
{
    public class CT_DKHPBLLService: ICT_PhieuDKHPBLLService
    {
        private readonly ICT_PhieuDKHPDALService _phieuDKHPDALService;

        public CT_DKHPBLLService(ICT_PhieuDKHPDALService phieuDKHPDALService)
        {
            _phieuDKHPDALService = phieuDKHPDALService;
        }

        public void TaoCT_PhieuDKHP(CT_PhieuDKHP ct_phieuDKHP)
        {
            _phieuDKHPDALService.TaoCT_PhieuDKHP(ct_phieuDKHP);
        }
        public void XoaDSMHDKHP(int maPhieu)
        {
            _phieuDKHPDALService.XoaDSMHDKHP(maPhieu);
        }
    }
}
