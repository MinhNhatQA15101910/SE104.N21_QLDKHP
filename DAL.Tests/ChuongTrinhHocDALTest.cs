namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class ChuongTrinhHocDALTest
    {
        #region Services
        private readonly IChuongTrinhHocDALService _chuongTrinhHocDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public ChuongTrinhHocDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _chuongTrinhHocDALService = new ChuongTrinhHocDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region DeleteListCTHoc
        [Theory, InlineData("KTPM", 1)]
        public void DeleteListCTHoc_ReturnsSuccessfulMessage(string maNganh, int hocKy)
        {
            // Arrange
            var expectedQuery = "spCHUONGTRINHHOC_DeleteListCTHoc";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedHocKyParameterName = "@HocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaNganhParameterName) == maNganh && 
                            p.Get<int>(expectedHocKyParameterName) == hocKy),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _chuongTrinhHocDALService.DeleteListCTHoc(maNganh, hocKy);

            // Assert
            Assert.Equal(MessageDeleteListCTHoc.Success, result);
        }

        [Theory, InlineData("KTPM", 1)]
        public void DeleteListCTHoc_ReturnsFailedMessage(string maNganh, int hocKy)
        {
            // Arrange
            var expectedQuery = "spCHUONGTRINHHOC_DeleteListCTHoc";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedHocKyParameterName = "@HocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaNganhParameterName) == maNganh &&
                            p.Get<int>(expectedHocKyParameterName) == hocKy),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _chuongTrinhHocDALService.DeleteListCTHoc(maNganh, hocKy);

            // Assert
            Assert.Equal(MessageDeleteListCTHoc.Failed, result);
        }
        #endregion

        #region GetAllCTHoc
        [Fact]
        public void GetAllCTHoc_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spCHUONGTRINHHOC_GetAll";
            var expectedResult = new List<ChuongTrinhHoc>
            {
                new ChuongTrinhHoc
                {
                    MaNganh = "KTPM",
                    MaMH = "IT001",
                    HocKy = 1
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<ChuongTrinhHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _chuongTrinhHocDALService.GetAllCTHoc();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region DeleteCTHoc
        [Theory, InlineData("IT001", "KTPM", 1)]
        public void DeleteCTHoc_ReturnsSuccessfulMessage(string maMH, string maNganh, int hocKy)
        {
            // Arrange
            var expectedQuery = "spCHUONGTRINHHOC_DeleteCTHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedHocKyParameterName = "@HocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == maMH &&
                            p.Get<string>(expectedMaNganhParameterName) == maNganh &&
                            p.Get<int>(expectedHocKyParameterName) == hocKy),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _chuongTrinhHocDALService.DeleteCTHoc(maMH, maNganh, hocKy);

            // Assert
            Assert.Equal(MessageDeleteCTHoc.Success, result);
        }

        [Theory, InlineData("IT001", "KTPM", 1)]
        public void DeleteCTHoc_ReturnsFailedMessage(string maMH, string maNganh, int hocKy)
        {
            // Arrange
            var expectedQuery = "spCHUONGTRINHHOC_DeleteCTHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedHocKyParameterName = "@HocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == maMH &&
                            p.Get<string>(expectedMaNganhParameterName) == maNganh &&
                            p.Get<int>(expectedHocKyParameterName) == hocKy),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _chuongTrinhHocDALService.DeleteCTHoc(maMH, maNganh, hocKy);

            // Assert
            Assert.Equal(MessageDeleteCTHoc.Failed, result);
        }
        #endregion

        #region AddCTHoc
        [Fact]
        public void AddCTHoc_ReturnsSuccessfulMessage()
        {
            // Arrange
            var expectedChuongTrinhHoc = new ChuongTrinhHoc
            {
                MaMH = "IT001",
                MaNganh = "KTPM",
                HocKy = 1
            };
            var expectedQuery = "spCHUONGTRINHHOC_AddCTHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedHocKyParameterName = "@HocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == expectedChuongTrinhHoc.MaMH &&
                            p.Get<string>(expectedMaNganhParameterName) == expectedChuongTrinhHoc.MaNganh &&
                            p.Get<int>(expectedHocKyParameterName) == expectedChuongTrinhHoc.HocKy),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _chuongTrinhHocDALService.AddCTHoc(expectedChuongTrinhHoc);

            // Assert
            Assert.Equal(MessageAddCTHoc.Success, result);
        }

        [Fact]
        public void AddCTHoc_ReturnsFailedMessage()
        {
            // Arrange
            var expectedChuongTrinhHoc = new ChuongTrinhHoc
            {
                MaMH = "IT001",
                MaNganh = "KTPM",
                HocKy = 1
            };
            var expectedQuery = "spCHUONGTRINHHOC_AddCTHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedHocKyParameterName = "@HocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == expectedChuongTrinhHoc.MaMH &&
                            p.Get<string>(expectedMaNganhParameterName) == expectedChuongTrinhHoc.MaNganh &&
                            p.Get<int>(expectedHocKyParameterName) == expectedChuongTrinhHoc.HocKy),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _chuongTrinhHocDALService.AddCTHoc(expectedChuongTrinhHoc);

            // Assert
            Assert.Equal(MessageAddCTHoc.Failed, result);
        }
        #endregion
    }
}
