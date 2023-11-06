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
        private readonly IDbConnection _connection;

        public TinhDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<Tinh> LayDSTinh()
		{
            return _connection.Query<Tinh>("spTINH_LayDSTinh").ToList();
        }

		public SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
		{
            var p = new DynamicParameters();
            p.Add("@MaTinh", maTinh);
            p.Add("@TenTinh", tenTinh);
            _connection.Execute("spTINH_SuaTinh", p, commandType: CommandType.StoredProcedure);

            return SuaTinhMessage.Success;
		}

		public XoaTinhMessage XoaTinh(int maTinh)
		{
            var p = new DynamicParameters();
            p.Add("@MaTinh", maTinh);
            _connection.Execute("spTINH_XoaTinh", p, commandType: CommandType.StoredProcedure);

            return XoaTinhMessage.Success;
		}

		public ThemTinhMessage ThemTinh(string tenTinh)
		{
            var p = new DynamicParameters();
            p.Add("@TenTinh", tenTinh);
            _connection.Execute("spTINH_ThemTinh", p, commandType: CommandType.StoredProcedure);

            return ThemTinhMessage.Success;
		}
	}
}
