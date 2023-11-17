using BLL.IServices;
using BLL.Services;
using DAL.IServices;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PL.Interfaces;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace PL
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<DangNhap>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {
                        #region DAL
                        services.AddScoped<IDapperWrapper, DapperWrapper>();

                        services.AddTransient<IChuongTrinhHocDALService>(provider => new ChuongTrinhHocDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<ICT_PhieuDKHPDALService>(provider => new CT_PhieuDKHPDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IDanhSachMonHocMoDALService>(provider => new DanhSachMonHocMoDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IDoiTuongDALService>(provider => new DoiTuongDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IGlobalConfigDALService>(provider => new GlobalConfigDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IHocKyDALService>(provider => new HocKyDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IHuyenDALService>(provider => new HuyenDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IKhoaDALService>(provider => new KhoaDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<ILoaiMonHocDALService>(provider => new LoaiMonHocDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IMonHocDALService>(provider => new MonHocDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IMonHocMoDALService>(provider => new MonHocMoDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<INganhDALService>(provider => new NganhDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<INguoiDungDALService>(provider => new NguoiDungDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<INhomNguoiDungDALService>(provider => new NhomNguoiDungDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IPhieuDKHPDALService>(provider => new PhieuDKHPDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<IPhieuThuHPDALService>(provider => new PhieuThuHPDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<ISinhVien_DoiTuongDALService>(provider => new SinhVien_DoiTuongDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<ISinhVienDALService>(provider => new SinhVienDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        services.AddTransient<ITinhDALService>(provider => new TinhDALService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, provider.GetRequiredService<IDapperWrapper>()));
                        #endregion

                        #region BLL
                        services.AddTransient<IChuongTrinhHocBLLService, ChuongTrinhHocBLLService>();
                        services.AddTransient<ICT_PhieuDKHPBLLService, CT_DKHPBLLService>();
                        services.AddTransient<IDanhSachMonHocMoBLLService, DanhSachMonHocMoBLLService>();
                        services.AddTransient<IDoiTuongBLLService, DoiTuongBLLService>();
                        services.AddTransient<IGlobalConfigBLLService, GlobalConfigBLLService>();
                        services.AddTransient<IHocKyBLLService, HocKyBLLService>();
                        services.AddTransient<IHuyenBLLService, HuyenBLLService>();
                        services.AddTransient<IKhoaBLLService, KhoaBLLService>();
                        services.AddTransient<ILoaiMonHocBLLService, LoaiMonHocBLLService>();
                        services.AddTransient<IMonHocBLLService, MonHocBLLService>();
                        services.AddTransient<IMonHocMoBLLService, MonHocMoBLLService>();
                        services.AddTransient<INganhBLLService, NganhBLLService>();
                        services.AddTransient<INguoiDungBLLService, NguoiDungBLLService>();
                        services.AddTransient<INhomNguoiDungBLLService, NhomNguoiDungBLLService>();
                        services.AddTransient<IPhieuDKHPBLLService, PhieuDKHPBLLService>();
                        services.AddTransient<IPhieuThuHPBLLService, PhieuThuHPBLLService>();
                        services.AddTransient<ISinhVienBLLService, SinhVienBLLService>();
                        services.AddTransient<ITinhBLLService, TinhBLLService>();
                        #endregion

                        #region PL
                        services.AddTransient<IAdminRequester>(provider => new DangNhap(provider.GetRequiredService<INguoiDungBLLService>(), provider.GetRequiredService<IGlobalConfigBLLService>()));
                        services.AddTransient<IBaoCaoRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<ICaiDatRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<IChuongTrinhHocRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<IDangKyHocPhanRequester>(provider => new SinhVien(provider.GetRequiredService<ISinhVienRequester>(), provider.GetRequiredService<IPhieuDKHPBLLService>(), provider.GetRequiredService<ISinhVienBLLService>()));
                        services.AddTransient<IDanhSachSinhVienRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<IGVRequester>(provider => new DangNhap(provider.GetRequiredService<INguoiDungBLLService>(), provider.GetRequiredService<IGlobalConfigBLLService>()));
                        services.AddTransient<IKhoaRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<IMonHocRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<IMonHocMoRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<INganhRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<ISinhVienRequester>(provider => new DangNhap(provider.GetRequiredService<INguoiDungBLLService>(), provider.GetRequiredService<IGlobalConfigBLLService>()));
                        services.AddTransient<IThanhToanHocPhiRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<IThemSuaDoiTuongRequester>(provider => new QuanLyDoiTuong(provider.GetRequiredService<ICaiDatRequester>(), provider.GetRequiredService<IDoiTuongBLLService>()));
                        services.AddTransient<IThemSuaHuyenRequester>(provider => new QuanLyHuyen(provider.GetRequiredService<ICaiDatRequester>(), provider.GetRequiredService<ITinhBLLService>(), provider.GetRequiredService<IHuyenBLLService>()));
                        services.AddTransient<IThemSuaKhoaRequester>(provider => new QuanLyKhoa(provider.GetRequiredService<IKhoaRequester>(), provider.GetRequiredService<IKhoaBLLService>()));
                        services.AddTransient<IThemSuaLoaiMonHocRequester>(provider => new QuanLyLoaiMonHoc(provider.GetRequiredService<ICaiDatRequester>(), provider.GetRequiredService<IGlobalConfigBLLService>(), provider.GetRequiredService<ILoaiMonHocBLLService>()));
                        services.AddTransient<IThemSuaLoaiMonHocRequester>(provider => new ThemSuaMonHoc(provider.GetRequiredService<IThemSuaMonHocRequester>()));
                        services.AddTransient<IThemSuaMonHocRequester>(provider => new QuanLyMonHoc(provider.GetRequiredService<IMonHocRequester>(), provider.GetRequiredService<IMonHocBLLService>(), provider.GetRequiredService<ILoaiMonHocBLLService>()));
                        services.AddTransient<IThemSuaNganhRequester>(provider => new QuanLyNganh(provider.GetRequiredService<INganhRequester>(), provider.GetRequiredService<INganhBLLService>(), provider.GetRequiredService<IKhoaBLLService>()));
                        services.AddTransient<IThemSuaSinhVienRequester>(provider => new QuanLySinhVien(provider.GetRequiredService<IDanhSachSinhVienRequester>(), provider.GetRequiredService<IDoiTuongBLLService>(), provider.GetRequiredService<ISinhVienBLLService>()));
                        services.AddTransient<IThemSuaTaiKhoanRequester>(provider => new Admin(provider.GetRequiredService<IAdminRequester>(), provider.GetRequiredService<INguoiDungBLLService>(), provider.GetRequiredService<ISinhVienBLLService>()));
                        services.AddTransient<IThemSuaTinhRequester>(provider => new QuanLyTinh(provider.GetRequiredService<ICaiDatRequester>(), provider.GetRequiredService<ITinhBLLService>()));
                        services.AddTransient<IThongTinSinhVienRequester>(provider => new SinhVien(provider.GetRequiredService<ISinhVienRequester>(), provider.GetRequiredService<IPhieuDKHPBLLService>(), provider.GetRequiredService<ISinhVienBLLService>()));
                        services.AddTransient<ITraCuuMonHocMoRequester>(provider => new QuanLyMonHocMo(provider.GetRequiredService<IMonHocMoRequester>(), provider.GetRequiredService<IMonHocBLLService>(), provider.GetRequiredService<IGlobalConfigBLLService>(), provider.GetRequiredService<IMonHocMoBLLService>()));
                        services.AddTransient<IXacNhanDKHPRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));
                        services.AddTransient<IXacNhanHocPhiRequester>(provider => new GiaoVien(provider.GetRequiredService<IGVRequester>()));

                        services.AddTransient<Admin>();
                        services.AddTransient<BaoCao>();
                        services.AddTransient<DangKyHocPhan>();
                        services.AddTransient<DangNhap>();
                        services.AddTransient<DoiMatKhau>();
                        services.AddTransient<GiaoVien>();
                        services.AddTransient<QuanLyChuongTrinhHoc>();
                        services.AddTransient<QuanLyDoiTuong>();
                        services.AddTransient<QuanLyHuyen>();
                        services.AddTransient<QuanLyKhoa>();
                        services.AddTransient<QuanLyLoaiMonHoc>();
                        services.AddTransient<QuanLyMonHoc>();
                        services.AddTransient<QuanLyMonHocMo>();
                        services.AddTransient<QuanLyNganh>();
                        services.AddTransient<QuanLySinhVien>();
                        services.AddTransient<QuanLyTinh>();
                        services.AddTransient<SinhVien>();
                        services.AddTransient<ThanhToanHocPhi>();
                        services.AddTransient<ThemSuaCTH>();
                        services.AddTransient<ThongTinDKHP>();
                        services.AddTransient<ThongTinHocPhi>();
                        services.AddTransient<ThongTinSinhVien>();
                        services.AddTransient<TraCuuMonHocMo>();
                        services.AddTransient<XacNhanDKHP>();
                        services.AddTransient<XacNhanHocPhi>();
                        #endregion
                    });
        }
    }
}
