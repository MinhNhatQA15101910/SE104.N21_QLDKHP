using DAL.IServices;
using DAL.Services;
using DTO;

namespace DAL.Tests
{
    public class KhoaDALTests
    {
        private readonly IKhoaDALService _khoaDALService;

        public KhoaDALTests()
        {
            _khoaDALService = new KhoaDALService(new DapperService(), @"Data Source=(local);Database=QuanLyDangKyHP;Trusted_Connection=True;");
        }

        [Fact]
        public void LayDSKhoa_ReturnsListOfKhoa()
        {
            // Act
            var result = _khoaDALService.LayDSKhoa();

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("CNPM", "HTTT", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithValidInputs_ReturnsDuplicateMaKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.DuplicateMaKhoa, result);
        }

        [Theory]
        [InlineData("CNPM", "CNPM1", "Hệ thống thông tin")]
        public void SuaKhoa_WithValidInputs_ReturnsDuplicateTenKhoaMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.DuplicateTenKhoa, result);
        }

        [Theory]
        [InlineData("CNPM", "CNPM1", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithValidInputs_ReturnsErrorMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.Error, result);
        }

        [Theory]
        [InlineData("CNPM", "CNPM", "Công nghệ phần mềm 1")]
        public void SuaKhoa_WithValidInputs_ReturnsSuccessMessage(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            // Act
            var result = _khoaDALService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);

            // Assert
            Assert.Equal(SuaKhoaMessage.Success, result);
        }
    }
}