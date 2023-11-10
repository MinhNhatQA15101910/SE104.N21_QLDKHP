namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class DoiTuongDALTest
    {
        #region Services
        private readonly IDoiTuongDALService _doiTuongDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public DoiTuongDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _doiTuongDALService = new DoiTuongDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSDoiTuong
        [Fact]
        public void LayDSDoiTuong_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spDOITUONG_LayDSDoiTuong";
            var expectedResult = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 1,
                    TenDT = "Con thuong binh",
                    TiLeGiamHocPhi = 0.5f
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<DoiTuong>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.LayDSDoiTuong();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region SuaDoiTuong
        [Theory, InlineData(1, "Con thuong binh", 0.5f)]
        public void SuaDoiTuong_ReturnsSuccessfulMessage(int maDTBanDau, string tenDT, float tiLeGiam)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_SuaDoiTuong";
            var expectedMaDoiTuongParameterName = "@MaDT";
            var expectedTenDoiTuongParameterName = "@TenDT";
            var expectedTiLeGiamHocPhiParameterName = "@TiLeGiamHocPhi";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaDoiTuongParameterName) == maDTBanDau &&
                            p.Get<string>(expectedTenDoiTuongParameterName) == tenDT &&
                            p.Get<float>(expectedTiLeGiamHocPhiParameterName) == tiLeGiam),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            Assert.Equal(SuaDoiTuongMessage.Success, result);
        }

        [Theory, InlineData(1, "Con thuong binh", 0.5f)]
        public void SuaDoiTuong_ReturnsFailedMessage(int maDTBanDau, string tenDT, float tiLeGiam)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_SuaDoiTuong";
            var expectedMaDoiTuongParameterName = "@MaDT";
            var expectedTenDoiTuongParameterName = "@TenDT";
            var expectedTiLeGiamHocPhiParameterName = "@TiLeGiamHocPhi";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaDoiTuongParameterName) == maDTBanDau &&
                            p.Get<string>(expectedTenDoiTuongParameterName) == tenDT &&
                            p.Get<float>(expectedTiLeGiamHocPhiParameterName) == tiLeGiam),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            Assert.Equal(SuaDoiTuongMessage.Failed, result);
        }
        #endregion

        #region ThemDoiTuong
        [Theory, InlineData("Con thuong binh", 0.5f)]
        public void ThemDoiTuong_ReturnsSuccessfulMessage(string tenDT, float tiLeGiam)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_ThemDoiTuong";
            var expectedTenDoiTuongParameterName = "@TenDT";
            var expectedTiLeGiamHocPhiParameterName = "@TiLeGiamHocPhi";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDoiTuongParameterName) == tenDT &&
                            p.Get<float>(expectedTiLeGiamHocPhiParameterName) == tiLeGiam),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.ThemDoiTuong(tenDT, tiLeGiam);

            // Assert
            Assert.Equal(ThemDoiTuongMessage.Success, result);
        }

        [Theory, InlineData("Con thuong binh", 0.5f)]
        public void ThemDoiTuong_ReturnsFailedMessage(string tenDT, float tiLeGiam)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_ThemDoiTuong";
            var expectedTenDoiTuongParameterName = "@TenDT";
            var expectedTiLeGiamHocPhiParameterName = "@TiLeGiamHocPhi";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDoiTuongParameterName) == tenDT &&
                            p.Get<float>(expectedTiLeGiamHocPhiParameterName) == tiLeGiam),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.ThemDoiTuong(tenDT, tiLeGiam);

            // Assert
            Assert.Equal(ThemDoiTuongMessage.Failed, result);
        }
        #endregion

        #region LayDSDoiTuong2
        [Fact]
        public void LayDSDoiTuong2_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spDOITUONG_LayDSDoiTuong2";
            var expectedResult = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 1,
                    TenDT = "Con thuong binh",
                    TiLeGiamHocPhi = 0.5f
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<DoiTuong>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.LayDSDoiTuong2();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDSDoiTuongKhongThuocVeMaSV
        [Theory, InlineData("SV21522415")]
        public void LayDSDoiTuongKhongThuocVeMaSV_VerifyQueryData(string maSV)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_LayDSDoiTuongKhongThuocVeMaSV";
            var expectedMaSVParameterName = "@MaSV";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 1,
                    TenDT = "Con thuong binh",
                    TiLeGiamHocPhi = 0.5f
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<DoiTuong>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterName) == maSV),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.LayDSDoiTuongKhongThuocVeMaSV(maSV);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDSDoiTuongBangMaSV
        [Theory, InlineData("SV21522415")]
        public void LayDSDoiTuongBangMaSV_VerifyQueryData(string maSV)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_LayDSDoiTuongBangMaSV";
            var expectedMaSVParameterName = "@MaSV";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 1,
                    TenDT = "Con thuong binh",
                    TiLeGiamHocPhi = 0.5f
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<DoiTuong>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterName) == maSV),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.LayDSDoiTuongBangMaSV(maSV);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region XoaDoiTuong
        [Theory, InlineData(1)]
        public void XoaDoiTuong_ReturnsSuccessfulMessage(int maDT)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_XoaDoiTuong";
            var expectedMaDoiTuongParameterName = "@MaDT";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaDoiTuongParameterName) == maDT),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.XoaDoiTuong(maDT);

            // Assert
            Assert.Equal(XoaDoiTuongMessage.Success, result);
        }

        [Theory, InlineData(1)]
        public void XoaDoiTuong_ReturnsFailedMessage(int maDT)
        {
            // Arrange
            var expectedQuery = "spDOITUONG_XoaDoiTuong";
            var expectedMaDoiTuongParameterName = "@MaDT";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaDoiTuongParameterName) == maDT),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _doiTuongDALService.XoaDoiTuong(maDT);

            // Assert
            Assert.Equal(XoaDoiTuongMessage.Failed, result);
        }
        #endregion
    }
}
