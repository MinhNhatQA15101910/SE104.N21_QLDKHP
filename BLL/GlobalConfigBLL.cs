using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GlobalConfigBLL
    {
        public static int GetCurrNamHoc()
        {
            return GlobalConfigDAL.GetCurrNamHoc();
        }

        public static int GetCurrMaHocKy()
        {
            return GlobalConfigDAL.GetCurrMaHocKy();
        }
    }
}
