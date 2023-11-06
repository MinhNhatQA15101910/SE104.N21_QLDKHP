using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class TinhDALService : ITinhDALService
	{
        private readonly string _connectionString;
        private readonly IDapperWrapper _dapperWrapper;

        public TinhDALService(string connectionString, IDapperWrapper dapperWrapper)
        {
            _connectionString = connectionString;
            _dapperWrapper = dapperWrapper;
        }

        public List<Tinh> LayDSTinh()
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                return _dapperWrapper.Query<Tinh>(connection, "spTINH_LayDSTinh").ToList();
            }
        }

		public SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaTinh", maTinh);
                p.Add("@TenTinh", tenTinh);
                _dapperWrapper.Execute(connection, "spTINH_SuaTinh", p, commandType: CommandType.StoredProcedure);

                return SuaTinhMessage.Success;
            }
		}

		public XoaTinhMessage XoaTinh(int maTinh)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@MaTinh", maTinh);
                _dapperWrapper.Execute(connection, "spTINH_XoaTinh", p, commandType: CommandType.StoredProcedure);

                return XoaTinhMessage.Success;
            }
		}

		public ThemTinhMessage ThemTinh(string tenTinh)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TenTinh", tenTinh);
                _dapperWrapper.Execute(connection, "spTINH_ThemTinh", p, commandType: CommandType.StoredProcedure);

                return ThemTinhMessage.Success;
            }
		}
	}
}
