using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
	public class TinhBLLTest
	{
		#region Services
		private readonly ITinhBLLService _tinhBLLService;
		private readonly Mock<ITinhDALService> _tinhDALServiceMock;
		private readonly Mock<IHuyenDALService> _huyenDALServiceMock;
		#endregion

		#region Constructor
		public TinhBLLTest()
		{
			_tinhDALServiceMock = new Mock<ITinhDALService>();
			_huyenDALServiceMock = new Mock<IHuyenDALService>();
			_tinhBLLService = new TinhBLLService(_tinhDALServiceMock.Object, _huyenDALServiceMock.Object);
		}
		#endregion

		#region LayDSTinh
		[Fact]		
		public void LayDSTinh_VerifyExecuteDAL()
		{
			// Act
			_tinhBLLService.LayDSTinh();

			// Assert
			_tinhDALServiceMock.Verify(_ => _.LayDSTinh(), Times.Once);
		}
		#endregion

		#region SuaTinh
		[Theory, InlineData(1, "")]
		public void SuaTinh_WithEmptyTenTinh_ReturnsEmptyTenTinhMessage(int matinh, string tentinh)
		{
			// Act
			var result = _tinhBLLService.SuaTinh(matinh, tentinh );

			// Assert
			Assert.Equal(SuaTinhMessage.EmptyTenTinh, result);
		}

		[Theory, InlineData(1, "TP HCM")]
		public void SuaTinh_WithDuplicateTenTinh_ReturnsDuplicateTenTinhMessage(int matinh, string tentinh)
		{
			//Arrange
			var tinhs = new List<Tinh>
			{
				new Tinh
				{
					MaTinh=2,
					TenTTP="TP HCM"
				}
			};
			_tinhDALServiceMock.Setup(_ => _.LayDSTinh()).Returns(tinhs);
			// Act
			var result = _tinhBLLService.SuaTinh(matinh, tentinh);

			// Assert
			Assert.Equal(SuaTinhMessage.DuplicateTenTinh, result);
		}

		[Theory, InlineData(1, "Thành Phố Hồ Chí Minh")]
		public void SuaTinh_WithValidInputs_VerifyExecuteDAL(int matinh, string tentinh)
		{
			//Arrange
			var tinhs = new List<Tinh>
			{
				new Tinh
				{
					MaTinh=1,
					TenTTP="TP HCM"
				}
			};
			_tinhDALServiceMock.Setup(_ => _.LayDSTinh()).Returns(tinhs);
			// Act
			var result = _tinhBLLService.SuaTinh(matinh, tentinh);

			// Assert
			_tinhDALServiceMock.Verify(_ => _.SuaTinh(matinh, tentinh), Times.Once);
		}

		[Theory, InlineData(1, "Thành Phố Hồ Chí Minh")]
		public void SuaTinh_WithValidInputs_VerifyExecuteDAL2(int matinh, string tentinh)
		{
			//Arrange
			var tinhs = new List<Tinh>
			{
				new Tinh
				{
					MaTinh=2,
					TenTTP="TP HCM"
				}
			};
			_tinhDALServiceMock.Setup(_ => _.LayDSTinh()).Returns(tinhs);
			// Act
			var result = _tinhBLLService.SuaTinh(matinh, tentinh);

			// Assert
			_tinhDALServiceMock.Verify(_ => _.SuaTinh(matinh, tentinh), Times.Once);
		}
		#endregion

		#region ThemTinh
		[Theory, InlineData("")]
		public void ThemTinh_WithEmptyTenTinh_ReturnsEmptyTenTinhMessage(string tentinh)
		{
			// Act
			var result = _tinhBLLService.ThemTinh(tentinh);

			// Assert
			Assert.Equal(ThemTinhMessage.EmptyTenTinh, result);
		}

		[Theory, InlineData("TP HCM")]
		public void ThemTinh_WithDuplicateTenTinh_ReturnsDuplicateTenTinhMessage(string tentinh)
		{
			//Arrange
			var tinhs = new List<Tinh>
			{
				new Tinh
				{
					MaTinh=2,
					TenTTP="TP HCM"
				}
			};
			_tinhDALServiceMock.Setup(_ => _.LayDSTinh()).Returns(tinhs);
			// Act
			var result = _tinhBLLService.ThemTinh(tentinh);

			// Assert
			Assert.Equal(ThemTinhMessage.DuplicateTenTinh, result);
		}

		[Theory, InlineData("Thành Phố Hồ Chí Minh")]
		public void ThemTinh_WithValidInputs_VerifyExecuteDAL(string tentinh)
		{
			//Arrange
			var tinhs = new List<Tinh>
			{
				new Tinh
				{
					MaTinh=1,
					TenTTP="TP HCM"
				}
			};
			_tinhDALServiceMock.Setup(_ => _.LayDSTinh()).Returns(tinhs);
			// Act
			var result = _tinhBLLService.ThemTinh(tentinh);

			// Assert
			_tinhDALServiceMock.Verify(_ => _.ThemTinh(tentinh), Times.Once);
		}
		#endregion

		#region XoaTinh
		[Theory, InlineData(1)]
		public void XoaTinh_WithMaTingRelativeToHuyen_ReturnsUnableMessage(int matinh)
		{
			//Arrange
			var ct_huyens = new List<CT_Huyen>
			{
				new CT_Huyen
				{
					MaTinh=1,
					TenTTP="TP HCM",
					MaHuyen=1,
					TenHuyen="Thủ Đức"
				}
			};
			_huyenDALServiceMock.Setup(_ => _.LayDSHuyen()).Returns(ct_huyens);
			// Act
			var result = _tinhBLLService.XoaTinh(matinh);

			// Assert
			Assert.Equal(XoaTinhMessage.Unable, result);
		}

		[Theory, InlineData(1)]
		public void XoaTinh_WithValidInputs_VerifyExecuteDAL(int matinh)
		{
			//Arrange
			var ct_huyens = new List<CT_Huyen>
			{
				new CT_Huyen
				{
					MaTinh=2,
					TenTTP="TP HCM",
					MaHuyen=1,
					TenHuyen="Thủ Đức"
				}
			};
			var tinhs = new List<Tinh>
			{
				new Tinh
				{
					MaTinh=1,
					TenTTP="TP HCM"
				}
			};
			_tinhDALServiceMock.Setup(_ => _.LayDSTinh()).Returns(tinhs);
			_huyenDALServiceMock.Setup(_ => _.LayDSHuyen()).Returns(ct_huyens);
			// Act
			var result = _tinhBLLService.XoaTinh(matinh);

			// Assert
			_tinhDALServiceMock.Verify(_ => _.XoaTinh(matinh), Times.Once);
		}
		#endregion
	}
}
