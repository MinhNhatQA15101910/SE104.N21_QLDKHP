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
}
