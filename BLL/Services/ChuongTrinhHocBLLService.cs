using BLL.IServices;
using DAL;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ChuongTrinhHocBLLService: IChuongTrinhHocBLLService
    {
        private readonly IChuongTrinhHocDALService _chuongTrinhHocDALService;

        public ChuongTrinhHocBLLService(IChuongTrinhHocDALService chuongTrinhHocDALService)
        {
            _chuongTrinhHocDALService = chuongTrinhHocDALService;
        }

        public MessageDeleteListCTHoc DeleteListCTHoc(string MaNganh, int HocKy)
        {
            return _chuongTrinhHocDALService.DeleteListCTHoc(MaNganh, HocKy);
        }

        public List<ChuongTrinhHoc> GetAllCTHoc()
        {
            return _chuongTrinhHocDALService.GetAllCTHoc();
        }

        public MessageAddCTHoc AddCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            return _chuongTrinhHocDALService.AddCTHoc(MaMH, MaNganh, HocKy);
        }

        public MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            return _chuongTrinhHocDALService.DeleteCTHoc(MaMH, MaNganh, HocKy);
        }
    }
}
