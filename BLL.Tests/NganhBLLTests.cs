using BLL.IServices;
using BLL.Services;
using DAL.IServices;
using DTO;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
    public class NganhBLLTests
    {
        private readonly INganhBLLService _nganhBLLService;
        private readonly Mock<INganhDALService> _nganhDALServiceMock;
        private readonly Mock<ISinhVienDALService> _sinhVienDALServiceMock;
        private readonly Mock<IChuongTrinhHocDALService> _chuongTrinhHocDALServiceMock;

        public NganhBLLTests()
        {
            _nganhDALServiceMock = new Mock<INganhDALService>();
            _sinhVienDALServiceMock = new Mock<ISinhVienDALService>();
            _chuongTrinhHocDALServiceMock = new Mock<IChuongTrinhHocDALService>();
            _nganhBLLService = new NganhBLLService(_nganhDALServiceMock.Object, _sinhVienDALServiceMock.Object, _chuongTrinhHocDALServiceMock.Object);
        }

        #region LayDSNganh
        [Fact]
        public void LayDSNganh_ReturnsCTNganhList()
        {
            // Act
            _nganhBLLService.LayDSNganh();

            // Assert
            _nganhDALServiceMock.Verify(d => d.LayDSNganh(), Times.Once);
        }
        #endregion

        #region SuaNganh
        [Theory]
        [InlineData("KTPM", "", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithEmptyMaNganhSua_ReturnsEmptyMaNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.EmptyMaNganh, result);
        }

        [Theory]
        [InlineData("KTPM", "KTPM1", "", "CNPM")]
        public void SuaNganh_WithEmptyTenNganhSua_ReturnsEmptyTenNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.EmptyTenNganh, result);
        }

        [Theory]
        [InlineData("KTPM", "HTTT", "Kỹ thuật phần mềm", "CNPM")]
        public void SuaNganh_WithDuplicateMaNganhSua_ReturnsDuplicateMaNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "HTTT"
                },
            };
            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.DuplicateMaNganh, result);
        }

        [Theory]
        [InlineData("KTPM", "KTPM", "Hệ thống thông tin", "CNPM")]
        public void SuaNganh_WithDuplicateTenNganhSua_ReturnsDuplicateTenNganhMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    TenNganh = "Hệ thống thông tin"
                }
            };
            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);

            // Act
            var result = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.DuplicateTenNganh, result);
        }

        [Theory]
        [InlineData("KTPM", "KTPM1", "Kỹ thuật phần mềm 1", "CNPM")]
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
                    MaNganh = "KTPM"
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

        [Theory]
        [InlineData("KTPM", "KTPM1", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithMaNganhRelativeToChuongTrinhHoc_ReturnsUnableForChuongTrinhHocMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaNganh = "HTTT"
                }
            };

            var chuongTrinhHocs = new List<ChuongTrinhHoc>
            {
                new ChuongTrinhHoc
                {
                    MaNganh = "KTPM"
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

        [Theory]
        [InlineData("KTPM", "KTPM", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithValidInputs_ReturnsSuccessfulMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var sinhViens = new List<CT_SinhVien>
            {
                new CT_SinhVien
                {
                    MaNganh = "HTTT"
                }
            };

            var chuongTrinhHocs = new List<ChuongTrinhHoc>
            {
                new ChuongTrinhHoc
                {
                    MaNganh = "KTMT"
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
                    MaNganh = "KTMT"
                }
            };

            _nganhDALServiceMock.Setup(_ => _.LayDSNganh()).Returns(nganhs);
            _sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhViens);
            _chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongTrinhHocs);

            // Act
            _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            _nganhDALServiceMock.Verify(d => d.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua), Times.Once);
        }

        #endregion
    }
}
