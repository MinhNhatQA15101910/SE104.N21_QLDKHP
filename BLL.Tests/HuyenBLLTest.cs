namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class HuyenBLLTest
    {
        #region Service
        private readonly Mock<IHuyenDALService> _huyenDALServiceMock;
        private readonly Mock<ISinhVienDALService> _sinhVienDALServiceMock;
        private readonly IHuyenBLLService _huyenBLLService;
        #endregion

        #region Constructor
        public HuyenBLLTest()
        {
            _huyenDALServiceMock = new Mock<IHuyenDALService>();
            _sinhVienDALServiceMock = new Mock<ISinhVienDALService>();
            _huyenBLLService = new HuyenBLLService(_huyenDALServiceMock.Object, _sinhVienDALServiceMock.Object);
        }
        #endregion

        #region LayDSHuyen
        [Fact]
        public void LayDSHuyenTest()
        {
            // Act
            _huyenBLLService.LayDSHuyen();
            
            // Assert
            _huyenDALServiceMock.Verify(x => x.LayDSHuyen(), Times.Once);
        }
        #endregion

        #region SuaHuyen
        [Theory, InlineData(1, "", 1, 1)]
        public void SuaHuyen_WithEmptyTenHuyen_ReturnEmptyTenHuyenMessage(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            // Act
            var result = _huyenBLLService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);
            
            // Assert
            Assert.Equal(SuaHuyenMessage.EmptyTenHuyen, result);
        }

        [Theory, InlineData(2, "Huyen 1", 1, 1)]
        public void SuaHuyen_WithDuplicateTenHuyen_ReturnDuplicateTenHuyenMessage(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var ct_Huyens = new List<CT_Huyen>
            {
                new CT_Huyen
                {
                    MaHuyen = 1,
                    TenHuyen = "Huyen 1",
                    MaTinh = 1
                }
            };
            _huyenDALServiceMock.Setup(x => x.LayDSHuyen()).Returns(ct_Huyens);
            
            // Act
            var result = _huyenBLLService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);
            
            // Assert
            Assert.Equal(SuaHuyenMessage.DuplicateTenHuyen, result);
        }

        [Theory, InlineData(2, "Huyen 1", 1, 2)]
        public void SuaHuyen_WithValidInput_VerifyExecuteDAL(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var ct_Huyens = new List<CT_Huyen>
            {
                new CT_Huyen
                {
                    MaHuyen = 1,
                    TenHuyen = "Huyen 1",
                    MaTinh = 1
                }
            };
            _huyenDALServiceMock.Setup(x => x.LayDSHuyen()).Returns(ct_Huyens);

            // Act
            _huyenBLLService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);

            // Assert
            _huyenDALServiceMock.Verify(x => x.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh), Times.Once);
        }
        #endregion

        #region ThemHuyen
        [Theory, InlineData("", 1, 1)]
        public void ThemHuyen_WithEmptyTenHuyen_ReturnEmptyTenHuyenMessage(string tenHuyen, int vungUT, int maTinh)
        {
            // Act
            var result = _huyenBLLService.ThemHuyen(tenHuyen, vungUT, maTinh);
            
            // Assert
            Assert.Equal(ThemHuyenMessage.EmptyTenHuyen, result);
        }

        [Theory, InlineData("Huyen 1", 1, 1)]
        public void ThemHuyen_WithDuplicateTenHuyen_ReturnDuplicateTenHuyenMessage(string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var ct_Huyens = new List<CT_Huyen>
            {
                new CT_Huyen
                {
                    MaHuyen = 1,
                    TenHuyen = "Huyen 1",
                    MaTinh = 1
                }
            };
            _huyenDALServiceMock.Setup(x => x.LayDSHuyen()).Returns(ct_Huyens);
            
            // Act
            var result = _huyenBLLService.ThemHuyen(tenHuyen, vungUT, maTinh);
            
            // Assert
            Assert.Equal(ThemHuyenMessage.DuplicateTenHuyen, result);
        }

        [Theory, InlineData("Huyen 2", 1, 1)]
        public void ThemHuyen_WithValidInput_VerifyExecuteDAL(string tenHuyen, int vungUT, int maTinh)
        {
            // Arrange
            var ct_Huyens = new List<CT_Huyen>
            {
                new CT_Huyen
                {
                    MaHuyen = 1,
                    TenHuyen = "Huyen 1",
                    MaTinh = 1
                }
            };
            _huyenDALServiceMock.Setup(x => x.LayDSHuyen()).Returns(ct_Huyens);
            
            // Act
            _huyenBLLService.ThemHuyen(tenHuyen, vungUT, maTinh);
            
            // Assert
            _huyenDALServiceMock.Verify(x => x.ThemHuyen(tenHuyen, vungUT, maTinh), Times.Once);
        }
        #endregion

        #region XoaHuyen
        [Theory, InlineData(1)]
        public void XoaHuyen_WithUnableToDelete_ReturnUnableToDeleteMessage(int maHuyen)
        {
            // Arrange
            var ct_SinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaHuyen = 1
                }
            };
            _sinhVienDALServiceMock.Setup(x => x.LayDSSV()).Returns(ct_SinhViens);
            
            // Act
            var result = _huyenBLLService.XoaHuyen(maHuyen);
            
            // Assert
            Assert.Equal(XoaHuyenMessage.Unable, result);
        }

        [Theory, InlineData(1)]
        public void XoaHuyen_WithValidInput_VerifyExecuteDAL(int maHuyen)
        {
            // Arrange
            var ct_SinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaHuyen = 2
                }
            };
            _sinhVienDALServiceMock.Setup(x => x.LayDSSV()).Returns(ct_SinhViens);
            
            // Act
            _huyenBLLService.XoaHuyen(maHuyen);
            
            // Assert
            _huyenDALServiceMock.Verify(x => x.XoaHuyen(maHuyen), Times.Once);
        }
        #endregion
    }
}
