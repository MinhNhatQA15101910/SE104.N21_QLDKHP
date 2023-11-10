namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class LoaiMonHocBLLTest
    {
        #region Service
        private readonly Mock<ILoaiMonHocDALService> _loaiMonHocDALServiceMock;
        private readonly Mock<IMonHocDALService> _monHocDALServiceMock;
        private readonly ILoaiMonHocBLLService _loaiMonHocBLLService;
        #endregion

        #region Constructor
        public LoaiMonHocBLLTest()
        {
            _loaiMonHocDALServiceMock = new Mock<ILoaiMonHocDALService>();
            _monHocDALServiceMock = new Mock<IMonHocDALService>();
            _loaiMonHocBLLService = new LoaiMonHocBLLService(_loaiMonHocDALServiceMock.Object, _monHocDALServiceMock.Object);
        }
        #endregion

        #region LayDSLoaiMonHoc
        [Fact]
        public void LayDSLoaiMonHocTest()
        {
            // Act
            _loaiMonHocBLLService.LayDSLoaiMonHoc();
            
            // Assert
            _loaiMonHocDALServiceMock.Verify(x => x.LayDSLoaiMonHoc(), Times.Once);
        }
        #endregion

        #region XoaLoaiMonHoc
        [Theory, InlineData(1)]
        public void XoaLoaiMonHoc_WithUnable_ReturnUnableMessage(int maLoaiMonHoc)
        {
            // Arrange
            var ct_MonHocs = new List<CT_MonHoc>
            {
                new CT_MonHoc
                {
                    MaLoaiMonHoc = 1
                },
                
            };
            _monHocDALServiceMock.Setup(x => x.LayDSMonHoc()).Returns(ct_MonHocs);
            
            // Act
            var result = _loaiMonHocBLLService.XoaLoaiMonHoc(maLoaiMonHoc);
            
            // Assert
            Assert.Equal(XoaLoaiMonHocMessage.Unable, result);
        }

        [Theory, InlineData(1)]
        public void XoaLoaiMonHoc_WithValidInput_VerifyExecuteDAL(int maLoaiMonHoc)
        {
            // Arrange
            var ct_MonHocs = new List<CT_MonHoc>
            {
                new CT_MonHoc
                {
                    MaLoaiMonHoc = 2
                },

            };
            _monHocDALServiceMock.Setup(x => x.LayDSMonHoc()).Returns(ct_MonHocs);

            // Act
            _loaiMonHocBLLService.XoaLoaiMonHoc(maLoaiMonHoc);

            // Assert
            _loaiMonHocDALServiceMock.Verify(x => x.XoaLoaiMonHoc(maLoaiMonHoc), Times.Once);
        }
        #endregion

        #region SuaLoaiMonHoc
        [Theory, InlineData(1, "", "10", "100000")]
        public void SuaLoaiMonHoc_WithEmptyTenLoaiMonHoc_ReturnEmptyTenLoaiMonHocMessage(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.EmptyTenLoaiMonHoc, result);
        }

        [Theory, InlineData(1, "Loai mon hoc 1", "", "100000")]
        public void SuaLoaiMonHoc_WithEmptySoTiet_ReturnEmptySoTietMessage(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.EmptySoTiet, result);
        }

        [Theory, InlineData(1, "Loai mon hoc 1", "10", "")]
        public void SuaLoaiMonHoc_WithEmptySoTien_ReturnEmptySoTienMessage(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.EmptySoTien, result);
        }

        [Theory, InlineData(1, "Loai mon hoc 1", "abc", "100000"), InlineData(1, "Loai mon hoc 1", "-1", "100000")]
        public void SuaLoaiMonHoc_WithInvalidSoTiet_ReturnSoTietKhongHopLeMessage(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.SoTietKhongHopLe, result);
        }

        [Theory, InlineData(1, "Loai mon hoc 1", "0", "abc"), InlineData(1, "Loai mon hoc 1", "10", "-1")]
        public void SuaLoaiMonHoc_WithInvalidSoTien_ReturnSoTienKhongHopLeMessage(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.SoTienKhongHopLe, result);
        }

        [Theory, InlineData(2, "Loai mon hoc 1", "10", "0")]
        public void SuaLoaiMonHoc_WithDuplicateTenLoaiMonHoc_ReturnDuplicateTenLoaiMonHocMessage(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Arrange
            var loaiMonHocs = new List<LoaiMonHoc>
            {
                new LoaiMonHoc
                {
                    MaLoaiMonHoc = 1,
                    TenLoaiMonHoc = "Loai mon hoc 1"
                },
                
            };
            _loaiMonHocDALServiceMock.Setup(x => x.LayDSLoaiMonHoc()).Returns(loaiMonHocs);
            
            // Act
            var result = _loaiMonHocBLLService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(SuaLoaiMonHocMessage.DuplicateTenLoaiMonHoc, result);
        }

        [Theory, InlineData(2, "Loai mon hoc 2", "10", "100000")]
        public void SuaLoaiMonHoc_WithValidInput_VerifyExecuteDAL(int maLoaiMonHoc, string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Arrange
            var loaiMonHocs = new List<LoaiMonHoc>
            {
                new LoaiMonHoc
                {
                    MaLoaiMonHoc = 1,
                    TenLoaiMonHoc = "Loai mon hoc 1"
                }
            };
            _loaiMonHocDALServiceMock.Setup(x => x.LayDSLoaiMonHoc()).Returns(loaiMonHocs);

            // Act
            _loaiMonHocBLLService.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);

            // Assert
            _loaiMonHocDALServiceMock.Verify(x => x.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, int.Parse(soTiet), decimal.Parse(soTien)), Times.Once);
        }
        #endregion

        #region ThemLoaiMonHoc
        [Theory, InlineData("", "10", "100000")]
        public void ThemLoaiMonHoc_WithEmptyTenLoaiMonHoc_ReturnEmptyTenLoaiMonHocMessage(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.EmptyTenLoaiMonHoc, result);
        }

        [Theory, InlineData("Loai mon hoc 1", "", "100000")]
        public void ThemLoaiMonHoc_WithEmptySoTiet_ReturnEmptySoTietMessage(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.EmptySoTiet, result);
        }

        [Theory, InlineData("Loai mon hoc 1", "10", "")]
        public void ThemLoaiMonHoc_WithEmptySoTien_ReturnEmptySoTienMessage(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.EmptySoTien, result);
        }

        [Theory, InlineData("Loai mon hoc 1", "abc", "100000"), InlineData("Loai mon hoc 1", "-1", "100000")]
        public void ThemLoaiMonHoc_WithInvalidSoTiet_ReturnSoTietKhongHopLeMessage(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.SoTietKhongHopLe, result);
        }

        [Theory, InlineData("Loai mon hoc 1", "10", "abc"), InlineData("Loai mon hoc 1", "10", "-1")]
        public void ThemLoaiMonHoc_WithInvalidSoTien_ReturnSoTienKhongHopLeMessage(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Act
            var result = _loaiMonHocBLLService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.SoTienKhongHopLe, result);
        }

        [Theory, InlineData("Loai mon hoc 1", "0", "0")]
        public void ThemLoaiMonHoc_WithDuplicateTenLoaiMonHoc_ReturnDuplicateTenLoaiMonHocMessage(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Arrange
            var loaiMonHocs = new List<LoaiMonHoc>
            {
                new LoaiMonHoc
                {
                    TenLoaiMonHoc = "Loai mon hoc 1"
                },
                
            };
            _loaiMonHocDALServiceMock.Setup(x => x.LayDSLoaiMonHoc()).Returns(loaiMonHocs);
            
            // Act
            var result = _loaiMonHocBLLService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);
            
            // Assert
            Assert.Equal(ThemLoaiMonHocMessage.DuplicateTenLoaiMonHoc, result);
        }

        [Theory, InlineData("Loai mon hoc 2", "10", "100000")]
        public void ThemLoaiMonHoc_WithValidInput_VerifyExecuteDAL(string tenLoaiMonHoc, string soTiet, string soTien)
        {
            // Arrange
            var loaiMonHocs = new List<LoaiMonHoc>
            {
                new LoaiMonHoc
                {
                    TenLoaiMonHoc = "Loai mon hoc 1"
                }
            };
            _loaiMonHocDALServiceMock.Setup(x => x.LayDSLoaiMonHoc()).Returns(loaiMonHocs);

            // Act
            _loaiMonHocBLLService.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);

            // Assert
            _loaiMonHocDALServiceMock.Verify(x => x.ThemLoaiMonHoc(tenLoaiMonHoc, It.IsAny<int>(), It.IsAny<decimal>()), Times.Once);
        }
        #endregion
    }
}
