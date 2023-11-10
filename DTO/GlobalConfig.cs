using System.Diagnostics.CodeAnalysis;

namespace DTO
{
    [ExcludeFromCodeCoverage]
    public class GlobalConfig
    {
        public static NguoiDung CurrNguoiDung { get; set; } = new NguoiDung();
        public static int CurrMaHocKy { get; set; }
        public static int CurrNamHoc { get; set; }
    }
}
