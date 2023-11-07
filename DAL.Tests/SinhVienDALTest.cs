namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class SinhVienDALTest
    {
        #region Services
        private readonly ISinhVienDALService _sinhVienDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public SinhVienDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _sinhVienDALService = new SinhVienDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSSVChuaCoTK
        [Fact]
        public void LayDSSVChuaCoTK_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spSINHVIEN_LayDSSVChuaCoTK";
            var expectedResult = new List<SinhVien>
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

            _dapperWrapperMock.Setup(
                _ => _.Query<SinhVien>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _sinhVienDALService.LayDSSVChuaCoTK();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayDSSV
        [Fact]
        public void LayDSSV_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spSINHVIEN_LayDSSV";
            var expectedResult = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    GioiTinh = "Nam",
                    MaHuyen = 1,
                    TenHuyen = "Huyen Go Cong Tay",
                    MaNganh = "KTPM",
                    TenNganh = "Ky thuat phan mem",
                    MaTinh = 1,
                    TenTTP = "Tinh Tien Giang"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<CT_SinhVien>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _sinhVienDALService.LayDSSV();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region SuaSinhVien
        [Fact]
        public void SuaSinhVien_ReturnsSuccessfulMessage()
        {
            // Arrange
            var testMssvBanDau = "SV21522415";
            var testMssv = "SV21522416";
            var testHoTen = "Do Minh Nhat";
            var testNgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc);
            var testGioiTinh = "Nam";
            var testMaHuyen = 1;
            var testMaNganh = "KTPM";
            var testMaDTList = new List<int> { 1, 2, 3 };

            var expectedQuery1 = "spSINHVIEN_SuaSinhVien";
            var expectedQuery2 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery3 = "spSINHVIEN_DOITUONG_Them";

            var expectedMaSVParameterKey = "@MaSV";
            var expectedHoTenParameterKey = "@HoTen";
            var expectedNgaySinhParameterKey = "@NgaySinh";
            var expectedGioiTinhParameterKey = "@GioiTinh";
            var expectedMaHuyenParameterKey = "@MaHuyen";
            var expectedMaNganhParameterKey = "@MaNganh";
            var expectedMaDTParameterKey = "@MaDT";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 1;
            var expectedResult3 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau &&
                            p.Get<string>(expectedHoTenParameterKey) == testHoTen &&
                            p.Get<DateTime>(expectedNgaySinhParameterKey) == testNgaySinh &&
                            p.Get<string>(expectedGioiTinhParameterKey) == testGioiTinh &&
                            p.Get<int>(expectedMaHuyenParameterKey) == testMaHuyen &&
                            p.Get<string>(expectedMaNganhParameterKey) == testMaNganh),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            testMaDTList.Contains(p.Get<int>(expectedMaDTParameterKey))),
                    expectedCommandType))
                .Returns(expectedResult3);

            // Act
            var result = _sinhVienDALService.SuaSinhVien(testMssvBanDau, testMssv, testHoTen, testNgaySinh, testGioiTinh, testMaHuyen, testMaNganh, testMaDTList);

            // Assert
            Assert.Equal(SuaSinhVienMessage.Success, result);
        }

        [Fact]
        public void SuaSinhVien_ReturnsFailedMessage1()
        {
            // Arrange
            var testMssvBanDau = "SV21522415";
            var testMssv = "SV21522416";
            var testHoTen = "Do Minh Nhat";
            var testNgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc);
            var testGioiTinh = "Nam";
            var testMaHuyen = 1;
            var testMaNganh = "KTPM";
            var testMaDTList = new List<int> { 1, 2, 3 };

            var expectedQuery1 = "spSINHVIEN_SuaSinhVien";
            var expectedQuery2 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery3 = "spSINHVIEN_DOITUONG_Them";

            var expectedMaSVParameterKey = "@MaSV";
            var expectedHoTenParameterKey = "@HoTen";
            var expectedNgaySinhParameterKey = "@NgaySinh";
            var expectedGioiTinhParameterKey = "@GioiTinh";
            var expectedMaHuyenParameterKey = "@MaHuyen";
            var expectedMaNganhParameterKey = "@MaNganh";
            var expectedMaDTParameterKey = "@MaDT";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 0;
            var expectedResult2 = 1;
            var expectedResult3 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau &&
                            p.Get<string>(expectedHoTenParameterKey) == testHoTen &&
                            p.Get<DateTime>(expectedNgaySinhParameterKey) == testNgaySinh &&
                            p.Get<string>(expectedGioiTinhParameterKey) == testGioiTinh &&
                            p.Get<int>(expectedMaHuyenParameterKey) == testMaHuyen &&
                            p.Get<string>(expectedMaNganhParameterKey) == testMaNganh),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            testMaDTList.Contains(p.Get<int>(expectedMaDTParameterKey))),
                    expectedCommandType))
                .Returns(expectedResult3);

            // Act
            var result = _sinhVienDALService.SuaSinhVien(testMssvBanDau, testMssv, testHoTen, testNgaySinh, testGioiTinh, testMaHuyen, testMaNganh, testMaDTList);

            // Assert
            Assert.Equal(SuaSinhVienMessage.Failed, result);
        }

        [Fact]
        public void SuaSinhVien_ReturnsFailedMessage2()
        {
            // Arrange
            var testMssvBanDau = "SV21522415";
            var testMssv = "SV21522416";
            var testHoTen = "Do Minh Nhat";
            var testNgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc);
            var testGioiTinh = "Nam";
            var testMaHuyen = 1;
            var testMaNganh = "KTPM";
            var testMaDTList = new List<int> { 1, 2, 3 };

            var expectedQuery1 = "spSINHVIEN_SuaSinhVien";
            var expectedQuery2 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery3 = "spSINHVIEN_DOITUONG_Them";

            var expectedMaSVParameterKey = "@MaSV";
            var expectedHoTenParameterKey = "@HoTen";
            var expectedNgaySinhParameterKey = "@NgaySinh";
            var expectedGioiTinhParameterKey = "@GioiTinh";
            var expectedMaHuyenParameterKey = "@MaHuyen";
            var expectedMaNganhParameterKey = "@MaNganh";
            var expectedMaDTParameterKey = "@MaDT";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 0;
            var expectedResult3 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau &&
                            p.Get<string>(expectedHoTenParameterKey) == testHoTen &&
                            p.Get<DateTime>(expectedNgaySinhParameterKey) == testNgaySinh &&
                            p.Get<string>(expectedGioiTinhParameterKey) == testGioiTinh &&
                            p.Get<int>(expectedMaHuyenParameterKey) == testMaHuyen &&
                            p.Get<string>(expectedMaNganhParameterKey) == testMaNganh),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            testMaDTList.Contains(p.Get<int>(expectedMaDTParameterKey))),
                    expectedCommandType))
                .Returns(expectedResult3);

            // Act
            var result = _sinhVienDALService.SuaSinhVien(testMssvBanDau, testMssv, testHoTen, testNgaySinh, testGioiTinh, testMaHuyen, testMaNganh, testMaDTList);

            // Assert
            Assert.Equal(SuaSinhVienMessage.Failed, result);
        }

        [Fact]
        public void SuaSinhVien_ReturnsFailedMessage3()
        {
            // Arrange
            var testMssvBanDau = "SV21522415";
            var testMssv = "SV21522416";
            var testHoTen = "Do Minh Nhat";
            var testNgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc);
            var testGioiTinh = "Nam";
            var testMaHuyen = 1;
            var testMaNganh = "KTPM";
            var testMaDTList = new List<int> { 1, 2, 3 };

            var expectedQuery1 = "spSINHVIEN_SuaSinhVien";
            var expectedQuery2 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery3 = "spSINHVIEN_DOITUONG_Them";

            var expectedMaSVParameterKey = "@MaSV";
            var expectedHoTenParameterKey = "@HoTen";
            var expectedNgaySinhParameterKey = "@NgaySinh";
            var expectedGioiTinhParameterKey = "@GioiTinh";
            var expectedMaHuyenParameterKey = "@MaHuyen";
            var expectedMaNganhParameterKey = "@MaNganh";
            var expectedMaDTParameterKey = "@MaDT";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 1;
            var expectedResult3 = 0;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau &&
                            p.Get<string>(expectedHoTenParameterKey) == testHoTen &&
                            p.Get<DateTime>(expectedNgaySinhParameterKey) == testNgaySinh &&
                            p.Get<string>(expectedGioiTinhParameterKey) == testGioiTinh &&
                            p.Get<int>(expectedMaHuyenParameterKey) == testMaHuyen &&
                            p.Get<string>(expectedMaNganhParameterKey) == testMaNganh),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssvBanDau),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            testMaDTList.Contains(p.Get<int>(expectedMaDTParameterKey))),
                    expectedCommandType))
                .Returns(expectedResult3);

            // Act
            var result = _sinhVienDALService.SuaSinhVien(testMssvBanDau, testMssv, testHoTen, testNgaySinh, testGioiTinh, testMaHuyen, testMaNganh, testMaDTList);

            // Assert
            Assert.Equal(SuaSinhVienMessage.Failed, result);
        }
        #endregion

        #region ThemSinhVien
        [Fact]
        public void ThemSinhVien_ReturnsSuccessfulMessage()
        {
            // Arrange
            var testMssv = "SV21522415";
            var testHoTen = "Do Minh Nhat";
            var testNgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc);
            var testGioiTinh = "Nam";
            var testMaHuyen = 1;
            var testMaNganh = "KTPM";
            var testMaDTList = new List<int> { 1, 2, 3 };

            var expectedQuery1 = "spSINHVIEN_ThemSinhVien";
            var expectedQuery2 = "spSINHVIEN_DOITUONG_Them";

            var expectedMaSVParameterKey = "@MaSV";
            var expectedHoTenParameterKey = "@HoTen";
            var expectedNgaySinhParameterKey = "@NgaySinh";
            var expectedGioiTinhParameterKey = "@GioiTinh";
            var expectedMaHuyenParameterKey = "@MaHuyen";
            var expectedMaNganhParameterKey = "@MaNganh";
            var expectedMaDTParameterKey = "@MaDT";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            p.Get<string>(expectedHoTenParameterKey) == testHoTen &&
                            p.Get<DateTime>(expectedNgaySinhParameterKey) == testNgaySinh &&
                            p.Get<string>(expectedGioiTinhParameterKey) == testGioiTinh &&
                            p.Get<int>(expectedMaHuyenParameterKey) == testMaHuyen &&
                            p.Get<string>(expectedMaNganhParameterKey) == testMaNganh),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            testMaDTList.Contains(p.Get<int>(expectedMaDTParameterKey))),
                    expectedCommandType))
                .Returns(expectedResult2);

            // Act
            var result = _sinhVienDALService.ThemSinhVien(testMssv, testHoTen, testNgaySinh, testGioiTinh, testMaHuyen, testMaNganh, testMaDTList);

            // Assert
            Assert.Equal(ThemSinhVienMessage.Success, result);
        }

        [Fact]
        public void ThemSinhVien_ReturnsFailedMessage1()
        {
            // Arrange
            var testMssv = "SV21522415";
            var testHoTen = "Do Minh Nhat";
            var testNgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc);
            var testGioiTinh = "Nam";
            var testMaHuyen = 1;
            var testMaNganh = "KTPM";
            var testMaDTList = new List<int> { 1, 2, 3 };

            var expectedQuery1 = "spSINHVIEN_ThemSinhVien";
            var expectedQuery2 = "spSINHVIEN_DOITUONG_Them";

            var expectedMaSVParameterKey = "@MaSV";
            var expectedHoTenParameterKey = "@HoTen";
            var expectedNgaySinhParameterKey = "@NgaySinh";
            var expectedGioiTinhParameterKey = "@GioiTinh";
            var expectedMaHuyenParameterKey = "@MaHuyen";
            var expectedMaNganhParameterKey = "@MaNganh";
            var expectedMaDTParameterKey = "@MaDT";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 0;
            var expectedResult2 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            p.Get<string>(expectedHoTenParameterKey) == testHoTen &&
                            p.Get<DateTime>(expectedNgaySinhParameterKey) == testNgaySinh &&
                            p.Get<string>(expectedGioiTinhParameterKey) == testGioiTinh &&
                            p.Get<int>(expectedMaHuyenParameterKey) == testMaHuyen &&
                            p.Get<string>(expectedMaNganhParameterKey) == testMaNganh),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            testMaDTList.Contains(p.Get<int>(expectedMaDTParameterKey))),
                    expectedCommandType))
                .Returns(expectedResult2);

            // Act
            var result = _sinhVienDALService.ThemSinhVien(testMssv, testHoTen, testNgaySinh, testGioiTinh, testMaHuyen, testMaNganh, testMaDTList);

            // Assert
            Assert.Equal(ThemSinhVienMessage.Failed, result);
        }

        [Fact]
        public void ThemSinhVien_ReturnsFailedMessage2()
        {
            // Arrange
            var testMssv = "SV21522415";
            var testHoTen = "Do Minh Nhat";
            var testNgaySinh = new DateTime(2003, 10, 19, 0, 0, 0, DateTimeKind.Utc);
            var testGioiTinh = "Nam";
            var testMaHuyen = 1;
            var testMaNganh = "KTPM";
            var testMaDTList = new List<int> { 1, 2, 3 };

            var expectedQuery1 = "spSINHVIEN_ThemSinhVien";
            var expectedQuery2 = "spSINHVIEN_DOITUONG_Them";

            var expectedMaSVParameterKey = "@MaSV";
            var expectedHoTenParameterKey = "@HoTen";
            var expectedNgaySinhParameterKey = "@NgaySinh";
            var expectedGioiTinhParameterKey = "@GioiTinh";
            var expectedMaHuyenParameterKey = "@MaHuyen";
            var expectedMaNganhParameterKey = "@MaNganh";
            var expectedMaDTParameterKey = "@MaDT";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 0;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            p.Get<string>(expectedHoTenParameterKey) == testHoTen &&
                            p.Get<DateTime>(expectedNgaySinhParameterKey) == testNgaySinh &&
                            p.Get<string>(expectedGioiTinhParameterKey) == testGioiTinh &&
                            p.Get<int>(expectedMaHuyenParameterKey) == testMaHuyen &&
                            p.Get<string>(expectedMaNganhParameterKey) == testMaNganh),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv &&
                            testMaDTList.Contains(p.Get<int>(expectedMaDTParameterKey))),
                    expectedCommandType))
                .Returns(expectedResult2);

            // Act
            var result = _sinhVienDALService.ThemSinhVien(testMssv, testHoTen, testNgaySinh, testGioiTinh, testMaHuyen, testMaNganh, testMaDTList);

            // Assert
            Assert.Equal(ThemSinhVienMessage.Failed, result);
        }
        #endregion

        #region XoaSinhVien
        [Fact]
        public void XoaSinhVien_ReturnsSuccessfulMessage()
        {
            // Arrange
            var testMssv = "SV21522415";

            var expectedQuery1 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery2 = "spCT_PHIEUDKHP_XoaSinhVien";
            var expectedQuery3 = "spPHIEUTHUHP_XoaSinhVien";
            var expectedQuery4 = "spPHIEUDKHP_XoaSinhVien";
            var expectedQuery5 = "spSINHVIEN_XoaSinhVien";

            var expectedMaSVParameterKey = "@MaSV";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 1;
            var expectedResult3 = 1;
            var expectedResult4 = 1;
            var expectedResult5 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult3);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery4,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult4);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery5,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult5);

            // Act
            var result = _sinhVienDALService.XoaSinhVien(testMssv);

            // Assert
            Assert.Equal(XoaSinhVienMessage.Success, result);
        }

        [Fact]
        public void XoaSinhVien_ReturnsFailedMessage1()
        {
            // Arrange
            var testMssv = "SV21522415";

            var expectedQuery1 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery2 = "spCT_PHIEUDKHP_XoaSinhVien";
            var expectedQuery3 = "spPHIEUTHUHP_XoaSinhVien";
            var expectedQuery4 = "spPHIEUDKHP_XoaSinhVien";
            var expectedQuery5 = "spSINHVIEN_XoaSinhVien";

            var expectedMaSVParameterKey = "@MaSV";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 0;
            var expectedResult2 = 1;
            var expectedResult3 = 1;
            var expectedResult4 = 1;
            var expectedResult5 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult3);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery4,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult4);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery5,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult5);

            // Act
            var result = _sinhVienDALService.XoaSinhVien(testMssv);

            // Assert
            Assert.Equal(XoaSinhVienMessage.Failed, result);
        }

        [Fact]
        public void XoaSinhVien_ReturnsFailedMessage2()
        {
            // Arrange
            var testMssv = "SV21522415";

            var expectedQuery1 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery2 = "spCT_PHIEUDKHP_XoaSinhVien";
            var expectedQuery3 = "spPHIEUTHUHP_XoaSinhVien";
            var expectedQuery4 = "spPHIEUDKHP_XoaSinhVien";
            var expectedQuery5 = "spSINHVIEN_XoaSinhVien";

            var expectedMaSVParameterKey = "@MaSV";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 0;
            var expectedResult3 = 1;
            var expectedResult4 = 1;
            var expectedResult5 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult3);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery4,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult4);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery5,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult5);

            // Act
            var result = _sinhVienDALService.XoaSinhVien(testMssv);

            // Assert
            Assert.Equal(XoaSinhVienMessage.Failed, result);
        }

        [Fact]
        public void XoaSinhVien_ReturnsFailedMessage3()
        {
            // Arrange
            var testMssv = "SV21522415";

            var expectedQuery1 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery2 = "spCT_PHIEUDKHP_XoaSinhVien";
            var expectedQuery3 = "spPHIEUTHUHP_XoaSinhVien";
            var expectedQuery4 = "spPHIEUDKHP_XoaSinhVien";
            var expectedQuery5 = "spSINHVIEN_XoaSinhVien";

            var expectedMaSVParameterKey = "@MaSV";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 1;
            var expectedResult3 = 0;
            var expectedResult4 = 1;
            var expectedResult5 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult3);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery4,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult4);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery5,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult5);

            // Act
            var result = _sinhVienDALService.XoaSinhVien(testMssv);

            // Assert
            Assert.Equal(XoaSinhVienMessage.Failed, result);
        }

        [Fact]
        public void XoaSinhVien_ReturnsFailedMessage4()
        {
            // Arrange
            var testMssv = "SV21522415";

            var expectedQuery1 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery2 = "spCT_PHIEUDKHP_XoaSinhVien";
            var expectedQuery3 = "spPHIEUTHUHP_XoaSinhVien";
            var expectedQuery4 = "spPHIEUDKHP_XoaSinhVien";
            var expectedQuery5 = "spSINHVIEN_XoaSinhVien";

            var expectedMaSVParameterKey = "@MaSV";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 1;
            var expectedResult3 = 1;
            var expectedResult4 = 0;
            var expectedResult5 = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult3);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery4,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult4);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery5,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult5);

            // Act
            var result = _sinhVienDALService.XoaSinhVien(testMssv);

            // Assert
            Assert.Equal(XoaSinhVienMessage.Failed, result);
        }

        [Fact]
        public void XoaSinhVien_ReturnsFailedMessage5()
        {
            // Arrange
            var testMssv = "SV21522415";

            var expectedQuery1 = "spSINHVIEN_DOITUONG_XoaSinhVien";
            var expectedQuery2 = "spCT_PHIEUDKHP_XoaSinhVien";
            var expectedQuery3 = "spPHIEUTHUHP_XoaSinhVien";
            var expectedQuery4 = "spPHIEUDKHP_XoaSinhVien";
            var expectedQuery5 = "spSINHVIEN_XoaSinhVien";

            var expectedMaSVParameterKey = "@MaSV";

            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult1 = 1;
            var expectedResult2 = 1;
            var expectedResult3 = 1;
            var expectedResult4 = 1;
            var expectedResult5 = 0;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery1,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult1);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery2,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult2);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery3,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult3);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery4,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult4);

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery5,
                    It.Is<DynamicParameters>(
                        p => p.Get<string>(expectedMaSVParameterKey) == testMssv),
                    expectedCommandType))
                .Returns(expectedResult5);

            // Act
            var result = _sinhVienDALService.XoaSinhVien(testMssv);

            // Assert
            Assert.Equal(XoaSinhVienMessage.Failed, result);
        }
        #endregion

        #region LayTenSV
        [Theory, InlineData("SV21522415")]
        public void LayTenSV_VerifyQueryData(string mssv)
        {
            // Arrange
            var expectedQuery = "spSINHVIEN_LayTenSV";
            var expectedResult = "Do Minh Nhat";
            var expectedMssvParameterKey = "@mssv";
            var expectedCommandType = CommandType.StoredProcedure;

            _dapperWrapperMock.Setup(
                _ => _.QueryFirstOrDefault<string>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<string>(expectedMssvParameterKey) == mssv),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _sinhVienDALService.LayTenSV(mssv);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region LayThongTinSV
        [Theory, InlineData("SV21522415")]
        public void LayThongTinSV_VerifyQueryData(string mssv)
        {
            // Arrange
            var expectedQuery = "spSINHVIEN_LayThongTinSV";
            var expectedMssvParameterKey = "@mssv";
            var expectedResult = new List<dynamic>
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
            var expectedCommandType = CommandType.StoredProcedure;

            _dapperWrapperMock.Setup(
                _ => _.Query<dynamic>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(p => p.Get<string>(expectedMssvParameterKey) == mssv),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _sinhVienDALService.LayThongTinSV(mssv);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region BaoCaoSinhVienChuaDongHocPhi
        [Theory, InlineData(1, 2023)]
        public void BaoCaoSinhVienChuaDongHocPhi_VerifyQueryData(int hocKy, int namHoc)
        {
            // Arrange
            var expectedQuery = "spSINHVIEN_BaoCao";
            var expectedHocKyParameterKey = "@hocKy";
            var expectedNamHocParameterKey = "@namHoc";
            var expectedResult = new List<dynamic>
            {
                new
                {
                    MaSV = "SV21522415",
                    SoTienDangKy = 12000000,
                    SoTienPhaiDong = 12000000,
                    SoTienDaDong = 10000000,
                    SoTienConLai = 2000000
                }
            };
            var expectedCommandType = CommandType.StoredProcedure;

            _dapperWrapperMock.Setup(
                _ => _.Query<dynamic>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedHocKyParameterKey) == hocKy &&
                            p.Get<int>(expectedNamHocParameterKey) == namHoc),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _sinhVienDALService.BaoCaoSinhVienChuaDongHocPhi(hocKy, namHoc);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
