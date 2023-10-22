using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
