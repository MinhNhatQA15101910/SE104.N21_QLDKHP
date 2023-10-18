namespace DTO
{
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string DisplayKhoa
        {
            get
            {
                return MaKhoa + " - " + TenKhoa;
            }
        }
    }
}
