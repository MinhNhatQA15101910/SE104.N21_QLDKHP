using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
	[ExcludeFromCodeCoverage]
	public class NhomNguoiDungBLLTest
	{
		#region Services
		private readonly INhomNguoiDungBLLService _nhomNguoiDungBLLService;
		private readonly Mock<INhomNguoiDungDALService> _nhomNguoiDungDALServiceMock;
		#endregion

		#region Constructor
		public NhomNguoiDungBLLTest()
		{
			_nhomNguoiDungDALServiceMock = new Mock<INhomNguoiDungDALService>();
			_nhomNguoiDungBLLService = new NhomNguoiDungBLLService(_nhomNguoiDungDALServiceMock.Object);
		}
		#endregion

		#region LayDSNhomNguoiDung
		[Fact]
		public void LayDSNhomNguoiDung_VerifyExecuteDAL()
		{
			// Act
			_nhomNguoiDungBLLService.LayDSNhomNguoiDung();

			// Assert
			_nhomNguoiDungDALServiceMock.Verify(_ => _.LayDSNhomNguoiDung(), Times.Once);
		}
		#endregion
	}
}
