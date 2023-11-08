namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class DanhSachMonHocMoBLLTest
    {
        #region Service
        private readonly IDanhSachMonHocMoBLLService _danhSachMonHocMoBLLService;
        private readonly Mock<IDanhSachMonHocMoDALService> _danhSachMonHocMoDALServiceMock;
        #endregion

        #region Constructor
        public DanhSachMonHocMoBLLTest()
        {
            _danhSachMonHocMoDALServiceMock = new Mock<IDanhSachMonHocMoDALService>();
            _danhSachMonHocMoBLLService = new DanhSachMonHocMoBLLService(_danhSachMonHocMoDALServiceMock.Object);
        }
        #endregion

        #region LayDanhSachMonHocMo
        [Fact]
        public void LayDanhSachMonHocMo_VerifyExecuteDAL()
        {
            // Arrange
            var expected = new List<dynamic>();
            _danhSachMonHocMoDALServiceMock.Setup(x => x.LayDanhSachMonHocMo(It.IsAny<int>(), It.IsAny<int>())).Returns(expected);

            // Act
            var result = _danhSachMonHocMoBLLService.LayDanhSachMonHocMo(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region TimKiemDanhSachMonHocMo
        [Fact]
        public void TimKiemDanhSachMonHocMo_VerifyExecuteDAL()
        {
            // Arrange
            var expected = new List<dynamic>();
            _danhSachMonHocMoDALServiceMock.Setup(x => x.TimKiemDanhSachMonHocMo(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(expected);

            // Act
            var result = _danhSachMonHocMoBLLService.TimKiemDanhSachMonHocMo(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>());

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion
    }
}
