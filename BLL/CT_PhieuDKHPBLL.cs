using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CT_PhieuDKHPBLL
    {
        public static void TaoCT_PhieuDKHP(int maPhieu, List<string> list)
        {
            CT_PhieuDKHPDAL.TaoCT_PhieuDKHP(maPhieu, list);
        }

        public static void XoaDSMHDKHP(int maPhieu)
        {
            CT_PhieuDKHPDAL.XoaDSMHDKHP(maPhieu);
        }
    }
}
