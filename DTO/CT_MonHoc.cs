using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_MonHoc
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int MaLoaiMonHoc { get; set; }
        public int SoTiet { get; set; }
        public string TenLoaiMonHoc { get; set; }
        public int SoTietLoaiMon { get; set; }
        public decimal SoTien { get; set; }
    }
}
