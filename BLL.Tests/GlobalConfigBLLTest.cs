namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class GlobalConfigBLLTest
    {
        #region Service
        private readonly Mock<IGlobalConfigDALService> _globalConfigDALServiceMock;
        private readonly IGlobalConfigBLLService _globalConfigBLLService;
        #endregion

        #region Constructor
        public GlobalConfigBLLTest()
        {
            _globalConfigDALServiceMock = new Mock<IGlobalConfigDALService>();
            _globalConfigBLLService = new GlobalConfigBLLService(_globalConfigDALServiceMock.Object);
        }
        #endregion

        #region GetCurrNamHoc
        [Fact]
        public void GetCurrNamHoc_VerifyExecuteDAL()
        {
            // Act
            _globalConfigBLLService.GetCurrNamHoc();

            // Assert
            _globalConfigDALServiceMock.Verify(x => x.GetCurrNamHoc(), Times.Once);
        }
        #endregion

        #region GetCurrMaHocKy
        [Fact]
        public void GetCurrMaHocKy_VerifyExecuteDAL()
        {
            // Act
            _globalConfigBLLService.GetCurrMaHocKy(It.IsAny<int>());

            // Assert
            _globalConfigDALServiceMock.Verify(x => x.GetCurrMaHocKy(It.IsAny<int>()), Times.Once);
        }
        #endregion

        #region LaySoTinChiToiDa
        [Fact]
        public void LaySoTinChiToiDa_VerifyExecuteDAL()
        {
            // Act
            _globalConfigBLLService.LaySoTinChiToiDa();

            // Assert
            _globalConfigDALServiceMock.Verify(x => x.LaySoTinChiToiDa(), Times.Once);
        }
        #endregion

        #region LaySoTinChiToiThieu
        [Fact]
        public void LaySoTinChiToiThieu_VerifyExecuteDAL()
        {
            // Act
            _globalConfigBLLService.LaySoTinChiToiThieu();

            // Assert
            _globalConfigDALServiceMock.Verify(x => x.LaySoTinChiToiThieu(), Times.Once);
        }
        #endregion

        #region SuaGioiHanTinChi
        [Theory, InlineData("", "10")]
        public void SuaGioiHanTinChi_WithEmptyTinChiToiDa_ReturnTinChiToiDaRongMessage(string tinChiToiDa, string tinChiToiThieu)
        {
            // Act
            var result = _globalConfigBLLService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            Assert.Equal(SuaGioiHanTinChiMessage.TinChiToiDaRong, result);
        }

        [Theory, InlineData("20", "")]
        public void SuaGioiHanTinChi_WithEmptyTinChiToiThieu_ReturnTinChiToiThieuRongMessage(string tinChiToiDa, string tinChiToiThieu)
        {
            // Act
            var result = _globalConfigBLLService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            Assert.Equal(SuaGioiHanTinChiMessage.TinChiToiThieuRong, result);
        }

        [Theory, InlineData("abc", "10"), InlineData("0", "10")]
        public void SuaGioiHanTinChi_WithInvalidTinChiToiDa_ReturnTinChiToiDaKhongHopLeMessage(string tinChiToiDa, string tinChiToiThieu)
        {
            // Act
            var result = _globalConfigBLLService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            Assert.Equal(SuaGioiHanTinChiMessage.TinChiToiDaKhongHopLe, result);
        }

        [Theory, InlineData("20", "abc"), InlineData("20", "0")]
        public void SuaGioiHanTinChi_WithInvalidTinChiToiThieu_ReturnTinChiToiThieuKhongHopLeMessage(string tinChiToiDa, string tinChiToiThieu)
        {
            // Act
            var result = _globalConfigBLLService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            Assert.Equal(SuaGioiHanTinChiMessage.TinChiToiThieuKhongHopLe, result);
        }

        [Theory, InlineData("20", "20")]
        public void SuaGioiHanTinChi_WithInvalidValue_ReturnUnableMessage(string tinChiToiDa, string tinChiToiThieu)
        {
            // Act
            var result = _globalConfigBLLService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            Assert.Equal(SuaGioiHanTinChiMessage.Unable, result);
        }

        [Theory, InlineData("20", "10")]
        public void SuaGioiHanTinChi_WithValidValue_VerifyExecuteDAL(string tinChiToiDa, string tinChiToiThieu)
        {
            // Act
            _globalConfigBLLService.SuaGioiHanTinChi(tinChiToiDa, tinChiToiThieu);

            // Assert
            _globalConfigDALServiceMock.Verify(x => x.SuaGioiHanTinChi(int.Parse(tinChiToiDa), int.Parse(tinChiToiThieu)), Times.Once);
        }
        #endregion

        #region LayKhoangTGDongHP
        [Fact]
        public void LayKhoangTGDongHP_VerifyExecuteDAL()
        {
            // Act
            _globalConfigBLLService.LayKhoangTGDongHP(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            _globalConfigDALServiceMock.Verify(x => x.LayKhoangTGDongHP(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        #endregion

        #region KhoangTGDongHP
        [Fact]
        public void KhoangTGDongHP_VerifyExecuteDAL()
        {
            // Act
            _globalConfigBLLService.KhoangTGDongHP(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());

            // Assert
            _globalConfigDALServiceMock.Verify(x => x.KhoangTGDongHP(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        #endregion
    }
}
