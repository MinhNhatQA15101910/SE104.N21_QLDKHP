using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_Huyen
    {
        public int MaHuyen { get; set; }
        public string TenHuyen { get; set; }
        public int VungUT { get; set; }
        public int MaTinh { get; set; }
        public string TenTTP { get; set; }
        public string DisplayHuyen
        {
            get
            {
                return TenTTP + ", " + TenHuyen;
            }
        }
    }
}
