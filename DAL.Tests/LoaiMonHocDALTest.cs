namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class LoaiMonHocDALTest
    {
        #region Services
        private readonly ILoaiMonHocDALService _loaiMonHocDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public LoaiMonHocDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _loaiMonHocDALService = new LoaiMonHocDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSLoaiMonHoc
        [Fact]
        public void LayDSHuyen_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spLOAIMONHOC_LayDSLoaiMonHoc";
            var expectedResult = new List<LoaiMonHoc>
            {
                new LoaiMonHoc
                {
                    MaLoaiMonHoc = 1,
                    TenLoaiMonHoc = "Ly thuyet",
                    SoTien = 1000000,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<LoaiMonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _loaiMonHocDALService.LayDSLoaiMonHoc();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region XoaLoaiMonHoc
        [Theory, InlineData(1)]
        public void XoaHuyen_ReturnsSuccessfulMessage(int maLoaiMonHoc)
        {
            // Arrange
            var expectedQuery = "spLOAIMONHOC_XoaLoaiMonHoc";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _loaiMonHocDALService.XoaLoaiMonHoc(maLoaiMonHoc);

            // Assert
            Assert.Equal(XoaLoaiMonHocMessage.Success, result);
        }

        [Theory, InlineData(1)]
        public void XoaHuyen_ReturnsFailedMessage(int maLoaiMonHoc)
        {
            // Arrange
            var expectedQuery = "spLOAIMONHOC_XoaLoaiMonHoc";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _loaiMonHocDALService.XoaLoaiMonHoc(maLoaiMonHoc);

            // Assert
            Assert.Equal(XoaLoaiMonHocMessage.Failed, result);
        }
        #endregion

        #region SuaLoaiMonHoc
        [Theory, InlineData(1, "Ly thuyet", 45, 1000000)]
        public void SuaLoaiMonHoc_ReturnsSuccessfulMessage(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            // Arrange
            var expectedQuery = "spLOAIMONHOC_SuaLoaiMonHoc";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedTenLoaiMonHocParameterName = "@TenLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedSoTienParameterName = "@SoTien";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc &&
                            p.Get<string>(expectedTenLoaiMonHocParameterName) == tenLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet &&
                            p.Get<decimal>(expectedSoTienParameterName) == soTien),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _loaiMonHocDALService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);

            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.Success, result);
        }

        [Theory, InlineData(1, "Ly thuyet", 45, 1000000)]
        public void SuaLoaiMonHoc_ReturnsFailedMessage(int maLoaiMonHoc, string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            // Arrange
            var expectedQuery = "spLOAIMONHOC_SuaLoaiMonHoc";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedTenLoaiMonHocParameterName = "@TenLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedSoTienParameterName = "@SoTien";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc &&
                            p.Get<string>(expectedTenLoaiMonHocParameterName) == tenLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet &&
                            p.Get<decimal>(expectedSoTienParameterName) == soTien),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _loaiMonHocDALService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);

            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.Failed, result);
        }
        #endregion

        #region ThemLoaiMonHoc
        [Theory, InlineData("Ly thuyet", 45, 1000000)]
        public void ThemLoaiMonHoc_ReturnsSuccessfulMessage(string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            // Arrange
            var expectedQuery = "spLOAIMONHOC_ThemLoaiMonHoc";
            var expectedTenLoaiMonHocParameterName = "@TenLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedSoTienParameterName = "@SoTien";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenLoaiMonHocParameterName) == tenLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet &&
                            p.Get<decimal>(expectedSoTienParameterName) == soTien),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _loaiMonHocDALService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);

            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.Success, result);
        }

        [Theory, InlineData("Ly thuyet", 45, 1000000)]
        public void ThemLoaiMonHoc_ReturnsFailedMessage(string tenLoaiMonHoc, int soTiet, decimal soTien)
        {
            // Arrange
            var expectedQuery = "spLOAIMONHOC_ThemLoaiMonHoc";
            var expectedTenLoaiMonHocParameterName = "@TenLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedSoTienParameterName = "@SoTien";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenLoaiMonHocParameterName) == tenLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet &&
                            p.Get<decimal>(expectedSoTienParameterName) == soTien),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _loaiMonHocDALService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);

            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.Failed, result);
        }
        #endregion
    }
}
