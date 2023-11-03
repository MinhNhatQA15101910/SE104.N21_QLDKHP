using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Data;

namespace DAL.Services
{
    public class GlobalConfigDALService : IGlobalConfigDALService
    {
        private readonly IDapperService _dapperService;

        public GlobalConfigDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public int GetCurrNamHoc()
        {
            return _dapperService.QueryFirst<int>("spGLOBALCONFIG_LayNamHocHienTai");
        }

        public int LaySoTinChiToiDa()
        {
            return _dapperService.QueryFirst<int>("spGLOBALCONFIG_LaySoTinChiToiDa");
        }

        public int LaySoTinChiToiThieu()
        {
            return _dapperService.QueryFirst<int>("spGLOBALCONFIG_LaySoTinChiToiThieu");
        }

        public int GetCurrMaHocKy()
        {
            var p = new DynamicParameters();
            p.Add("@NamHocHienTai", GlobalConfig.CurrNamHoc);
            return _dapperService.QueryFirst<int>("spGLOBALCONFIG_LayMaHocKyHienTai", p, commandType: CommandType.StoredProcedure);
        }

        public SuaGioiHanTinChiMessage SuaGioiHanTinChi(int tinChiToiDa, int tinChiToiThieu)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@SoTinChiToiDa", tinChiToiDa);
                p.Add("@SoTinChiToiThieu", tinChiToiThieu);
                _dapperService.Execute("spGLOBALCONFIG_SuaGioiHanTinChi", p, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return SuaGioiHanTinChiMessage.Error;
            }

            return SuaGioiHanTinChiMessage.Success;
        }

        public int LayKhoangTGDongHP(int hocKy, int namHoc)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@hocKy", hocKy);
            parameters.Add("@namHoc", namHoc);
            return _dapperService.QueryFirstOrDefault<int>("spGLOBALCONFIG_LayKhoangTGDongHP", parameters, commandType: CommandType.StoredProcedure);
        }

        public MessageKhoangTGDongHP KhoangTGDongHP(int MaHocKy, int NamHoc, int KhoangTG)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", MaHocKy);
                p.Add("@NamHoc", NamHoc);
                p.Add("@KhoangTG", KhoangTG);
                _dapperService.Execute("spKHOANGTGDONGHP_Add", p, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return MessageKhoangTGDongHP.Failed;
            }
            return MessageKhoangTGDongHP.Success;

        }
    }
}
