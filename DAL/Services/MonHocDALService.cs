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
    public class MonHocDALService: IMonHocDALService
    {
        private readonly IDapperService _dapperService;

        public MonHocDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<CT_MonHoc> LayDSMonHoc()
        {
            return _dapperService.Query<CT_MonHoc>("spMONHOC_LayDSMonHoc").ToList();
        }

        public  XoaMonHocMessage XoaMonHoc(string maMH)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMH);
                _dapperService.Execute("spMONHOC_XoaMonHoc", p, CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return XoaMonHocMessage.Error;
            }

            return XoaMonHocMessage.Success;
        }

        public  SuaMonHocMessage SuaMonHoc(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMHBanDau);
                p.Add("@TenMH", tenMH);
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                _dapperService.Execute("spMONHOC_SuaMonHoc", p, CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return SuaMonHocMessage.Error;
            }

            return SuaMonHocMessage.Success;
        }

        public  ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaMH", maMH);
                p.Add("@TenMH", tenMH);
                p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                p.Add("@SoTiet", soTiet);
                _dapperService.Execute("spMONHOC_ThemMonHoc", p, CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 && ex.Message.Contains("PK_MONHOC"))
                {
                    return ThemMonHocMessage.DuplicateMaMH;
                }
            }
            catch (Exception)
            {
                return ThemMonHocMessage.Error;
            }

            return ThemMonHocMessage.Success;
        }

        public  List<MonHoc> LayDSMonHoc2()
        {
            return _dapperService.Query<MonHoc>("spMONHOC_LayDSMonHoc2").ToList();
        }

        public  List<MonHoc> GetTermMonHoc(int HocKy)
        {
            if (HocKy == 1)
            {
                return _dapperService.Query<MonHoc>("spMONHOC_GetOddCTMonHoc").ToList();
            }
            else if (HocKy == 2)
            {
                return _dapperService.Query<MonHoc>("spMONHOC_GetEvenCTMonHoc").ToList();
            }

            return _dapperService.Query<MonHoc>("spMONHOC_GetAllCTMonHoc").ToList();
        }

        public  List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc)
        {
            var p = new DynamicParameters();
            p.Add("@HocKy", HocKy);
            p.Add("@NamHoc", NamHoc);
            return _dapperService.Query<MonHoc>("spMONHOC_GetTermMonHocMo", p, CommandType.StoredProcedure).ToList();
        }

        public  List<MonHoc> GetChuongTrinhHoc(string MaNganh, int HocKy)
        {
            if (HocKy != 0)
            {
                var p = new DynamicParameters();
                p.Add("@MaNganh", MaNganh);
                p.Add("@HocKy", HocKy);
                return _dapperService.Query<MonHoc>("spMONHOC_GetCTHHocKy", p, CommandType.StoredProcedure).ToList();
            }
            else
            {
                var p = new DynamicParameters();
                p.Add("@MaNganh", MaNganh);
                return _dapperService.Query<MonHoc>("spMONHOC_GetCTHHocKy", p, CommandType.StoredProcedure).ToList();
            }
        }

        public  List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP)
        {
            var p = new DynamicParameters();
            p.Add("@MaPhieuDKHP", MaPhieuDKHP);
            return _dapperService.Query<MonHoc>("spMONHOC_GetMonHocPhieuDKHP", p, CommandType.StoredProcedure).ToList();
        }
    }
}
