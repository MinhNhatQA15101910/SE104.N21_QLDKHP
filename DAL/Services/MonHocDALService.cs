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

        public  XoaMonHocMessage XoaMonHoc(string maMH)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMH);
                _dapperWrapper.Execute(connection, "spMONHOC_XoaMonHoc", p, commandType: CommandType.StoredProcedure);

                return XoaMonHocMessage.Success;
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
                _dapperWrapper.Execute(connection, "spMONHOC_SuaMonHoc", p, commandType: CommandType.StoredProcedure);

                return SuaMonHocMessage.Success;
            }
        }

        public  ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMH);
                p.Add("@TenMH", tenMH);
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                _dapperWrapper.Execute(connection, "spMONHOC_ThemMonHoc", p, commandType: CommandType.StoredProcedure);

                return ThemMonHocMessage.Success;
            }
        }

        public  List<MonHoc> LayDSMonHoc2()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_LayDSMonHoc2").ToList();
            }
        }

        public  List<MonHoc> GetTermMonHoc(int HocKy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                if (HocKy == 1)
                {
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetOddCTMonHoc").ToList();
                }
                else if (HocKy == 2)
                {
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetEvenCTMonHoc").ToList();
                }

                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetAllCTMonHoc").ToList();
            }
        }

        public  List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@HocKy", HocKy);
                p.Add("@NamHoc", NamHoc);
                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetTermMonHocMo", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public  List<MonHoc> GetChuongTrinhHoc(string MaNganh, int HocKy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                if (HocKy != 0)
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", MaNganh);
                    p.Add("@HocKy", HocKy);
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetCTHHocKy", p, commandType: CommandType.StoredProcedure).ToList();
                }
                else
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", MaNganh);
                    return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetCTHHocKy", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
        }

        public  List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaPhieuDKHP", MaPhieuDKHP);
                return _dapperWrapper.Query<MonHoc>(connection, "spMONHOC_GetMonHocPhieuDKHP", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
