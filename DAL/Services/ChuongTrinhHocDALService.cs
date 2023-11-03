using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class ChuongTrinhHocDALService: IChuongTrinhHocDALService
    {
        private readonly IDapperService _dapperService;

        public ChuongTrinhHocDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public MessageDeleteListCTHoc DeleteListCTHoc(string MaNganh, int HocKy)
        {
            try
            {
                var mhm = new DynamicParameters();
                mhm.Add("@MaNganh", MaNganh);
                mhm.Add("@HocKy", HocKy);
                _dapperService.Execute("spCHUONGTRINHHOC_DeleteListCTHoc", mhm, CommandType.StoredProcedure);

                return MessageDeleteListCTHoc.Success;
            }
            catch (Exception)
            {
                return MessageDeleteListCTHoc.Failed;
            }
            
        }

        public List<ChuongTrinhHoc> GetAllCTHoc()
        {
            return _dapperService.Query<ChuongTrinhHoc>("spCHUONGTRINHHOC_GetAll").ToList();
        }

        public MessageAddCTHoc AddCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            try
            {
                var mhm = new DynamicParameters();
                mhm.Add("@MaMH", MaMH);
                mhm.Add("@MaNganh", MaNganh);
                mhm.Add("@HocKy", HocKy);

                _dapperService.Execute("spCHUONGTRINHHOC_AddCTHoc", mhm, CommandType.StoredProcedure);

                return MessageAddCTHoc.Success;
            }
            catch (Exception)
            {
                return MessageAddCTHoc.Failed;
            }
        }

        public MessageDeleteCTHoc DeleteCTHoc(string MaMH, string MaNganh, int HocKy)
        {
            try
            {
                var mhm = new DynamicParameters();
                mhm.Add("@MaMH", MaMH);
                mhm.Add("@MaNganh", MaNganh);
                mhm.Add("@HocKy", HocKy);
                _dapperService.Execute("spCHUONGTRINHHOC_DeleteCTHoc", mhm, CommandType.StoredProcedure);

                return MessageDeleteCTHoc.Success;
            }
            catch (Exception)
            {
                return MessageDeleteCTHoc.Failed;
            }
        }
    }
}
