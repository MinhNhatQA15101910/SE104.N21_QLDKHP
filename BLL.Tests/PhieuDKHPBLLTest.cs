namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
	public class PhieuDKHPBLLTest
	{
		#region Services
		private readonly IPhieuDKHPBLLService _phieuDKHPBLLService;
		private readonly Mock<IPhieuDKHPDALService> _phieuDKHPDALServiceMock;
		#endregion

		#region Constructor
		public PhieuDKHPBLLTest()
		{
			_phieuDKHPDALServiceMock = new Mock<IPhieuDKHPDALService>();
			_phieuDKHPBLLService = new PhieuDKHPBLLService(_phieuDKHPDALServiceMock.Object);
		}
		#endregion

		#region GetAllPhieuDKHP
		[Fact]
		public void GetAllPhieuDKHP_VerifyExecuteDAL()
		{
			// Act
			_phieuDKHPBLLService.GetAllPhieuDKHP();

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.GetAllPhieuDKHP(), Times.Once);
		}
		#endregion

		#region LayTTPhieuDKHP
		[Theory, InlineData("SV21520001",1,2023)]
		public void LayTTPhieuDKHP_WithValidInputs_VerifyExecuteDAL(string mssv, int hocky, int namhoc)
		{
			// Act
			_phieuDKHPBLLService.LayTTPhieuDKHP(mssv, hocky,namhoc);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.LayTTPhieuDKHP(mssv, hocky, namhoc), Times.Once);
		}
		#endregion

		#region LayDSMHThuocHP
		[Theory, InlineData(1)]
		public void LayDSMHThuocHP_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_phieuDKHPBLLService.LayDSMHThuocHP(maphieudkhp);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.LayDSMHThuocHP(maphieudkhp), Times.Once);
		}
		#endregion

		#region TinhHocPhi
		[Theory, InlineData(1)]
		public void TinhHocPhi_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_phieuDKHPBLLService.TinhHocPhi(maphieudkhp);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.TinhHocPhi(maphieudkhp), Times.Once);
		}
		#endregion

		#region TinhHocPhiPhaiDong
		[Theory, InlineData(1)]
		public void TinhHocPhiPhaiDong_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_phieuDKHPBLLService.TinhHocPhiPhaiDong(maphieudkhp);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.TinhHocPhiPhaiDong(maphieudkhp), Times.Once);
		}
		#endregion

		#region TinhHocPhiDaDong
		[Theory, InlineData(1)]
		public void TinhHocPhiDaDong_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_phieuDKHPBLLService.TinhHocPhiDaDong(maphieudkhp);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.TinhHocPhiDaDong(maphieudkhp), Times.Once);
		}
		#endregion

		#region TinhHocPhiConThieu
		[Theory, InlineData(1)]
		public void TinhHocPhiConThieu_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_phieuDKHPBLLService.TinhHocPhiConThieu(maphieudkhp);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.TinhHocPhiConThieu(maphieudkhp), Times.Once);
		}
		#endregion

		#region LayDSMHThuocHP2
		[Theory, InlineData(1)]
		public void LayDSMHThuocHP2_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_phieuDKHPBLLService.LayDSMHThuocHP2(maphieudkhp);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.LayDSMHThuocHP2(maphieudkhp), Times.Once);
		}
		#endregion

		#region TaoPhieuDKHP
		[Theory, InlineData("SV21520001", 1, 2023)]
		public void TaoPhieuDKHP_WithValidInputs_VerifyExecuteDAL(string mssv, int hocky, int namhoc)
		{
			// Act
			_phieuDKHPBLLService.TaoPhieuDKHP(mssv, hocky, namhoc);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.TaoPhieuDKHP(mssv, hocky, namhoc), Times.Once);
		}
		#endregion

		#region LayMaPhieuDKHP
		[Theory, InlineData(1, 2023)]
		public void LayMaPhieuDKHP_WithValidInputs_VerifyExecuteDAL(int hocky, int namhoc)
		{
			// Act
			_phieuDKHPBLLService.LayMaPhieuDKHP(hocky, namhoc);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.LayMaPhieuDKHP(hocky, namhoc), Times.Once);
		}
		#endregion

		#region LayDanhSachDKHPDaXacNhan
		[Theory, InlineData("SV21520001")]
		public void LayDanhSachDKHPDaXacNhan_WithValidInputs_VerifyExecuteDAL(string mssv)
		{
			// Act
			_phieuDKHPBLLService.LayDanhSachDKHPDaXacNhan(mssv);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.LayDanhSachDKHPDaXacNhan(mssv), Times.Once);
		}
		#endregion

		#region GetPhieuDKHP
		[Theory, InlineData(1, 2023, 1)]
		public void GetPhieuDKHP_WithValidInputs_VerifyExecuteDAL(int hocky, int namhoc, int matrinhtrang)
		{
			// Act
			_phieuDKHPBLLService.GetPhieuDKHP(hocky, namhoc, matrinhtrang);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.GetPhieuDKHP(hocky, namhoc, matrinhtrang), Times.Once);
		}
		#endregion

		#region PhieuDKHPUpdateTinhTrang
		[Theory, InlineData(1, 1)]
		public void PhieuDKHPUpdateTinhTrang_WithValidInputs_VerifyExecuteDAL(int maphieudkhp, int matinhtrang)
		{
			// Act
			_phieuDKHPBLLService.PhieuDKHPUpdateTinhTrang(maphieudkhp, matinhtrang);

			// Assert
			_phieuDKHPDALServiceMock.Verify(_ => _.PhieuDKHPUpdateTinhTrang(maphieudkhp, matinhtrang), Times.Once);
		}
		#endregion

		#region KtTimKiemPhieuDKHP
		[Theory, InlineData("")]
		public void KtTimKiemPhieuDKHPn_WithEmptyNamHoc_VerifyExecuteDAL(string namhoc)
		{
			// Act
			var result = _phieuDKHPBLLService.KtTimKiemPhieuDKHP(namhoc);

			// Assert
			Assert.Equal(TimKiemPhieuDKHPMessage.EmptyNamHoc, result);
		}

		[Theory, InlineData("a"), InlineData("-1")]
		public void KtTimKiemPhieuDKHPn_WithInvalidNamHoc_VerifyExecuteDAL(string namhoc)
		{
			// Act
			var result = _phieuDKHPBLLService.KtTimKiemPhieuDKHP(namhoc);

			// Assert
			Assert.Equal(TimKiemPhieuDKHPMessage.InvalidNamHoc, result);
		}

		[Theory, InlineData("0")]
		public void KtTimKiemPhieuDKHP_WithValidInputs_VerifyExecuteDAL(string namhoc)
		{
			// Act
			var result =_phieuDKHPBLLService.KtTimKiemPhieuDKHP(namhoc);

			// Assert
			Assert.Equal(TimKiemPhieuDKHPMessage.Sucess, result);
		}
		#endregion
	}
}
