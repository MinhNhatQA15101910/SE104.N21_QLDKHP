using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class DoiTuongDALService: IDoiTuongDALService
    {
        private readonly IDapperService _dapperService;

        public DoiTuongDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<DoiTuong> LayDSDoiTuong()
        {
            return _dapperService.Query<DoiTuong>("spDOITUONG_LayDSDoiTuong").ToList();
        }

        public SuaDoiTuongMessage SuaDoiTuong(int maDTBanDau, string tenDT, float tiLeGiam)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaDT", maDTBanDau);
                p.Add("@TenDT", tenDT);
                p.Add("@TiLeGiamHocPhi", tiLeGiam);
                _dapperService.Execute("spDOITUONG_SuaDoiTuong", p, CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("UQ_DOITUONG_TenDT"))
                {
                    return SuaDoiTuongMessage.DuplicateTenDoiTuong;
                }
            }
            catch (Exception)
            {
                return SuaDoiTuongMessage.Error;
            }

            return SuaDoiTuongMessage.Success;
        }

        public ThemDoiTuongMessage ThemDoiTuong(string tenDT, float tiLeGiam)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@TenDT", tenDT);
                p.Add("@TiLeGiamHocPhi", tiLeGiam);
                _dapperService.Execute("spDOITUONG_ThemDoiTuong", p, CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("UQ_DOITUONG_TenDT"))
                {
                    return ThemDoiTuongMessage.DuplicateTenDoiTuong;
                }
            }
            catch (Exception)
            {
                return ThemDoiTuongMessage.Error;
            }

            return ThemDoiTuongMessage.Success;
        }

        public List<DoiTuong> LayDSDoiTuong2()
        {
            return _dapperService.Query<DoiTuong>("spDOITUONG_LayDSDoiTuong").ToList();
        }

        public List<DoiTuong> LayDSDoiTuongKhongThuocVeMaSV(string maSV)
        {
            var p = new DynamicParameters();
            p.Add("@MaSV", maSV);

            return _dapperService.Query<DoiTuong>("spDOITUONG_LayDSDoiTuongKhongThuocVeMaSV", p, CommandType.StoredProcedure).ToList();
        }

        public List<DoiTuong> LayDSDoiTuongBangMaSV(string maSV)
        {
            var p = new DynamicParameters();
            p.Add("@MaSV", maSV);

            return _dapperService.Query<DoiTuong>("spDOITUONG_LayDSDoiTuongBangMaSV", p, CommandType.StoredProcedure).ToList();
        }

        public XoaDoiTuongMessage XoaDoiTuong(int maDT)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaDT", maDT);
                _dapperService.Execute("spDOITUONG_XoaDoiTuong", p, CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return XoaDoiTuongMessage.Error;
            }

            return XoaDoiTuongMessage.Success;
        }
    }
}
