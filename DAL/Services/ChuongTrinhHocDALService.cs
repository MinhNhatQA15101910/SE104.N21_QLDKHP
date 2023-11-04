using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class ChuongTrinhHocDALService : IChuongTrinhHocDALService
    {
        private readonly IDapperService _dapperService;

        public ChuongTrinhHocDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public MessageDeleteListCTHoc DeleteListCTHoc(string maNganh, int hocKy)
        {
            var mhm = new DynamicParameters();
            mhm.Add("@MaNganh", maNganh);
            mhm.Add("@HocKy", hocKy);
            _dapperService.Execute("spCHUONGTRINHHOC_DeleteListCTHoc", mhm, CommandType.StoredProcedure);

            return MessageDeleteListCTHoc.Success;
        }

        public List<ChuongTrinhHoc> GetAllCTHoc()
        {
            return _dapperService.Query<ChuongTrinhHoc>("spCHUONGTRINHHOC_GetAll").ToList();
        }

        public MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            var mhm = new DynamicParameters();
            mhm.Add("@MaMH", MaMH);
            mhm.Add("@MaNganh", MaNganh);
            mhm.Add("@HocKy", HocKy);
            _dapperService.Execute("spCHUONGTRINHHOC_DeleteCTHoc", mhm, CommandType.StoredProcedure);

            return MessageDeleteCTHoc.Success;
        }

        public MessageAddCTHoc AddCTHoc(ChuongTrinhHoc chuongTrinhHoc)
        {
            var mhm = new DynamicParameters();
            mhm.Add("@MaMH", chuongTrinhHoc.MaMH);
            mhm.Add("@MaNganh", chuongTrinhHoc.MaNganh);
            mhm.Add("@HocKy", chuongTrinhHoc.HocKy);

            _dapperService.Execute("spCHUONGTRINHHOC_AddCTHoc", mhm, CommandType.StoredProcedure);

            return MessageAddCTHoc.Success;
        }
    }
}
