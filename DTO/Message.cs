using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public enum DangNhapMessage
    {
        EmptyTenDangNhap,
        EmptyMatKhau,
        Failed, 
        Success, 
        Error
    }

    public enum ThemTaiKhoanSVMessage
    {
        Success, 
        Error, 
        Unable
    }

    public enum XoaTaiKhoanMessage
    {
        Success,
        Error, 
        Unable
    }

    public enum DoiMatKhauMessage
    {
        EmptyMatKhauHT,
        EmptyMatKhauMoi, 
        EmptyMatKhauNhapLai,
        InvalidNewPassword, 
        Success, 
        Failed,
        Error
    }

    public enum SuaTaiKhoanMessage
    {
        EmptyTenDangNhap, 
        DuplicateTenDangNhap,
        Success, 
        Error
    }

    public enum ThemTaiKhoanMessage
    {
        EmptyTenDangNhap,
        DuplicateTenDangNhap,
        Success,
        Error
    }

    public enum SuaDoiTuongMessage
    {
        EmptyTenDoiTuong,
        EmptyTiLeGiam,
        TiLeGiamKhongHopLe,
        Unable, 
        DuplicateTenDoiTuong,
        Success,
        Error
    }

    public enum ThemDoiTuongMessage
    {
        EmptyTenDoiTuong,
        EmptyTiLeGiam,
        TiLeGiamKhongHopLe,
        DuplicateTenDoiTuong,
        Success,
        Error
    }

    public enum XoaDoiTuongMessage
    {
        Success, 
        Error, 
        Unable
    }

    public enum SuaGioiHanTinChiMessage
    {
        TinChiToiDaRong,
        TinChiToiThieuRong,
        TinChiToiDaKhongHopLe, 
        TinChiToiThieuKhongHopLe, 
        Unable, 
        Success, 
        Error
    }

    public enum XoaLoaiMonHocMessage
    {
        Success, 
        Error
    }

    public enum SuaLoaiMonHocMessage
    {
        EmptyTenLoaiMonHoc,
        EmptySoTiet,
        EmptySoTien,
        SoTietKhongHopLe,
        SoTienKhongHopLe,
        DuplicateTenLoaiMonHoc,
        Success,
        Error
    }

    public enum ThemLoaiMonHocMessage
    {
        EmptyTenLoaiMonHoc,
        EmptySoTiet,
        EmptySoTien,
        SoTietKhongHopLe,
        SoTienKhongHopLe,
        DuplicateTenLoaiMonHoc,
        Success,
        Error
    }

    public enum SuaTinhMessage
    {
        EmptyTenTinh,
        DuplicateTenTinh,
        Success,
        Error
    }

    public enum ThemTinhMessage
    {
        EmptyTenTinh,
        DuplicateTenTinh,
        Success,
        Error
    }

    public enum XoaTinhMessage
    {
        Success, 
        Error
    }

    public enum SuaHuyenMessage
    {
        EmptyTenHuyen,
        DuplicateTenHuyen,
        Success,
        Error
    }

    public enum ThemHuyenMessage
    {
        EmptyTenHuyen,
        DuplicateTenHuyen,
        Success,
        Error
    }

    public enum XoaHuyenMessage
    {
        Success, 
        Error
    }

    public enum XoaNganhMessage
    {
        Success,
        Error
    }

    public enum SuaKhoaMessage
    {
        EmptyMaKhoa,
        EmptyTenKhoa,
        DuplicateMaKhoa,
        DuplicateTenKhoa,
        Success,
        Error
    }

    public enum ThemKhoaMessage
    {
        EmptyMaKhoa,
        EmptyTenKhoa,
        DuplicateMaKhoa,
        DuplicateTenKhoa,
        Success,
        Error
    }

    public enum SuaNganhMessage
    {
        EmptyMaNganh,
        EmptyTenNganh,
        DuplicateMaNganh,
        DuplicateTenNganh,
        Success,
        Error
    }

    public enum ThemNganhMessage
    {
        EmptyMaNganh,
        EmptyTenNganh,
        DuplicateMaNganh,
        DuplicateTenNganh,
        Success,
        Error
    }

    public enum XoaKhoaMessage
    {
        Success,
        Error
    }

    public enum XoaMonHocMessage
    {
        Success,
        Error
    }

    public enum SuaMonHocMessage
    {
        Unable,
        EmptyMaMH,
        EmptyTenMH,
        EmptySoTiet,
        InvalidSoTiet,
        DuplicateMaMH,
        Success,
        Error
    }

    public enum ThemMonHocMessage
    {
        EmptyMaMH,
        EmptyTenMH,
        EmptySoTiet,
        InvalidSoTiet,
        DuplicateMaMH,
        Success,
        Error
    }

    public enum SuaSinhVienMessage
    {
        EmptyMaSV,
        EmptyTenSV,
        DuplicateMaSV,
        Success,
        Error
    }

    public enum ThemSinhVienMessage
    {
        EmptyMaSV,
        EmptyTenSV,
        DuplicateMaSV,
        Success,
        Error
    }

    public enum XoaSinhVienMessage
    {
        Success,
        Error
    }
}
