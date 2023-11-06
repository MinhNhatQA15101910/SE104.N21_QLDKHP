using DAL.IServices;
using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Services
{
    public class NhomNguoiDungDALService : INhomNguoiDungDALService
	{
        private readonly IDbConnection _connection;

        public NhomNguoiDungDALService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<NhomNguoiDung> LayDSNhomNguoiDung()
		{
            return _connection.Query<NhomNguoiDung>("spNHOMNGUOIDUNG_LayDSNhomNguoiDung").ToList();
        }
	}
}
