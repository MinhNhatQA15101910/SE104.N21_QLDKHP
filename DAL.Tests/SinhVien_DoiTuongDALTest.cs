namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class SinhVien_DoiTuongDALTest
    {
        #region Services
        private readonly ISinhVien_DoiTuongDALService _sinhVien_DoiTuongDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public SinhVien_DoiTuongDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _sinhVien_DoiTuongDALService = new SinhVien_DoiTuongDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region GetSinhVien_DoiTuongs
        [Fact]
        public void GetSinhVien_DoiTuongs_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spSINHVIEN_DOITUONG_GetSinhVien_DoiTuongs";
            var expectedResult = new List<SinhVien_DoiTuong>
            {
                new SinhVien_DoiTuong
                {
                    MaDT = 1,
                    MaSV = "SV21522415"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<SinhVien_DoiTuong>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _sinhVien_DoiTuongDALService.GetSinhVien_DoiTuongs();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
