using DTO;

namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class NganhDALTest
    {
        #region Services
        private readonly INganhDALService _nganhDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public NganhDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _nganhDALService = new NganhDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSNganh
        [Fact]
        public void LayDSNganh_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spNGANH_LayDSNganh";
            var expectedResult = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Ky thuat phan mem",
                    MaKhoa = "CNPM",
                    TenKhoa = "Cong nghe phan mem"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<CT_Nganh>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.LayDSNganh();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region XoaNganh
        [Theory, InlineData("KTPM")]
        public void XoaNganh_ReturnsSuccessfulMessage(string maNganh)
        {
            // Arrange
            var expectedQuery = "spNGANH_XoaNganh";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.XoaNganh(maNganh);

            // Assert
            Assert.Equal(XoaNganhMessage.Success, result);
        }

        [Theory, InlineData("KTPM")]
        public void XoaNganh_ReturnsFailedMessage(string maNganh)
        {
            // Arrange
            var expectedQuery = "spNGANH_XoaNganh";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.XoaNganh(maNganh);

            // Assert
            Assert.Equal(XoaNganhMessage.Failed, result);
        }
        #endregion

        #region SuaNganh
        [Theory, InlineData("KTPM", "KTPM1", "Ky thuat phan mem 1", "CNPM")]
        public void SuaNganh_ReturnsSuccessfulMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var expectedQuery = "spNGANH_SuaNganh";
            var expectedMaNganhBanDauParameterName = "@MaNganhBanDau";
            var expectedMaNganhSuaParameterName = "@MaNganh";
            var expectedTenNganhSuaParameterName = "@TenNganh";
            var expectedMaKhoaSuaParameterName = "@MaKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhBanDauParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhSuaParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenNganhSuaParameterName)) && 
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaSuaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.Equal(SuaNganhMessage.Success, result);
        }

        [Theory, InlineData("KTPM", "KTPM1", "Ky thuat phan mem 1", "CNPM")]
        public void SuaNganh_ReturnsFailedMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var expectedQuery = "spNGANH_SuaNganh";
            var expectedMaNganhBanDauParameterName = "@MaNganhBanDau";
            var expectedMaNganhSuaParameterName = "@MaNganh";
            var expectedTenNganhSuaParameterName = "@TenNganh";
            var expectedMaKhoaSuaParameterName = "@MaKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhBanDauParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhSuaParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenNganhSuaParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaSuaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.Equal(SuaNganhMessage.Failed, result);
        }
        #endregion

        #region ThemNganh
        [Theory, InlineData("KTPM1", "Ky thuat phan mem 1", "CNPM")]
        public void ThemNganh_ReturnsSuccessfulMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Arrange
            var expectedQuery = "spNGANH_ThemNganh";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedTenNganhParameterName = "@TenNganh";
            var expectedMaKhoaParameterName = "@MaKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenNganhParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            Assert.Equal(ThemNganhMessage.Success, result);
        }

        [Theory, InlineData("KTPM1", "Ky thuat phan mem 1", "CNPM")]
        public void ThemNganh_ReturnsFailedMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Arrange
            var expectedQuery = "spNGANH_ThemNganh";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedTenNganhParameterName = "@TenNganh";
            var expectedMaKhoaParameterName = "@MaKhoa";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => !string.IsNullOrEmpty(p.Get<string>(expectedMaNganhParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedTenNganhParameterName)) &&
                            !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            Assert.Equal(ThemNganhMessage.Failed, result);
        }
        #endregion

        #region GetNganh
        [Theory, InlineData(null)]
        public void GetNganh_WithNullMaKhoa_VerifyExecuteDAL(string maKhoa)
        {
            // Arrange
            var expectedQuery = "spNGANH_LayDSNganh";
            var expectedResult = new List<Nganh>
            {
                new Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Ky thuat phan mem",
                    MaKhoa = "CNPM"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<Nganh>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.GetNganh(maKhoa);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory, InlineData("CNPM")]
        public void GetNganh_WithNotNullMaKhoa_VerifyExecuteDAL(string maKhoa)
        {
            // Arrange
            var expectedQuery = "spNGANH_LayNganhBangMaKhoa";
            var expectedMaKhoaParameterName = "@MaKhoa";
            var expectedCommandType = CommandType.StoredProcedure;

            var expectedResult = new List<Nganh>
            {
                new Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Ky thuat phan mem",
                    MaKhoa = "CNPM"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<Nganh>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => !string.IsNullOrEmpty(p.Get<string>(expectedMaKhoaParameterName))),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nganhDALService.GetNganh(maKhoa);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
