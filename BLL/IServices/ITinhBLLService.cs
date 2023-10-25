using DTO;
using System.Collections.Generic;

namespace BLL.IServices
{
    public interface ITinhBLLService
	{
		List<Tinh> LayDSTinh();
		SuaTinhMessage SuaTinh(int maTinh, string tenTinh);
		XoaTinhMessage XoaTinh(int maTinh);
		ThemTinhMessage ThemTinh(string tenTinh);
	}
}
