namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class PhieuThuHPDALTest
    {
        #region Services
        private readonly IPhieuThuHPDALService _phieuThuHPDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public PhieuThuHPDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _phieuThuHPDALService = new PhieuThuHPDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayThoiGianDongHPGanNhat
        [Theory, InlineData(1)]
        public void LayThoiGianDongHPGanNhat_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUTHUHP_LayThoiGianDongHPGanNhat";
            var expectedMaParameterName = "@ma";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = DateTime.Now;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<DateTime>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuThuHPDALService.LayThoiGianDongHPGanNhat(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TaoPhieuThu_ChoXacNhan
        [Theory, InlineData(1000000, 1)]
        public void TaoPhieuThu_ChoXacNhan_ReturnsTrue(int soTienThu, int soPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUTHUHP_TaoPhieuThu_ChoXacNhan";
            var expectedSoTienThuParameterName = "@soTienThu";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedSoTienThuParameterName) == soTienThu &&
                            p.Get<int>(expectedMaPhieuDKHPParameterName) == soPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuThuHPDALService.TaoPhieuThu_ChoXacNhan(soTienThu, soPhieuDKHP);

            // Assert
            Assert.True(result);
        }

        [Theory, InlineData(1000000, 1)]
        public void TaoPhieuThu_ChoXacNhan_ReturnsFalse(int soTienThu, int soPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUTHUHP_TaoPhieuThu_ChoXacNhan";
            var expectedSoTienThuParameterName = "@soTienThu";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedSoTienThuParameterName) == soTienThu &&
                            p.Get<int>(expectedMaPhieuDKHPParameterName) == soPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuThuHPDALService.TaoPhieuThu_ChoXacNhan(soTienThu, soPhieuDKHP);

            // Assert
            Assert.False(result);
        }
        #endregion

        #region GetPhieuThuHP
        [Theory, InlineData(1)]
        public void GetPhieuThuHP_VerifyQueryData(int maTinhTrang)
        {
            // Arrange
            var expectedQuery = "spPHIEUTHUHP_GetPhieuThuHP";
            var expectedMaTinhTrangParameterName = "@MaTinhTrang";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<PhieuThuHP>
            {
                new PhieuThuHP
                {
                    MaPhieuThuHP = 1,
                    MaPhieuDKHP = 1,
                    NgayLap = DateTime.Now,
                    SoTienThu = 1000000
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<PhieuThuHP>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaTinhTrangParameterName) == maTinhTrang),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuThuHPDALService.GetPhieuThuHP(maTinhTrang);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region PhieuThuHPUpdateTinhTrang
        [Theory, InlineData(1000000, 1)]
        public void PhieuThuHPUpdateTinhTrang_ReturnsSuccessfulMessage(int maPhieuThuHP, int maTinhTrang)
        {
            // Arrange
            var expectedQuery = "spPHIEUTHUHP_UpdateTinhTrang";
            var expectedMaPhieuThuHPParameterName = "@MaPhieuThuHP";
            var expectedMaTinhTrangParameterName = "@MaTinhTrang";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuThuHPParameterName) == maPhieuThuHP &&
                            p.Get<int>(expectedMaTinhTrangParameterName) == maTinhTrang),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuThuHPDALService.PhieuThuHPUpdateTinhTrang(maPhieuThuHP, maTinhTrang);

            // Assert
            Assert.Equal(MessagePhieuThuHPUpdateTinhTrang.Success, result);
        }

        [Theory, InlineData(1000000, 1)]
        public void PhieuThuHPUpdateTinhTrang_ReturnsFailedMessage(int maPhieuThuHP, int maTinhTrang)
        {
            // Arrange
            var expectedQuery = "spPHIEUTHUHP_UpdateTinhTrang";
            var expectedMaPhieuThuHPParameterName = "@MaPhieuThuHP";
            var expectedMaTinhTrangParameterName = "@MaTinhTrang";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuThuHPParameterName) == maPhieuThuHP &&
                            p.Get<int>(expectedMaTinhTrangParameterName) == maTinhTrang),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuThuHPDALService.PhieuThuHPUpdateTinhTrang(maPhieuThuHP, maTinhTrang);

            // Assert
            Assert.Equal(MessagePhieuThuHPUpdateTinhTrang.Failed, result);
        }
        #endregion
    }
}
