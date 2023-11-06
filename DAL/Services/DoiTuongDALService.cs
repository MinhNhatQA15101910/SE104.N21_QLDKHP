using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class DoiTuongDALService: IDoiTuongDALService
    {
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public DoiTuongDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<DoiTuong> LayDSDoiTuong()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuong").ToList();
            }
        }

        public SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, float tiLeGiam)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaDT", maDTBanDau);
                p.Add("@TenDT", tenDT);
                p.Add("@TiLeGiamHocPhi", tiLeGiam);
                int result = _dapperWrapper.Execute(connection, "spDOITUONG_SuaDoiTuong", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? SuaDoiTuongMessage.Success : SuaDoiTuongMessage.Failed;
            }
        }

        public ThemDoiTuongMessage ThemDoiTuong(string tenDT, float tiLeGiam)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenDT", tenDT);
                p.Add("@TiLeGiamHocPhi", tiLeGiam);
                int result = _dapperWrapper.Execute(connection, "spDOITUONG_ThemDoiTuong", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? ThemDoiTuongMessage.Success : ThemDoiTuongMessage.Failed;
            }
        }

        public List<DoiTuong> LayDSDoiTuong2()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuong").ToList();
            }
        }

        public List<DoiTuong> LayDSDoiTuongKhongThuocVeMaSV(string maSV)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);

                return _dapperWrapper.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuongKhongThuocVeMaSV", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<DoiTuong> LayDSDoiTuongBangMaSV(string maSV)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);

                return _dapperWrapper.Query<DoiTuong>(connection, "spDOITUONG_LayDSDoiTuongBangMaSV", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public XoaDoiTuongMessage XoaDoiTuong(int maDT)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaDT", maDT);
                int result = _dapperWrapper.Execute(connection, "spDOITUONG_XoaDoiTuong", p, commandType: CommandType.StoredProcedure);

                return (result > 0) ? XoaDoiTuongMessage.Success : XoaDoiTuongMessage.Failed;
            }
        }
    }
}
