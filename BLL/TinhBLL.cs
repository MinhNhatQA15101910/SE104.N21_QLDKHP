using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TinhBLL
    {
        public static List<Tinh> LayDSTinh()
        {
            return TinhDAL.LayDSTinh();
        }

        public static SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
        {
            if (tenTinh.Equals(""))
            {
                return SuaTinhMessage.EmptyTenTinh;
            }

            return TinhDAL.SuaTinh(maTinh, tenTinh);
        }

        public static ThemTinhMessage ThemTinh(string tenTinh)
        {
            if (tenTinh.Equals(""))
            {
                return ThemTinhMessage.EmptyTenTinh;
            }

            return TinhDAL.ThemTinh(tenTinh);
        }

        public static XoaTinhMessage XoaTinh(int maTinh)
        {
            return TinhDAL.XoaTinh(maTinh);
        }
    }
}
