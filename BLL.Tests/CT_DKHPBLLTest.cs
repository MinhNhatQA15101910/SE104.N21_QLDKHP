namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class CT_DKHPBLLTest
    {
        #region Service
        private readonly Mock<ICT_PhieuDKHPDALService> CT_PhieuDKHPDALServiceMock;
        private readonly ICT_PhieuDKHPBLLService _CT_PhieuDKHPBLLService;
        #endregion

        #region Constructor
        public CT_DKHPBLLTest()
        {
            CT_PhieuDKHPDALServiceMock = new Mock<ICT_PhieuDKHPDALService>();
            _CT_PhieuDKHPBLLService = new CT_DKHPBLLService(CT_PhieuDKHPDALServiceMock.Object);
        }
        #endregion

        #region TaoCT_PhieuDKHP
        [Fact]
        public void TaoCT_PhieuDKHP_VerifyExecuteDAL()
        {
            // Arrange
            var ct_phieuDKHP = new CT_PhieuDKHP();

            // Act
            _CT_PhieuDKHPBLLService.TaoCT_PhieuDKHP(ct_phieuDKHP);

            // Assert
            CT_PhieuDKHPDALServiceMock.Verify(_ => _.TaoCT_PhieuDKHP(ct_phieuDKHP), Times.Once());
        }
        #endregion

        #region XoaDSMHDKHP
        [Fact]
        public void XoaDSMHDKHPT_VerifyExecuteDAL()
        {
            // Arrange
            const int maPhieu = 1;

            // Act
            _CT_PhieuDKHPBLLService.XoaDSMHDKHP(maPhieu);

            // Assert
            CT_PhieuDKHPDALServiceMock.Verify(_ => _.XoaDSMHDKHP(maPhieu), Times.Once());
        }
        #endregion
    }
}
