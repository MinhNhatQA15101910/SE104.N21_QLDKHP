namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class GlobalConfigDALTest
    {
        #region Services
        private readonly IGlobalConfigDALService _globalConfigDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public GlobalConfigDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _globalConfigDALService = new GlobalConfigDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region GetCurrNamHoc
        [Fact]
        public void GetCurrNamHoc_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spGLOBALCONFIG_LayNamHocHienTai";
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirst<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.GetCurrNamHoc();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LaySoTinChiToiDa
        [Fact]
        public void LaySoTinChiToiDa_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spGLOBALCONFIG_LaySoTinChiToiDa";
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirst<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.LaySoTinChiToiDa();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LaySoTinChiToiThieu
        [Fact]
        public void LaySoTinChiToiThieu_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spGLOBALCONFIG_LaySoTinChiToiThieu";
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirst<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.LaySoTinChiToiThieu();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region GetCurrMaHocKy
        [Theory, InlineData(2023)]
        public void GetCurrMaHocKy_VerifyQueryData(int namHoc)
        {
            // Arrange
            var expectedQuery = "spGLOBALCONFIG_LayMaHocKyHienTai";
            var expectedNamHocHienTaiParameterKey = "@NamHocHienTai";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirst<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<int>(expectedNamHocHienTaiParameterKey) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.GetCurrMaHocKy(namHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region SuaGioiHanTinChi
        [Theory, InlineData(8, 25)]
        public void SuaGioiHanTinChi_ReturnsSuccessfulMessage(int tinChiToiDa, int tinChiToiThieu)
        {
            // Arrange
            var expectedQuery = "spGLOBALCONFIG_SuaGioiHanTinChi";
            var expectedSoTinChiToiDaParameterName = "@SoTinChiToiDa";
            var expectedSoTinChiToiThieuParameterName = "@SoTinChiToiThieu";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedSoTinChiToiDaParameterName) == tinChiToiDa &&
                            p.Get<int>(expectedSoTinChiToiThieuParameterName) == tinChiToiThieu),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            Assert.Equal(SuaGioiHanTinChiMessage.Success, result);
        }

        [Theory, InlineData(8, 25)]
        public void SuaGioiHanTinChi_ReturnsFailedMessage(int tinChiToiDa, int tinChiToiThieu)
        {
            // Arrange
            var expectedQuery = "spGLOBALCONFIG_SuaGioiHanTinChi";
            var expectedSoTinChiToiDaParameterName = "@SoTinChiToiDa";
            var expectedSoTinChiToiThieuParameterName = "@SoTinChiToiThieu";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedSoTinChiToiDaParameterName) == tinChiToiDa &&
                            p.Get<int>(expectedSoTinChiToiThieuParameterName) == tinChiToiThieu),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            Assert.Equal(SuaGioiHanTinChiMessage.Failed, result);
        }
        #endregion

        #region LayKhoangTGDongHP
        [Theory, InlineData(8, 25)]
        public void LayKhoangTGDongHP_VerifyQueryData(int hocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spGLOBALCONFIG_LayKhoangTGDongHP";
            var expectedHocKyParameterName = "@hocKy";
            var expectedNamHocParameterName = "@namHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 5;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedHocKyParameterName) == hocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.LayKhoangTGDongHP(hocKy, namHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region KhoangTGDongHP
        [Theory, InlineData(1, 2023, 5)]
        public void KhoangTGDongHP_ReturnsSuccessfulMessage(int maHocKy, int namHoc, int khoangTG)
        {
            // Arrange
            var expectedQuery = "spKHOANGTGDONGHP_Add";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedKhoangTGParameterName = "@KhoangTG";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc &&
                            p.Get<int>(expectedKhoangTGParameterName) == khoangTG),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.KhoangTGDongHP(maHocKy, namHoc, khoangTG);

            // Assert
            Assert.Equal(MessageKhoangTGDongHP.Success, result);
        }

        [Theory, InlineData(1, 2023, 5)]
        public void KhoangTGDongHP_ReturnsFailedMessage(int maHocKy, int namHoc, int khoangTG)
        {
            // Arrange
            var expectedQuery = "spKHOANGTGDONGHP_Add";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedKhoangTGParameterName = "@KhoangTG";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc &&
                            p.Get<int>(expectedKhoangTGParameterName) == khoangTG),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _globalConfigDALService.KhoangTGDongHP(maHocKy, namHoc, khoangTG);

            // Assert
            Assert.Equal(MessageKhoangTGDongHP.Failed, result);
        }
        #endregion
    }
}
