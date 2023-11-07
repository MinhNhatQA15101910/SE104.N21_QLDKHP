namespace DTO
{
    public enum DangNhapMessage
    {
        None,
        EmptyTenDangNhap,
        EmptyMatKhau,
        Failed,
        Success
    }

    public enum ThemTaiKhoanSVMessage
    {
        None,
        Success,
        Failed,
        Unable
    }

    public enum XoaTaiKhoanMessage
    {
        None,
        Success,
        Failed,
        Unable
    }

    public enum DoiMatKhauMessage
    {
        None,
        EmptyMatKhauHT,
        EmptyMatKhauMoi, 
        EmptyMatKhauNhapLai,
        InvalidNewPassword,
        Success,
        Failed
    }

    public enum SuaTaiKhoanMessage
    {
        None,
        EmptyTenDangNhap, 
        DuplicateTenDangNhap,
        Failed,
        Success
    }

    public enum ThemTaiKhoanMessage
    {
        None,
        EmptyTenDangNhap,
        DuplicateTenDangNhap,
        Failed,
        Success
    }

    public enum SuaDoiTuongMessage
    {
        None,
        EmptyTenDoiTuong,
        EmptyTiLeGiam,
        TiLeGiamKhongHopLe,
        Unable, 
        DuplicateTenDoiTuong,
        Failed,
        Success
    }

    public enum ThemDoiTuongMessage
    {
        None,
        EmptyTenDoiTuong,
        EmptyTiLeGiam,
        TiLeGiamKhongHopLe,
        DuplicateTenDoiTuong,
        Failed,
        Success
    }

    public enum XoaDoiTuongMessage
    {
        None,
        Success,
        UnableToDeleteVungSauVungXa,
        Failed,
        Unable
    }

    public enum SuaGioiHanTinChiMessage
    {
        None,
        TinChiToiDaRong,
        TinChiToiThieuRong,
        TinChiToiDaKhongHopLe, 
        TinChiToiThieuKhongHopLe, 
        Unable,
        Failed,
        Success
    }

    public enum XoaLoaiMonHocMessage
    {
        None,
        Unable,
        Failed,
        Success 
    }

    public enum SuaLoaiMonHocMessage
    {
        None,
        EmptyTenLoaiMonHoc,
        EmptySoTiet,
        EmptySoTien,
        SoTietKhongHopLe,
        SoTienKhongHopLe,
        DuplicateTenLoaiMonHoc,
        Failed,
        Success,
    }

    public enum ThemLoaiMonHocMessage
    {
        None,
        EmptyTenLoaiMonHoc,
        EmptySoTiet,
        EmptySoTien,
        SoTietKhongHopLe,
        SoTienKhongHopLe,
        DuplicateTenLoaiMonHoc,
        Failed,
        Success,
    }

    public enum SuaTinhMessage
    {
        None,
        EmptyTenTinh,
        DuplicateTenTinh,
        Failed,
        Success,
    }

    public enum ThemTinhMessage
    {
        None,
        EmptyTenTinh,
        DuplicateTenTinh,
        Failed,
        Success,
    }

    public enum XoaTinhMessage
    {
        None,
        Unable,
        Failed,
        Success
    }

    public enum SuaHuyenMessage
    {
        None,
        EmptyTenHuyen,
        DuplicateTenHuyen,
        Failed,
        Success
    }

    public enum ThemHuyenMessage
    {
        None,
        EmptyTenHuyen,
        DuplicateTenHuyen,
        Failed,
        Success
    }

    public enum XoaHuyenMessage
    {
        None,
        Unable,
        Failed,
        Success
    }

    public enum SuaNganhMessage
    {
        None,
        EmptyMaNganh,
        EmptyTenNganh,
        DuplicateMaNganh,
        DuplicateTenNganh,
        UnableForSinhVien,
        UnableForChuongTrinhHoc,
        Failed,
        Success
    }

    public enum ThemNganhMessage
    {
        None,
        EmptyMaNganh,
        EmptyTenNganh,
        DuplicateMaNganh,
        DuplicateTenNganh,
        Failed,
        Success
    }

    public enum XoaNganhMessage
    {
        None,
        UnableForSinhVien,
        UnableForChuongTrinhHoc,
        Failed,
        Success
    }

    public enum SuaKhoaMessage
    {
        None,
        EmptyMaKhoa,
        EmptyTenKhoa,
        DuplicateMaKhoa,
        DuplicateTenKhoa,
        Unable,
        Success,
        Failed
    }

    public enum ThemKhoaMessage
    {
        None,
        EmptyMaKhoa,
        EmptyTenKhoa,
        DuplicateMaKhoa,
        DuplicateTenKhoa,
        Success,
        Failed
    }

    public enum XoaKhoaMessage
    {
        None,
        Unable,
        Success,
        Failed
    }

    public enum XoaMonHocMessage
    {
        None,
        UnableForDanhSachMonHocMo,
        UnableForCT_PhieuDKHP,
        UnableForChuongTrinhHoc,
        Failed,
        Success
    }

    public enum SuaMonHocMessage
    {
        None,
        EmptyMaMH,
        EmptyTenMH,
        EmptySoTiet,
        InvalidSoTiet,
        DuplicateMaMH,
        UnableForDanhSachMonHocMo,
        UnableForCT_PhieuDKHP,
        UnableForChuongTrinhHoc,
        Failed,
        Success
    }

    public enum ThemMonHocMessage
    {
        None,
        EmptyMaMH,
        EmptyTenMH,
        EmptySoTiet,
        InvalidSoTiet,
        DuplicateMaMH,
        Failed,
        Success
    }

    public enum SuaSinhVienMessage
    {
        None,
        EmptyMaSV,
        EmptyTenSV,
        DuplicateMaSV,
        Failed,
        Success
    }

    public enum ThemSinhVienMessage
    {
        None,
        EmptyMaSV,
        EmptyTenSV,
        DuplicateMaSV,
        Failed,
        Success
    }

    public enum XoaSinhVienMessage
    {
        None,
        Failed,
        Success
    }

    public enum TimKiemPhieuDKHPMessage
    {
        None,
        EmptyNamHoc,
        InvalidNamHoc,
        Failed,
        Sucess
    }

    public enum TimKiemTTHocPhiMessage
    {
        None,
        EmptyNamHoc,
        InvalidNamHoc,
        Failed,
        Sucess
    }

    public enum MessageKhoangTGDongHP
    {
        None,
        Success,
        Failed,
    }

    public enum MessageAddMonHocMo
    {
        None,
        Success,
        Failed,
        Data
    }

    public enum MessageDeleteHocKyNamHocMHM
    {
        None,
        Success,
        Failed
    }

    public enum MessageDeleteListCTHoc
    {
        None,
        Success,
        Failed
    }

    public enum MessageAddCTHoc
    {
        None,
        Success,
        Failed,
        Data
    }

    public enum MessageDeleteCTHoc
    {
        None,
        Success,
        Failed,
        Data
    }

    public enum MessagePhieuDKHPUpdateTinhTrang
    {
        None,
        Success,
        Failed
    }

    public enum MessagePhieuThuHPUpdateTinhTrang
    {
        None,
        Success,
        Failed
    }
}
