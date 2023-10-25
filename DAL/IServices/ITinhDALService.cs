using DTO;
using System.Collections.Generic;

namespace DAL.IServices
{
    public interface ITinhDALService
	{
		List<Tinh> LayDSTinh();
		SuaTinhMessage SuaTinh(int maTinh, string tenTinh);
		XoaTinhMessage XoaTinh(int maTinh);
		ThemTinhMessage ThemTinh(string tenTinh);

	}
}
