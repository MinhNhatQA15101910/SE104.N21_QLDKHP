namespace DAL.Tests
{
    [ExcludeFromCodeCoverage]
    public class CT_PhieuDKHPDALTest
    {
        #region Services
        private readonly ICT_PhieuDKHPDALService _ct_PhieuDKHPDALService;
        private readonly Mock<IDapperWrapper> _dapperWrapperMock;
        private readonly string _testConnectionString;
        #endregion

        #region Constructor
        public CT_PhieuDKHPDALTest()
        {
            _dapperWrapperMock = new Mock<IDapperWrapper>();
            _testConnectionString = @"Server=SERVERNAME;Database=TESTDB;Integrated Security=true;";
            _ct_PhieuDKHPDALService = new CT_PhieuDKHPDALService(_testConnectionString, _dapperWrapperMock.Object);
        }
        #endregion

        #region GetCT_PhieuDKHPs
        [Fact]
        public void GetCT_PhieuDKHPs_VerifyQueryData()
        {
            // Arrange
            var expectedQuery = "spCT_PHIEUDKHP_GetCT_PhieuDKHPs";
            var expectedResult = new List<CT_PhieuDKHP>
            {
                new CT_PhieuDKHP
                {
                    MaPhieuDKHP = 1,
                    MaMH = "IT001"
                }
            };

            _dapperWrapperMock.Setup(
                _ => _.Query<CT_PhieuDKHP>(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery))
                .Returns(expectedResult);

            // Act
            var result = _ct_PhieuDKHPDALService.GetCT_PhieuDKHPs();

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region TaoCT_PhieuDKHP
        [Fact]
        public void TaoCT_PhieuDKHP_ReturnsRowsAffected()
        {
            // Arrange
            var expectedCt_PhieuDKHP = new CT_PhieuDKHP
            {
                MaPhieuDKHP = 1,
                MaMH = "IT001"
            };
            var expectedQuery = "spPHIEUDKHP_TaoCT_PhieuDKHP";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedMaMHParameterName = "@maMH";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == expectedCt_PhieuDKHP.MaPhieuDKHP &&
                            p.Get<string>(expectedMaMHParameterName) == expectedCt_PhieuDKHP.MaMH),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _ct_PhieuDKHPDALService.TaoCT_PhieuDKHP(expectedCt_PhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion

        #region XoaDSMHDKHP
        [Theory, InlineData(1)]
        public void XoaDSMHDKHP_ReturnsRowsAffected(int maPhieuDKHP)
        {
            // Arrange
            var expectedQuery = "spPHIEUDKHP_XoaCT_PhieuDKHP";
            var expectedMaPhieuDKHPParameterName = "@maPhieuDKHP";
            var expectedCommandType = CommandType.StoredProcedure;
            var expectedResult = 1;

            _dapperWrapperMock.Setup(_ => _.Execute(
                    It.Is<IDbConnection>(db => db.ConnectionString == _testConnectionString),
                    expectedQuery,
                    It.Is<DynamicParameters>(
                        p => p.Get<int>(expectedMaPhieuDKHPParameterName) == maPhieuDKHP),
                    expectedCommandType))
                .Returns(expectedResult);

            // Act
            var result = _ct_PhieuDKHPDALService.XoaDSMHDKHP(maPhieuDKHP);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        #endregion
    }
}
