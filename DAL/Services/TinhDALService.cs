using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class TinhDALService : ITinhDALService
	{
		private readonly IDapperService _dapperService;

		public TinhDALService(IDapperService dapperService)
		{
			_dapperService = dapperService;
		}
		public List<Tinh> LayDSTinh()
		{
            return _dapperService.Query<Tinh>("spTINH_LayDSTinh").ToList();
        }

		public SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
		{
            var p = new DynamicParameters();
            p.Add("@MaTinh", maTinh);
            p.Add("@TenTinh", tenTinh);
            _dapperService.Execute("spTINH_SuaTinh", p, commandType: CommandType.StoredProcedure);

            return SuaTinhMessage.Success;
		}

		public XoaTinhMessage XoaTinh(int maTinh)
		{
            var p = new DynamicParameters();
            p.Add("@MaTinh", maTinh);
            _dapperService.Execute("spTINH_XoaTinh", p, commandType: CommandType.StoredProcedure);

            return XoaTinhMessage.Success;
		}

		public ThemTinhMessage ThemTinh(string tenTinh)
		{
            var p = new DynamicParameters();
            p.Add("@TenTinh", tenTinh);
            _dapperService.Execute("spTINH_ThemTinh", p, commandType: CommandType.StoredProcedure);

            return ThemTinhMessage.Success;
		}
	}
}
