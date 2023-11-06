namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class KhoaDALTests
    {
        #region Services
        private readonly IKhoaDALService _khoaDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public KhoaDALTests()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _khoaDALService = new KhoaDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSKhoa
        [Fact]
        public void LayDSKhoa_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spKHOA_LayDSKhoa";
            var expectedResult = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "CNPM"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<Khoa>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString), 
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _khoaDALService.LayDSKhoa();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region XoaKhoa
        [Theory, InlineData("CNPM")]
        public void XoaKhoa_ReturnsSuccessfulMessage(string maKhoa)
        {
            // Arrange
            var expectedQuery = "spKHOA_XoaKhoa";
            var expectedMaKhoaParameterName = "@MaKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString), 
                    expectedQuery,
                    It.Is<DynamicParameters>(p => !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _khoaDALService.XoaKhoa(maKhoa);

            // Assert
            Assert.Equal(XoaKhoaMessage.Success, result);
        }

        [Theory, InlineData("CNPM")]
        public void XoaKhoa_ReturnsFailedMessage(string maKhoa)
        {
            // Arrange
            var expectedQuery = "spKHOA_XoaKhoa";
            var expectedMaKhoaParameterName = "@MaKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _khoaDALService.XoaKhoa(maKhoa);

            // Assert
            Assert.Equal(XoaKhoaMessage.Failed, result);
        }
        #endregion

        #region SuaKhoa
        [Theory, InlineData("CNPM", "CNPM1", "Công nghệ phần mềm 1")]
        public void SuaKhoa_ReturnsSuccessfulMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Arrange
            var expectedQuery = "spKHOA_SuaKhoa";
            var expectedMaKhoaBanDauParameterName = "@MaKhoaBanDau";
            var expectedMaKhoaSuaParameterName = "@MaKhoaSua";
            var expectedTenKhoaSuaParameterName = "@TenKhoaSua";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaBanDauParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaSuaParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenKhoaSuaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.Success, result);
        }

        [Theory, InlineData("CNPM", "CNPM1", "Công nghệ phần mềm 1")]
        public void SuaKhoa_ReturnsFailedMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Arrange
            var expectedQuery = "spKHOA_SuaKhoa";
            var expectedMaKhoaBanDauParameterName = "@MaKhoaBanDau";
            var expectedMaKhoaSuaParameterName = "@MaKhoaSua";
            var expectedTenKhoaSuaParameterName = "@TenKhoaSua";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaBanDauParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaSuaParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenKhoaSuaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.Failed, result);
        }
        #endregion

        #region ThemKhoa
        [Theory, InlineData("CNPM1", "Công nghệ phần mềm 1")]
        public void ThemKhoa_ReturnsSuccessfulMessage(string maKhoa, string tenKhoa)
        {
            // Arrange
            var expectedQuery = "spKHOA_ThemKhoa";
            var expectedMaKhoaParameterName = "@MaKhoa";
            var expectedTenKhoaParameterName = "@TenKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenKhoaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _khoaDALService.ThemKhoa(maKhoa, tenKhoa);

            // Assert
            Assert.Equal(ThemKhoaMessage.Success, result);
        }

        [Theory, InlineData("CNPM1", "Công nghệ phần mềm 1")]
        public void ThemKhoa_ReturnsFailedMessage(string maKhoa, string tenKhoa)
        {
            // Arrange
            var expectedQuery = "spKHOA_ThemKhoa";
            var expectedMaKhoaParameterName = "@MaKhoa";
            var expectedTenKhoaParameterName = "@TenKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenKhoaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _khoaDALService.ThemKhoa(maKhoa, tenKhoa);

            // Assert
            Assert.Equal(ThemKhoaMessage.Failed, result);
        }
        #endregion
    }
}
