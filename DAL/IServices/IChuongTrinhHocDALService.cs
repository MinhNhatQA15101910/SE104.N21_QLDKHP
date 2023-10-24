using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IChuongTrinhHocDALService
    {
        MessageDeleteListCTHoc DeleteListCTHoc(string MaNganh, int HocKy);
        List<ChuongTrinhHoc> GetAllCTHoc();
        MessageAddCTHoc AddCTHoc(string MaMH, string MaNganh, int HocKy);
        MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy);
    }
}
