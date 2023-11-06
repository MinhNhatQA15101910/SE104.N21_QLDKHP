namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class NganhBLLTests
    {
        #region Services
        private readonly INganhBLLService _nganhBLLService;
        private readonly Mock<INganhDALService> _nganhDALServiceMock;
        private readonly Mock<ISinhVienDALService> _sinhVienDALServiceMock;
        private readonly Mock<IChuongTrinhHocDALService> _chuongTrinhHocDALServiceMock;
        #endregion

        #region Constructor
        public NganhBLLTests()
        {
            _nganhDALServiceMock = new Mock<INganhDALService>();
            _sinhVienDALServiceMock = new Mock<ISinhVienDALService>();
            _chuongTrinhHocDALServiceMock = new Mock<IChuongTrinhHocDALService>();
            _nganhBLLService = new NganhBLLService(_nganhDALServiceMock.Object, _sinhVienDALServiceMock.Object, _chuongTrinhHocDALServiceMock.Object);
        }
        #endregion

        #region LayDSNganh
        [Fact]
        public void LayDSNganh_ReturnsCTNganhList()
        {
            // Act
            _nganhBLLService.LayDSNganh();

            // Assert
            _nganhDALServiceMock.Verify(_ => _.LayDSNganh(), Times.Once);
        }
        #endregion

        #region SuaNganh
        [Theory, InlineData("KTPM", "", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithEmptyMaNganhSua_ReturnsEmptyMaNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.EmptyMaNganh, result);
        }

        [Theory, InlineData("KTPM", "KTPM1", "", "CNPM")]
        public void SuaNganh_WithEmptyTenNganhSua_ReturnsEmptyTenNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.EmptyTenNganh, result);
        }

        [Theory, InlineData("KTPM", "HTTT", "Kỹ thuật phần mềm", "CNPM")]
        public void SuaNganh_WithDuplicateMaNganhSua_ReturnsDuplicateMaNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
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
                },
            };
            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.DuplicateMaNganh, result);
        }

        [Theory, InlineData("KTPM", "KTPM", "Hệ thống thông tin", "CNPM")]
        public void SuaNganh_WithDuplicateTenNganhSua_ReturnsDuplicateTenNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
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
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.DuplicateTenNganh, result);
        }

        [Theory, InlineData("KTPM", "KTPM1", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithMaNganhRelativeToSinhVien_ReturnsUnableForSinhVienMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
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
                },
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Kỹ thuật phần mềm",
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                },
            };

            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19),
                    GioiTinh = "Nam",
                    MaHuyen = 100,
                    MaNganh = "KTPM",
                    TenHuyen = "Huyện Gò Công Tây",
                    VungUT = 1,
                    MaTinh = 10,
                    TenTTP = "Tien Giang",
                    TenNganh = "Ky thuat phan mem",
                    MaKhoa = "CNPM",
                    TenKhoa = "Cong nghe phan mem"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);
            _sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhViens);

            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.UnableForSinhVien, result);
        }

        [Theory, InlineData("KTPM", "KTPM1", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithMaNganhRelativeToChuongTrinhHoc_ReturnsUnableForChuongTrinhHocMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19),
                    GioiTinh = "Nam",
                    MaHuyen = 100,
                    MaNganh = "HTTT",
                    TenHuyen = "Huyện Gò Công Tây",
                    VungUT = 1,
                    MaTinh = 10,
                    TenTTP = "Tien Giang",
                    TenNganh = "He thong thong tin",
                    MaKhoa = "HTTT",
                    TenKhoa = "He thong thong tin"
                }
            };

            var chuongTrinhHocs = new List<ChuongTrinhHoc>
            {
                new ChuongTrinhHoc
                {
                    MaNganh = "KTPM",
                    MaMH = "IT001",
                    HocKy = 1
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
                },
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Kỹ thuật phần mềm",
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                },
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);
            _sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhViens);
            _chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongTrinhHocs);

            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.UnableForChuongTrinhHoc, result);
        }

        [Theory, InlineData("KTPM", "KTPM1", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithValidInputs_ReturnsSuccessfulMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19),
                    GioiTinh = "Nam",
                    MaHuyen = 100,
                    MaNganh = "HTTT",
                    TenHuyen = "Huyện Gò Công Tây",
                    VungUT = 1,
                    MaTinh = 10,
                    TenTTP = "Tien Giang",
                    TenNganh = "He thong thong tin",
                    MaKhoa = "HTTT",
                    TenKhoa = "He thong thong tin"
                }
            };

            var chuongTrinhHocs = new List<ChuongTrinhHoc>
            {
                new ChuongTrinhHoc
                {
                    MaNganh = "KTMT",
                    MaMH = "IT001",
                    HocKy = 1
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
                },
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Kỹ thuật phần mềm",
                    MaKhoa = "CNPM",
                    TenKhoa = "Công nghệ phần mềm"
                },
                new CT_Nganh
                {
                    MaNganh = "KTMT",
                    TenNganh = "Ky thuat may tinh",
                    MaKhoa = "KTMT",
                    TenKhoa = "Ky thuat may tinh"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);
            _sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhViens);
            _chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongTrinhHocs);

            // Act
            _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            _nganhDALServiceMock.Verify(_ => _.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua), Times.Once);
        }
        #endregion

        #region ThemNganh
        [Theory, InlineData("", "Kỹ Thuật Phần Mềm 1", "CNPM")]
        public void ThemNganh_WithEmptyMaNganh_ReturnEmptyMaNganhMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Act
            var result = _nganhBLLService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            Assert.IsType<ThemNganhMessage>(result);
            Assert.Equal(ThemNganhMessage.EmptyMaNganh, result);
        }

        [Theory, InlineData("KTPM1", "", "CNPM")]
        public void ThemNganh_WithEmptyTenNganh_ReturnEmptyTenNganhMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Act
            var result = _nganhBLLService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            Assert.IsType<ThemNganhMessage>(result);
            Assert.Equal(ThemNganhMessage.EmptyTenNganh, result);
        }

        [Theory, InlineData("KTPM", "Kỹ Thuật Phần Mềm 1", "CNPM")]
        public void ThemNganh_WithDuplicateMaNganh_ReturnDuplicateMaNganhMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Arrange
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Ky thuat phan mem",
                    MaKhoa = "CNPM",
                    TenKhoa = "Cong nghe phan mem"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            var result = _nganhBLLService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            Assert.IsType<ThemNganhMessage>(result);
            Assert.Equal(ThemNganhMessage.DuplicateMaNganh, result);
        }

        [Theory, InlineData("KTPM1", "Ky thuat phan mem", "CNPM")]
        public void ThemNganh_WithDuplicateTenNganh_ReturnDuplicateTenNganhMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Arrange
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Ky thuat phan mem",
                    MaKhoa = "CNPM",
                    TenKhoa = "Cong nghe phan mem"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            var result = _nganhBLLService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            Assert.IsType<ThemNganhMessage>(result);
            Assert.Equal(ThemNganhMessage.DuplicateTenNganh, result);
        }

        [Theory, InlineData("KTPM1", "Kỹ Thuật Phần Mềm 1", "CNPM")]
        public void ThemNganh_WithValidInputs_ReturnSuccessfulMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Arrange
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "KTPM",
                    TenNganh = "Ky thuat phan mem",
                    MaKhoa = "CNPM",
                    TenKhoa = "Cong nghe phan mem"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            _nganhBLLService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            _nganhDALServiceMock.Verify(_ => _.ThemNganh(maNganh, tenNganh, maKhoa), Times.Once);
        }
        #endregion

        #region XoaNganh
        [Theory, InlineData("HTTT")]
        public void XoaNganh_WithMaNganhRelativeToSinhVien_ReturnsUnableForSinhVienMessage(string maNganh)
        {
            // Arrange
            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19),
                    GioiTinh = "Nam",
                    MaHuyen = 100,
                    MaNganh = "HTTT",
                    TenHuyen = "Huyện Gò Công Tây",
                    VungUT = 1,
                    MaTinh = 10,
                    TenTTP = "Tien Giang",
                    TenNganh = "He thong thong tin",
                    MaKhoa = "HTTT",
                    TenKhoa = "He thong thong tin"
                }
            };

            _sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhViens);

            // Act
            var result = _nganhBLLService.XoaNganh(maNganh);

            // Assert
            Assert.IsType<XoaNganhMessage>(result);
            Assert.Equal(XoaNganhMessage.UnableForSinhVien, result);
        }

        [Theory, InlineData("KTPM")]
        public void XoaNganh_WithMaNganhRelativeToChuongTrinhHoc_ReturnsUnableForChuongTrinhHocMessage(string maNganh)
        {
            // Arrange
            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19),
                    GioiTinh = "Nam",
                    MaHuyen = 100,
                    MaNganh = "HTTT",
                    TenHuyen = "Huyện Gò Công Tây",
                    VungUT = 1,
                    MaTinh = 10,
                    TenTTP = "Tien Giang",
                    TenNganh = "He thong thong tin",
                    MaKhoa = "HTTT",
                    TenKhoa = "He thong thong tin"
                }
            };

            var chuongTrinhHocs = new List<ChuongTrinhHoc>
            {
                new ChuongTrinhHoc
                {
                    MaNganh = "KTPM",
                    MaMH = "IT001",
                    HocKy = 1
                }
            };

            _sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhViens);
            _chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongTrinhHocs);

            // Act
            var result = _nganhBLLService.XoaNganh(maNganh);

            // Assert
            Assert.IsType<XoaNganhMessage>(result);
            Assert.Equal(XoaNganhMessage.UnableForChuongTrinhHoc, result);
        }

        [Theory, InlineData("KTMT")]
        public void XoaNganh_WithValidInputs_VerifyExecuteDAL(string maNganh)
        {
            // Arrange
            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaSV = "SV21522415",
                    HoTen = "Do Minh Nhat",
                    NgaySinh = new DateTime(2003, 10, 19),
                    GioiTinh = "Nam",
                    MaHuyen = 100,
                    MaNganh = "HTTT",
                    TenHuyen = "Huyện Gò Công Tây",
                    VungUT = 1,
                    MaTinh = 10,
                    TenTTP = "Tien Giang",
                    TenNganh = "He thong thong tin",
                    MaKhoa = "HTTT",
                    TenKhoa = "He thong thong tin"
                }
            };

            var chuongTrinhHocs = new List<ChuongTrinhHoc>
            {
                new ChuongTrinhHoc
                {
                    MaNganh = "KTPM",
                    MaMH = "IT001",
                    HocKy = 1
                }
            };

            _sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhViens);
            _chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongTrinhHocs);

            // Act
            _nganhBLLService.XoaNganh(maNganh);

            // Assert
            _nganhDALServiceMock.Verify(_ => _.XoaNganh(maNganh), Times.Once);
        }
        #endregion

        #region GetNganh
        [Theory, InlineData("KTPM")]
        public void GetNganh_WithValidInputs_VerifyExecuteDAL(string maNganh)
        {
            // Act
            _nganhBLLService.GetNganh(maNganh);

            // Assert
            _nganhDALServiceMock.Verify(_ => _.GetNganh(maNganh), Times.Once);
        }
        #endregion
    }
}
