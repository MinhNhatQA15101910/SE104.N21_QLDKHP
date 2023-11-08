namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class HuyenDALTest
    {
        #region Services
        private readonly IHuyenDALService _huyenDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public HuyenDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _huyenDALService = new HuyenDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSHuyen
        [Fact]
        public void LayDSHuyen_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spHUYEN_LayDSHuyen";
            var expectedResult = new List<CT_Huyen>
            {
                new CT_Huyen
                {
                    MaHuyen = 1,
                    TenHuyen = "Huyen Go Cong Tay",
                    MaTinh = 1,
                    TenTTP = "Tinh Tien Giang",
                    VungUT = 0
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<CT_Huyen>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _huyenDALService.LayDSHuyen();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region SuaHuyen
        [Theory, InlineData(1, "Huyen Go Cong Tay", 1, 1)]
        public void SuaHuyen_ReturnsSuccessfulMessage(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var expectedQuery = "spHUYEN_SuaHuyen";
            var expectedMaHuyenBanDauParameterName = "@MaHuyen";
            var expectedTenHuyenParameterName = "@TenHuyen";
            var expectedVungUTParameterName = "@VungUT";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHuyenBanDauParameterName) == maHuyen &&
                            p.Get<string>(expectedTenHuyenParameterName) == tenHuyen &&
                            p.Get<int>(expectedVungUTParameterName) == vungUT &&
                            p.Get<int>(expectedMaTinhParameterName) == maTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _huyenDALService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);

            // Assert
            Assert.Equal(SuaHuyenMessage.Success, result);
        }

        [Theory, InlineData(1, "Huyen Go Cong Tay", 1, 1)]
        public void SuaHuyen_ReturnsFailedMessage(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var expectedQuery = "spHUYEN_SuaHuyen";
            var expectedMaHuyenBanDauParameterName = "@MaHuyen";
            var expectedTenHuyenParameterName = "@TenHuyen";
            var expectedVungUTParameterName = "@VungUT";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHuyenBanDauParameterName) == maHuyen &&
                            p.Get<string>(expectedTenHuyenParameterName) == tenHuyen &&
                            p.Get<int>(expectedVungUTParameterName) == vungUT &&
                            p.Get<int>(expectedMaTinhParameterName) == maTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _huyenDALService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);

            // Assert
            Assert.Equal(SuaHuyenMessage.Failed, result);
        }
        #endregion

        #region XoaHuyen
        [Theory, InlineData(1)]
        public void XoaHuyen_ReturnsSuccessfulMessage(int maHuyen)
        {
            // Arrange
            var expectedQuery = "spHUYEN_XoaHuyen";
            var expectedMaHuyenBanDauParameterName = "@MaHuyen";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHuyenBanDauParameterName) == maHuyen),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _huyenDALService.XoaHuyen(maHuyen);

            // Assert
            Assert.Equal(XoaHuyenMessage.Success, result);
        }

        [Theory, InlineData(1)]
        public void XoaHuyen_ReturnsFailedMessage(int maHuyen)
        {
            // Arrange
            var expectedQuery = "spHUYEN_XoaHuyen";
            var expectedMaHuyenBanDauParameterName = "@MaHuyen";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHuyenBanDauParameterName) == maHuyen),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _huyenDALService.XoaHuyen(maHuyen);

            // Assert
            Assert.Equal(XoaHuyenMessage.Failed, result);
        }
        #endregion

        #region ThemHuyen
        [Theory, InlineData("Huyen Go Cong Tay", 1, 1)]
        public void ThemHuyen_ReturnsSuccessfulMessage(string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var expectedQuery = "spHUYEN_ThemHuyen";
            var expectedTenHuyenParameterName = "@TenHuyen";
            var expectedVungUTParameterName = "@VungUT";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenHuyenParameterName) == tenHuyen &&
                            p.Get<int>(expectedVungUTParameterName) == vungUT &&
                            p.Get<int>(expectedMaTinhParameterName) == maTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _huyenDALService.ThemHuyen(tenHuyen, vungUT, maTinh);

            // Assert
            Assert.Equal(ThemHuyenMessage.Success, result);
        }

        [Theory, InlineData("Huyen Go Cong Tay", 1, 1)]
        public void ThemHuyen_ReturnsFailedMessage(string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var expectedQuery = "spHUYEN_ThemHuyen";
            var expectedTenHuyenParameterName = "@TenHuyen";
            var expectedVungUTParameterName = "@VungUT";
            var expectedMaTinhParameterName = "@MaTinh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenHuyenParameterName) == tenHuyen &&
                            p.Get<int>(expectedVungUTParameterName) == vungUT &&
                            p.Get<int>(expectedMaTinhParameterName) == maTinh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _huyenDALService.ThemHuyen(tenHuyen, vungUT, maTinh);

            // Assert
            Assert.Equal(ThemHuyenMessage.Failed, result);
        }
        #endregion
    }
}
