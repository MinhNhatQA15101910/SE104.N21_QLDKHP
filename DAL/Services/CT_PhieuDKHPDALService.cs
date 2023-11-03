using DAL.IServices;
using Dapper;
using DTO;
using System.Data;

namespace DAL.Services
{
    public class CT_PhieuDKHPDALService : ICT_PhieuDKHPDALService
    {
        public readonly IDapperService _dapperService;

        public CT_PhieuDKHPDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public void TaoCT_PhieuDKHP(CT_PhieuDKHP ct_PhieuDKHP)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@maPhieuDKHP", ct_PhieuDKHP.MaPhieuDKHP);
            parameters.Add("@maMH", ct_PhieuDKHP.MaMH);
            _dapperService.Execute("spPHIEUDKHP_TaoCT_PhieuDKHP", parameters, CommandType.StoredProcedure);
        }

        public void XoaDSMHDKHP(int maPhieu)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@maPhieuDKHP", maPhieu);
            _dapperService.Execute("spPHIEUDKHP_XoaCT_PhieuDKHP", parameters, CommandType.StoredProcedure);
        }
    }
}
