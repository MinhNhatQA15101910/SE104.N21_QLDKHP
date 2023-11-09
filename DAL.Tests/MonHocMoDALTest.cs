namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class MonHocMoDALTest
    {
        #region Services
        private readonly IMonHocMoDALService _monHocMoDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public MonHocMoDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _monHocMoDALService = new MonHocMoDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region GetAllHocKyNamHoc
        [Fact]
        public void GetAllHocKyNamHoc_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spDANHSACHMONHOCMO_GetHocKyNamHoc";
            var expectedResult = new List<HocKyNamHoc>
            {
                new HocKyNamHoc
                {
                    MaHocKy = 1,
                    NamHoc = 2023
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<HocKyNamHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _monHocMoDALService.GetAllHocKyNamHoc();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region AddMonHocMo
        [Theory, InlineData("IT001", 1, 2023)]
        public void AddMonHocMo_ReturnsSuccessfulMessage(string maMH, int maHocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spDANHSACHMONHOCMO_AddMonHocMo";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedMaMHParameterName = "@MaMH";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<string>(expectedMaMHParameterName) == maMH &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocMoDALService.AddMonHocMo(maMH, maHocKy, namHoc);

            // Assert
            Assert.Equal(MessageAddMonHocMo.Success, result);
        }

        [Theory, InlineData("IT001", 1, 2023)]
        public void AddMonHocMo_ReturnsFailedMessage(string maMH, int maHocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spDANHSACHMONHOCMO_AddMonHocMo";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedMaMHParameterName = "@MaMH";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<string>(expectedMaMHParameterName) == maMH &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocMoDALService.AddMonHocMo(maMH, maHocKy, namHoc);

            // Assert
            Assert.Equal(MessageAddMonHocMo.Failed, result);
        }
        #endregion

        #region GetAllNamHoc
        [Fact]
        public void GetAllNamHoc_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spDANHSACHMONHOCMO_GetNam";
            var expectedResult = new List<int> { 2023 };

            _dapperWrapperMock.Setup(
                _ => _.Query<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _monHocMoDALService.GetAllNamHoc();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region DeleteHocKyNamHocMHM
        [Theory, InlineData(1, 2023)]
        public void DeleteHocKyNamHocMHM_ReturnsSuccessfulMessage(int maHocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spDANHSACHMONHOCMO_XoaDanhSach";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocMoDALService.DeleteHocKyNamHocMHM(maHocKy, namHoc);

            // Assert
            Assert.Equal(MessageDeleteHocKyNamHocMHM.Success, result);
        }

        [Theory, InlineData(1, 2023)]
        public void DeleteHocKyNamHocMHM_ReturnsFailedMessage(int maHocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spDANHSACHMONHOCMO_XoaDanhSach";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocMoDALService.DeleteHocKyNamHocMHM(maHocKy, namHoc);

            // Assert
            Assert.Equal(MessageDeleteHocKyNamHocMHM.Failed, result);
        }
        #endregion
    }
}
