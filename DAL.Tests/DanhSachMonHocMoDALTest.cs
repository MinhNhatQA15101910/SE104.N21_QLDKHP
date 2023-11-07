namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class DanhSachMonHocMoDALTest
    {
        #region Services
        private readonly IDanhSachMonHocMoDALService _danhSachMonHocMoDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public DanhSachMonHocMoDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _danhSachMonHocMoDALService = new DanhSachMonHocMoDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSMonHocMo
        [Fact]
        public void LayDSMonHocMo_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spDANHSACHMONHOCMO_LayDSMonHocMo";
            var expectedResult = new List<string> { "IT001", "IT002" };

            _dapperWrapperMock.Setup(
                _ => _.Query<string>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _danhSachMonHocMoDALService.LayDSMonHocMo();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDanhSachMonHocMo
        [Theory, InlineData(1, 2023)]
        public void LayDanhSachMonHocMo_VerifyQueryData(int hocKy, int namHoc)
        {
            // Arrange
            var expectedResult = new List<dynamic> { "IT001", "IT002" };
            var expectedQuery = "spDANHSACHMONHOCMO_LayDSMH";
            var expectedHocKyParameterName = "@hocKy";
            var expectedNamHocParameterName = "@namHoc";
            var expectedCommandType = CommandType.StoredProcedure;

            _dapperWrapperMock.Setup(_ => _.Query<dynamic>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedHocKyParameterName) == hocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _danhSachMonHocMoDALService.LayDanhSachMonHocMo(hocKy, namHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TimKiemDanhSachMonHocMo
        [Theory, InlineData(1, 2023, "IT001")]
        public void TimKiemDanhSachMonHocMo_VerifyQueryData(int hocKy, int namHoc, string monHoc)
        {
            // Arrange
            var expectedResult = new List<dynamic> { "IT001", "IT002" };
            var expectedQuery = "spDANHSACHMONHOCMO_TimKiemDSMH";
            var expectedHocKyParameterName = "@hocKy";
            var expectedNamHocParameterName = "@namHoc";
            var expectedMonHocParameterName = "@monHoc";
            var expectedCommandType = CommandType.StoredProcedure;

            _dapperWrapperMock.Setup(_ => _.Query<dynamic>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedHocKyParameterName) == hocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc &&
                            p.Get<string>(expectedMonHocParameterName) == monHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _danhSachMonHocMoDALService.TimKiemDanhSachMonHocMo(hocKy, namHoc, monHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
