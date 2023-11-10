namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class DoiTuongBLLTest
    {
        #region Service
        private readonly Mock<IDoiTuongDALService> _doiTuongDALServiceMock;
        private readonly Mock<ISinhVien_DoiTuongDALService> _doiTuong_SinhVienDALServiceMock;
        private readonly IDoiTuongBLLService _doiTuongBLLService;
        #endregion

        #region Constructor
        public DoiTuongBLLTest()
        {
            _doiTuongDALServiceMock = new Mock<IDoiTuongDALService>();
            _doiTuong_SinhVienDALServiceMock = new Mock<ISinhVien_DoiTuongDALService>();
            _doiTuongBLLService = new DoiTuongBLLService(_doiTuongDALServiceMock.Object, _doiTuong_SinhVienDALServiceMock.Object);
        }
        #endregion

        #region LayDSDoiTuong
        [Fact]
        public void LayDSDoiTuong_VerifyExecuteDAL()
        {
            // Act
            _doiTuongBLLService.LayDSDoiTuong();

            // Assert
            _doiTuongDALServiceMock.Verify(_ => _.LayDSDoiTuong(), Times.Once);
        }
        #endregion

        #region SuaDoiTuong
        [Theory, InlineData (1, "", "0.5")]
        public void SuaDoiTuong_EmptyTenDoiTuong_ReturnEmptyTenDoiTuongMessage(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            // Act
            var result = _doiTuongBLLService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            Assert.Equal(SuaDoiTuongMessage.EmptyTenDoiTuong, result);
        }

        [Theory, InlineData(1, "Không thuộc đối tượng ưu tiên", "")]
        public void SuaDoiTuong_EmptyTiLeGiam_ReturnEmptyTiLeGiamMessage(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            // Act
            var result = _doiTuongBLLService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            Assert.Equal(SuaDoiTuongMessage.EmptyTiLeGiam, result);
        }

        [Theory, InlineData(1, "Không thuộc đối tượng ưu tiên", "abc"), InlineData(1, "Không thuộc đối tượng ưu tiên", "1,1"), InlineData(1, "Không thuộc đối tượng ưu tiên", "0"), InlineData(1, "Không thuộc đối tượng ưu tiên", "-1")]
        public void SuaDoiTuong_InvalidTiLeGiam_ReturnTiLeGiamKhongHopLeMessage(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            // Act
            var result = _doiTuongBLLService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            Assert.Equal(SuaDoiTuongMessage.TiLeGiamKhongHopLe, result);
        }

        [Theory, InlineData(2, "Không thuộc đối tượng ưu tiên", "1")]
        public void SuaDoiTuong_Unable_ReturnUnableMessage(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            // Act
            var result = _doiTuongBLLService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            Assert.Equal(SuaDoiTuongMessage.Unable, result);
        }

        [Theory , InlineData(1, "Đối tượng 1", "0.5")]
        public void SuaDoiTuong_DuplicateTenDoiTuong_ReturnDuplicateTenDoiTuongMessage(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            // Arrange
            var doiTuongList = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 2,
                    TenDT = "Đối tượng 1",
                    TiLeGiamHocPhi = 0
                }
            };
            _doiTuongDALServiceMock.Setup(_ => _.LayDSDoiTuong()).Returns(doiTuongList);

            // Act
            var result = _doiTuongBLLService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            Assert.Equal(SuaDoiTuongMessage.DuplicateTenDoiTuong, result);
        }

        [Theory, InlineData(1, "Đối tượng ưu tiên mới", "0.5")]
        public void SuaDoiTuong_WithValidInput_VerifyExecuteDAL(int maDTBanDau, string tenDT, string tiLeGiam)
        {
            // Arrange
            var doiTuongList = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 2,
                    TenDT = "Không thuộc đối tượng ưu tiên",
                    TiLeGiamHocPhi = 0
                }
            };
            _doiTuongDALServiceMock.Setup(_ => _.LayDSDoiTuong()).Returns(doiTuongList);

            // Act
            _doiTuongBLLService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);

            // Assert
            _doiTuongDALServiceMock.Verify(_ => _.SuaDoiTuong(maDTBanDau, tenDT, float.Parse(tiLeGiam)), Times.Once);
        }
        #endregion

        #region ThemDoiTuong
        [Theory, InlineData("", "0.5")]
        public void ThemDoiTuong_EmptyTenDoiTuong_ReturnEmptyTenDoiTuongMessage(string tenDT, string tiLeGiam)
        {
            // Act
            var result = _doiTuongBLLService.ThemDoiTuong(tenDT, tiLeGiam);

            // Assert
            Assert.Equal(ThemDoiTuongMessage.EmptyTenDoiTuong, result);
        }

        [Theory, InlineData("Đối tượng mới", "")]
        public void ThemDoiTuong_EmptyTiLeGiam_ReturnEmptyTiLeGiamMessage(string tenDT, string tiLeGiam)
        {
            // Act
            var result = _doiTuongBLLService.ThemDoiTuong(tenDT, tiLeGiam);

            // Assert
            Assert.Equal(ThemDoiTuongMessage.EmptyTiLeGiam, result);
        }

        [Theory, InlineData("Đối tượng mới", "abc"), InlineData("Đối tượng mới", "1.1"), InlineData("Đối tượng mới", "0"), InlineData("Đối tượng mới", "-1")]
        public void ThemDoiTuong_InvalidTiLeGiam_ReturnTiLeGiamKhongHopLeMessage(string tenDT, string tiLeGiam)
        {
            // Act
            var result = _doiTuongBLLService.ThemDoiTuong(tenDT, tiLeGiam);

            // Assert
            Assert.Equal(ThemDoiTuongMessage.TiLeGiamKhongHopLe, result);
        }

        [Theory, InlineData("Đối tượng 1", "1")]
        public void ThemDoiTuong_DuplicateTenDoiTuong_ReturnDuplicateTenDoiTuongMessage(string tenDT, string tiLeGiam)
        {
            // Arrange
            var doiTuongList = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 1,
                    TenDT = "Đối tượng 1",
                    TiLeGiamHocPhi = 0
                }
            };
            _doiTuongDALServiceMock.Setup(_ => _.LayDSDoiTuong()).Returns(doiTuongList);

            // Act
            var result = _doiTuongBLLService.ThemDoiTuong(tenDT, tiLeGiam);

            // Assert
            Assert.Equal(ThemDoiTuongMessage.DuplicateTenDoiTuong, result);
        }

        [Theory, InlineData("Đối tượng mới", "0.5")]
        public void ThemDoiTuong_WithValidInput_VerifyExecuteDAL(string tenDT, string tiLeGiam)
        {
            // Arrange
            var doiTuongList = new List<DoiTuong>
            {
                new DoiTuong
                {
                    MaDT = 1,
                    TenDT = "Đối tượng 1",
                    TiLeGiamHocPhi = 0
                }
            };
            _doiTuongDALServiceMock.Setup(_ => _.LayDSDoiTuong()).Returns(doiTuongList);

            // Act
            _doiTuongBLLService.ThemDoiTuong(tenDT, tiLeGiam);

            // Assert
            _doiTuongDALServiceMock.Verify(_ => _.ThemDoiTuong(tenDT, float.Parse(tiLeGiam)), Times.Once);
        }
        #endregion

        #region XoaDoiTuong
        [Theory, InlineData(2)]
        public void XoaDoiTuong_WithMaDT2_ReturnUnableMessage(int maDT)
        {
            // Act
            var result = _doiTuongBLLService.XoaDoiTuong(maDT);

            // Assert
            Assert.Equal(XoaDoiTuongMessage.UnableToDeleteVungSauVungXa, result);
        }

        [Theory, InlineData(1)]
        public void XoaDoiTuong_nrelatedMaDT_ReturnUnableMessage(int maDT)
        {
            // Arrange
            var doiTuong_SinhVienList = new List<SinhVien_DoiTuong>
            {
                new SinhVien_DoiTuong
                {
                    MaSV = "1",
                    MaDT = 1
                }
            };
            _doiTuong_SinhVienDALServiceMock.Setup(_ => _.GetSinhVien_DoiTuongs()).Returns(doiTuong_SinhVienList);

            // Act
            var result = _doiTuongBLLService.XoaDoiTuong(maDT);

            // Assert
            Assert.Equal(XoaDoiTuongMessage.Unable, result);
        }

        [Theory, InlineData(1)]
        public void XoaDoiTuong_WithValidInput_VerifyExecuteDAL(int maDT)
        {
            // Arrange
            var doiTuong_SinhVienList = new List<SinhVien_DoiTuong>
            {
                new SinhVien_DoiTuong
                {
                    MaSV = "1",
                    MaDT = 2
                }
            };
            _doiTuong_SinhVienDALServiceMock.Setup(_ => _.GetSinhVien_DoiTuongs()).Returns(doiTuong_SinhVienList);
            // Act
            _doiTuongBLLService.XoaDoiTuong(maDT);

            // Assert
            _doiTuongDALServiceMock.Verify(_ => _.XoaDoiTuong(maDT), Times.Once);
        }
        #endregion

        #region LayDSDoiTuongBangMaSV
        [Theory, InlineData("1")]
        public void LayDSDoiTuongBangMaSV_VerifyExecuteDAL(string maSV)
        {
            // Act
            _doiTuongBLLService.LayDSDoiTuongBangMaSV(maSV);

            // Assert
            _doiTuongDALServiceMock.Verify(_ => _.LayDSDoiTuongBangMaSV(maSV), Times.Once);
        }
        #endregion

        #region LayDSDoiTuongKhongThuocVeMaSV
        [Theory, InlineData("1")]
        public void LayDSDoiTuongKhongThuocVeMaSV_VerifyExecuteDAL(string maSV)
        {
            // Act
            _doiTuongBLLService.LayDSDoiTuongKhongThuocVeMaSV(maSV);

            // Assert
            _doiTuongDALServiceMock.Verify(_ => _.LayDSDoiTuongKhongThuocVeMaSV(maSV), Times.Once);
        }
        #endregion

        #region LayDSDoiTuong2
        [Fact]
        public void LayDSDoiTuong2_VerifyExecuteDAL()
        {
            // Act
            _doiTuongBLLService.LayDSDoiTuong2();

            // Assert
            _doiTuongDALServiceMock.Verify(_ => _.LayDSDoiTuong2(), Times.Once);
        }
        #endregion
    }
}
