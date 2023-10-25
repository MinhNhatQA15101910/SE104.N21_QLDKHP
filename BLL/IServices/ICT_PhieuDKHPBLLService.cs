using System.Collections.Generic;

namespace BLL.IServices
{
    public interface ICT_PhieuDKHPBLLService
    {
        void TaoCT_PhieuDKHP(int maPhieu, List<string> list);
        void XoaDSMHDKHP(int maPhieu);
    }
}
