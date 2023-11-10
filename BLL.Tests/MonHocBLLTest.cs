namespace BLL.Tests
{
    [ExcludeFromCodeCoverage]
	public class MonHocBLLTest
	{
		#region Services
		private readonly IMonHocBLLService _monHocBLLService;
		private readonly Mock<IMonHocDALService> _monHocDALServiceMock;
		private readonly Mock<IDanhSachMonHocMoDALService> _danhSachMonHocMoDALServiceMock;
		private readonly Mock<ICT_PhieuDKHPDALService> _ct_PhieuDKHPDALServiceMock;
		private readonly Mock<IChuongTrinhHocDALService> _chuongTrinhHocDALServiceMock;
		#endregion

		#region Constructor
		public MonHocBLLTest()
		{
			_monHocDALServiceMock = new Mock<IMonHocDALService>();
			_danhSachMonHocMoDALServiceMock = new Mock<IDanhSachMonHocMoDALService>();
			_ct_PhieuDKHPDALServiceMock = new Mock<ICT_PhieuDKHPDALService>();
			_chuongTrinhHocDALServiceMock = new Mock<IChuongTrinhHocDALService>();
			_monHocBLLService = new MonHocBLLService(_monHocDALServiceMock.Object, _danhSachMonHocMoDALServiceMock.Object, _ct_PhieuDKHPDALServiceMock.Object, _chuongTrinhHocDALServiceMock.Object);
		}
		#endregion

		#region LayDSMonHoc
		[Fact]
		public void LayDSMonHoc_VerifyExecuteDAL()
		{
			// Act
			_monHocBLLService.LayDSMonHoc();

			// Assert
			_monHocDALServiceMock.Verify(_ => _.LayDSMonHoc(), Times.Once);
		}
		#endregion

		#region XoaMonHoc

		[Theory, InlineData("NMLT")]
		public void XoaMonHoc_MaMHInDanhSachMonHocMo_ReturnsUnableForDanhSachMonHocMoMessage(string mamh)
		{
			// Arrange
			var monhocmos = new List<string>
			{
				"NMLT"
			};
			_danhSachMonHocMoDALServiceMock.Setup(_ => _.LayDSMonHocMo()).Returns(monhocmos);

			// Act
			var result = _monHocBLLService.XoaMonHoc(mamh);

			// Assert
			Assert.Equal(XoaMonHocMessage.UnableForDanhSachMonHocMo, result);
		}

		[Theory, InlineData("NMLT")]
		public void XoaMonHoc_MaMHInCT_PhieuDKHP_ReturnsUnableForCT_PhieuDKHPMessage(string mamh)
		{
			// Arrange
			var monhocmos = new List<string>
			{
				"LTHDT"
			};

			var ctphieudkhps = new List<CT_PhieuDKHP>
			{
				new CT_PhieuDKHP
				{
					MaPhieuDKHP=1,
					MaMH="NMLT"
				}
			};
			_danhSachMonHocMoDALServiceMock.Setup(_ => _.LayDSMonHocMo()).Returns(monhocmos);
			_ct_PhieuDKHPDALServiceMock.Setup(_ => _.GetCT_PhieuDKHPs()).Returns(ctphieudkhps);

			// Act
			var result = _monHocBLLService.XoaMonHoc(mamh);

			// Assert
			Assert.Equal(XoaMonHocMessage.UnableForCT_PhieuDKHP, result);
		}

		[Theory, InlineData("NMLT")]
		public void XoaMonHoc_MaMHInChuongTrinhHoc_ReturnsUnableForChuongTrinhHocMessage(string mamh)
		{
			// Arrange
			var monhocmos = new List<string>
			{
				"LTHDT"
			};

			var ctphieudkhps = new List<CT_PhieuDKHP>
			{
				new CT_PhieuDKHP
				{
					MaPhieuDKHP=1,
					MaMH="LTHDT"
				}
			};
			var chuongtrinhhocs = new List<ChuongTrinhHoc>
			{
				new ChuongTrinhHoc
				{
					MaNganh="HTTT",
					MaMH = "NMLT",
					HocKy=1
				}
			};
			_danhSachMonHocMoDALServiceMock.Setup(_ => _.LayDSMonHocMo()).Returns(monhocmos);
			_ct_PhieuDKHPDALServiceMock.Setup(_ => _.GetCT_PhieuDKHPs()).Returns(ctphieudkhps);
			_chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongtrinhhocs);

			// Act
			var result = _monHocBLLService.XoaMonHoc(mamh);

			// Assert
			Assert.Equal(XoaMonHocMessage.UnableForChuongTrinhHoc, result);
		}

		[Theory, InlineData("NMLT")]
		public void XoaMonHoc_WithValidInputs_VerifyExecuteDAL(string mamh)
		{
			// Arrange
			var monhocmos = new List<string>
			{
				"LTHDT"
			};

			var ctphieudkhps = new List<CT_PhieuDKHP>
			{
				new CT_PhieuDKHP
				{
					MaPhieuDKHP=1,
					MaMH="LTHDT"
				}
			};
			var chuongtrinhhocs = new List<ChuongTrinhHoc>
			{
				new ChuongTrinhHoc
				{
					MaNganh="HTTT",
					MaMH = "LTHDT",
					HocKy=1
				}
			};
			_danhSachMonHocMoDALServiceMock.Setup(_ => _.LayDSMonHocMo()).Returns(monhocmos);
			_ct_PhieuDKHPDALServiceMock.Setup(_ => _.GetCT_PhieuDKHPs()).Returns(ctphieudkhps);
			_chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongtrinhhocs);

			// Act
			_monHocBLLService.XoaMonHoc(mamh);

			// Assert
			_monHocDALServiceMock.Verify(_ => _.XoaMonHoc(mamh), Times.Once);
		}
		#endregion

		#region SuaMonHoc
		[Theory, InlineData("NMLT","","Nhập môn lập trình",1,"45",15)]
		public void SuaMonHoc_WithEmptyMaMonHoc_ReturnsEmptyMaMHMessage(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau,mamh,tenmh,maloaimonhoc,sotiet,sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.EmptyMaMH, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "", 1, "45", 15)]
		public void SuaMonHoc_WithEmptyTenMonHoc_ReturnsEmptyTenMHMessage(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.EmptyTenMH, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "Nhập môn lập trình", 1, "", 15)]
		public void SuaMonHoc_WithEmptySoTiet_ReturnsEmptySoTietMessage(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.EmptySoTiet, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "Nhập môn lập trình", 1, "a", 15)]
		public void SuaMonHoc_WithInvalidSoTiet_ReturnsInvalidSoTietMessage2(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.InvalidSoTiet, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "Nhập môn lập trình", 1, "0", 15)]
		public void SuaMonHoc_WithDuplicateMaMH_ReturnsDuplicateMaMHMessage(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Arrange
			var monhocs = new List<CT_MonHoc>
			{
				new CT_MonHoc
				{
					MaMH="NMLT1",
					TenMH="Nhập môn lập trình",
					MaLoaiMonHoc=1,
					SoTiet=45,
					TenLoaiMonHoc="Lý thuyết",
					SoTietLoaiMon=15,
					SoTien=27000
				}
			};
			_monHocDALServiceMock.Setup(_ => _.LayDSMonHoc()).Returns(monhocs);
			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.DuplicateMaMH, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "Nhập môn lập trình", 1, "45", 15)]
		public void SuaMonHoc_WithUnableForDanhSachMonHocMo_ReturnsUnableForDanhSachMonHocMoMessage(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Arrange
			var monhocs = new List<CT_MonHoc>
			{
				new CT_MonHoc
				{
					MaMH="LTHDT",
					TenMH="Lập trình hướng đối tượng",
					MaLoaiMonHoc=1,
					SoTiet=45,
					TenLoaiMonHoc="Lý thuyết",
					SoTietLoaiMon=15,
					SoTien=27000
				}
			};
			var monhocmos = new List<string>
			{
				"NMLT1"
			};
			_monHocDALServiceMock.Setup(_ => _.LayDSMonHoc()).Returns(monhocs);
			_danhSachMonHocMoDALServiceMock.Setup(m => m.LayDSMonHocMo()).Returns(monhocmos);

			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.UnableForDanhSachMonHocMo, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "Nhập môn lập trình", 1, "45", 15)]
		public void SuaMonHoc_WithUnableForCT_PhieuDKHP_ReturnsUnableForCT_PhieuDKHPMessage(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Arrange
			var monhocs = new List<CT_MonHoc>
			{
				new CT_MonHoc
				{
					MaMH="LTHDT",
					TenMH="Lập trình hướng đối tượng",
					MaLoaiMonHoc=1,
					SoTiet=45,
					TenLoaiMonHoc="Lý thuyết",
					SoTietLoaiMon=15,
					SoTien=27000
				}
			};
			var monhocmos = new List<string>
			{
				"LTHDT"
			};
			var ctphieudkhps = new List<CT_PhieuDKHP>
			{
				new CT_PhieuDKHP
				{
					MaPhieuDKHP=1,
					MaMH="NMLT1"
				}
			};
			_ct_PhieuDKHPDALServiceMock.Setup(_ => _.GetCT_PhieuDKHPs()).Returns(ctphieudkhps);
			_monHocDALServiceMock.Setup(_ => _.LayDSMonHoc()).Returns(monhocs);
			_danhSachMonHocMoDALServiceMock.Setup(m => m.LayDSMonHocMo()).Returns(monhocmos);

			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.UnableForCT_PhieuDKHP, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "Nhập môn lập trình", 1, "45", 15)]
		public void SuaMonHoc_WithUnableForChuongTrinhHoc_ReturnsUnableForChuongTrinhHocMessage(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Arrange
			var monhocs = new List<CT_MonHoc>
			{
				new CT_MonHoc
				{
					MaMH="LTHDT",
					TenMH="Lập trình hướng đối tượng",
					MaLoaiMonHoc=1,
					SoTiet=45,
					TenLoaiMonHoc="Lý thuyết",
					SoTietLoaiMon=15,
					SoTien=27000
				}
			};
			var monhocmos = new List<string>
			{
				"LTHDT"
			};
			var ctphieudkhps = new List<CT_PhieuDKHP>
			{
				new CT_PhieuDKHP
				{
					MaPhieuDKHP=1,
					MaMH="LTHDT"
				}
			};
			var chuongtrinhhocs = new List<ChuongTrinhHoc>
			{
				new ChuongTrinhHoc
				{
					MaNganh="HTTT",
					MaMH = "NMLT1",
					HocKy=1
				}
			};
			_chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongtrinhhocs);
			_ct_PhieuDKHPDALServiceMock.Setup(_ => _.GetCT_PhieuDKHPs()).Returns(ctphieudkhps);
			_monHocDALServiceMock.Setup(_ => _.LayDSMonHoc()).Returns(monhocs);
			_danhSachMonHocMoDALServiceMock.Setup(m => m.LayDSMonHocMo()).Returns(monhocmos);

			// Act
			var result = _monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(SuaMonHocMessage.UnableForChuongTrinhHoc, result);
		}

		[Theory, InlineData("NMLT", "NMLT1", "Nhập môn lập trình", 1, "45", 15)]
		public void SuaMonHoc_WithValidInputs_VerifyExecuteDAL(string mamhbandau, string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Arrange
			var monhocs = new List<CT_MonHoc>
			{
				new CT_MonHoc
				{
					MaMH="LTHDT",
					TenMH="Lập trình hướng đối tượng",
					MaLoaiMonHoc=1,
					SoTiet=45,
					TenLoaiMonHoc="Lý thuyết",
					SoTietLoaiMon=15,
					SoTien=27000
				}
			};
			var monhocmos = new List<string>
			{
				"LTHDT"
			};
			var ctphieudkhps = new List<CT_PhieuDKHP>
			{
				new CT_PhieuDKHP
				{
					MaPhieuDKHP=1,
					MaMH="LTHDT"
				}
			};
			var chuongtrinhhocs = new List<ChuongTrinhHoc>
			{
				new ChuongTrinhHoc
				{
					MaNganh="HTTT",
					MaMH = "LTHDT",
					HocKy=1
				}
			};
			_chuongTrinhHocDALServiceMock.Setup(_ => _.GetAllCTHoc()).Returns(chuongtrinhhocs);
			_ct_PhieuDKHPDALServiceMock.Setup(_ => _.GetCT_PhieuDKHPs()).Returns(ctphieudkhps);
			_monHocDALServiceMock.Setup(_ => _.LayDSMonHoc()).Returns(monhocs);
			_danhSachMonHocMoDALServiceMock.Setup(m => m.LayDSMonHocMo()).Returns(monhocmos);

			// Act
			_monHocBLLService.SuaMonHoc(mamhbandau, mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			_monHocDALServiceMock.Verify(_ => _.SuaMonHoc(mamhbandau, tenmh, maloaimonhoc, Int32.Parse(sotiet)), Times.Once);
		}
		#endregion

		#region ThemMonHoc
		[Theory, InlineData("", "Nhập môn lập trình", 1, "45", 15)]
		public void ThemMonHoc_WithEmptyMaMH_ReturnsEmptyMaMHMessage(string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.ThemMonHoc(mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(ThemMonHocMessage.EmptyMaMH, result);
		}

		[Theory, InlineData("NMLT", "", 1, "45", 15)]
		public void ThemMonHoc_WithEmptyTenMH_ReturnEmptyTenMHMessage(string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.ThemMonHoc(mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(ThemMonHocMessage.EmptyTenMH, result);
		}

		[Theory, InlineData("NMLT", "Nhập môn lập trình", 1, "", 15)]
		public void ThemMonHoc_WithEmptySoTiet_ReturnEmptySoTietMessage(string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.ThemMonHoc(mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(ThemMonHocMessage.EmptySoTiet, result);
		}

		[Theory, InlineData("NMLT", "Nhập môn lập trình", 1, "-3", 15), InlineData("NMLT", "Nhập môn lập trình", 1, "a", 15), InlineData("NMLT", "Nhập môn lập trình", 1, "14", 15)]
		public void ThemMonHoc_WithInvalidSoTiet_ReturnInvalidSoTietMessage(string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Act
			var result = _monHocBLLService.ThemMonHoc(mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(ThemMonHocMessage.InvalidSoTiet, result);
		}

		[Theory, InlineData("NMLT", "Nhập môn lập trình", 1, "0", 15)]
		public void ThemMonHoc_WithDuplicateMaMH_ReturnDuplicateMaMHMessage(string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Arrange
			var monhocs = new List<CT_MonHoc>
			{
				new CT_MonHoc
				{
					MaMH="NMLT",
					TenMH="Nhập môn lập trình",
					MaLoaiMonHoc=1,
					SoTiet=45,
					TenLoaiMonHoc="Lý thuyết",
					SoTietLoaiMon=15,
					SoTien=27000
				}
			};
			_monHocDALServiceMock.Setup(_ => _.LayDSMonHoc()).Returns(monhocs);
			// Act
			var result = _monHocBLLService.ThemMonHoc(mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			Assert.Equal(ThemMonHocMessage.DuplicateMaMH, result);
		}

		[Theory, InlineData("NMLT", "Nhập môn lập trình", 1, "45", 15)]
		public void ThemMonHoc_WithValidInputs_VerifyExecuteDAL(string mamh, string tenmh, int maloaimonhoc, string sotiet, int sotietloaimon)
		{
			// Arrange
			var monhocs = new List<CT_MonHoc>
			{
				new CT_MonHoc
				{
					MaMH="NMLT1",
					TenMH="Nhập môn lập trình",
					MaLoaiMonHoc=1,
					SoTiet=45,
					TenLoaiMonHoc="Lý thuyết",
					SoTietLoaiMon=15,
					SoTien=27000
				}
			};
			_monHocDALServiceMock.Setup(_ => _.LayDSMonHoc()).Returns(monhocs);
			// Act
			_monHocBLLService.ThemMonHoc(mamh, tenmh, maloaimonhoc, sotiet, sotietloaimon);

			// Assert
			_monHocDALServiceMock.Verify(_ => _.ThemMonHoc(mamh, tenmh, maloaimonhoc, Int32.Parse(sotiet)), Times.Once);
		}
		#endregion

		#region GetTermMonHoc
		[Theory, InlineData(1)]
		public void GetTermMonHoc_WithValidInputs_VerifyExecuteDAL(int hocky)
		{
			// Act
			_monHocBLLService.GetTermMonHoc(hocky);

			// Assert
			_monHocDALServiceMock.Verify(_ => _.GetTermMonHoc(hocky), Times.Once);
		}
		#endregion

		#region GetTermMonHocMo
		[Theory, InlineData(1,2023)]
		public void GetTermMonHocMo_WithValidInputs_VerifyExecuteDAL(int hocky, int namhoc)
		{
			// Act
			_monHocBLLService.GetTermMonHocMo(hocky, namhoc);

			// Assert
			_monHocDALServiceMock.Verify(_ => _.GetTermMonHocMo(hocky, namhoc), Times.Once);
		}
		#endregion

		#region GetChuongTrinhHoc
		[Theory, InlineData("KTPM", 1)]
		public void GetChuongTrinhHoc_WithValidInputs_VerifyExecuteDAL(string nganh, int hocky)
		{
			// Act
			_monHocBLLService.GetChuongTrinhHoc(nganh, hocky);

			// Assert
			_monHocDALServiceMock.Verify(_ => _.GetChuongTrinhHoc(nganh, hocky), Times.Once);
		}
		#endregion

		#region LayDSMonHoc2
		[Fact]
		public void LayDSMonHoc2_VerifyExecuteDAL()
		{
			// Act
			_monHocBLLService.LayDSMonHoc2();

			// Assert
			_monHocDALServiceMock.Verify(_ => _.LayDSMonHoc2(), Times.Once);
		}
		#endregion

		#region GetMonHocPhieuDKHP
		[Theory, InlineData(1)]
		public void GetMonHocPhieuDKHP_WithValidInputs_VerifyExecuteDAL(int maphieudkhp)
		{
			// Act
			_monHocBLLService.GetMonHocPhieuDKHP(maphieudkhp);

			// Assert
			_monHocDALServiceMock.Verify(_ => _.GetMonHocPhieuDKHP(maphieudkhp), Times.Once);
		}
		#endregion
	}
}
