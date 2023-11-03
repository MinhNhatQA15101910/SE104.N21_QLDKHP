using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class HocKyDALService: IHocKyDALService
    {
        private readonly IDapperService _dapperService;

        public HocKyDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<HocKy> LayDanhSachHK()
        {
            return _dapperService.Query<HocKy>("spHOCKY_LayDanhSachHK").ToList();
        }

        public string LayHKByMaHK(int currMaHocKy)
        {
            var p = new DynamicParameters();
            p.Add("@MaHocKy", currMaHocKy);
            return _dapperService.Query<string>("spHOCKY_LayHKByMaHK", p, commandType: CommandType.StoredProcedure).ToString();
        }
    }
}
