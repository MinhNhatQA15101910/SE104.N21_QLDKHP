using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ChuongTrinhHocBLLService : IChuongTrinhHocBLLService
    {
        private readonly IChuongTrinhHocDALService _chuongTrinhHocDALService;

        public ChuongTrinhHocBLLService(IChuongTrinhHocDALService chuongTrinhHocDALService)
        {
            _chuongTrinhHocDALService = chuongTrinhHocDALService;
        }

        public MessageDeleteListCTHoc DeleteListCTHoc(string maNganh, int hocKy)
        {
            return _chuongTrinhHocDALService.DeleteListCTHoc(maNganh, hocKy);
        }

        public List<ChuongTrinhHoc> GetAllCTHoc()
        {
            return _chuongTrinhHocDALService.GetAllCTHoc();
        }

        public MessageAddCTHoc AddCTHoc(ChuongTrinhHoc chuongTrinhHoc)
        {
            return _chuongTrinhHocDALService.AddCTHoc(chuongTrinhHoc);
        }

        public MessageDeleteCTHoc DeleteCTHoc(string maMH, string maNganh, int hocKy)
        {
            return _chuongTrinhHocDALService.DeleteCTHoc(maMH, maNganh, hocKy);
        }
    }
}
