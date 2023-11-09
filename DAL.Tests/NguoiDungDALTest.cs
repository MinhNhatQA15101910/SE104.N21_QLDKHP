namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class NguoiDungDALTest
    {
        #region Services
        private readonly INguoiDungDALService _nguoiDungDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public NguoiDungDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _nguoiDungDALService = new NguoiDungDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region ConvertToSHA512
        [Theory, InlineData("12345678")]
        public void ConvertToSHA512_WithPasswordInput_ReturnsHashedString(string source)
        {
            string expectedResult = "FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE";
            Type type = typeof(NguoiDungDALService);
            MethodInfo methodInfo = type.GetMethod("ConvertToSHA512", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = { source };

            // Act
            string result = (string)methodInfo.Invoke(null, parameters);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDSNguoiDung
        [Fact]
        public void LayDSNguoiDung_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_LayDSNguoiDung";
            var expectedResult = new List<CT_NguoiDung>
            {
                new CT_NguoiDung
                {
                    TenDangNhap = "admin1",
                    MatKhau = "12345678",
                    MaNhom = "ad",
                    TenNhom = "Admin"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<CT_NguoiDung>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.LayDSNguoiDung();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region DangNhap
        [Theory, InlineData("admin1", "12345678")]
        public void DangNhap_ReturnsSuccessfulMessage(string tenDangNhap, string matKhau)
        {
            // Arrange
            var expectedPasswordResult = "FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE";
            var expectedQuery = "spNGUOIDUNG_LayBangTenDangNhapVaMatKhau";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMatKhauParameterName = "@MatKhau";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = new NguoiDung
            {
                TenDangNhap = tenDangNhap,
                MatKhau = expectedPasswordResult,
                MaNhom = "ad"
            };

            _dapperWrapperMock.Setup(
                _ => _.QuerySingleOrDefault<NguoiDung>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMatKhauParameterName) == expectedPasswordResult),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.DangNhap(tenDangNhap, matKhau);

            // Assert
            Assert.Equal(DangNhapMessage.Success, result);
        }

        [Theory, InlineData("admin1", "12345678")]
        public void DangNhap_ReturnsFailedMessage(string tenDangNhap, string matKhau)
        {
            // Arrange
            var expectedPasswordResult = "FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE";
            var expectedQuery = "spNGUOIDUNG_LayBangTenDangNhapVaMatKhau";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMatKhauParameterName = "@MatKhau";
            var expectedCommandType = CommandType.StoredProcedure;
            NguoiDung? expectedResult = null;

            _dapperWrapperMock.Setup(
                _ => _.QuerySingleOrDefault<NguoiDung>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMatKhauParameterName) == expectedPasswordResult),
                    expectedCommandType))
                .Returns(expectedResult!);

            // Act
            var result = _nguoiDungDALService.DangNhap(tenDangNhap, matKhau);

            // Assert
            Assert.Equal(DangNhapMessage.Failed, result);
        }
        #endregion

        #region XoaTaiKhoan
        [Theory, InlineData("admin1")]
        public void XoaTaiKhoan_ReturnsSuccessfulMessage(string tenDangNhap)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_XoaTaiKhoan";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.XoaTaiKhoan(tenDangNhap);

            // Assert
            Assert.Equal(XoaTaiKhoanMessage.Success, result);
        }

        [Theory, InlineData("admin1")]
        public void XoaTaiKhoan_ReturnsFailedMessage(string tenDangNhap)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_XoaTaiKhoan";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.XoaTaiKhoan(tenDangNhap);

            // Assert
            Assert.Equal(XoaTaiKhoanMessage.Failed, result);
        }
        #endregion

        #region DoiMatKhau
        [Theory, InlineData("admin1", "12345678", "12345678")]
        public void DoiMatKhau_ReturnsSuccessfulMessage(string tenDangNhap, string matKhauHT, string matKhauMoi)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_DoiMatKhau";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMatKhauHTParameterName = "@MatKhauHT";
            var expectedMatKhauMoiParameterName = "@MatKhauMoi";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMatKhauHTParameterName) == "FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE" &&
                            p.Get<string>(expectedMatKhauMoiParameterName) == "FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE"),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.DoiMatKhau(tenDangNhap, matKhauHT, matKhauMoi);

            // Assert
            Assert.Equal(DoiMatKhauMessage.Success, result);
        }

        [Theory, InlineData("admin1", "12345678", "12345678")]
        public void DoiMatKhau_ReturnsFailedMessage(string tenDangNhap, string matKhauHT, string matKhauMoi)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_DoiMatKhau";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMatKhauHTParameterName = "@MatKhauHT";
            var expectedMatKhauMoiParameterName = "@MatKhauMoi";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMatKhauHTParameterName) == "FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE" &&
                            p.Get<string>(expectedMatKhauMoiParameterName) == "FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE"),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.DoiMatKhau(tenDangNhap, matKhauHT, matKhauMoi);

            // Assert
            Assert.Equal(DoiMatKhauMessage.Failed, result);
        }
        #endregion

        #region ThemTaiKhoan
        [Theory, InlineData("admin1", "ad")]
        public void ThemTaiKhoan_ReturnsSuccessfulMessage(string tenDangNhap, string maNhom)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_ThemTaiKhoan";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMaNhomParameterName = "@MaNhom";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMaNhomParameterName) == maNhom),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.ThemTaiKhoan(tenDangNhap, maNhom);

            // Assert
            Assert.Equal(ThemTaiKhoanMessage.Success, result);
        }

        [Theory, InlineData("admin1", "ad")]
        public void ThemTaiKhoan_ReturnsFailedMessage(string tenDangNhap, string maNhom)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_ThemTaiKhoan";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMaNhomParameterName = "@MaNhom";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMaNhomParameterName) == maNhom),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.ThemTaiKhoan(tenDangNhap, maNhom);

            // Assert
            Assert.Equal(ThemTaiKhoanMessage.Failed, result);
        }
        #endregion

        #region SuaTaiKhoan
        [Theory, InlineData("admin1", "admin2", "ad")]
        public void SuaTaiKhoan_ReturnsSuccessfulMessage(string tenDangNhapBD, string tenDangNhap, string maNhom)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_SuaTaiKhoan";
            var expectedTenDangNhapBDParameterName = "@TenDangNhapBD";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMaNhomParameterName = "@MaNhom";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapBDParameterName) == tenDangNhapBD &&
                            p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMaNhomParameterName) == maNhom),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.SuaTaiKhoan(tenDangNhapBD, tenDangNhap, maNhom);

            // Assert
            Assert.Equal(SuaTaiKhoanMessage.Success, result);
        }

        [Theory, InlineData("admin1", "admin2", "ad")]
        public void SuaTaiKhoan_ReturnsFailedMessage(string tenDangNhapBD, string tenDangNhap, string maNhom)
        {
            // Arrange
            var expectedQuery = "spNGUOIDUNG_SuaTaiKhoan";
            var expectedTenDangNhapBDParameterName = "@TenDangNhapBD";
            var expectedTenDangNhapParameterName = "@TenDangNhap";
            var expectedMaNhomParameterName = "@MaNhom";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedTenDangNhapBDParameterName) == tenDangNhapBD &&
                            p.Get<string>(expectedTenDangNhapParameterName) == tenDangNhap &&
                            p.Get<string>(expectedMaNhomParameterName) == maNhom),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.SuaTaiKhoan(tenDangNhapBD, tenDangNhap, maNhom);

            // Assert
            Assert.Equal(SuaTaiKhoanMessage.Failed, result);
        }
        #endregion

        #region ThemTaiKhoanSV
        [Fact]
        public void ThemTaiKhoanSV_ReturnsSuccessfulMessage()
        {
            // Arrange
            IList<SinhVien> testSinhVienList = new List<SinhVien>
            {
                new SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    GioiTinh = "Nam",
                    MaHuyen = 1,
                    MaNganh = "KTPM"
                }
            };
            var expectedQuery = "spNGUOIDUNG_ThemTaiKhoanSV";
            var expectedMaSVParameterName = "@MaSV";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => testSinhVienList.First(sv => sv.MaSV == p.Get<string>(expectedMaSVParameterName)) != null),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.ThemTaiKhoanSV(testSinhVienList);

            // Assert
            Assert.Equal(ThemTaiKhoanSVMessage.Success, result);
        }

        [Fact]
        public void ThemTaiKhoanSV_ReturnsFailedMessage()
        {
            // Arrange
            IList<SinhVien> testSinhVienList = new List<SinhVien>
            {
                new SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    GioiTinh = "Nam",
                    MaHuyen = 1,
                    MaNganh = "KTPM"
                }
            };
            var expectedQuery = "spNGUOIDUNG_ThemTaiKhoanSV";
            var expectedMaSVParameterName = "@MaSV";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 0;

            _dapperWrapperMock.Setup(
                _ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => testSinhVienList.First(sv => sv.MaSV == p.Get<string>(expectedMaSVParameterName)) != null),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _nguoiDungDALService.ThemTaiKhoanSV(testSinhVienList);

            // Assert
            Assert.Equal(ThemTaiKhoanSVMessage.Failed, result);
        }
        #endregion
    }
}
