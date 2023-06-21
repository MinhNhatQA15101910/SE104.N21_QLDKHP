using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GlobalConfig
    {
        public static NguoiDung CurrNguoiDung { get; set; } = new NguoiDung();
        public static int CurrMaHocKy { get; set; }
        public static int CurrNamHoc { get; set; }
    }
}
