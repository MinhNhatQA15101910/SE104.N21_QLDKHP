using DAL.Services;
using BLL.IServices;
using DAL;
using DTO;
using System.Collections.Generic;
using DAL.IServices;
using System.Configuration;

namespace BLL.Services
{
    public class MonHocBLLService: IMonHocBLLService
    {
        private readonly IDanhSachMonHocMoDALService _danhSachMonHocMoDALService = new DanhSachMonHocMoDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString);
        
        private readonly IMonHocDALService _monHocDALService;

        public MonHocBLLService(IMonHocDALService monHocDALService)
        {
            _monHocDALService = monHocDALService;
        }
        public List<CT_MonHoc> LayDSMonHoc()
        {
            return _monHocDALService.LayDSMonHoc();
        }

        public XoaMonHocMessage XoaMonHoc(string maMH)
        {
            return _monHocDALService.XoaMonHoc(maMH);
        }

        public SuaMonHocMessage SuaMonHoc(string maMHBanDau, string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon)
        {
            List<string> currMonHocMoList = _danhSachMonHocMoDALService.LayDSMonHocMo();
            if (currMonHocMoList.Contains(maMHBanDau))
            {
                return SuaMonHocMessage.Unable;
            }

            if (maMH.Equals(""))
            {
                return SuaMonHocMessage.EmptyMaMH;
            }

            if (tenMH.Equals(""))
            {
                return SuaMonHocMessage.EmptyTenMH;
            }

            if (soTiet.Equals(""))
            {
                return SuaMonHocMessage.EmptySoTiet;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return SuaMonHocMessage.InvalidSoTiet;
            }

            if (soTietValue < 0)
            {
                return SuaMonHocMessage.InvalidSoTiet;
            }

            if (soTietValue % soTietLoaiMon != 0)
            {
                return SuaMonHocMessage.InvalidSoTiet;
            }

            return _monHocDALService.SuaMonHoc(maMHBanDau, tenMH, maLoaiMonHoc, soTietValue);
        }

        public ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, string soTiet, int soTietLoaiMon)
        {
            if (maMH.Equals(""))
            {
                return ThemMonHocMessage.EmptyMaMH;
            }

            if (tenMH.Equals(""))
            {
                return ThemMonHocMessage.EmptyTenMH;
            }

            if (soTiet.Equals(""))
            {
                return ThemMonHocMessage.EmptySoTiet;
            }

            int soTietValue;
            if (!int.TryParse(soTiet, out soTietValue))
            {
                return ThemMonHocMessage.InvalidSoTiet;
            }

            if (soTietValue % soTietLoaiMon != 0)
            {
                return ThemMonHocMessage.InvalidSoTiet;
            }

            return _monHocDALService.ThemMonHoc(maMH, tenMH, maLoaiMonHoc, soTietValue);
        }

        public List<MonHoc> GetTermMonHoc(int HocKy)
        {
            return _monHocDALService.GetTermMonHoc(HocKy);
        }

        public List<MonHoc> GetTermMonHocMo(int HocKy, int NamHoc)
        {
            return _monHocDALService.GetTermMonHocMo(HocKy, NamHoc);
        }

        public List<MonHoc> GetChuongTrinhHoc(string Nganh, int HocKy)
        {
            return _monHocDALService.GetChuongTrinhHoc(Nganh, HocKy);
        }

        public List<MonHoc> LayDSMonHoc2()
        {
            return _monHocDALService.LayDSMonHoc2();
        }

        public List<MonHoc> GetMonHocPhieuDKHP(int MaPhieuDKHP)
        {
            return _monHocDALService.GetMonHocPhieuDKHP(MaPhieuDKHP);
        }
    }
}
