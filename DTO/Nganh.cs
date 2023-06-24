using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Nganh
    {
        public string MaNganh { get; set; }
        public string TenNganh { get; set; }
        public string MaKhoa { get; set; }
        public string DisplayNganh
        {
            get
            {
                return MaNganh + " - " + TenNganh;
            }
        }
    }
}
