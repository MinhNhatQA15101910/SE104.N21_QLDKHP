using BLL.IServices;
using BLL.Services;
using DAL.IServices;
using DTO;
using Moq;

namespace BLL.Tests
{
    public class KhoaBLLTests
    {
        private readonly Mock<IKhoaDALService> _khoaDALServiceMock;
        private readonly IKhoaBLLService _khoaBLLService;

        public KhoaBLLTests()
        {
            _khoaDALServiceMock = new Mock<IKhoaDALService>();
            _khoaBLLService = new KhoaBLLService(_khoaDALServiceMock.Object);
        }

        #region LayDSKhoa

        [Fact]
        public void LayDSKhoa_ReturnsKhoaList()
        {
            // Act
            _khoaBLLService.LayDSKhoa();

            // Assert
            _khoaDALServiceMock.Verify(d => d.LayDSKhoa(), Times.Once);
        }
        #endregion

        #region SuaKhoa
        [Theory]
        [InlineData("CNPM", "", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithEmptyMaKhoa_ReturnsEmptyMaKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.IsType<SuaKhoaMessage>(result);
            Assert.Equal(SuaKhoaMessage.EmptyMaKhoa, result);
        }

        [Theory]
        [InlineData("CNPM", "CNPM1", "")]
        public void SuaKhoa_WithEmptyTenKhoa_ReturnsEmptyTenKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.IsType<SuaKhoaMessage>(result);
            Assert.Equal(SuaKhoaMessage.EmptyTenKhoa, result);
        }

        [Theory]
        [InlineData("CNPM", "CNPM1", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithValidInputs_CallsKhoaDAL(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            _khoaDALServiceMock.Verify(d => d.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua), Times.Once);
        }
        #endregion
    }
}