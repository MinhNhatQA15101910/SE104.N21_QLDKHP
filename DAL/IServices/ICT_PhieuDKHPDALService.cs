using System.Collections.Generic;

namespace DAL.IServices
{
    public interface ICT_PhieuDKHPDALService
    {
        void TaoCT_PhieuDKHP(int maPhieu, List<string> list);
        void XoaDSMHDKHP(int maPhieu);
    }
}
