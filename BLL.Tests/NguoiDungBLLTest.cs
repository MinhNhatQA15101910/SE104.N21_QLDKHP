using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
	[ExcludeFromCodeCoverage]
	public class NguoiDungBLLTest
	{
		#region Services
		private readonly INguoiDungBLLService _nguoiDungBLLService;
		private readonly Mock<INguoiDungDALService> _nguoiDungDALServiceMock;
		#endregion

		#region Constructor
		public NguoiDungBLLTest()
		{
			_nguoiDungDALServiceMock = new Mock<INguoiDungDALService>();
			_nguoiDungBLLService = new NguoiDungBLLService(_nguoiDungDALServiceMock.Object);
		}
		#endregion

		#region LayDSNguoiDung
		[Fact]
		public void LayDSNguoiDung_VerifyExecuteDAL()
		{
			// Act
			_nguoiDungBLLService.LayDSNguoiDung();

			// Assert
			_nguoiDungDALServiceMock.Verify(_ => _.LayDSNguoiDung(), Times.Once);
		}
		#endregion

		#region DangNhap
		[Theory, InlineData("","12345678")]
		public void DangNhap_WithEmptyTenDangNhap_ReturnsEmptyTenDangNhapMessage(string tendangnhap, string matkhau)
		{
			// Act
			var result = _nguoiDungBLLService.DangNhap(tendangnhap, matkhau);

			// Assert
			Assert.Equal(DangNhapMessage.EmptyTenDangNhap, result);
		}

		[Theory, InlineData("username", "")]
		public void DangNhap_WithEmptyMatKhau_ReturnsEmptyMatKhauMessage(string tendangnhap, string matkhau)
		{
			// Act
			var result = _nguoiDungBLLService.DangNhap(tendangnhap, matkhau);

			// Assert
			Assert.Equal(DangNhapMessage.EmptyMatKhau, result);
		}

		[Theory, InlineData("username", "12345678")]
		public void DangNhap_WithValidInputs_VerifyExecuteDA(string tendangnhap, string matkhau)
		{
			// Arrange
			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="user"
				}
			};
			_nguoiDungDALServiceMock.Setup(_ => _.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.DangNhap(tendangnhap, matkhau);

			// Assert
			_nguoiDungDALServiceMock.Verify(_ => _.DangNhap(tendangnhap, matkhau), Times.Once);
		}
		#endregion

		#region XoaTaiKhoan
		[Theory, InlineData("username")]
		public void XoaTaiKhoan_WithTenDangNhapRelateToCurrNguoiDung_ReturnsUnableForXoaTaiKhoanMessage(string tendangnhap)
		{
			// Arrange
			GlobalConfig.CurrNguoiDung.TenDangNhap = "username";

			// Act
			var result = _nguoiDungBLLService.XoaTaiKhoan(tendangnhap);

			// Assert
			Assert.Equal(XoaTaiKhoanMessage.Unable, result);
		}

		[Theory, InlineData("username")]
		public void XoaTaiKhoan_WithValidInputs_VerifyExecuteDAL(string tendangnhap)
		{
			// Arrange
			GlobalConfig.CurrNguoiDung.TenDangNhap = "username1";

			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="User",
				}
			};
			_nguoiDungDALServiceMock.Setup(_=>_.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.XoaTaiKhoan(tendangnhap);

			// Assert
			_nguoiDungDALServiceMock.Verify(_ => _.XoaTaiKhoan(tendangnhap), Times.Once);
		}
		#endregion

		#region DoiMatKhau
		[Theory, InlineData("admin1","", "123456789", "123456789")]
		public void DoiMatKhau_WithEmptyMatKhauHT_ReturnsEmptyMatKhauHTMessage(string tenDangNhap, string matkhauht, string matkhaumoi, string matkhaunhaplai)
		{
			// Act
			var result = _nguoiDungBLLService.DoiMatKhau(tenDangNhap, matkhauht, matkhaumoi, matkhaunhaplai);

			// Assert
			Assert.Equal(DoiMatKhauMessage.EmptyMatKhauHT, result);
		}

		[Theory, InlineData("admin1", "12345678", "", "123456789")]
		public void DoiMatKhau_WithEmptyMatKhauMoi_ReturnsEmptyMatKhauMoiMessage(string tendangnhap, string matkhauht, string matkhaumoi, string matkhaunhaplai)
		{
			// Act
			var result = _nguoiDungBLLService.DoiMatKhau(tendangnhap, matkhauht, matkhaumoi, matkhaunhaplai);

			// Assert
			Assert.Equal(DoiMatKhauMessage.EmptyMatKhauMoi, result);
		}

		[Theory, InlineData("admin1", "12345678", "123456789", "")]
		public void DoiMatKhau_WithEmptyMatKhauNhapLai_ReturnsEmptyMatKhauNhapLaiMessage(string tendangnhap, string matkhauht, string matkhaumoi, string matkhaunhaplai)
		{
			// Act
			var result = _nguoiDungBLLService.DoiMatKhau(tendangnhap, matkhauht, matkhaumoi, matkhaunhaplai);

			// Assert
			Assert.Equal(DoiMatKhauMessage.EmptyMatKhauNhapLai, result);
		}

		[Theory, InlineData("admin1", "12345678", "123456789", "1234567")]
		public void DoiMatKhau_WithInvalidNewPassword_ReturnsInvalidNewPasswordMessage(string tendangnhap, string matkhauht, string matkhaumoi, string matkhaunhaplai)
		{
			// Act
			var result = _nguoiDungBLLService.DoiMatKhau(tendangnhap, matkhauht, matkhaumoi, matkhaunhaplai);

			// Assert
			Assert.Equal(DoiMatKhauMessage.InvalidNewPassword, result);
		}

		[Theory, InlineData("admin1", "12345678", "123456789", "123456789")]
		public void DoiMatKhau_WithValidInputs_VerifyExecuteDAL(string tendangnhap, string matkhauht, string matkhaumoi, string matkhaunhaplai)
		{
			//Arrange
			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="User",
				}
			};
			_nguoiDungDALServiceMock.Setup(_ => _.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.DoiMatKhau(tendangnhap, matkhauht, matkhaumoi, matkhaunhaplai);

			// Assert
			_nguoiDungDALServiceMock.Verify(_ => _.DoiMatKhau(tendangnhap, matkhauht, matkhaumoi), Times.Once);
		}
		#endregion

		#region ThemTaiKhoan
		[Theory, InlineData("", "1")]	
		public void ThemTaiKhoan_WithEmptyTenDangNhap_ReturnsEmptyTenDangNhapMessage(string tendangnhap, string manhom)
		{
			// Act
			var result = _nguoiDungBLLService.ThemTaiKhoan(tendangnhap, manhom);

			// Assert
			Assert.Equal(ThemTaiKhoanMessage.EmptyTenDangNhap, result);

		}

		[Theory, InlineData("username", "1")]
		public void ThemTaiKhoan_WithDuplicateTenDangNhap_ReturnsDuplicateTenDangNhapMessage(string tendangnhap, string manhom)
		{
			//Arrange
			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="User",
				}
			};
			_nguoiDungDALServiceMock.Setup(_ => _.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.ThemTaiKhoan(tendangnhap, manhom);

			// Assert
			Assert.Equal(ThemTaiKhoanMessage.DuplicateTenDangNhap, result);
		}

		[Theory, InlineData("username", "1")]
		public void ThemTaiKhoan_WithValidInputs_VerifyExecuteDAL(string tendangnhap, string manhom)
		{
			//Arrange
			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username1",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="User",
				}
			};
			_nguoiDungDALServiceMock.Setup(_ => _.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.ThemTaiKhoan(tendangnhap, manhom);

			// Assert
			_nguoiDungDALServiceMock.Verify(_ => _.ThemTaiKhoan(tendangnhap, manhom), Times.Once);
		}
		#endregion

		#region SuaTaiKhoan 
		[Theory, InlineData("username", "", "1")]
		public void SuaTaiKhoan_WitEmptyTenDangNhap_ReturnsEmptyTenDangNhapMessage(string tendangnhapbd, string tendangnhap, string manhom)
		{
			// Act
			var result = _nguoiDungBLLService.SuaTaiKhoan(tendangnhapbd, tendangnhap, manhom);

			// Assert
			Assert.Equal(SuaTaiKhoanMessage.EmptyTenDangNhap, result);
		}

		[Theory, InlineData("username", "username1", "1")]
		public void SuaTaiKhoan_WithDuplicateTenDangNhap_ReturnsDuplicateTenDangNhapMessage(string tendangnhapbd, string tendangnhap, string manhom)
		{
			//Arrange
			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username1",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="User",
				}
			};
			_nguoiDungDALServiceMock.Setup(_ => _.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.SuaTaiKhoan(tendangnhapbd, tendangnhap, manhom);

			// Assert
			Assert.Equal(SuaTaiKhoanMessage.DuplicateTenDangNhap, result);
		}

		[Theory, InlineData("username", "username1", "1")]
		public void SuaTaiKhoan_WithValidInputs_VerifyExecuteDAL(string tendangnhapbd, string tendangnhap, string manhom)
		{
			//Arrange
			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="User",
				}
			};
			_nguoiDungDALServiceMock.Setup(_ => _.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.SuaTaiKhoan(tendangnhapbd, tendangnhap, manhom);

			// Assert
			_nguoiDungDALServiceMock.Verify(_ => _.SuaTaiKhoan(tendangnhapbd, tendangnhap, manhom), Times.Once);
		}

		[Theory, InlineData("username", "username1", "1")]
		public void SuaTaiKhoan_WithValidInputs_VerifyExecuteDAL2(string tendangnhapbd, string tendangnhap, string manhom)
		{
			//Arrange
			var nguoidungs = new List<CT_NguoiDung>
			{
				new CT_NguoiDung
				{
					TenDangNhap="username2",
					MatKhau="12345678",
					MaNhom="1",
					TenNhom="User",
				}
			};
			_nguoiDungDALServiceMock.Setup(_ => _.LayDSNguoiDung()).Returns(nguoidungs);
			// Act
			var result = _nguoiDungBLLService.SuaTaiKhoan(tendangnhapbd, tendangnhap, manhom);

			// Assert
			_nguoiDungDALServiceMock.Verify(_ => _.SuaTaiKhoan(tendangnhapbd, tendangnhap, manhom), Times.Once);
		}
		#endregion

		#region ThemTaiKhoanSV
		[Fact]
		public void ThemTaiKhoanSV_WithNullDSSV_ReturnsUnableMessage()
		{
			// Arrange
			IList<SinhVien> dssv = null;

			// Act
			var result = _nguoiDungBLLService.ThemTaiKhoanSV(dssv);

			// Assert
			Assert.Equal(ThemTaiKhoanSVMessage.Unable, result);
		}
		[Fact]
		public void ThemTaiKhoanSV_WithEmptyDSSV_ReturnsUnableMessage()
		{
			// Arrange
			IList<SinhVien> dssv = new List<SinhVien>();

			// Act
			var result = _nguoiDungBLLService.ThemTaiKhoanSV(dssv);

			// Assert
			Assert.Equal(ThemTaiKhoanSVMessage.Unable, result);
		}

		[Fact]
		public void ThemTaiKhoanSV_WithValidDSSV_CallsNguoiDungDALService()
		{
			// Arrange
			var dssvs = new List<SinhVien>
			{
				new SinhVien 
				{
					MaSV="SV21520001",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};

			// Act
			var result = _nguoiDungBLLService.ThemTaiKhoanSV(dssvs);

			// Assert
			_nguoiDungDALServiceMock.Verify(service => service.ThemTaiKhoanSV(dssvs), Times.Once);
		}

		#endregion
	}
}
