using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class MonHocDALService: IMonHocDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public MonHocDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<CT_MonHoc> LayDSMonHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<CT_MonHoc>(connection, "spMONHOC_LayDSMonHoc").ToList();
            }
        }

        public XoaMonHocMessage XoaMonHoc(string maMH)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMH);
                int result = _dapperWrapper.Execute(connection, "spMONHOC_XoaMonHoc", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? XoaMonHocMessage.Success : XoaMonHocMessage.Failed;
            }
        }

        public  SuaMonHocMessage SuaMonHoc(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMHBanDau);
                p.Add("@TenMH", tenMH);
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                int result = _dapperWrapper.Execute(connection, "spMONHOC_SuaMonHoc", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaMonHocMessage.Success : SuaMonHocMessage.Failed;
            }
        }

        public ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMH);
                p.Add("@TenMH", tenMH);
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                int result = _dapperWrapper.Execute(connection, "spMONHOC_ThemMonHoc", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? ThemMonHocMessage.Success : ThemMonHocMessage.Failed;
            }
        }

        public List<MonHoc> LayDSMonHoc2()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_LayDSMonHoc2").ToList();
            }
        }

        public List<MonHoc> GetTermMonHoc(int hocKy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                if (hocKy == 1)
                {
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetOddCTMonHoc").ToList();
                }
                else if (hocKy == 2)
                {
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetEvenCTMonHoc").ToList();
                }

                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetAllCTMonHoc").ToList();
            }
        }

        public List<MonHoc> GetTermMonHocMo(int hocKy, int namHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@HocKy", hocKy);
                p.Add("@NamHoc", namHoc);
                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetTermMonHocMo", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<MonHoc> GetChuongTrinhHoc(string maNganh, int hocKy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                if (hocKy != 0)
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", maNganh);
                    p.Add("@HocKy", hocKy);
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetCTHHocKy", p, commandType: CommandType.StoredProcedure).ToList();
                }
                else
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", maNganh);
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetCTHHocKy", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
        }

        public List<MonHoc> GetMonHocPhieuDKHP(int maPhieuDKHP)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaPhieuDKHP", maPhieuDKHP);
                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetMonHocPhieuDKHP", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
