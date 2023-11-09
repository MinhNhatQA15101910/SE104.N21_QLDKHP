using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
	public class SinhVienBLLTest
	{
		#region Services
		private readonly ISinhVienBLLService _sinhVienBLLService;
		private readonly Mock<ISinhVienDALService> _sinhVienDALServiceMock;
		#endregion

		#region Constructor
		public SinhVienBLLTest()
		{
			_sinhVienDALServiceMock = new Mock<ISinhVienDALService>();
			_sinhVienBLLService = new SinhVienBLLService(_sinhVienDALServiceMock.Object);
		}
		#endregion

		#region LayDSSVChuaCoTK
		[Fact]
		public void LayDSSVChuaCoTK_VerifyExecuteDAL()
		{
			// Act
			_sinhVienBLLService.LayDSSVChuaCoTK();

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.LayDSSVChuaCoTK(), Times.Once);
		}
		#endregion

		#region LayDSSV
		[Fact]
		public void LayDSSV_VerifyExecuteDAL()
		{
			// Act
			_sinhVienBLLService.LayDSSV();

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.LayDSSV(), Times.Once);
		}
		#endregion

		#region SuaSinhVien
		[Theory, InlineData("SV21520001", "", "Nguyễn Văn A", "Nam", 1, "KTPM")]
		public void SuaSinhVien_WithEmptyMaSV_ReturnsEmptyMaSVMessage(string masvbandau, string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh= DateTime.Now;
			// Act
			var result = _sinhVienBLLService.SuaSinhVien(masvbandau, mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh,madts);

			// Assert
			Assert.Equal(SuaSinhVienMessage.EmptyMaSV, result);
		}

		[Theory, InlineData("SV21520001", "SV21520002", "", "Nam", 1, "KTPM")]
		public void SuaSinhVien_WithEmptyTenSV_ReturnsEmptyTenSVMessage(string masvbandau, string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			// Act
			var result = _sinhVienBLLService.SuaSinhVien(masvbandau, mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			Assert.Equal(SuaSinhVienMessage.EmptyTenSV, result);
		}

		[Theory, InlineData("SV21520001", "SV21520002", "Nguyễn Văn A", "Nam", 1, "KTPM")]
		public void SuaSinhVien_WithDuplicateMaSV_ReturnsDuplicateMaSVMessage(string masvbandau, string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520002",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			var result = _sinhVienBLLService.SuaSinhVien(masvbandau, mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			Assert.Equal(SuaSinhVienMessage.DuplicateMaSV, result);
		}

		[Theory, InlineData("SV21520001", "SV21520002", "Nguyễn Văn A", "Nam", 1, "KTPM")]
		public void SuaSinhVien_WithValidInputs_VerifyExecuteDAL(string masvbandau, string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520001",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			var result = _sinhVienBLLService.SuaSinhVien(masvbandau, mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.SuaSinhVien(masvbandau, mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts), Times.Once);
		}

		[Theory, InlineData("SV21520001", "SV21520002", "Nguyễn Văn A", "Nam", 1, "KTPM")]
		public void SuaSinhVien_WithValidInputs_VerifyExecuteDAL2(string masvbandau, string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520003",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			var result = _sinhVienBLLService.SuaSinhVien(masvbandau, mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.SuaSinhVien(masvbandau, mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts), Times.Once);
		}
		#endregion

		#region ThemSinhVien
		[Theory, InlineData("", "Nguyễn Văn A", "Nam", 1, "KTPM")]
		public void ThemSinhVien_WithEmptyMaSV_ReturnsEmptyMaSVMessage(string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			// Act
			var result = _sinhVienBLLService.ThemSinhVien(mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			Assert.Equal(ThemSinhVienMessage.EmptyMaSV, result);
		}

		[Theory, InlineData("SV21520002", "", "Nam", 1, "KTPM")]
		public void ThemSinhVien_WithEmptyTenSV_ReturnsEmptyTenSVMessage(string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			// Act
			var result = _sinhVienBLLService.ThemSinhVien(mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			Assert.Equal(ThemSinhVienMessage.EmptyTenSV, result);
		}

		[Theory, InlineData("SV21520001", "Nguyễn Văn A", "Nam", 1, "KTPM")]
		public void ThemSinhVien_WithDuplicateMaSV_ReturnsDuplicateMaSVMessage(string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520001",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			var result = _sinhVienBLLService.ThemSinhVien(mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			Assert.Equal(ThemSinhVienMessage.DuplicateMaSV, result);
		}

		[Theory, InlineData("SV21520002", "Nguyễn Văn A", "Nam", 1, "KTPM")]
		public void ThemSinhVien_WithValidInputs_VerifyExecuteDAL(string mssv, string hoten, string gioitinh, int mahuyen, string manganh)
		{
			//Arrange
			var madts = new List<int>
			{
				1,
				2
			};
			DateTime ngaysinh = DateTime.Now;
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520001",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			var result = _sinhVienBLLService.ThemSinhVien(mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts);

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.ThemSinhVien(mssv, hoten, ngaysinh, gioitinh, mahuyen, manganh, madts), Times.Once);
		}

		#endregion

		#region XoaSinhVien
		[Theory, InlineData("21520001")]
		public void XoaSinhVien_WithValidInputs_VerifyExecuteDAL(string mssv)
		{
			//Arrange
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520001",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			var result = _sinhVienBLLService.XoaSinhVien(mssv);

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.XoaSinhVien(mssv), Times.Once);
		}
		#endregion

		#region LayTenSV
		[Theory, InlineData("SV21520001")]
		public void LayTenSV_WithValidInputs_VerifyExecuteDAL(string mssv)
		{
			// Arrange
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520001",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			_sinhVienBLLService.LayTenSV(mssv);

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.LayTenSV(mssv), Times.Once);
		}
		#endregion

		#region LayThongTinSinhVien
		[Theory, InlineData("SV21520001")]
		public void LayThongTinSinhVien_WithValidInputs_VerifyExecuteDAL(string mssv)
		{
			// Arrange
			var sinhviens = new List<CT_SinhVien>
			{
				new CT_SinhVien
				{
					MaSV="SV21520001",
					HoTen="Nguyễn Văn A",
					NgaySinh=DateTime.Now,
					GioiTinh="Nam",
					MaHuyen=1,
					MaNganh="KTPM"
				}
			};
			_sinhVienDALServiceMock.Setup(_ => _.LayDSSV()).Returns(sinhviens);
			// Act
			_sinhVienBLLService.LayThongTinSV(mssv);

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.LayThongTinSV(mssv), Times.Once);
		}
		#endregion

		#region BaoCaoSinhVienChuaDongHocPhi
		[Theory, InlineData(1,2023)]
		public void BaoCaoSinhVienChuaDongHocPhi_WithValidInputs_VerifyExecuteDAL(int hocky, int namhoc)
		{
			// Act
			_sinhVienBLLService.BaoCaoSinhVienChuaDongHocPhi(hocky,namhoc);

			// Assert
			_sinhVienDALServiceMock.Verify(_ => _.BaoCaoSinhVienChuaDongHocPhi(hocky, namhoc), Times.Once);
		}
		#endregion
	}
}
