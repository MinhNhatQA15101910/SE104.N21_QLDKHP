namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class HocKyDALTest
    {
        #region Services
        private readonly IHocKyDALService _hocKyDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public HocKyDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _hocKyDALService = new HocKyDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDanhSachHK
        [Fact]
        public void LayDanhSachHK_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spHOCKY_LayDanhSachHK";
            var expectedResult = new List<HocKy>
            {
                new HocKy
                {
                    MaHocKy = 1,
                    TenHocKy = "HK I"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<HocKy>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _hocKyDALService.LayDanhSachHK();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayHKByMaHK
        [Theory, InlineData(1)]
        public void LayHKByMaHK_VerifyQueryData(int currMaHocKy)
        {
            // Arrange
            var expectedQuery = "spHOCKY_LayHKByMaHK";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedQueryResult = new List<string> { "HK I" };

            _dapperWrapperMock.Setup(
                _ => _.Query<string>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<int>(expectedMaHocKyParameterName) == currMaHocKy),
                    expectedCommandType))
                .Returns(expectedQueryResult);

            // Act
            var result = _hocKyDALService.LayHKByMaHK(currMaHocKy);

            // Assert
            Assert.Equal(expectedQueryResult.ToString(), result);
        }
        #endregion
    }
}
