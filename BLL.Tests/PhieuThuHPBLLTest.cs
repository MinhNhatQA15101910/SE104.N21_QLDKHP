namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
	public class PhieuThuHPBLLTest
	{
		#region Services
		private readonly IPhieuThuHPBLLService _phieuThuHPBLLService;
		private readonly Mock<IPhieuThuHPDALService> _phieuThuHPDALServiceMock;
		#endregion

		#region Constructor
		public PhieuThuHPBLLTest()
		{
			_phieuThuHPDALServiceMock = new Mock<IPhieuThuHPDALService>();
			_phieuThuHPBLLService = new PhieuThuHPBLLService(_phieuThuHPDALServiceMock.Object);
		}
		#endregion

		#region KtTimKiemTTHocPhi
		[Theory, InlineData("")]
		public void KtTimKiemTTHocPhi_WithEmptyNamHoc_ReturnsEmptyNamHocMessage(string namhoc)
		{
			// Act
			var result = _phieuThuHPBLLService.KtTimKiemTTHocPhi(namhoc);

			// Assert
			Assert.Equal(TimKiemTTHocPhiMessage.EmptyNamHoc, result);
		}

		[Theory, InlineData("a"), InlineData("-1")]
		public void KtTimKiemTTHocPhi_WithInvalidNamHoc_ReturnsInvalidNamHocMessage(string namhoc)
		{
			// Act
			var result = _phieuThuHPBLLService.KtTimKiemTTHocPhi(namhoc);

			// Assert
			Assert.Equal(TimKiemTTHocPhiMessage.InvalidNamHoc, result);
		}

		[Theory, InlineData("0")]
		public void KtTimKiemTTHocPhi_WithValidInputs_VerifyExecuteDAL(string namhoc)
		{
			// Act
			var result = _phieuThuHPBLLService.KtTimKiemTTHocPhi(namhoc);

			// Assert
			Assert.Equal(TimKiemTTHocPhiMessage.Sucess, result);
		}
		#endregion

		#region LayThoiGianDongHPGanNhat
		[Theory, InlineData(1)]
		public void LayThoiGianDongHPGanNhat_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_phieuThuHPBLLService.LayThoiGianDongHPGanNhat(maphieudkhp);

			// Assert
			_phieuThuHPDALServiceMock.Verify(_ => _.LayThoiGianDongHPGanNhat(maphieudkhp), Times.Once);
		}
		#endregion

		#region KtTimKiemSoTienThu
		[Theory, InlineData("")]
		public void KtTimKiemSoTienThu_WithEmptyNamHoc_ReturnsEmptyNamHocMessage(string namhoc)
		{
			// Act
			var result = _phieuThuHPBLLService.KtTimKiemSoTienThu(namhoc);

			// Assert
			Assert.Equal(TimKiemPhieuDKHPMessage.EmptyNamHoc, result);
		}

		[Theory, InlineData("a")]
		public void KtTimKiemSoTienThu_WithInvalidNamHoc_ReturnsInvalidNamHocMessage(string namhoc)
		{
			// Act
			var result = _phieuThuHPBLLService.KtTimKiemSoTienThu(namhoc);

			// Assert
			Assert.Equal(TimKiemPhieuDKHPMessage.InvalidNamHoc, result);
		}

		[Theory, InlineData("2023")]
		public void KtTimKiemSoTienThu_WithValidInputs_VerifyExecuteDAL(string namhoc)
		{
			// Act
			var result = _phieuThuHPBLLService.KtTimKiemSoTienThu(namhoc);

			// Assert
			Assert.Equal(TimKiemPhieuDKHPMessage.Sucess, result);
		}
		#endregion

		#region TaoPhieuThu_ChoXacNhan
		[Theory, InlineData(100000,1)]
		public void TaoPhieuThu_ChoXacNhan_WithValidInputs_VerifyExecuteDAL(int sotienthu, int maphieudkhp)
		{
			// Act
			_phieuThuHPBLLService.TaoPhieuThu_ChoXacNhan(sotienthu, maphieudkhp);

			// Assert
			_phieuThuHPDALServiceMock.Verify(_ => _.TaoPhieuThu_ChoXacNhan(sotienthu, maphieudkhp), Times.Once);
		}
		#endregion

		#region GetPhieuThuHP
		[Theory, InlineData(1)]
		public void GetPhieuThuHP_WithValidInputs_VerifyExecuteDAL(int matinhtrang)
		{
			// Act
			_phieuThuHPBLLService.GetPhieuThuHP(matinhtrang);

			// Assert
			_phieuThuHPDALServiceMock.Verify(_ => _.GetPhieuThuHP(matinhtrang), Times.Once);
		}
		#endregion

		#region PhieuThuHPUpdateTinhTrang
		[Theory, InlineData(1, 1)]
		public void PhieuThuHPUpdateTinhTrang_WithValidInputs_VerifyExecuteDAL(int maphieuthu, int maphieudkhp)
		{
			// Act
			_phieuThuHPBLLService.PhieuThuHPUpdateTinhTrang(maphieuthu, maphieudkhp);

			// Assert
			_phieuThuHPDALServiceMock.Verify(_ => _.PhieuThuHPUpdateTinhTrang(maphieuthu, maphieudkhp), Times.Once);
		}
		#endregion
	}
}
