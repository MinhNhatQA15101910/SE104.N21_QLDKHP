namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
	public class MonHocMoBLLTest
	{
		#region Services
		private readonly IMonHocMoBLLService _monHocMoBLLService;
		private readonly Mock<IMonHocMoDALService> _monHocMoDALServiceMock;
		#endregion

		#region Constructor
		public MonHocMoBLLTest()
		{
			_monHocMoDALServiceMock = new Mock<IMonHocMoDALService>();
			_monHocMoBLLService = new MonHocMoBLLService(_monHocMoDALServiceMock.Object);
		}
		#endregion

		#region GetAllHocKyNamHoc
		[Fact]
		public void GetAllHocKyNamHoc_VerifyExecuteDAL()
		{
			// Act
			_monHocMoBLLService.GetAllHocKyNamHoc();

			// Assert
			_monHocMoDALServiceMock.Verify(_ => _.GetAllHocKyNamHoc(), Times.Once);
		}
		#endregion

		#region AddMonHocMo
		[Theory, InlineData("NMLT", 1, 2023)]
		public void AddMonHocMo_WithValidInputs_VerifyExecuteDAL(string mamh, int mahocky, int namhoc)
		{
			// Act
			_monHocMoBLLService.AddMonHocMo(mamh, mahocky, namhoc);

			// Assert
			_monHocMoDALServiceMock.Verify(_ => _.AddMonHocMo(mamh, mahocky, namhoc), Times.Once);
		}
		#endregion

		#region GetAllNamHoc
		[Fact]
		public void GetAllNamHoc_VerifyExecuteDAL()
		{
			// Act
			_monHocMoBLLService.GetAllNamHoc();

			// Assert
			_monHocMoDALServiceMock.Verify(_ => _.GetAllNamHoc(), Times.Once);
		}
		#endregion

		#region DeleteHocKyNamHocMHM
		[Theory, InlineData(1,2023)]
		public void DeleteHocKyNamHocMHM_WithValidInputs_VerifyExecuteDAL(int mahk, int namhoc)
		{
			// Arrange
			var hockynamhoc = new List<HocKyNamHoc>
			{
				new HocKyNamHoc
				{
					MaHocKy=1,
					NamHoc=2023
				}
			};
			_monHocMoDALServiceMock.Setup(_ => _.GetAllHocKyNamHoc()).Returns(hockynamhoc);

			// Act
			_monHocMoBLLService.DeleteHocKyNamHocMHM(mahk,namhoc);

			// Assert
			_monHocMoDALServiceMock.Verify(_ => _.DeleteHocKyNamHocMHM(mahk,namhoc), Times.Once);
		}
		#endregion

	}
}
