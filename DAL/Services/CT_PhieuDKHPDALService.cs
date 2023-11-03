using DAL.IServices;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DAL.Services
{
    public class CT_PhieuDKHPDALService: ICT_PhieuDKHPDALService
    {
        public readonly IDapperService _dapperService;

        public CT_PhieuDKHPDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public void TaoCT_PhieuDKHP(int maPhieu, List<string> list)
        {
            foreach (var i in list)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@maPhieuDKHP", maPhieu);
                parameters.Add("@maMH", i);
                _dapperService.Execute("spPHIEUDKHP_TaoCT_PhieuDKHP", parameters, CommandType.StoredProcedure);
            }
        }

        public void XoaDSMHDKHP(int maPhieu)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@maPhieuDKHP", maPhieu);
            _dapperService.Execute("spPHIEUDKHP_XoaCT_PhieuDKHP", parameters, CommandType.StoredProcedure);
        }
    }
}
