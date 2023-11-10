namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class PhieuDKHPDALTest
    {
        #region Services
        private readonly IPhieuDKHPDALService _phieuDKHPDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public PhieuDKHPDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _phieuDKHPDALService = new PhieuDKHPDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayTTPhieuDKHP
        [Theory, InlineData("SV21522415", 1, 2023)]
        public void LayTTPhieuDKHP_VerifyQueryData(string mssv, int maHocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_LayTTPhieuDKHP";
            var expectedMssvParameterName = "@mssv";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<PhieuDKHP>
            {
                new PhieuDKHP
                {
                    MaPhieuDKHP = 1,
                    MaSV = "SV21522415",
                    MaHocKy = 1,
                    NamHoc = 2023,
                    MaTinhTrang = 1,
                    NgayLap = DateTime.Now
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<PhieuDKHP>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMssvParameterName) == mssv &&
                            p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.LayTTPhieuDKHP(mssv, maHocKy, namHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDSMHThuocHP
        [Theory, InlineData(1)]
        public void LayDSMHThuocHP_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_LayDSMHThuocHP";
            var expectedMaParameterName = "@ma";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<dynamic>
            {
                new PhieuDKHP
                {
                    MaPhieuDKHP = 1,
                    MaSV = "SV21522415",
                    MaHocKy = 1,
                    NamHoc = 2023,
                    MaTinhTrang = 1,
                    NgayLap = DateTime.Now
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<dynamic>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.LayDSMHThuocHP(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TinhHocPhi
        [Theory, InlineData(1)]
        public void TinhHocPhi_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_TinhHocPhi";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1000000;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.TinhHocPhi(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TinhHocPhiPhaiDong
        [Theory, InlineData(1)]
        public void TinhHocPhiPhaiDong_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_TinhHocPhiPhaiDong";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1000000;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<float>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.TinhHocPhiPhaiDong(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TinhHocPhiDaDong
        [Theory, InlineData(1)]
        public void TinhHocPhiDaDong_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_TinhHocPhiDaDong";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1000000;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<float>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.TinhHocPhiDaDong(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TinhHocPhiConThieu
        [Theory, InlineData(1)]
        public void TinhHocPhiConThieu_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_TinhHocPhiConThieu";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1000000;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<float>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.TinhHocPhiConThieu(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDSMHThuocHP2
        [Theory, InlineData(1)]
        public void LayDSMHThuocHP2_VerifyQueryData(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_layDSMHThuocHP2";
            var expectedMaParameterName = "@ma";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<dynamic>
            {
                new PhieuDKHP
                {
                    MaPhieuDKHP = 1,
                    MaSV = "SV21522415",
                    MaHocKy = 1,
                    NamHoc = 2023,
                    MaTinhTrang = 1,
                    NgayLap = DateTime.Now
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<dynamic>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.LayDSMHThuocHP2(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TaoPhieuDKHP
        [Theory, InlineData("SV21522415", 1, 2023)]
        public void TaoPhieuDKHP_ReturnsTrue(string mssv, int hocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_TaoPhieuDKHP";
            var expectedMaSVParameterName = "@maSV";
            var expectedHocKyParameterName = "@hocKy";
            var expectedNamHocParameterName = "@namHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterName) == mssv &&
                            p.Get<int>(expectedHocKyParameterName) == hocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.TaoPhieuDKHP(mssv, hocKy, namHoc);

            // Assert
            Assert.True(result);
        }

        [Theory, InlineData("SV21522415", 1, 2023)]
        public void TaoPhieuDKHP_ReturnsFalse(string mssv, int hocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_TaoPhieuDKHP";
            var expectedMaSVParameterName = "@maSV";
            var expectedHocKyParameterName = "@hocKy";
            var expectedNamHocParameterName = "@namHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterName) == mssv &&
                            p.Get<int>(expectedHocKyParameterName) == hocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.TaoPhieuDKHP(mssv, hocKy, namHoc);

            // Assert
            Assert.False(result);
        }
        #endregion

        #region LayMaPhieuDKHP
        [Theory, InlineData(1, 2023)]
        public void LayMaPhieuDKHP_VerifyQueryData(int hocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_LayMaPhieuDKHP";
            var expectedMaHocKyParameterName = "@maHocKy";
            var expectedNamHocParameterName = "@namHoc";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<int>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == hocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.LayMaPhieuDKHP(hocKy, namHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDanhSachDKHPDaXacNhan
        [Theory, InlineData("SV21522415")]
        public void LayDanhSachDKHPDaXacNhan_VerifyQueryData(string mssv)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_LayDanhSachDKHPChoThanhToan";
            var expectedMssvParameterName = "@mssv";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<PhieuDKHP>
            {
                new PhieuDKHP
                {
                    MaPhieuDKHP = 1,
                    MaSV = "SV21522415",
                    MaHocKy = 1,
                    NamHoc = 2023,
                    MaTinhTrang = 1,
                    NgayLap = DateTime.Now
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<PhieuDKHP>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMssvParameterName) == mssv),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.LayDanhSachDKHPDaXacNhan(mssv);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region GetPhieuDKHP
        [Theory, InlineData(1, 2023, 1)]
        public void GetPhieuDKHP_VerifyQueryData(int maHocKy, int namHoc, int maTinhTrang)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_GetPhieuDKHP";
            var expectedMaHocKyParameterName = "@MaHocKy";
            var expectedNamHocParameterName = "@NamHoc";
            var expectedMaTinhTrangParameterName = "@MaTinhTrang";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new List<PhieuDKHP>
            {
                new PhieuDKHP
                {
                    MaPhieuDKHP = 1,
                    MaSV = "SV21522415",
                    MaHocKy = 1,
                    NamHoc = 2023,
                    MaTinhTrang = 1,
                    NgayLap = DateTime.Now
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<PhieuDKHP>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaHocKyParameterName) == maHocKy &&
                            p.Get<int>(expectedNamHocParameterName) == namHoc &&
                            p.Get<int>(expectedMaTinhTrangParameterName) == maTinhTrang),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.GetPhieuDKHP(maHocKy, namHoc, maTinhTrang);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region PhieuDKHPUpdateTinhTrang
        [Theory, InlineData(1, 1)]
        public void SuaNganh_ReturnsSuccessfulMessage(int maPhieuDKHP, int maTinhTrang)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_UpdateTinhTrang";
            var expectedMaPhieuDKHPParameterName = "@MaPhieuDKHP";
            var expectedMaTinhTrangParameterName = "@MaTinhTrang";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP &&
                            p.Get<int>(expectedMaTinhTrangParameterName) == maTinhTrang),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.PhieuDKHPUpdateTinhTrang(maPhieuDKHP, maTinhTrang);

            // Assert
            Assert.Equal(MessagePhieuDKHPUpdateTinhTrang.Success, result);
        }

        [Theory, InlineData(1, 1)]
        public void SuaNganh_ReturnsFailedMessage(int maPhieuDKHP, int maTinhTrang)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_UpdateTinhTrang";
            var expectedMaPhieuDKHPParameterName = "@MaPhieuDKHP";
            var expectedMaTinhTrangParameterName = "@MaTinhTrang";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP &&
                            p.Get<int>(expectedMaTinhTrangParameterName) == maTinhTrang),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.PhieuDKHPUpdateTinhTrang(maPhieuDKHP, maTinhTrang);

            // Assert
            Assert.Equal(MessagePhieuDKHPUpdateTinhTrang.Failed, result);
        }
        #endregion

        #region GetAllPhieuDKHP
        [Fact]
        public void GetAllPhieuDKHP_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_GetAllPhieuDKHP";
            var expectedResult = new List<PhieuDKHP>
            {
                new PhieuDKHP
                {
                    MaPhieuDKHP = 1,
                    MaSV = "SV21522415",
                    MaHocKy = 1,
                    NamHoc = 2023,
                    MaTinhTrang = 1,
                    NgayLap = DateTime.Now
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<PhieuDKHP>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _phieuDKHPDALService.GetAllPhieuDKHP();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
