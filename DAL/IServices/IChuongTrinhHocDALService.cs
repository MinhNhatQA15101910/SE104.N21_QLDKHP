using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface IChuongTrinhHocDALService
    {
        MessageDeleteListCTHoc DeleteListCTHoc(string maNganh, int hocKy);
        List<ChuongTrinhHoc> GetAllCTHoc();
        MessageAddCTHoc AddCTHoc(ChuongTrinhHoc chuongTrinhHoc);
        MessageDeleteCTHoc DeleteCTHoc(string maMH, string maNganh, int hocKy);
    }
}
