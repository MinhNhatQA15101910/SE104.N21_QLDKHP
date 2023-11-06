namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class KhoaDALTests
    {
        #region Services
        private readonly IKhoaDALService _khoaDALService;
        private readonly Mock<IDbConnection> _dbConnectionMock;
        #endregion

        #region Constructor
        public KhoaDALTests()
        {
            _dbConnectionMock = new Mock<IDbConnection>();
            _khoaDALService = new KhoaDALService(_dbConnectionMock.Object);
        }
        #endregion

        #region LayDSKhoa
        [Fact]
        public void LayDSKhoa_VerifyQueryData()
        {
            // Act
            var result = _khoaDALService.LayDSKhoa();

            // Assert
            _dbConnectionMock.Verify(_ => _.Query("LayDSKhoaSP"));
        }
        #endregion

        //#region XoaKhoa
        //[Theory, InlineData("CNPM")]
        //public void XoaKhoa_ReturnsSuccessfulMessage(string maKhoa)
        //{
        //    // Arrange
        //    var xoaKhoaSql = "XoaKhoaSql";
        //    var dynamicParametersMock = new Mock<DynamicParameters>();
        //    var commandType = CommandType.StoredProcedure;

        //    _dapperServiceMock.Setup(_ => _.Execute(xoaKhoaSql, dynamicParametersMock.Object, commandType)).Returns(1);

        //    // Act
        //    var result = _khoaDALService.XoaKhoa(maKhoa);

        //    // Assert
        //    Assert.IsType<XoaKhoaMessage>(result);
        //    Assert.Equal(XoaKhoaMessage.Success, result);
        //}
        //#endregion

        //#region SuaKhoa
        //[Fact]
        //public void SuaKhoa_ReturnsSuccessfulMessage()
        //{
        //    //// Arrange
        //    //var suaKhoaSql = "SuaKhoaSql";
        //    //var dynamicParameter = new DynamicParameters();
        //    //var commandType = CommandType.StoredProcedure;

        //    //_dbConnectionMock.Setup(_ => _.Execute(suaKhoaSql, dynamicParameter, commandType: commandType)).Returns(1);

        //    //// Act
        //    //var result = _khoaDALService.SuaKhoa(dynamicParameter, suaKhoaSql);

        //    //// Assert
        //    //Assert.IsType<SuaKhoaMessage>(result);
        //    //Assert.Equal(SuaKhoaMessage.Success, result);
        //}

        //[Fact]
        //public void SuaKhoa_ReturnsFailedMessage()
        //{
        //    //// Arrange
        //    //var suaKhoaSql = "SuaKhoaSql";
        //    //var dynamicParameters = new DynamicParameters();
        //    //var commandType = CommandType.StoredProcedure;

        //    //_dapperServiceMock = new Mock<IDapperService>();
        //    //_dapperServiceMock.Setup(_ => _.Execute(suaKhoaSql, dynamicParameters, commandType)).Returns(0);
        //    //_khoaDALService = new KhoaDALService(_dapperServiceMock.Object);

        //    //// Act
        //    //var result = _khoaDALService.SuaKhoa(dynamicParameters, suaKhoaSql);

        //    //// Assert
        //    //Assert.IsType<SuaKhoaMessage>(result);
        //    //Assert.Equal(SuaKhoaMessage.Failed, result);
        //}
        //#endregion

        //#region ThemKhoa
        //[Theory, InlineData("CNPM1", "Công nghệ phần mềm 1")]
        //public void ThemKhoa_ReturnsSuccessfulMessage(string maKhoa, string tenKhoa)
        //{
        //    // Arrange
        //    var themKhoaSql = "ThemKhoaSql";
        //    var dynamicParametersMock = new Mock<DynamicParameters>();
        //    var commandType = CommandType.StoredProcedure;

        //    _dbConnectionMock.Setup(_ => _.Execute("ThemKhoaSql", dynamicParametersMock.Object, commandType: CommandType.StoredProcedure)).Returns(1);

        //    // Act
        //    var result = _khoaDALService.ThemKhoa(maKhoa, tenKhoa);

        //    // Assert
        //    Assert.IsType<ThemKhoaMessage>(result);
        //    Assert.Equal(ThemKhoaMessage.Success, result);
        //}
        //#endregion
    }
}
