using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class MonHocMoDALService : IMonHocMoDALService
    {
        private readonly IDapperService _dapperService;

        public MonHocMoDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<HocKyNamHoc> GetAllHocKyNamHoc()
        {
            return _dapperService.Query<HocKyNamHoc>("spDANHSACHMONHOCMO_GetHocKyNamHoc").ToList();
        }

        public MessageAddMonHocMo AddMonHocMo(string MaMH, int MaHocKy, int NamHoc)
        {
            var p = new DynamicParameters();
            p.Add("@MaHocKy", MaHocKy);
            p.Add("@MaMH", MaMH);
            p.Add("@NamHoc", NamHoc);
            _dapperService.Execute("spDANHSACHMONHOCMO_AddMonHocMo", p, commandType: CommandType.StoredProcedure);

            return MessageAddMonHocMo.Success;
        }

        public List<int> GetAllNamHoc()
        {
            return _dapperService.Query<int>("spDANHSACHMONHOCMO_GetNam").ToList();
        }

        public MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int MaHocKy, int NamHoc)
        {
            var mhm = new DynamicParameters();
            mhm.Add("@MaHocKy", MaHocKy);
            mhm.Add("@NamHoc", NamHoc);
            _dapperService.Execute("spDANHSACHMONHOCMO_XoaDanhSach", mhm, commandType: CommandType.StoredProcedure);

            return MessageDeleteHocKyNamHocMHM.Success;
        }
    }
}
