using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class NganhDALService : INganhDALService
    {
        private readonly IDapperService _dapperService;

        public NganhDALService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public List<CT_Nganh> LayDSNganh()
        {
            return _dapperService.Query<CT_Nganh>("spNGANH_LayDSNganh").ToList();
        }

        public XoaNganhMessage XoaNganh(string maNganh)
        {
            var p = new DynamicParameters();
            p.Add("@MaNganh", maNganh);
            _dapperService.Execute("spNGANH_XoaNganh", p, CommandType.StoredProcedure);

            return XoaNganhMessage.Success;
        }

        public SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            var p = new DynamicParameters();
            p.Add("@MaNganhBanDau", maNganhBanDau);
            p.Add("@MaNganh", maNganhSua);
            p.Add("@TenNganh", tenNganhSua);
            p.Add("@MaKhoa", maKhoaSua);
            _dapperService.Execute("spNGANH_SuaNganh", p, commandType: CommandType.StoredProcedure);

            return SuaNganhMessage.Success;
        }

        public ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            var p = new DynamicParameters();
            p.Add("@MaNganh", maNganh);
            p.Add("@TenNganh", tenNganh);
            p.Add("@MaKhoa", maKhoa);
            _dapperService.Execute("spNGANH_ThemNganh", p, commandType: CommandType.StoredProcedure);

            return ThemNganhMessage.Success;
        }

        public List<Nganh> GetNganh(string maKhoa)
        {
            if (maKhoa != null)
            {
                var p = new DynamicParameters();
                p.Add("@MaKhoa", maKhoa);
                return _dapperService.Query<Nganh>("spNGANH_LayNganhBangMaKhoa", p, commandType: CommandType.StoredProcedure).ToList();
            }
            else
            {
                return _dapperService.Query<Nganh>("spNGANH_LayDSNganh").ToList();
            }

        }
    }
}
