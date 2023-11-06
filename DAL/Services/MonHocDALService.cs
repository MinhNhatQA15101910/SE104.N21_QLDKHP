using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class MonHocDALService: IMonHocDALService
    {
        private readonly IDbConnection _connection;

        public MonHocDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<CT_MonHoc> LayDSMonHoc()
        {
            return _connection.Query<CT_MonHoc>("spMONHOC_LayDSMonHoc").ToList();
        }

        public  XoaMonHocMessage XoaMonHoc(string maMH)
        {
            var p = new DynamicParameters();
            p.Add("@MaMH", maMH);
            _connection.Execute("spMONHOC_XoaMonHoc", p, commandType: CommandType.StoredProcedure);

            return XoaMonHocMessage.Success;
        }

        public  SuaMonHocMessage SuaMonHoc(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            var p = new DynamicParameters();
            p.Add("@MaMH", maMHBanDau);
            p.Add("@TenMH", tenMH);
            p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
            p.Add("@SoTiet", soTiet);
            _connection.Execute("spMONHOC_SuaMonHoc", p, commandType: CommandType.StoredProcedure);

            return SuaMonHocMessage.Success;
        }

        public  ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            var p = new DynamicParameters();
            p.Add("@MaMH", maMH);
            p.Add("@TenMH", tenMH);
            p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
            p.Add("@SoTiet", soTiet);
            _connection.Execute("spMONHOC_ThemMonHoc", p, commandType: CommandType.StoredProcedure);

            return ThemMonHocMessage.Success;
        }

        public  List<MonHoc> LayDSMonHoc2()
        {
            return _connection.Query<MonHoc>("spMONHOC_LayDSMonHoc2").ToList();
        }

        public  List<MonHoc> GetTermMonHoc(int HocKy)
        {
            if (HocKy == 1)
            {
                return _connection.Query<MonHoc>("spMONHOC_GetOddCTMonHoc").ToList();
            }
            else if (HocKy == 2)
            {
                return _connection.Query<MonHoc>("spMONHOC_GetEvenCTMonHoc").ToList();
            }

            return _connection.Query<MonHoc>("spMONHOC_GetAllCTMonHoc").ToList();
        }

        public  List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc)
        {
            var p = new DynamicParameters();
            p.Add("@HocKy", HocKy);
            p.Add("@NamHoc", NamHoc);
            return _connection.Query<MonHoc>("spMONHOC_GetTermMonHocMo", p, commandType: CommandType.StoredProcedure).ToList();
        }

        public  List<MonHoc> GetChuongTrinhHoc(string MaNganh, int HocKy)
        {
            if (HocKy != 0)
            {
                var p = new DynamicParameters();
                p.Add("@MaNganh", MaNganh);
                p.Add("@HocKy", HocKy);
                return _connection.Query<MonHoc>("spMONHOC_GetCTHHocKy", p, commandType: CommandType.StoredProcedure).ToList();
            }
            else
            {
                var p = new DynamicParameters();
                p.Add("@MaNganh", MaNganh);
                return _connection.Query<MonHoc>("spMONHOC_GetCTHHocKy", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public  List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP)
        {
            var p = new DynamicParameters();
            p.Add("@MaPhieuDKHP", MaPhieuDKHP);
            return _connection.Query<MonHoc>("spMONHOC_GetMonHocPhieuDKHP", p, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
