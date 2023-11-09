namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class HocKyBLLTest
    {
        #region Service
        private readonly Mock<IHocKyDALService> _hocKyDALServiceMock;
        private readonly IHocKyBLLService _hocKyBLLService;
        #endregion

        #region Constructor
        public HocKyBLLTest()
        {
            _hocKyDALServiceMock = new Mock<IHocKyDALService>();
            _hocKyBLLService = new HocKyBLLService(_hocKyDALServiceMock.Object);
        }
        #endregion

        #region LayDanhSachHK
        [Fact]
        public void LayDanhSachHK_VerifyExecuteDAL()
        {
            // Act
            _hocKyBLLService.LayDanhSachHK();

            // Assert
            _hocKyDALServiceMock.Verify(x => x.LayDanhSachHK(), Times.Once);
        }
        #endregion

        #region LayHKByMaHK
        [Fact]
        public void LayHKByMaHK_VerifyExecuteDAL()
        {
            // Act
            _hocKyBLLService.LayHKByMaHK(It.IsAny<int>());

            // Assert
            _hocKyDALServiceMock.Verify(x => x.LayHKByMaHK(It.IsAny<int>()), Times.Once);
        }
        #endregion
    }
}
