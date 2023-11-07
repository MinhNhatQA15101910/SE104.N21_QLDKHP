namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class KhoaBLLTests
    {
        #region Services
        private readonly IKhoaBLLService _khoaBLLService;
        private readonly Mock<IKhoaDALService> _khoaDALServiceMock;
        private readonly Mock<INganhDALService> _nganhDALServiceMock;
        #endregion

        #region Constructor
        public KhoaBLLTests()
        {
            _khoaDALServiceMock = new Mock<IKhoaDALService>();
            _nganhDALServiceMock = new Mock<INganhDALService>();
            _khoaBLLService = new KhoaBLLService(_khoaDALServiceMock.Object, _nganhDALServiceMock.Object);
        }
        #endregion

        #region LayDSKhoa
        [Fact]
        public void LayDSKhoa_VerifyExecuteDAL()
        {
            // Act
            _khoaBLLService.LayDSKhoa();

            // Assert
            _khoaDALServiceMock.Verify(_ => _.LayDSKhoa(), Times.Once);
        }
        #endregion

        #region SuaKhoa
        [Theory, InlineData("CNPM", "", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithEmptyMaKhoaSua_ReturnsEmptyMaKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.EmptyMaKhoa, result);
        }

        [Theory, InlineData("CNPM", "CNPM1", "")]
        public void SuaKhoa_WithEmptyTenKhoaSua_ReturnsEmptyTenKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.EmptyTenKhoa, result);
        }

        [Theory, InlineData("CNPM", "HTTT", "Công nghệ phần mềm")]
        public void SuaKhoa_WithDuplicateMaKhoaSua_ReturnsDuplicateMaKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Arrange
            var khoas = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                },
                new Khoa
                {
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            _khoaDALServiceMock.Setup(_ => _.LayDSKhoa()).Returns(khoas);

            // Act
            var result = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.DuplicateMaKhoa, result);
        }

        [Theory, InlineData("CNPM", "CNPM1", "Hệ thống thông tin")]
        public void SuaKhoa_WithDuplicateTenKhoaSua_ReturnsDuplicateTenKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Arrange
            var khoas = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                },
                new Khoa
                {
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            _khoaDALServiceMock.Setup(_ => _.LayDSKhoa()).Returns(khoas);

            // Act
            var result = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.DuplicateTenKhoa, result);
        }

        [Theory, InlineData("CNPM", "CNPM1", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithMaKhoaRelativeToNganh_ReturnsUnableMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Arrange
            var khoas = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                },
                new Khoa
                {
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Kỹ thuật phần mềm",
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            _khoaDALServiceMock.Setup(_ => _.LayDSKhoa()).Returns(khoas);
            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            var result = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.Unable, result);
        }

        [Theory, InlineData("CNPM", "CNPM1", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithValidInputs_VerifyExecuteDAL(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Arrange
            var khoas = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                },
                new Khoa
                {
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "HTTT",
                    TenNganh = "Hệ thống thông tin",
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                }
            };

            _khoaDALServiceMock.Setup(_ => _.LayDSKhoa()).Returns(khoas);
            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            _khoaDALServiceMock.Verify(_ => _.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua), Times.Once);
        }
        #endregion

        #region ThemKhoa
        [Theory, InlineData("", "Công nghệ phần mềm 1")]
        public void ThemKhoa_WithEmptyMaKhoa_ReturnsEmptyMaKhoaMessage(string maKhoa, string tenKhoa)
        {
            // Act
            var result = _khoaBLLService.ThemKhoa(maKhoa, tenKhoa);

            // Assert
            Assert.Equal(ThemKhoaMessage.EmptyMaKhoa, result);
        }

        [Theory, InlineData("CNPM1", "")]
        public void ThemKhoa_WithEmptyTenKhoa_ReturnsEmptyTenKhoaMessage(string maKhoa, string tenKhoa)
        {
            // Act
            var result = _khoaBLLService.ThemKhoa(maKhoa, tenKhoa);

            // Assert
            Assert.Equal(ThemKhoaMessage.EmptyTenKhoa, result);
        }

        [Theory, InlineData("HTTT", "Công nghệ phần mềm 1")]
        public void ThemKhoa_WithDuplicateMaKhoa_ReturnsDuplicateMaKhoaMessage(string maKhoa, string tenKhoa)
        {
            // Arrange
            var khoas = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                },
                new Khoa
                {
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            _khoaDALServiceMock.Setup(_ => _.LayDSKhoa()).Returns(khoas);

            // Act
            var result = _khoaBLLService.ThemKhoa(maKhoa, tenKhoa);

            // Assert
            Assert.Equal(ThemKhoaMessage.DuplicateMaKhoa, result);
        }

        [Theory, InlineData("CNPM1", "Hệ thống thông tin")]
        public void ThemKhoa_WithDuplicateTenKhoa_ReturnsDuplicateTenKhoaMessage(string maKhoa, string tenKhoa)
        {
            // Arrange
            var khoas = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                },
                new Khoa
                {
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            _khoaDALServiceMock.Setup(_ => _.LayDSKhoa()).Returns(khoas);

            // Act
            var result = _khoaBLLService.ThemKhoa(maKhoa, tenKhoa);

            // Assert
            Assert.Equal(ThemKhoaMessage.DuplicateTenKhoa, result);
        }

        [Theory, InlineData("CNPM1", "Công nghệ phần mềm 1")]
        public void ThemKhoa_WithValidInputs_VerifyExecuteDAL(string maKhoa, string tenKhoa)
        {
            // Arrange
            var khoas = new List<Khoa>
            {
                new Khoa
                {
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                },
                new Khoa
                {
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            _khoaDALServiceMock.Setup(_ => _.LayDSKhoa()).Returns(khoas);

            // Act
            _khoaBLLService.ThemKhoa(maKhoa, tenKhoa);

            // Assert
            _khoaDALServiceMock.Verify(_ => _.ThemKhoa(maKhoa, tenKhoa), Times.Once);
        }
        #endregion

        #region XoaKhoa
        [Theory, InlineData("CNPM")]
        public void XoaKhoa_WithMaKhoaRelativeToNganh_ReturnsUnableMessage(string maKhoa)
        {
            // Arrange
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Kỹ thuật phần mềm",
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            var result = _khoaBLLService.XoaKhoa(maKhoa);

            // Assert
            Assert.Equal(XoaKhoaMessage.Unable, result);
        }

        [Theory, InlineData("CNPM")]
        public void XoaKhoa_WithValidInputs_VerifyExecuteDAL(string maKhoa)
        {
            // Arrange
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "HTTT",
                    TenNganh = "Hệ thống thông tin",
                    MaKhoa = "HTTT",
                    TenKhoa = "Hệ thống thông tin"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            _khoaBLLService.XoaKhoa(maKhoa);

            // Assert
            _khoaDALServiceMock.Verify(_ => _.XoaKhoa(maKhoa), Times.Once);
        }
        #endregion
    }
}
