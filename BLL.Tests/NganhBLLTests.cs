using BLL.IServices;
using BLL.Services;
using DAL.IServices;
using DTO;
using Moq;

namespace BLL.Tests
{
    public class NganhBLLTests
    {
        private readonly INganhBLLService _nganhBLLService;
        private readonly Mock<INganhDALService> _nganhDALServiceMock;

        public NganhBLLTests()
        {
            _nganhDALServiceMock = new Mock<INganhDALService>();
            _nganhBLLService = new NganhBLLService(_nganhDALServiceMock.Object);
        }

        #region LayDSNganh
        [Fact]
        public void LayDSNganh_ReturnsCTNganhList()
        {
            // Arrange

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
        [InlineData("KTPM", "KTPM1", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_WithValidInputs_ReturnsSuccessMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Act
            _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            _nganhDALServiceMock.Verify(d => d.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua), Times.Once);
        }
        #endregion
    }
}
