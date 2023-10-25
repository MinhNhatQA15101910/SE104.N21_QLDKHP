using BLL.IServices;
using DAL.IServices;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CT_DKHPBLLService: ICT_PhieuDKHPBLLService
    {
        private readonly ICT_PhieuDKHPDALService _phieuDKHPDALService;

        public CT_DKHPBLLService(ICT_PhieuDKHPDALService phieuDKHPDALService)
        {
            _phieuDKHPDALService = phieuDKHPDALService;
        }

        public void TaoCT_PhieuDKHP(int maPhieu, List<string> list)
        {
            _phieuDKHPDALService.TaoCT_PhieuDKHP(maPhieu, list);
        }
        public void XoaDSMHDKHP(int maPhieu)
        {
            _phieuDKHPDALService.XoaDSMHDKHP(maPhieu);
        }
    }
}
