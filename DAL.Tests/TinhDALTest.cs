namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class TinhDALTest
    {
        #region Services
        private readonly ITinhDALService _tinhDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public TinhDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _tinhDALService = new TinhDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSTinh
        [Fact]
        public void LayDSTinh_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spTINH_LayDSTinh";
            var expectedResult = new List<Tinh>
            {
                new Tinh
                {
                    MaTinh = 1,
                    TenTTP = "Tinh Tien Giang"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<Tinh>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _tinhDALService.LayDSTinh();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region SuaTinh
        [Theory, InlineData(1, "Tinh Tien Giang")]
        public void SuaTinh_ReturnsSuccessfulMessage(int maTinh, string tenTinh)
        {
            // Arrange
            var expectedQuery = "spTINH_SuaTinh";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedTenTinhParameterName = "@TenTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaTinhParameterName) == maTinh &&
                            p.Get<string>(expectedTenTinhParameterName) == tenTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _tinhDALService.SuaTinh(maTinh, tenTinh);

            // Assert
            Assert.Equal(SuaTinhMessage.Success, result);
        }

        [Theory, InlineData(1, "Tinh Tien Giang")]
        public void SuaTinh_ReturnsFailedMessage(int maTinh, string tenTinh)
        {
            // Arrange
            var expectedQuery = "spTINH_SuaTinh";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedTenTinhParameterName = "@TenTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaTinhParameterName) == maTinh &&
                            p.Get<string>(expectedTenTinhParameterName) == tenTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _tinhDALService.SuaTinh(maTinh, tenTinh);

            // Assert
            Assert.Equal(SuaTinhMessage.Failed, result);
        }
        #endregion

        #region XoaTinh
        [Theory, InlineData(1)]
        public void XoaTinh_ReturnsSuccessfulMessage(int maTinh)
        {
            // Arrange
            var expectedQuery = "spTINH_XoaTinh";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<int>(expectedMaTinhParameterName) == maTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _tinhDALService.XoaTinh(maTinh);

            // Assert
            Assert.Equal(XoaTinhMessage.Success, result);
        }

        [Theory, InlineData(1)]
        public void XoaTinh_ReturnsFailedMessage(int maTinh)
        {
            // Arrange
            var expectedQuery = "spTINH_XoaTinh";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<int>(expectedMaTinhParameterName) == maTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _tinhDALService.XoaTinh(maTinh);

            // Assert
            Assert.Equal(XoaTinhMessage.Failed, result);
        }
        #endregion

        #region ThemTinh
        [Theory, InlineData("Tinh Tien Giang")]
        public void ThemTinh_ReturnsSuccessfulMessage(string tenTinh)
        {
            // Arrange
            var expectedQuery = "spTINH_ThemTinh";
            var expectedTenTinhParameterName = "@TenTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenTinhParameterName) == tenTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _tinhDALService.ThemTinh(tenTinh);

            // Assert
            Assert.Equal(ThemTinhMessage.Success, result);
        }

        [Theory, InlineData("Tinh Tien Giang")]
        public void ThemTinh_ReturnsFailedMessage(string tenTinh)
        {
            // Arrange
            var expectedQuery = "spTINH_ThemTinh";
            var expectedTenTinhParameterName = "@TenTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenTinhParameterName) == tenTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _tinhDALService.ThemTinh(tenTinh);

            // Assert
            Assert.Equal(ThemTinhMessage.Failed, result);
        }
        #endregion
    }
}
