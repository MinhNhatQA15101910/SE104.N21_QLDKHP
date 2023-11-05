namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class NganhDALTests
    {
        #region Services
        private readonly INganhDALService _nganhDALService;
        private readonly Mock<IDapperService> _dapperServiceMock;
        #endregion

        #region Constructor
        public NganhDALTests()
        {
            _dapperServiceMock = new Mock<IDapperService>();
            _nganhDALService = new NganhDALService(_dapperServiceMock.Object);
        }
        #endregion

        #region LayDSNganh
        [Fact]
        public void LayDSNganh_VerifyExecuteDapperService()
        {
            // Arrange
            var layDSNganhSql = "LayDSNganhSql";
            var nganhs = new List<CT_Nganh>
            {
                new CT_Nganh
                {
                    MaNganh = "KTPM"
                },
                new CT_Nganh
                {
                    MaNganh = "KTMT"
                }
            };
            _dapperServiceMock.Setup(_ => _.Query<CT_Nganh>(layDSNganhSql)).Returns(nganhs);

            // Act
            var result = _nganhDALService.LayDSNganh();

            // Assert
            Assert.NotNull(result);
        }
        #endregion

        #region XoaNganh
        [Theory, InlineData("KTPM")]
        public void XoaNganh_ReturnsSuccessfulMessage(string maNganh)
        {
            // Arrange
            var xoaNganhSql = "XoaNganhSql";
            var dynamicParametersMock = new Mock<DynamicParameters>();
            var commandType = CommandType.StoredProcedure;

            _dapperServiceMock.Setup(_ => _.Execute(xoaNganhSql, dynamicParametersMock.Object, commandType)).Returns(1);

            // Act
            var result = _nganhDALService.XoaNganh(maNganh);

            // Assert
            Assert.IsType<XoaNganhMessage>(result);
            Assert.Equal(XoaNganhMessage.Success, result);
        }
        #endregion

        #region SuaNganh
        [Theory, InlineData("KTPM", "KTPM", "Kỹ thuật phần mềm 1", "CNPM")]
        public void SuaNganh_ReturnsSuccessfulMessage(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            // Arrange
            var suaNganhSql = "SuaNganhSql";
            var dynamicParametersMock = new Mock<DynamicParameters>();
            var commandType = CommandType.StoredProcedure;

            _dapperServiceMock.Setup(_ => _.Execute(suaNganhSql, dynamicParametersMock.Object, commandType)).Returns(1);

            // Act
            var result = _nganhDALService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);

            // Assert
            Assert.IsType<SuaNganhMessage>(result);
            Assert.Equal(SuaNganhMessage.Success, result);
        }
        #endregion

        #region ThemNganh
        [Theory, InlineData("TTNT", "Trí tuệ nhân tạo", "KHMT")]
        public void ThemNganh_ReturnsSuccessfulMessage(string maNganh, string tenNganh, string maKhoa)
        {
            // Arrange
            var themNganhSql = "ThemNganhSql";
            var dynamicParametersMock = new Mock<DynamicParameters>();
            var commandType = CommandType.StoredProcedure;

            _dapperServiceMock.Setup(_ => _.Execute(themNganhSql, dynamicParametersMock.Object, commandType)).Returns(1);

            // Act
            var result = _nganhDALService.ThemNganh(maNganh, tenNganh, maKhoa);

            // Assert
            Assert.IsType<ThemNganhMessage>(result);
            Assert.Equal(ThemNganhMessage.Success, result);
        }
        #endregion

        #region GetNganh
        [Theory, InlineData("CNPM")]
        public void GetNganh_ReturnsNganhListWithMaKhoa(string maKhoa)
        {
            // Arrange
            var getNganhWithMaKhoaSql = "getNganhWithMaKhoaSql";
            var dynamicParametersMock = new Mock<DynamicParameters>();
            var commandType = CommandType.StoredProcedure;
            var expectedNganhs = new List<Nganh>
            {
                new Nganh
                {
                    MaKhoa = "CNPM"
                },
                new Nganh
                {
                    MaKhoa = "CNPM"
                },
            };

            _dapperServiceMock.Setup(_ => _.Query<Nganh>(getNganhWithMaKhoaSql, dynamicParametersMock.Object, commandType)).Returns(expectedNganhs);

            // Act
            var result = _nganhDALService.GetNganh(maKhoa);

            // Assert
            Assert.NotNull(result);
        }

        [Theory, InlineData(null)]
        public void GetNganh_WithNullMaKhoa_ReturnsNganhList(string maKhoa)
        {
            // Arrange
            var getNganhWithMaKhoaSql = "getNganhWithMaKhoaSql";
            var expectedNganhs = new List<Nganh>
            {
                new Nganh
                {
                    MaNganh = "KTPM",
                    MaKhoa = "CNPM"
                },
                new Nganh
                {
                    MaNganh = "HTTT",
                    MaKhoa = "HTTT"
                },
            };

            _dapperServiceMock.Setup(_ => _.Query<Nganh>(getNganhWithMaKhoaSql)).Returns(expectedNganhs);

            // Act
            var result = _nganhDALService.GetNganh(maKhoa);

            // Assert
            Assert.NotNull(result);
        }
        #endregion
    }
}
