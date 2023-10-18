namespace DTO
{
    public class CT_Nganh
    {
        public string MaNganh { get; set; }
        public string TenNganh { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string DisplayNganh
        {
            get
            {
                return MaNganh + " - " + TenNganh;
            }
        }
    }
}
