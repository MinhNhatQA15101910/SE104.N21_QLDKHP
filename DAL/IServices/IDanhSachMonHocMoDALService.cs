using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IServices
{
    public interface IDanhSachMonHocMoDALService
    {
        List<string> LayDSMonHocMo();
        List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc);
        List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc);
    }
}
