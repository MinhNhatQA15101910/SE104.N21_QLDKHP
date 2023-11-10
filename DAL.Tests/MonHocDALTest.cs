using DTO;

namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class MonHocDALTest
    {
        #region Services
        private readonly IMonHocDALService _monHocDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public MonHocDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _monHocDALService = new MonHocDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSMonHoc
        [Fact]
        public void LayDSMonHoc_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spMONHOC_LayDSMonHoc";
            var expectedResult = new List<CT_MonHoc>
            {
                new CT_MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45,
                    TenLoaiMonHoc = "Ly thuyet",
                    SoTietLoaiMon = 15,
                    SoTien = 1000000
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<CT_MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.LayDSMonHoc();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region XoaMonHoc
        [Theory, InlineData("IT001")]
        public void XoaMonHoc_ReturnsSuccessfulMessage(string maMH)
        {
            // Arrange
            var expectedQuery = "spMONHOC_XoaMonHoc";
            var expectedMaMonHocParameterName = "@MaMH";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMonHocParameterName) == maMH),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.XoaMonHoc(maMH);

            // Assert
            Assert.Equal(XoaMonHocMessage.Success, result);
        }

        [Theory, InlineData("IT001")]
        public void XoaMonHoc_ReturnsFailedMessage(string maMH)
        {
            // Arrange
            var expectedQuery = "spMONHOC_XoaMonHoc";
            var expectedMaMonHocParameterName = "@MaMH";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMonHocParameterName) == maMH),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.XoaMonHoc(maMH);

            // Assert
            Assert.Equal(XoaMonHocMessage.Failed, result);
        }
        #endregion

        #region SuaMonHoc
        [Theory, InlineData("IT001", "Nhap mon lap trinh", 1, 45)]
        public void SuaMonHoc_ReturnsSuccessfulMessage(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            // Arrange
            var expectedQuery = "spMONHOC_SuaMonHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedTenMHParameterName = "@TenMH";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == maMHBanDau &&
                            p.Get<string>(expectedTenMHParameterName) == tenMH &&
                            p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.SuaMonHoc(maMHBanDau, tenMH, maLoaiMonHoc, soTiet);

            // Assert
            Assert.Equal(SuaMonHocMessage.Success, result);
        }

        [Theory, InlineData("IT001", "Nhap mon lap trinh", 1, 45)]
        public void SuaMonHoc_ReturnsFailedMessage(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            // Arrange
            var expectedQuery = "spMONHOC_SuaMonHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedTenMHParameterName = "@TenMH";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == maMHBanDau &&
                            p.Get<string>(expectedTenMHParameterName) == tenMH &&
                            p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.SuaMonHoc(maMHBanDau, tenMH, maLoaiMonHoc, soTiet);

            // Assert
            Assert.Equal(SuaMonHocMessage.Failed, result);
        }
        #endregion

        #region ThemMonHoc
        [Theory, InlineData("IT001", "Nhap mon lap trinh", 1, 45)]
        public void ThemMonHoc_ReturnsSuccessfulMessage(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            // Arrange
            var expectedQuery = "spMONHOC_ThemMonHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedTenMHParameterName = "@TenMH";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == maMH &&
                            p.Get<string>(expectedTenMHParameterName) == tenMH &&
                            p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.ThemMonHoc(maMH, tenMH, maLoaiMonHoc, soTiet);

            // Assert
            Assert.Equal(ThemMonHocMessage.Success, result);
        }

        [Theory, InlineData("IT001", "Nhap mon lap trinh", 1, 45)]
        public void ThemMonHoc_ReturnsFailedMessage(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            // Arrange
            var expectedQuery = "spMONHOC_ThemMonHoc";
            var expectedMaMHParameterName = "@MaMH";
            var expectedTenMHParameterName = "@TenMH";
            var expectedMaLoaiMonHocParameterName = "@MaLoaiMonHoc";
            var expectedSoTietParameterName = "@SoTiet";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaMHParameterName) == maMH &&
                            p.Get<string>(expectedTenMHParameterName) == tenMH &&
                            p.Get<int>(expectedMaLoaiMonHocParameterName) == maLoaiMonHoc &&
                            p.Get<int>(expectedSoTietParameterName) == soTiet),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.ThemMonHoc(maMH, tenMH, maLoaiMonHoc, soTiet);

            // Assert
            Assert.Equal(ThemMonHocMessage.Failed, result);
        }
        #endregion

        #region LayDSMonHoc2
        [Fact]
        public void LayDSMonHoc2_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spMONHOC_LayDSMonHoc2";
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.LayDSMonHoc2();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region GetTermMonHoc
        [Theory, InlineData(1)]
        public void GetTermMonHoc_WithinHKI_VerifyQueryData(int hocKy)
        {
            // Arrange
            var expectedQuery = "spMONHOC_GetOddCTMonHoc";
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.GetTermMonHoc(hocKy);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory, InlineData(2)]
        public void GetTermMonHoc_WithinHKII_VerifyQueryData(int hocKy)
        {
            // Arrange
            var expectedQuery = "spMONHOC_GetEvenCTMonHoc";
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.GetTermMonHoc(hocKy);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory, InlineData(3)]
        public void GetTermMonHoc_WithinHKHe_VerifyQueryData(int hocKy)
        {
            // Arrange
            var expectedQuery = "spMONHOC_GetAllCTMonHoc";
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.GetTermMonHoc(hocKy);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region GetTermMonHocMo
        [Theory, InlineData(1, 2023)]
        public void GetTermMonHocMo_VerifyQueryData(int hocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spMONHOC_GetTermMonHocMo";
            var expectedHocKyParameterName = "@HocKy";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedHocKyParameterName) == hocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.GetTermMonHocMo(hocKy, namHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region GetChuongTrinhHoc
        [Theory, InlineData("KTPM", 1)]
        public void GetChuongTrinhHoc_WithHocKyIsNotZero_VerifyQueryData(string maNganh, int hocKy)
        {
            // Arrange
            var expectedQuery = "spMONHOC_GetCTHHocKy";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedHocKyParameterName = "@HocKy";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaNganhParameterName) == maNganh &&
                            p.Get<int>(expectedHocKyParameterName) == hocKy),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.GetChuongTrinhHoc(maNganh, hocKy);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory, InlineData("KTPM", 0)]
        public void GetChuongTrinhHoc_WithHocKyIsZero_VerifyQueryData(string maNganh, int hocKy)
        {
            // Arrange
            var expectedQuery = "spMONHOC_GetCTHHocKy";
            var expectedMaNganhParameterName = "@MaNganh";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaNganhParameterName) == maNganh),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.GetChuongTrinhHoc(maNganh, hocKy);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region GetMonHocPhieuDKHP
        [Theory, InlineData(1)]
        public void GetMonHocPhieuDKHP_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spMONHOC_GetMonHocPhieuDKHP";
            var expectedMaPhieuDKHPParameterName = "@MaPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<MonHoc>
            {
                new MonHoc
                {
                    MaMH = "IT001",
                    TenMH = "Nhap mon lap trinh",
                    MaLoaiMonHoc = 1,
                    SoTiet = 45
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<MonHoc>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _monHocDALService.GetMonHocPhieuDKHP(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
