using BLL.IServices;
using DAL.IServices;
using DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public class HuyenBLLService : IHuyenBLLService
    {
        private readonly IHuyenDALService _huyenDALService;

        public HuyenBLLService(IHuyenDALService huyenDALService)
        {
            _huyenDALService = huyenDALService;
        }

        public List<CT_Huyen> LayDSHuyen()
        {
            return _huyenDALService.LayDSHuyen();
        }

        public SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            if (tenHuyen.Equals(""))
            {
                return SuaHuyenMessage.EmptyTenHuyen;
            }

            return _huyenDALService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);
        }

        public ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh)
        {
            if (tenHuyen.Equals(""))
            {
                return ThemHuyenMessage.EmptyTenHuyen;
            }

            return _huyenDALService.ThemHuyen(tenHuyen, vungUT, maTinh);
        }

        public XoaHuyenMessage XoaHuyen(int maHuyen)
        {
            return _huyenDALService.XoaHuyen(maHuyen);
        }
    }
}
