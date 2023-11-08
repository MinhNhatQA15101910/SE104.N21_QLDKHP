namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class ChuongTrinhHocBLLTest
    {
        #region Service
        private readonly Mock<IChuongTrinhHocDALService> _chuongTrinhHocDALServiceMock;
        private readonly IChuongTrinhHocBLLService _chuongTrinhHocBLLService;
        #endregion

        #region Constructor
        public ChuongTrinhHocBLLTest()
        {
            _chuongTrinhHocDALServiceMock = new Mock<IChuongTrinhHocDALService>();
            _chuongTrinhHocBLLService = new ChuongTrinhHocBLLService(_chuongTrinhHocDALServiceMock.Object);
        }
        #endregion

        #region DeleteListCTHoc
        [Fact]
        public void DeleteListCTHoc_VerifyExecuteDAL()
        {
            // Arrange
            string maNganh = "CNTT";
            int hocKy = 1;

            // Act
            _chuongTrinhHocBLLService.DeleteListCTHoc(maNganh, hocKy);

            // Assert
            _chuongTrinhHocDALServiceMock.Verify(m => m.DeleteListCTHoc(maNganh, hocKy), Times.Once);
        }
        #endregion

        #region GetAllCTHoc
        [Fact]
        public void GetAllCTHoc_VerifyExecuteDAL()
        {
            //Act
            _chuongTrinhHocBLLService.GetAllCTHoc();

            // Assert
            _chuongTrinhHocDALServiceMock.Verify(_ => _.GetAllCTHoc(), Times.Once);
        }
        #endregion

        #region AddCTHoc
        [Fact]
        public void AddCTHoc_VerifyExecuteDAL()
        {
            // Arrange
            var chuongTrinhHoc = new ChuongTrinhHoc()
            {
                MaMH = "IE005",
                MaNganh = "CNTT",
                HocKy = 1,
            };

            // Act
            _chuongTrinhHocBLLService.AddCTHoc(chuongTrinhHoc);

            // Assert
            _chuongTrinhHocDALServiceMock.Verify(m => m.AddCTHoc(chuongTrinhHoc), Times.Once);
        }
        #endregion

        #region DeleteCTHoc
        [Fact]
        public void DeleteCTHoc_VerifyExecuteDAL()
        {
            // Arrange
            string maMH = "IE005";
            string maNganh = "CNTT";
            int hocKy = 1;

            // Act
            _chuongTrinhHocBLLService.DeleteCTHoc(maMH, maNganh, hocKy);

            // Assert
            _chuongTrinhHocDALServiceMock.Verify(m => m.DeleteCTHoc(maMH, maNganh, hocKy), Times.Once);
        }
        #endregion

    }
}
