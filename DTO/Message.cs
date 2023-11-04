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
        Unable
    }

    public enum XoaTaiKhoanMessage
    {
        None,
        Success,
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
        Success
    }

    public enum ThemTaiKhoanMessage
    {
        None,
        EmptyTenDangNhap,
        DuplicateTenDangNhap,
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
        Success
    }

    public enum ThemDoiTuongMessage
    {
        None,
        EmptyTenDoiTuong,
        EmptyTiLeGiam,
        TiLeGiamKhongHopLe,
        DuplicateTenDoiTuong,
        Success
    }

    public enum XoaDoiTuongMessage
    {
        None,
        Success,
        UnableToDeleteVungSauVungXa,
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
        Success
    }

    public enum XoaLoaiMonHocMessage
    {
        None,
        Unable,
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
        Success,
    }

    public enum SuaTinhMessage
    {
        None,
        EmptyTenTinh,
        DuplicateTenTinh,
        Success,
    }

    public enum ThemTinhMessage
    {
        None,
        EmptyTenTinh,
        DuplicateTenTinh,
        Success,
    }

    public enum XoaTinhMessage
    {
        None,
        Success
    }

    public enum SuaHuyenMessage
    {
        None,
        EmptyTenHuyen,
        DuplicateTenHuyen,
        Success
    }

    public enum ThemHuyenMessage
    {
        None,
        EmptyTenHuyen,
        DuplicateTenHuyen,
        Success
    }

    public enum XoaHuyenMessage
    {
        None,
        Success
    }

    public enum XoaNganhMessage
    {
        None,
        Success
    }

    public enum SuaKhoaMessage
    {
        None,
        EmptyMaKhoa,
        EmptyTenKhoa,
        DuplicateMaKhoa,
        DuplicateTenKhoa,
        Success
    }

    public enum ThemKhoaMessage
    {
        None,
        EmptyMaKhoa,
        EmptyTenKhoa,
        DuplicateMaKhoa,
        DuplicateTenKhoa,
        Success
    }

    public enum SuaNganhMessage
    {
        None,
        EmptyMaNganh,
        EmptyTenNganh,
        DuplicateMaNganh,
        DuplicateTenNganh,
        Success
    }

    public enum ThemNganhMessage
    {
        None,
        EmptyMaNganh,
        EmptyTenNganh,
        DuplicateMaNganh,
        DuplicateTenNganh,
        Success
    }

    public enum XoaKhoaMessage
    {
        None,
        Success
    }

    public enum XoaMonHocMessage
    {
        None,
        Success
    }

    public enum SuaMonHocMessage
    {
        None,
        Unable,
        EmptyMaMH,
        EmptyTenMH,
        EmptySoTiet,
        InvalidSoTiet,
        DuplicateMaMH,
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
        Success
    }

    public enum SuaSinhVienMessage
    {
        None,
        EmptyMaSV,
        EmptyTenSV,
        DuplicateMaSV,
        Success
    }

    public enum ThemSinhVienMessage
    {
        None,
        EmptyMaSV,
        EmptyTenSV,
        DuplicateMaSV,
        Success
    }

    public enum XoaSinhVienMessage
    {
        None,
        Success
    }

    public enum TimKiemPhieuDKHPMessage
    {
        None,
        EmptyNamHoc,
        InvalidNamHoc,
        Sucess
    }

    public enum TimKiemTTHocPhiMessage
    {
        None,
        EmptyNamHoc,
        InvalidNamHoc,
        Sucess
    }

    public enum MessageKhoangTGDongHP
    {
        None,
        Success,
        Failed
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
