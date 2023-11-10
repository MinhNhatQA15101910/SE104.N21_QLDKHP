namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class NhomNguoiDungDALTest
    {
        #region Services
        private readonly INhomNguoiDungDALService _nhomNguoiDungDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public NhomNguoiDungDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _nhomNguoiDungDALService = new NhomNguoiDungDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region LayDSNhomNguoiDung
        [Fact]
        public void LayDSNguoiDung_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spNHOMNGUOIDUNG_LayDSNhomNguoiDung";
            var expectedResult = new List<NhomNguoiDung>
            {
                new NhomNguoiDung
                {
                    MaNhom = "ad",
                    TenNhom = "Admin"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<NhomNguoiDung>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _nhomNguoiDungDALService.LayDSNhomNguoiDung();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
