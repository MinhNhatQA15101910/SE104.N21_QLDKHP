--create database QuanLyDangKyHP;
--use QuanLyDangKyHP;
--drop database QuanLyDangKyHP;

-- 1.1. Yêu cầu lập hồ sơ sinh viên - Tính đúng đắn
create table SINHVIEN
(
	MaSV varchar(10) not null,
	HoTen nvarchar(100) not null, 
	NgaySinh date not null, 
	GioiTinh nvarchar(10) not null, 
	QueQuan nvarchar(200) not null, 
	TenDoiTuong nvarchar(100) not null, 
	TenNganh nvarchar(100) not null, 

	constraint PK_SINHVIEN primary key (MaSV)
);
go

-- 1.2. Yêu cầu lập hồ sơ sinh viên - Tính tiến hóa
drop table SINHVIEN;
go
create table KHOA
(
	MaKhoa nvarchar(50) not null, 
	TenKhoa nvarchar(100) not null, 

	constraint PK_KHOA primary key (MaKhoa), 
	constraint UQ_KHOA_TenKhoa unique (TenKhoa)
);
go
create table NGANH 
(
	MaNganh nvarchar(50) not null, 
	TenNganh nvarchar(100) not null, 
	MaKhoa nvarchar(50) not null, 

	constraint PK_NGANH primary key (MaNganh), 
	constraint FK_NGANH_KHOA foreign key (MaKhoa) references KHOA(MaKhoa), 
	constraint UQ_NGANH_TenNganh unique (TenNganh)
);
go
create table TINH
(
	MaTinh int identity(1, 1) not null,
	TenTTP nvarchar(100) not null,

	constraint PK_TINH primary key (MaTinh), 
	constraint UQ_TINH_TenTTP unique (TenTTP)
);
go
create table HUYEN
(
	MaHuyen int identity(1, 1) not null,
	TenHuyen nvarchar(100) not null, 
	VungUT int not null, 
	MaTinh int not null, 

	constraint PK_HUYEN primary key (MaHuyen), 
	constraint FK_HUYEN_TINH foreign key (MaTinh) references TINH(MaTinh)
);
go
create table DOITUONG
(
	MaDT int identity(1, 1) not null,
	TenDT nvarchar(100) not null, 
	TiLeGiamHocPhi float not null, 

	constraint PK_DOITUONG primary key (MaDT), 
	constraint UQ_DOITUONG_TenDT unique (TenDT)
);
go
create table SINHVIEN
(
	MaSV varchar(10) not null, 
	HoTen nvarchar(100) not null, 
	NgaySinh date not null, 
	GioiTinh nvarchar(10) not null, 
	MaHuyen int not null, 
	MaNganh nvarchar(50) not null, 

	constraint PK_SINHVIEN primary key (MaSV), 
	constraint FK_SINHVIEN_HUYEN foreign key (MaHuyen) references HUYEN(MaHuyen), 
	constraint FK_SINHVIEN_NGANH foreign key (MaNganh) references NGANH(MaNganh)
);
go
create table SINHVIEN_DOITUONG 
(
	MaSV varchar(10) not null, 
	MaDT int not null, 

	constraint PK_SINHVIEN_DOITUONG primary key (MaSV, MaDT), 
	constraint FK_SINHVIEN_DOITUONG1 foreign key (MaSV) references SINHVIEN(MaSV), 
	constraint FK_SINHVIEN_DOITUONG2 foreign key (MaDT) references DOITUONG(MaDT)
);
go

-- 2.1. Yêu cầu nhập danh sách môn học - Tính đúng đắn
create table MONHOC
(
	MaMH nvarchar(50) not null, 
	TenMH nvarchar(100) not null, 
	LoaiMon nvarchar(50) not null, 
	SoTiet int not null, 

	constraint PK_MONHOC primary key (MaMH)
);
go

-- 2.2. Yêu cầu nhập danh sách môn học - Tính tiến hóa
drop table MONHOC;
go

create table LOAIMONHOC
(
	MaLoaiMonHoc int identity(1, 1) not null, 
	TenLoaiMonHoc nvarchar(100) not null, 
	SoTiet int not null, 

	constraint PK_LOAIMONHOC primary key (MaLoaiMonHoc), 
	constraint UQ_LOAIMONHOC_TenLoaiMonHoc unique (TenLoaiMonHoc)
);
go
create table MONHOC
(
	MaMH nvarchar(50) not null, 
	TenMH nvarchar(100) not null, 
	MaLoaiMonHoc int not null, 
	SoTiet int not null, 

	constraint PK_MONHOC primary key (MaMH), 
	constraint FK_MONHOC_LOAIMONHOC foreign key (MaLoaiMonHoc) references LOAIMONHOC(MaLoaiMonHoc),
);
go

-- 3.1. Yêu cầu nhập danh sách khoa - Tính đúng đắn

-- 3.2. Yêu cầu nhập danh sách khoa - Tính tiến hóa

-- 4.1. Yêu cầu nhập danh sách ngành - Tính đúng đắn

-- 4.2. Yêu cầu nhập danh sách ngành - Tính tiến hóa

-- 5.1. Yêu cầu nhập chương trình học - Tính đúng đắn
create table CHUONGTRINHHOC 
(
	MaNganh nvarchar(50) not null, 
	MaMH nvarchar(50) not null, 
	HocKy int not null, 

	constraint PK_CHUONGTRINHHOC primary key (MaNganh, MaMH), 
	constraint FK_CHUONGTRINHHOC_NGANH foreign key (MaNganh) references NGANH(MaNganh), 
	constraint FK_CHUONGTRINHHOC_MONHOC foreign key (MaMH) references MONHOC(MaMH)
);
go

-- 5.2. Yêu cầu nhập chương trình học - Tính tiến hóa

-- 6.1. Yêu cầu nhập môn học mở trong học kỳ - Tính đúng đắn
create table DANHSACHMONHOCMO
(
	MaMH nvarchar(50), 
	HocKy nvarchar(50),
	NamHoc int, 

	constraint PK_DANHSACHMONHOCMO primary key (MaMH, HocKy, NamHoc), 
	constraint FK_DANHSACHMONHOCMO_MONHOC foreign key (MaMH) references MONHOC(MaMH)
);
go

-- 6.2 Yêu cầu nhập môn học mở trong học kỳ - Tính tiến hóa
drop table DANHSACHMONHOCMO;
go

create table HOCKY
(
	MaHocKy int identity (1, 1) not null, 
	TenHocKy nvarchar(50) not null, 

	constraint PK_HOCKY primary key (MaHocKy), 
	constraint UQ_HOCKY_TenHocKy unique (TenHocKy)
);
go
create table DANHSACHMONHOCMO
(
	MaMH nvarchar(50), 
	MaHocKy int,
	NamHoc int, 

	constraint PK_DANHSACHMONHOCMO primary key (MaMH, MaHocKy, NamHoc), 
	constraint FK_DANHSACHMONHOCMO_MONHOC foreign key (MaMH) references MONHOC(MaMH),
	constraint FK_DANHSACHMONHOCMO_HOCKY foreign key (MaHocKy) references HOCKY(MaHocKy)
);
go

-- 7.1 - Yêu cầu lập phiếu đăng ký học phần - Tính đúng đắn
create table PHIEUDKHP
(
	MaPhieuDKHP int identity(1, 1) not null,
	MaSV varchar(10) not null, 
	NgayLap datetime not null, 
	MaHocKy int not null, 
	NamHoc int not null,

	constraint PK_PHIEUDKHP primary key (MaPhieuDKHP), 
	constraint FK_PHIEUDKHP_SINHVIEN foreign key (MaSV) references SINHVIEN(MaSV),
	constraint FK_PHIEUDKHP_HOCKY foreign key (MaHocKy) references HOCKY(MaHocKy),
	constraint UQ_PHIEUDKHP unique(MaSV, MaHocKy, NamHoc)
);
go
create table CT_PHIEUDKHP
(
	MaPhieuDKHP int not null, 
	MaMH nvarchar(50) not null, 

	constraint PK_CT_PHIEUDKHP primary key (MaPhieuDKHP, MAMH),
	constraint FK_CT_PHIEUDKHP_PHIEUDKHP foreign key (MaPhieuDKHP) references PHIEUDKHP(MaPhieuDKHP), 
	constraint FK_CT_PHIEUDKHP_MONHOC foreign key (MaMH) references MONHOC(MaMH)
);
go

-- 7.2 - Yêu cầu lập phiếu đăng ký học phần - Tính tiến hóa
alter table LOAIMONHOC add SoTien decimal not null;
go

create function dbo.chk_MaMH(@MaMH nvarchar(50), @MaPhieuDKHP int)
returns varchar(5)
as
begin
	if exists
	(
		select * 
		from PHIEUDKHP, DANHSACHMONHOCMO
		where PHIEUDKHP.MaPhieuDKHP = @MaPhieuDKHP
		and PHIEUDKHP.MaHocKy = DANHSACHMONHOCMO.MaHocKy
		and PHIEUDKHP.NamHoc = DANHSACHMONHOCMO.NamHoc
		and DANHSACHMONHOCMO.MaMH = @MaMH
	)
		return 'True'
	return 'False'
end;
go
alter table CT_PHIEUDKHP add constraint CHK_CT_PHIEUDKHP check (dbo.chk_MaMH(MaMH, MaPhieuDKHP) = 'True');
create table THAMSO
(
	SoTinChiToiDa int not null, 
	SoTinChiToiThieu int not null
);

-- 8.1 - Yêu cầu lập phiếu thu học phí - Tính đúng đắn
create table PHIEUTHUHP
(
	MaPhieuThuHP int identity(1, 1) not null,
	MaPhieuDKHP int not null, 
	NgayLap datetime not null, 
	SoTienThu int not null, 

	constraint PK_PHIEUTHUHP primary key (MaPhieuThuHP), 
	constraint FK_MaPhieuDKHP foreign key (MaPhieuDKHP) references PHIEUDKHP(MaPhieuDKHP), 
);

-- 8.2 - Yêu cầu lập phiếu thu học phí - Tính tiến hóa
create table KHOANGTGDONGHP
(
	MaHocKy int not null, 
	NamHoc int not null, 
	KhoangTG int not null, 

	constraint PK_KHOANGTGDONGHOCPHI primary key (MaHocKy, NamHoc), 
	constraint FK_KHOANGTGDONGHOCPHI_MaHocKy foreign key (MaHocKy) references HOCKY(MaHocKy), 
);
go
create function dbo.chk_KhoangTGDongHP(@MaPhieuThuHP int)
returns varchar(5)
as
begin
	declare @NgayLapPhieuDKHP datetime = 
	(
		select PHIEUDKHP.NgayLap
		from PHIEUDKHP, PHIEUTHUHP
		where PHIEUTHUHP.MaPhieuThuHP = @MaPhieuThuHP
		and PHIEUDKHP.MaPhieuDKHP = PHIEUTHUHP.MaPhieuDKHP
	)
	declare @NgayLapPhieuThuHP datetime = 
	(
		select PHIEUTHUHP.NgayLap
		from PHIEUTHUHP
		where PHIEUTHUHP.MaPhieuThuHP = @MaPhieuThuHP
	)
	declare @KhoangTGChoPhepDongHP int =
	(
		select KHOANGTGDONGHP.KhoangTG
		from KHOANGTGDONGHP, PHIEUDKHP, PHIEUTHUHP
		where PHIEUTHUHP.MaPhieuThuHP = @MaPhieuThuHP
		and PHIEUTHUHP.MaPhieuDKHP = PHIEUDKHP.MaPhieuDKHP
		and PHIEUDKHP.MaHocKy = KHOANGTGDONGHP.MaHocKy
		and PHIEUDKHP.NamHoc = KHOANGTGDONGHP.NamHoc
	)

	if datediff(day, @NgayLapPhieuThuHP, @NgayLapPhieuDKHP) <= @KhoangTGChoPhepDongHP
		return 'True'
	return 'False'
end;
go
alter table PHIEUTHUHP add constraint CHK_PHIEUTHUHP_NgayLap check (dbo.chk_KhoangTGDongHP(MaPhieuThuHP) = 'True');
go
create table TINHTRANG
(
	MaTinhTrang int identity(1, 1) not null,
	TenTinhTrang nvarchar(100) not null, 
	
	constraint PK_TINHTRANG primary key (MaTinhTrang),
	constraint UQ_TINHTRANG_TenTinhTrang unique (TenTinhTrang)
);

alter table PHIEUDKHP add MaTinhTrang int not null;
go
alter table PHIEUDKHP add constraint FK_PHIEUDKHP_MaTinhTrang foreign key (MaTinhTrang) references TINHTRANG(MaTinhTrang);
go

-- 9.1 - Yêu cầu lập báo cáo sinh viên chưa đóng học phí - Tính đúng đắn

-- 9.2 - Yêu cầu lập báo cáo sinh viên chưa đóng học phí - Tính tiến hóa

-- 10.1 - Yêu cầu tra cứu sinh viên - Tính đúng đắn

-- 10.2 - Yêu cầu tra cứu sinh viên - Tính tiến hóa

-- 11.1 - Yêu cầu tra cứu phiếu đăng ký học phần - Tính đúng đắn

-- 11.2 - Yêu cầu tra cứu phiếu đăng ký học phần - Tính tiến hóa

-- 12.1 - Yêu cầu tra cứu phiếu thu học phí - Tính đúng đắn

-- 12.2 - Yêu cầu tra cứu phiếu thu học phí - Tính tiến hóa

-- 13.1 - Yêu cầu phân quyền người dùng - Tính đúng đắn
create table NHOMNGUOIDUNG
(
	MaNhom nvarchar(20) not null, 
	TenNhom nvarchar(100) not null, 

	constraint PK_NHOMNGUOIDUNG primary key (MaNhom), 
	constraint UQ_NHOMNGUOIDUNG_TenNhom unique (TenNhom)
);
go
create table NGUOIDUNG
(
	TenDangNhap varchar(10) not null, 
	MatKhau nvarchar(200) not null, 
	MaNhom nvarchar(20) not null,

	constraint PK_NGUOIDUNG primary key (TenDangNhap), 
	constraint FK_NGUOIDUNG_MaNhom foreign key (MaNhom) references NHOMNGUOIDUNG(MaNhom)
);
go

-- 13.2 - Yêu cầu phân quyền người dùng - Tính tiến hóa

-- Các ràng buộc khác:
-- SINHVIEN
alter table SINHVIEN add constraint CHK_SINHVIEN_GioiTinh check (GioiTinh in (N'Nam', N'Nữ'));
go

-- THAMSO
alter table THAMSO add constraint CHK_THAMSO_SoTinChiToiDa check (SoTinChiToiDa > 0);
go
alter table THAMSO add constraint CHK_THAMSO_SoTinChiToiThieu check (SoTinChiToiThieu > 0);
go
alter table THAMSO add constraint CHK_THAMSO_SoTinChi check (SoTinChiToiDa > SoTinChiToiThieu);
go

-- LOAIMONHOC
alter table LOAIMONHOC add constraint CHK_LOAIMONHOC_SoTiet check (SoTiet > 0);
go
alter table LOAIMONHOC add constraint CHK_LOAIMONHOC_SoTien check (SoTien > 0);
go

-- CHUONGTRINHHOC
alter table CHUONGTRINHHOC add constraint CHK_CHUONGTRINHHOC_HocKy check (HocKy > 0);
go

-- DOITUONG
alter table DOITUONG add constraint CHK_DOITUONG_TiLeGiamHocPhi check (TiLeGiamHocPhi >= 0 and TiLeGiamHocPhi <= 1);
go

-- Add data
-- table KHOA
insert into KHOA values
('KHMT', N'Khoa Học Máy Tính'),
('CNPM', N'Công Nghệ Phần Mềm'),
('KTMT', N'Kĩ Thuật Máy Tính'),
('HTTT', N'Hệ thống thông tin'),
('MMT&TT', N'Mạng máy tính và Truyền thông'),
('KH&KTTT',N'Khoa Học và Kỹ thuật thông tin');

-- table NGANH
insert into NGANH values
('KHMT', N'Khoa học máy tính', 'KHMT'),
('TTNT', N'Trí tuệ nhân tạo', 'KHMT'),
('KTPM', N'Kĩ thuật phần mềm', 'CNPM'),
('KTMT', N'Kỹ thuật máy tính', 'KTMT'),
('HTTT', N'Hệ thống thông tin', 'HTTT'),
('TMDT', N'Thương mại điện tử', 'HTTT'),
('MMT', N'Mạng máy tính', 'MMT&TT'),
('ATTT', N'An toàn thông tin', 'MMT&TT'),
('CNTT', N'Công nghệ thông tin', 'KH&KTTT'),
('KHDL', N'Khoa học dữ liệu', 'KH&KTTT');

-- table TINH
insert into TINH values
(N'Hà Nội'),
(N'Hà Giang'),
(N'Cao Bằng'),
(N'Bắc Kạn'),
(N'Tuyên Quang'),
(N'Lào Cai'),
(N'Điện Biên'),
(N'Lai Châu'),
(N'Sơn La'),
(N'Yên Bái'),
(N'Hòa Bình'),
(N'Thái Nguyên'),
(N'Lạng Sơn'),
(N'Quảng Ninh'),
(N'Bắc Giang'),
(N'Phú Thọ'),
(N'Vĩnh Phúc'),
(N'Bắc Ninh'),
(N'Hải Dương'),
(N'Hải Phòng'),
(N'Hưng Yên'),
(N'Thái Bình'),
(N'Hà Nam'),
(N'Nam Định'),
(N'Ninh Bình'),
(N'Thanh Hóa'),
(N'Nghệ An'),
(N'Hà Tĩnh'),
(N'Quảng Bình'),
(N'Quảng Trị'),
(N'Thừa Thiên Huế'),
(N'Đà Nẵng'),
(N'Quảng Nam'),
(N'Quảng Ngãi'),
(N'Bình Định'),
(N'Phú Yên'),
(N'Khánh Hòa'),
(N'Ninh THuyện'),
(N'Bình THuyện'),
(N'Kon Tum'),
(N'Gia Lai'),
(N'Đắk Lắk'),
(N'Đăk Nông'),
(N'Lâm Đồng'),
(N'Bình Phước'),
(N'Tây Ninh'),
(N'Bình Dương'),
(N'Đồng Nai'),
(N'Bà Rịa - Vũng Tàu'),
(N'Hồ Chí Minh'),
(N'Long An'),
(N'Tiền Giang'),
(N'Bến Tre'),
(N'Trà Vinh'),
(N'Vĩnh Long'),
(N'Đồng Tháp'),
(N'An Giang'),
(N'Kiên Giang'),
(N'Cần Thơ'),
(N'Hậu Giang'),
(N'Sóc Trăng'),
(N'Bạc Liêu'),
(N'Cà Mau');

-- table HUYEN
insert into HUYEN values
(N'Huyện Ba Đình', 0, 1),
(N'Huyện Hoàn Kiếm', 0, 1),
(N'Huyện Tây Hồ', 0, 1),
(N'Huyện Long Biên', 0, 1),
(N'Huyện Cầu Giấy', 0, 1),
(N'Huyện Đống Đa', 0, 1),
(N'Huyện Hai Bà Trưng', 0, 1),
(N'Huyện Hoàng Mai', 0, 1),
(N'Huyện Thanh Xuân', 0, 1),
(N'Huyện Sóc Sơn', 0, 1),
(N'Huyện Đông Anh', 0, 1),
(N'Huyện Gia Lâm', 0, 1),
(N'Huyện Nam Từ Liêm', 0, 1),
(N'Huyện Thanh Trì', 0, 1),
(N'Huyện Bắc Từ Liêm', 0, 1),
(N'Huyện Mê Linh', 0, 1),
(N'Huyện Hà Đông', 0, 1),
(N'Thị xã Sơn Tây', 0, 1),
(N'Huyện Ba Vì', 1, 1),
(N'Huyện Phúc Thọ', 0, 1),
(N'Huyện Đan Phượng', 0, 1),
(N'Huyện Hoài Đức', 0, 1),
(N'Huyện Quốc Oai', 0, 1),
(N'Huyện Thạch Thất', 0, 1),
(N'Huyện Chương Mỹ', 0, 1),
(N'Huyện Thanh Oai', 0, 1),
(N'Huyện Thường Tín', 0, 1),
(N'Huyện Phú Xuyên', 0, 1),
(N'Huyện Ứng Hòa', 0, 1),
(N'Huyện Mỹ Đức', 0, 1),
(N'Thành phố Hà Giang', 1, 2),
(N'Huyện Đồng Văn', 1, 2),
(N'Huyện Mèo Vạc', 1, 2),
(N'Huyện Yên Minh', 1, 2),
(N'Huyện Quản Bạ', 1, 2),
(N'Huyện Vị Xuyên', 1, 2),
(N'Huyện Bắc Mê', 1, 2),
(N'Huyện Hoàng Su Phì', 1, 2),
(N'Huyện Xín Mần', 1, 2),
(N'Huyện Bắc Quang', 1, 2),
(N'Huyện Quang Bình', 1, 2),
(N'Thành phố Cao Bằng', 1, 3),
(N'Huyện Bảo Lâm', 1, 3),
(N'Huyện Bảo Lạc', 1, 3),
(N'Huyện Hà Quảng', 1, 3),
(N'Huyện Trùng Khánh', 1, 3),
(N'Huyện Hạ Lang', 1, 3),
(N'Huyện Quảng Hòa', 1, 3),
(N'Huyện Hoà An', 1, 3),
(N'Huyện Nguyên Bình', 1, 3),
(N'Huyện Thạch An', 1, 3),
(N'Thành Phố Bắc Kạn', 1, 4),
(N'Huyện Pác Nặm', 1, 4),
(N'Huyện Ba Bể', 1, 4),
(N'Huyện Ngân Sơn', 1, 4),
(N'Huyện Bạch Thông', 1, 4),
(N'Huyện Chợ Đồn', 1, 4),
(N'Huyện Chợ Mới', 1, 4),
(N'Huyện Na Rì', 1, 4),
(N'Thành phố Tuyên Quang', 1, 5),
(N'Huyện Lâm Bình', 1, 5),
(N'Huyện Na Hang', 1, 5),
(N'Huyện Chiêm Hóa', 1, 5),
(N'Huyện Hàm Yên', 1, 5),
(N'Huyện Yên Sơn', 1, 5),
(N'Huyện Sơn Dương', 1, 5),
(N'Thành phố Lào Cai', 1, 6),
(N'Huyện Bát Xát', 1, 6),
(N'Huyện Mường Khương', 1, 6),
(N'Huyện Si Ma Cai', 1, 6),
(N'Huyện Bắc Hà', 1, 6),
(N'Huyện Bảo Thắng', 1, 6),
(N'Huyện Bảo Yên', 1, 6),
(N'Thị xã Sa Pa', 1, 6),
(N'Huyện Văn Bàn', 1, 6),
(N'Thành phố Điện Biên Phủ', 1, 7),
(N'Thị Xã Mường Lay', 1, 7),
(N'Huyện Mường Nhé', 1, 7),
(N'Huyện Mường Chà', 1, 7),
(N'Huyện Tủa Chùa', 1, 7),
(N'Huyện Tuần Giáo', 1, 7),
(N'Huyện Điện Biên', 1, 7),
(N'Huyện Điện Biên Đông', 1, 7),
(N'Huyện Mường Ảng', 1, 7),
(N'Huyện Nậm Pồ', 1, 7),
(N'Thành phố Lai Châu', 1, 8),
(N'Huyện Tam Đường', 1, 8),
(N'Huyện Mường Tè', 1, 8),
(N'Huyện Sìn Hồ', 1, 8),
(N'Huyện Phong Thổ', 1, 8),
(N'Huyện Than Uyên', 1, 8),
(N'Huyện Tân Uyên', 1, 8),
(N'Huyện Nậm Nhùn', 1, 8),
(N'Thành phố Sơn La', 1, 9),
(N'Huyện Quỳnh Nhai', 1, 9),
(N'Huyện THuyện Châu', 1, 9),
(N'Huyện Mường La', 1, 9),
(N'Huyện Bắc Yên', 1, 9),
(N'Huyện Phù Yên', 1, 9),
(N'Huyện Mộc Châu', 1, 9),
(N'Huyện Yên Châu', 1, 9),
(N'Huyện Mai Sơn', 1, 9),
(N'Huyện Sông Mã', 1, 9),
(N'Huyện Sốp Cộp', 1, 9),
(N'Huyện Vân Hồ', 1, 9),
(N'Thành phố Yên Bái', 1, 10),
(N'Thị xã Nghĩa Lộ', 1, 10),
(N'Huyện Lục Yên', 1, 10),
(N'Huyện Văn Yên', 1, 10),
(N'Huyện Mù Căng Chải', 1, 10),
(N'Huyện Trấn Yên', 1, 10),
(N'Huyện Trạm Tấu', 1, 10),
(N'Huyện Văn Chấn', 1, 10),
(N'Huyện Yên Bình', 1, 10),
(N'Thành phố Hòa Bình', 1, 11),
(N'Huyện Đà Bắc', 1, 11),
(N'Huyện Lương Sơn', 1, 11),
(N'Huyện Kim Bôi', 1, 11),
(N'Huyện Cao Phong', 1, 11),
(N'Huyện Tân Lạc', 1, 11),
(N'Huyện Mai Châu', 1, 11),
(N'Huyện Lạc Sơn', 1, 11),
(N'Huyện Yên Thủy', 1, 11),
(N'Huyện Lạc Thủy', 1, 11),
(N'Thành phố Thái Nguyên', 1, 12),
(N'Thành phố Sông Công', 0, 12),
(N'Huyện Định Hóa', 1, 12),
(N'Huyện Phú Lương', 1, 12),
(N'Huyện Đồng Hỷ', 1, 12),
(N'Huyện Võ Nhai', 1, 12),
(N'Huyện Đại Từ', 1, 12),
(N'Thị xã Phổ Yên', 1, 12),
(N'Huyện Phú Bình', 1, 12),
(N'Thành phố Lạng Sơn', 1, 13),
(N'Huyện Tràng Định', 1, 13),
(N'Huyện Bình Gia', 1, 13),
(N'Huyện Văn Lãng', 1, 13),
(N'Huyện Cao Lộc', 1, 13),
(N'Huyện Văn Quan', 1, 13),
(N'Huyện Bắc Sơn', 1, 13),
(N'Huyện Hữu Lũng', 1, 13),
(N'Huyện Chi Lăng', 1, 13),
(N'Huyện Lộc Bình', 1, 13),
(N'Huyện Đình Lập', 1, 13),
(N'Thành phố Hạ Long', 0, 14),
(N'Thành phố Móng Cái', 0, 14),
(N'Thành phố Cẩm Phả', 0, 14),
(N'Thành phố Uông Bí', 0, 14),
(N'Huyện Bình Liêu', 1, 14),
(N'Huyện Tiên Yên', 1, 14),
(N'Huyện Đầm Hà', 1, 14),
(N'Huyện Hải Hà', 1, 14),
(N'Huyện Ba Chẽ', 1, 14),
(N'Huyện Vân Đồn', 1, 14),
(N'Thị xã Đông Triều', 1, 14),
(N'Thị xã Quảng Yên', 0, 14),
(N'Huyện Cô Tô', 1, 14),
(N'Thành phố Bắc Giang', 0, 15),
(N'Huyện Yên Thế', 0, 15),
(N'Huyện Tân Yên', 0, 15),
(N'Huyện Lạng Giang', 1, 15),
(N'Huyện Lục Nam', 0, 15),
(N'Huyện Lục Ngạn', 0, 15),
(N'Huyện Sơn Động', 0, 15),
(N'Huyện Yên Dũng', 0, 15),
(N'Huyện Việt Yên', 1, 15),
(N'Huyện Hiệp Hòa', 1, 15),
(N'Thành phố Việt Trì', 0, 16),
(N'Thị xã Phú Thọ', 0, 16),
(N'Huyện Đoan Hùng', 1, 16),
(N'Huyện Hạ Hoà', 1, 16),
(N'Huyện Thanh Ba', 1, 16),
(N'Huyện Phù Ninh', 1, 16),
(N'Huyện Yên Lập', 1, 16),
(N'Huyện Cẩm Khê', 1, 16),
(N'Huyện Tam Nông', 1, 16),
(N'Huyện Lâm Thao', 1, 16),
(N'Huyện Thanh Sơn', 1, 16),
(N'Huyện Thanh Thuỷ', 1, 16),
(N'Huyện Tân Sơn', 1, 16),
(N'Thành phố Vĩnh Yên', 0, 17),
(N'Thành phố Phúc Yên', 0, 17),
(N'Huyện Lập Thạch', 0, 17),
(N'Huyện Tam Dương', 0, 17),
(N'Huyện Tam Đảo', 1, 17),
(N'Huyện Bình Xuyên', 1, 17),
(N'Huyện Yên Lạc', 0, 17),
(N'Huyện Vĩnh Tường', 0, 17),
(N'Huyện Sông Lô', 0, 17),
(N'Thành phố Bắc Ninh', 0, 18),
(N'Huyện Yên Phong', 0, 18),
(N'Huyện Quế Võ', 0, 18),
(N'Huyện Tiên Du', 0, 18),
(N'Thành phố Từ Sơn', 0, 18),
(N'Huyện THuyện Thành', 0, 18),
(N'Huyện Gia Bình', 0, 18),
(N'Huyện Lương Tài', 0, 18),
(N'Thành phố Hải Dương', 0, 19),
(N'Thành phố Chí Linh', 1, 19),
(N'Huyện Nam Sách', 0, 19),
(N'Thị xã Kinh Môn', 1, 19),
(N'Huyện Kim Thành', 0, 19),
(N'Huyện Thanh Hà', 0, 19),
(N'Huyện Cẩm Giàng', 0, 19),
(N'Huyện Bình Giang', 0, 19),
(N'Huyện Gia Lộc', 0, 19),
(N'Huyện Tứ Kỳ', 0, 19),
(N'Huyện Ninh Giang', 0, 19),
(N'Huyện Thanh Miện', 0, 19),
(N'Huyện Hồng Bàng', 0, 20),
(N'Huyện Ngô Quyền', 0, 20),
(N'Huyện Lê Chân', 0, 20),
(N'Huyện Hải An', 0, 20),
(N'Huyện Kiến An', 0, 20),
(N'Huyện Đồ Sơn', 0, 20),
(N'Huyện Dương Kinh', 0, 20),
(N'Huyện Thuỷ Nguyên', 1, 20),
(N'Huyện An Dương', 0, 20),
(N'Huyện An Lão', 0, 20),
(N'Huyện Kiến Thuỵ', 0, 20),
(N'Huyện Tiên Lãng', 0, 20),
(N'Huyện Vĩnh Bảo', 0, 20),
(N'Huyện Cát Hải', 1, 20),
(N'Huyện Bạch Long Vĩ', 0, 20),
(N'Thành phố Hưng Yên', 0, 21),
(N'Huyện Văn Lâm', 0, 21),
(N'Huyện Văn Giang', 0, 21),
(N'Huyện Yên Mỹ', 0, 21),
(N'Thị xã Mỹ Hào', 0, 21),
(N'Huyện Ân Thi', 0, 21),
(N'Huyện Khoái Châu', 0, 21),
(N'Huyện Kim Động', 0, 21),
(N'Huyện Tiên Lữ', 0, 21),
(N'Huyện Phù Cừ', 0, 21),
(N'Thành phố Thái Bình', 0, 22),
(N'Huyện Quỳnh Phụ', 0, 22),
(N'Huyện Hưng Hà', 0, 22),
(N'Huyện Đông Hưng', 0, 22),
(N'Huyện Thái Thụy', 0, 22),
(N'Huyện Tiền Hải', 0, 22),
(N'Huyện Kiến Xương', 0, 22),
(N'Huyện Vũ Thư', 0, 22),
(N'Thành phố Phủ Lý', 0, 23),
(N'Thị xã Duy Tiên', 0, 23),
(N'Huyện Kim Bảng', 0, 23),
(N'Huyện Thanh Liêm', 0, 23),
(N'Huyện Bình Lục', 0, 23),
(N'Huyện Lý Nhân', 0, 23),
(N'Thành phố Nam Định', 0, 24),
(N'Huyện Mỹ Lộc', 0, 24),
(N'Huyện Vụ Bản', 0, 24),
(N'Huyện Ý Yên', 0, 24),
(N'Huyện Nghĩa Hưng', 0, 24),
(N'Huyện Nam Trực', 0, 24),
(N'Huyện Trực Ninh', 0, 24),
(N'Huyện Xuân Trường', 0, 24),
(N'Huyện Giao Thủy', 0, 24),
(N'Huyện Hải Hậu', 0, 24),
(N'Thành phố Ninh Bình', 0, 25),
(N'Thành phố Tam Điệp', 1, 25),
(N'Huyện Nho Quan', 1, 25),
(N'Huyện Gia Viễn', 1, 25),
(N'Huyện Hoa Lư', 1, 25),
(N'Huyện Yên Khánh', 0, 25),
(N'Huyện Kim Sơn', 1, 25),
(N'Huyện Yên Mô', 1, 25),
(N'Thành phố Thanh Hóa', 0, 26),
(N'Thị xã Bỉm Sơn', 0, 26),
(N'Thành phố Sầm Sơn', 0, 26),
(N'Huyện Mường Lát', 1, 26),
(N'Huyện Quan Hóa', 1, 26),
(N'Huyện Bá Thước', 1, 26),
(N'Huyện Quan Sơn', 1, 26),
(N'Huyện Lang Chánh', 1, 26),
(N'Huyện Ngọc Lặc', 1, 26),
(N'Huyện Cẩm Thủy', 1, 26),
(N'Huyện Thạch Thành', 1, 26),
(N'Huyện Hà Trung', 0, 26),
(N'Huyện Vĩnh Lộc', 0, 26),
(N'Huyện Yên Định', 0, 26),
(N'Huyện Thọ Xuân', 0, 26),
(N'Huyện Thường Xuân', 1, 26),
(N'Huyện Triệu Sơn', 0, 26),
(N'Huyện Thiệu Hóa', 0, 26),
(N'Huyện Hoằng Hóa', 0, 26),
(N'Huyện Hậu Lộc', 0, 26),
(N'Huyện Nga Sơn', 0, 26),
(N'Huyện Như Xuân', 1, 26),
(N'Huyện Như Thanh', 1, 26),
(N'Huyện Nông Cống', 0, 26),
(N'Huyện Đông Sơn', 0, 26),
(N'Huyện Quảng Xương', 0, 26),
(N'Thị xã Nghi Sơn', 1, 26),
(N'Thành phố Vinh', 0, 27),
(N'Thị xã Cửa Lò', 0, 27),
(N'Thị xã Thái Hoà', 0, 27),
(N'Huyện Quế Phong', 1, 27),
(N'Huyện Quỳ Châu', 1, 27),
(N'Huyện Kỳ Sơn', 1, 27),
(N'Huyện Tương Dương', 1, 27),
(N'Huyện Nghĩa Đàn', 1, 27),
(N'Huyện Quỳ Hợp', 1, 27),
(N'Huyện Quỳnh Lưu', 0, 27),
(N'Huyện Con Cuông', 1, 27),
(N'Huyện Tân Kỳ', 1, 27),
(N'Huyện Anh Sơn', 1, 27),
(N'Huyện Diễn Châu', 0, 27),
(N'Huyện Yên Thành', 0, 27),
(N'Huyện Đô Lương', 0, 27),
(N'Huyện Thanh Chương', 0, 27),
(N'Huyện Nghi Lộc', 0, 27),
(N'Huyện Nam Đàn', 0, 27),
(N'Huyện Hưng Nguyên', 0, 27),
(N'Thị xã Hoàng Mai', 0, 27),
(N'Thành phố Hà Tĩnh', 0, 28),
(N'Thị xã Hồng Lĩnh', 0, 28),
(N'Huyện Hương Sơn', 0, 28),
(N'Huyện Đức Thọ', 1, 28),
(N'Huyện Vũ Quang', 0, 28),
(N'Huyện Nghi Xuân', 0, 28),
(N'Huyện Can Lộc', 1, 28),
(N'Huyện Hương Khê', 0, 28),
(N'Huyện Thạch Hà', 1, 28),
(N'Huyện Cẩm Xuyên', 1, 28),
(N'Huyện Kỳ Anh', 1, 28),
(N'Huyện Lộc Hà', 1, 28),
(N'Thị xã Kỳ Anh', 1, 28),
(N'Thành Phố Đồng Hới', 0, 29),
(N'Huyện Minh Hóa', 0, 29),
(N'Huyện Tuyên Hóa', 0, 29),
(N'Huyện Quảng Trạch', 1, 29),
(N'Huyện Bố Trạch', 1, 29),
(N'Huyện Quảng Ninh', 1, 29),
(N'Huyện Lệ Thủy', 1, 29),
(N'Thị xã Ba Đồn', 1, 29),
(N'Thành phố Đông Hà', 0, 30),
(N'Thị xã Quảng Trị', 0, 30),
(N'Huyện Vĩnh Linh', 1, 30),
(N'Huyện Hướng Hóa', 0, 30),
(N'Huyện Gio Linh', 1, 30),
(N'Huyện Đa Krông', 0, 30),
(N'Huyện Cam Lộ', 1, 30),
(N'Huyện Triệu Phong', 1, 30),
(N'Huyện Hải Lăng', 1, 30),
(N'Huyện Cồn Cỏ', 0, 30),
(N'Thành phố Huế', 0, 31),
(N'Huyện Phong Điền', 1, 31),
(N'Huyện Quảng Điền', 1, 31),
(N'Huyện Phú Vang', 1, 31),
(N'Thị xã Hương Thủy', 0, 31),
(N'Thị xã Hương Trà', 1, 31),
(N'Huyện A Lưới', 0, 31),
(N'Huyện Phú Lộc', 1, 31),
(N'Huyện Nam Đông', 0, 31),
(N'Huyện Liên Chiểu', 0, 32),
(N'Huyện Thanh Khê', 0, 32),
(N'Huyện Hải Châu', 0, 32),
(N'Huyện Sơn Trà', 0, 32),
(N'Huyện Ngũ Hành Sơn', 0, 32),
(N'Huyện Cẩm Lệ', 0, 32),
(N'Huyện Hòa Vang', 0, 32),
(N'Huyện Hoàng Sa', 1, 32),
(N'Thành phố Tam Kỳ', 0, 33),
(N'Thành phố Hội An', 0, 33),
(N'Huyện Tây Giang', 0, 33),
(N'Huyện Đông Giang', 0, 33),
(N'Huyện Đại Lộc', 1, 33),
(N'Thị xã Điện Bàn', 0, 33),
(N'Huyện Duy Xuyên', 1, 33),
(N'Huyện Quế Sơn', 0, 33),
(N'Huyện Nam Giang', 0, 33),
(N'Huyện Phước Sơn', 0, 33),
(N'Huyện Hiệp Đức', 0, 33),
(N'Huyện Thăng Bình', 1, 33),
(N'Huyện Tiên Phước', 0, 33),
(N'Huyện Bắc Trà My', 0, 33),
(N'Huyện Nam Trà My', 0, 33),
(N'Huyện Núi Thành', 1, 33),
(N'Huyện Phú Ninh', 1, 33),
(N'Huyện Nông Sơn', 0, 33),
(N'Thành phố Quảng Ngãi', 0, 34),
(N'Huyện Bình Sơn', 0, 34),
(N'Huyện Trà Bồng', 1, 34),
(N'Huyện Sơn Tịnh', 0, 34),
(N'Huyện Tư Nghĩa', 0, 34),
(N'Huyện Sơn Hà', 1, 34),
(N'Huyện Sơn Tây', 1, 34),
(N'Huyện Minh Long', 1, 34),
(N'Huyện Nghĩa Hành', 0, 34),
(N'Huyện Mộ Đức', 0, 34),
(N'Thị xã Đức Phổ', 1, 34),
(N'Huyện Ba Tơ', 1, 34),
(N'Huyện Lý Sơn', 1, 34),
(N'Thành phố Quy Nhơn', 0, 35),
(N'Huyện An Lão', 1, 35),
(N'Thị xã Hoài Nhơn', 0, 35),
(N'Huyện Hoài Ân', 0, 35),
(N'Huyện Phù Mỹ', 0, 35),
(N'Huyện Vĩnh Thạnh', 1, 35),
(N'Huyện Tây Sơn', 0, 35),
(N'Huyện Phù Cát', 0, 35),
(N'Thị xã An Nhơn', 0, 35),
(N'Huyện Tuy Phước', 1, 35),
(N'Huyện Vân Canh', 1, 35),
(N'Thành phố Tuy Hoà', 0, 36),
(N'Thị xã Sông Cầu', 1, 36),
(N'Huyện Đồng Xuân', 0, 36),
(N'Huyện Tuy An', 1, 36),
(N'Huyện Sơn Hòa', 0, 36),
(N'Huyện Sông Hinh', 0, 36),
(N'Huyện Tây Hòa', 1, 36),
(N'Huyện Phú Hoà', 0, 36),
(N'Thị xã Đông Hòa', 0, 36),
(N'Thành phố Nha Trang', 0, 37),
(N'Thành phố Cam Ranh', 0, 37),
(N'Huyện Cam Lâm', 0, 37),
(N'Huyện Vạn Ninh', 1, 37),
(N'Thị xã Ninh Hòa', 0, 37),
(N'Huyện Khánh Vĩnh', 1, 37),
(N'Huyện Diên Khánh', 0, 37),
(N'Huyện Khánh Sơn', 1, 37),
(N'Huyện Trường Sa', 1, 37),
(N'Thành phố Phan Rang-Tháp Chàm', 0, 38),
(N'Huyện Bác Ái', 1, 38),
(N'Huyện Ninh Sơn', 1, 38),
(N'Huyện Ninh Hải', 0, 38),
(N'Huyện Ninh Phước', 1, 38),
(N'Huyện THuyện Bắc', 1, 38),
(N'Huyện THuyện Nam', 1, 38),
(N'Thành phố Phan Thiết', 0, 39),
(N'Thị xã La Gi', 0, 39),
(N'Huyện Tuy Phong', 1, 39),
(N'Huyện Bắc Bình', 1, 39),
(N'Huyện Hàm THuyện Bắc', 1, 39),
(N'Huyện Hàm THuyện Nam', 1, 39),
(N'Huyện Tánh Linh', 1, 39),
(N'Huyện Đức Linh', 1, 39),
(N'Huyện Hàm Tân', 1, 39),
(N'Huyện Phú Quí', 0, 39),
(N'Thành phố Kon Tum', 1, 40),
(N'Huyện Đắk Glei', 1, 40),
(N'Huyện Ngọc Hồi', 1, 40),
(N'Huyện Đắk Tô', 1, 40),
(N'Huyện Kon Plông', 1, 40),
(N'Huyện Kon Rẫy', 1, 40),
(N'Huyện Đắk Hà', 1, 40),
(N'Huyện Sa Thầy', 1, 40),
(N'Huyện Tu Mơ Rông', 1, 40),
(N'Huyện Ia HDrai', 1, 40),
(N'Thành phố Pleiku', 1, 41),
(N'Thị xã An Khê', 1, 41),
(N'Thị xã Ayun Pa', 1, 41),
(N'Huyện KBang', 1, 41),
(N'Huyện Đăk Đoa', 1, 41),
(N'Huyện Chư Păh', 1, 41),
(N'Huyện Ia Grai', 1, 41),
(N'Huyện Mang Yang', 1, 41),
(N'Huyện Kông Chro', 1, 41),
(N'Huyện Đức Cơ', 1, 41),
(N'Huyện Chư Prông', 1, 41),
(N'Huyện Chư Sê', 1, 41),
(N'Huyện Đăk Pơ', 1, 41),
(N'Huyện Ia Pa', 1, 41),
(N'Huyện Krông Pa', 1, 41),
(N'Huyện Phú Thiện', 1, 41),
(N'Huyện Chư Pưh', 1, 41),
(N'Thành phố Buôn Ma Thuột', 1, 42),
(N'Thị Xã Buôn Hồ', 1, 42),
(N'Huyện Ea Hleo', 1, 42),
(N'Huyện Ea Súp', 1, 42),
(N'Huyện Buôn Đôn', 1, 42),
(N'Huyện Cư Mgar', 1, 42),
(N'Huyện Krông Búk', 1, 42),
(N'Huyện Krông Năng', 1, 42),
(N'Huyện Ea Kar', 1, 42),
(N'Huyện MĐrắk', 1, 42),
(N'Huyện Krông Bông', 1, 42),
(N'Huyện Krông Pắc', 1, 42),
(N'Huyện Krông A Na', 1, 42),
(N'Huyện Lắk', 1, 42),
(N'Huyện Cư Kuin', 1, 42),
(N'Thành phố Gia Nghĩa', 1, 43),
(N'Huyện Đăk Glong', 1, 43),
(N'Huyện Cư Jút', 1, 43),
(N'Huyện Đắk Mil', 1, 43),
(N'Huyện Krông Nô', 1, 43),
(N'Huyện Đắk Song', 1, 43),
(N'Huyện Đắk RLấp', 1, 43),
(N'Huyện Tuy Đức', 1, 43),
(N'Thành phố Đà Lạt', 0, 44),
(N'Thành phố Bảo Lộc', 0, 44),
(N'Huyện Đam Rông', 1, 44),
(N'Huyện Lạc Dương', 1, 44),
(N'Huyện Lâm Hà', 1, 44),
(N'Huyện Đơn Dương', 1, 44),
(N'Huyện Đức Trọng', 1, 44),
(N'Huyện Di Linh', 1, 44),
(N'Huyện Bảo Lâm', 1, 44),
(N'Huyện Đạ Huoai', 1, 44),
(N'Huyện Đạ Tẻh', 1, 44),
(N'Huyện Cát Tiên', 1, 44),
(N'Thị xã Phước Long', 1, 45),
(N'Thành phố Đồng Xoài', 1, 45),
(N'Thị xã Bình Long', 1, 45),
(N'Huyện Bù Gia Mập', 1, 45),
(N'Huyện Lộc Ninh', 1, 45),
(N'Huyện Bù Đốp', 1, 45),
(N'Huyện Hớn Quản', 1, 45),
(N'Huyện Đồng Phú', 1, 45),
(N'Huyện Bù Đăng', 1, 45),
(N'Huyện Chơn Thành', 1, 45),
(N'Huyện Phú Riềng', 1, 45),
(N'Thành phố Tây Ninh', 0, 46),
(N'Huyện Tân Biên', 0, 46),
(N'Huyện Tân Châu', 1, 46),
(N'Huyện Dương Minh Châu', 0, 46),
(N'Huyện Châu Thành', 1, 46),
(N'Thị xã Hòa Thành', 0, 46),
(N'Huyện Gò Dầu', 0, 46),
(N'Huyện Bến Cầu', 1, 46),
(N'Thị xã Trảng Bàng', 0, 46),
(N'Thành phố Thủ Dầu Một', 0, 47),
(N'Huyện Bàu Bàng', 0, 47),
(N'Huyện Dầu Tiếng', 0, 47),
(N'Thị xã Bến Cát', 0, 47),
(N'Huyện Phú Giáo', 0, 47),
(N'Thị xã Tân Uyên', 0, 47),
(N'Thành phố Dĩ An', 0, 47),
(N'Thành phố THuyện An', 0, 47),
(N'Huyện Bắc Tân Uyên', 0, 47),
(N'Thành phố Biên Hòa', 0, 48),
(N'Thành phố Long Khánh', 0, 48),
(N'Huyện Tân Phú', 1, 48),
(N'Huyện Vĩnh Cửu', 0, 48),
(N'Huyện Định Quán', 1, 48),
(N'Huyện Trảng Bom', 0, 48),
(N'Huyện Thống Nhất', 0, 48),
(N'Huyện Cẩm Mỹ', 1, 48),
(N'Huyện Long Thành', 0, 48),
(N'Huyện Xuân Lộc', 1, 48),
(N'Huyện Nhơn Trạch', 0, 48),
(N'Thành phố Vũng Tàu', 0, 49),
(N'Thành phố Bà Rịa', 0, 49),
(N'Huyện Châu Đức', 1, 49),
(N'Huyện Xuyên Mộc', 0, 49),
(N'Huyện Long Điền', 0, 49),
(N'Huyện Đất Đỏ', 0, 49),
(N'Thị xã Phú Mỹ', 0, 49),
(N'Huyện Côn Đảo', 0, 49),
(N'Huyện 1', 0, 50),
(N'Huyện 12', 0, 50),
(N'Huyện Gò Vấp', 0, 50),
(N'Huyện Bình Thạnh', 0, 50),
(N'Huyện Tân Bình', 0, 50),
(N'Huyện Tân Phú', 0, 50),
(N'Huyện Phú NHuyện', 0, 50),
(N'Thành phố Thủ Đức', 0, 50),
(N'Huyện 3', 0, 50),
(N'Huyện 10', 0, 50),
(N'Huyện 11', 0, 50),
(N'Huyện 4', 0, 50),
(N'Huyện 5', 0, 50),
(N'Huyện 6', 0, 50),
(N'Huyện 8', 0, 50),
(N'Huyện Bình Tân', 0, 50),
(N'Huyện 7', 0, 50),
(N'Huyện Củ Chi', 0, 50),
(N'Huyện Hóc Môn', 0, 50),
(N'Huyện Bình Chánh', 0, 50),
(N'Huyện Nhà Bè', 0, 50),
(N'Huyện Cần Giờ', 0, 50),
(N'Thành phố Tân An', 0, 51),
(N'Thị xã Kiến Tường', 0, 51),
(N'Huyện Tân Hưng', 0, 51),
(N'Huyện Vĩnh Hưng', 0, 51),
(N'Huyện Mộc Hóa', 0, 51),
(N'Huyện Tân Thạnh', 0, 51),
(N'Huyện Thạnh Hóa', 0, 51),
(N'Huyện Đức Huệ', 0, 51),
(N'Huyện Đức Hòa', 0, 51),
(N'Huyện Bến Lức', 0, 51),
(N'Huyện Thủ Thừa', 0, 51),
(N'Huyện Tân Trụ', 0, 51),
(N'Huyện Cần Đước', 0, 51),
(N'Huyện Cần Giuộc', 0, 51),
(N'Huyện Châu Thành', 0, 51),
(N'Thành phố Mỹ Tho', 0, 52),
(N'Thị xã Gò Công', 0, 52),
(N'Thị xã Cai Lậy', 0, 52),
(N'Huyện Tân Phước', 0, 52),
(N'Huyện Cái Bè', 0, 52),
(N'Huyện Cai Lậy', 0, 52),
(N'Huyện Châu Thành', 0, 52),
(N'Huyện Chợ Gạo', 0, 52),
(N'Huyện Gò Công Tây', 0, 52),
(N'Huyện Gò Công Đông', 0, 52),
(N'Huyện Tân Phú Đông', 1, 52),
(N'Thành phố Bến Tre', 0, 53),
(N'Huyện Châu Thành', 0, 53),
(N'Huyện Chợ Lách', 0, 53),
(N'Huyện Mỏ Cày Nam', 0, 53),
(N'Huyện Giồng Trôm', 0, 53),
(N'Huyện Bình Đại', 0, 53),
(N'Huyện Ba Tri', 1, 53),
(N'Huyện Thạnh Phú', 1, 53),
(N'Huyện Mỏ Cày Bắc', 0, 53),
(N'Thành phố Trà Vinh', 0, 54),
(N'Huyện Càng Long', 0, 54),
(N'Huyện Cầu Kè', 1, 54),
(N'Huyện Tiểu Cần', 1, 54),
(N'Huyện Châu Thành', 1, 54),
(N'Huyện Cầu Ngang', 1, 54),
(N'Huyện Trà Cú', 1, 54),
(N'Huyện Duyên Hải', 1, 54),
(N'Thị xã Duyên Hải', 0, 54),
(N'Thành phố Vĩnh Long', 0, 55),
(N'Huyện Long Hồ', 0, 55),
(N'Huyện Mang Thít', 0, 55),
(N'Huyện Vũng Liêm', 0, 55),
(N'Huyện Tam Bình', 0, 55),
(N'Thị xã Bình Minh', 0, 55),
(N'Huyện Trà Ôn', 0, 55),
(N'Huyện Bình Tân', 0, 55),
(N'Thành phố Cao Lãnh', 0, 56),
(N'Thành phố Sa Đéc', 0, 56),
(N'Thành phố Hồng Ngự', 1, 56),
(N'Huyện Tân Hồng', 0, 56),
(N'Huyện Hồng Ngự', 0, 56),
(N'Huyện Tam Nông', 0, 56),
(N'Huyện Tháp Mười', 0, 56),
(N'Huyện Cao Lãnh', 0, 56),
(N'Huyện Thanh Bình', 0, 56),
(N'Huyện Lấp Vò', 0, 56),
(N'Huyện Lai Vung', 0, 56),
(N'Huyện Châu Thành', 0, 56),
(N'Thành phố Long Xuyên', 0, 57),
(N'Thành phố Châu Đốc', 0, 57),
(N'Huyện An Phú', 1, 57),
(N'Thị xã Tân Châu', 0, 57),
(N'Huyện Phú Tân', 0, 57),
(N'Huyện Châu Phú', 0, 57),
(N'Huyện Tịnh Biên', 1, 57),
(N'Huyện Tri Tôn', 1, 57),
(N'Huyện Châu Thành', 0, 57),
(N'Huyện Chợ Mới', 0, 57),
(N'Huyện Thoại Sơn', 0, 57),
(N'Thành phố Rạch Giá', 0, 58),
(N'Thành phố Hà Tiên', 0, 58),
(N'Huyện Kiên Lương', 0, 58),
(N'Huyện Hòn Đất', 0, 58),
(N'Huyện Tân Hiệp', 0, 58),
(N'Huyện Châu Thành', 0, 58),
(N'Huyện Giồng Riềng', 1, 58),
(N'Huyện Gò Quao', 1, 58),
(N'Huyện An Biên', 0, 58),
(N'Huyện An Minh', 0, 58),
(N'Huyện Vĩnh THuyện', 1, 58),
(N'Thành phố Phú Quốc', 1, 58),
(N'Huyện Kiên Hải', 1, 58),
(N'Huyện U Minh Thượng', 1, 58),
(N'Huyện Giang Thành', 1, 58),
(N'Huyện Ninh Kiều', 0, 59),
(N'Huyện Ô Môn', 0, 59),
(N'Huyện Bình Thuỷ', 0, 59),
(N'Huyện Cái Răng', 0, 59),
(N'Huyện Thốt Nốt', 0, 59),
(N'Huyện Vĩnh Thạnh', 0, 59),
(N'Huyện Cờ Đỏ', 0, 59),
(N'Huyện Phong Điền', 0, 59),
(N'Huyện Thới Lai', 0, 59),
(N'Thành phố Vị Thanh', 0, 60),
(N'Thành phố Ngã Bảy', 0, 60),
(N'Huyện Châu Thành A', 0, 60),
(N'Huyện Châu Thành', 0, 60),
(N'Huyện Phụng Hiệp', 1, 60),
(N'Huyện Vị Thuỷ', 0, 60),
(N'Huyện Long Mỹ', 1, 60),
(N'Thị xã Long Mỹ', 0, 60),
(N'Thành phố Sóc Trăng', 1, 61),
(N'Huyện Châu Thành', 1, 61),
(N'Huyện Kế Sách', 1, 61),
(N'Huyện Mỹ Tú', 1, 61),
(N'Huyện Cù Lao Dung', 1, 61),
(N'Huyện Long Phú', 1, 61),
(N'Huyện Mỹ Xuyên', 1, 61),
(N'Thị xã Ngã Năm', 1, 61),
(N'Huyện Thạnh Trị', 1, 61),
(N'Thị xã Vĩnh Châu', 1, 61),
(N'Huyện Trần Đề', 1, 61),
(N'Thành phố Bạc Liêu', 0, 62),
(N'Huyện Hồng Dân', 0, 62),
(N'Huyện Phước Long', 1, 62),
(N'Huyện Vĩnh Lợi', 0, 62),
(N'Thị xã Giá Rai', 0, 62),
(N'Huyện Đông Hải', 0, 62),
(N'Huyện Hoà Bình', 0, 62),
(N'Thành phố Cà Mau', 0, 63),
(N'Huyện U Minh', 1, 63),
(N'Huyện Thới Bình', 1, 63),
(N'Huyện Trần Văn Thời', 1, 63),
(N'Huyện Cái Nước', 1, 63),
(N'Huyện Đầm Dơi', 1, 63),
(N'Huyện Năm Căn', 0, 63),
(N'Huyện Phú Tân', 0, 63),
(N'Huyện Ngọc Hiển', 0, 63);

-- table DOITUONG
insert into DOITUONG values
(N'Không thuộc đối tượng ưu tiên', 0),
(N'Vùng sâu vùng xa', 0.3),
(N'Con thương binh', 0.5),
(N'Con liệt sĩ', 0.8);

select * from DOITUONG

-- table SINHVIEN
set dateformat dmy;
insert into SINHVIEN(MaSV, HoTen, NgaySinh, GioiTinh, MaHuyen, MaNganh) values
('SV21520007', N'Võ Thanh Bình',            '15/05/2003', N'Nam', 700, 'KHMT'),
('SV21520013', N'Trương Bá Cường',          '20/10/2003', N'Nam', 693, 'KHMT'),
('SV21520053', N'Nguyễn Hữu Hiếu',          '17/09/2003', N'Nam', 686, 'KHMT'),
('SV21520167', N'Phan Huy Tiến',            '04/08/2003', N'Nam', 679, 'KHMT'),
('SV21520179', N'Nguyễn Thành Trung',       '05/08/2003', N'Nam', 672, 'KHMT'),
('SV21520210', N'Nguyễn Minh Đức',          '06/05/2003', N'Nam', 665, 'KHMT'),
('SV21520302', N'Bế Hải Long',              '03/08/2003', N'Nam', 658, 'KHMT'),
('SV21520438', N'Phan Quốc An',             '13/04/2003', N'Nam', 651, 'KHMT'),
('SV21520608', N'Võ Minh Đôn',              '05/02/2003', N'Nam', 644, 'KHMT'),
('SV21520626', N'Trương Hữu Minh Đức',      '10/03/2003', N'Nam', 637, 'KHMT'),
('SV21521066', N'Nguyễn Xuân Luân',         '17/07/2003', N'Nam', 630, 'TTNT'),
('SV21521079', N'Nguyễn Thị Khánh Ly',      '07/12/2003', N'Nữ',  623, 'TTNT'),
('SV21521117', N'Đào Duy Từ',               '06/01/2003', N'Nam', 616, 'TTNT'),
('SV21521528', N'Nguyễn Hữu Trí',           '16/03/2003', N'Nam', 609, 'TTNT'),
('SV21521585', N'Nguyễn Xuân Tú',           '24/11/2003', N'Nam', 602, 'TTNT'),
('SV21521604', N'Nguyễn Thanh Tuấn',        '16/08/2003', N'Nam', 595, 'TTNT'),
('SV21521616', N'Lê Xuân Tùng',             '20/08/2003', N'Nam', 588, 'TTNT'),
('SV21520251', N'Nguyễn Đình Tuấn Anh',     '15/05/2003', N'Nam', 581, 'TTNT'),
('SV21520266', N'Nguyễn Minh Đức',          '22/04/2003', N'Nam', 574, 'TTNT'),
('SV21520032', N'Đôn Khánh Duy',            '30/09/2003', N'Nam', 567, 'TTNT'),
('SV21520093', N'Trần Hoàng Long',          '15/02/2003', N'Nam', 560, 'KTPM'),
('SV21521457', N'Lê Minh Thông',            '30/05/2003', N'Nam', 553, 'KTPM'),
('SV21521477', N'Nguyễn Thị Thúy',          '26/02/2003', N'Nữ',  546, 'KTPM'),
('SV21520378', N'Nguyễn Thị Thủy Tiên',     '11/06/2003', N'Nữ',  539, 'KTPM'),
('SV21521495', N'Trương Thảo Tiên',         '28/06/2003', N'Nữ',  532, 'KTPM'),
('SV21521572', N'Trần Nguyễn Quang Trường', '16/07/2003', N'Nam', 525, 'KTPM'),
('SV21521156', N'Đào Trung Nguyên',         '30/04/2003', N'Nữ',  518, 'KTPM'),
('SV21521236', N'Dương Hoài Phong',         '23/09/2003', N'Nam', 511, 'KTPM'),
('SV21521332', N'Đặng Xuân Sang',           '06/03/2003', N'Nam', 504, 'KTPM'),
('SV21521415', N'Văn Duy Thanh',            '04/09/2003', N'Nữ',  497, 'KTPM'),
('SV21520365', N'Trần Chí Thiện',           '11/02/2003', N'Nam', 490, 'KTMT'),
('SV21521544', N'Bùi Chí Trung',            '07/11/2003', N'Nam', 483, 'KTMT'),
('SV21520182', N'Nguyễn Quang Trường',      '04/04/2003', N'Nam', 476, 'KTMT'),
('SV21520423', N'Huỳnh Ngọc Thiên Ân',      '26/12/2003', N'Nam', 469, 'KTMT'),
('SV21520262', N'Phù Hữu Đạt',              '10/04/2003', N'Nam', 462, 'KTMT'),
('SV21520648', N'Nguyễn Thị Thùy Dương',    '23/08/2003', N'Nữ',  455, 'KTMT'),
('SV21520800', N'Nguyễn Hải Hưng',          '12/10/2003', N'Nam', 448, 'KTMT'),
('SV21520863', N'Nguyễn Thị Thu Huyền',     '10/05/2003', N'Nữ',  441, 'KTMT'),
('SV21520866', N'Hồ Công Huynh',            '01/03/2003', N'Nam', 434, 'KTMT'),
('SV21520879', N'Phan Tấn Nhất Khâm',       '16/03/2003', N'Nam', 427, 'KTMT'),
('SV21520099', N'Trần Xuân Mạnh',           '07/12/2003', N'Nam', 420, 'HTTT'),
('SV21521286', N'Phạm Hồ Anh Quân',         '13/02/2003', N'Nam', 413, 'HTTT'),
('SV21521520', N'Nguyễn Trần Thị Bích Trâm','27/11/2003', N'Nữ',  406, 'HTTT'),
('SV21521525', N'Vòng Thủy Thùy Trang',     '04/04/2003', N'Nữ',  399, 'HTTT'),
('SV21520190', N'Bùi Thúy Vi',              '12/11/2003', N'Nữ',  392, 'HTTT'),
('SV21520136', N'Huỳnh Bá Anh Quân',        '07/06/2003', N'Nam', 385, 'HTTT'),
('SV21520381', N'Lê Nguyễn Công Toại',      '12/04/2003', N'Nam', 378, 'HTTT'),
('SV21520591', N'Trần Tiến Đạt',            '15/03/2003', N'Nam', 371, 'HTTT'),
('SV21520597', N'Nguyễn Thị Ngọc Diễm',     '04/11/2003', N'Nữ',  364, 'HTTT'),
('SV21520984', N'Đào Quang Linh',           '07/07/2003', N'Nam', 357, 'HTTT'),
('SV21521021', N'Đinh Phạm Thiên Long',     '31/12/2003', N'Nam', 350, 'TMDT'),
('SV21521065', N'Nguyễn Tiến Luận',         '24/11/2003', N'Nam', 343, 'TMDT'),
('SV21521178', N'Nguyễn Thành Nhân',        '10/04/2003', N'Nam', 336, 'TMDT'),
('SV21521197', N'Phạm Tân Nhật',            '08/04/2003', N'Nam', 329, 'TMDT'),
('SV21521250', N'Trần Hoàng Thiên Phú',     '06/05/2003', N'Nam', 322, 'TMDT'),
('SV21521449', N'Phạm Công Thịnh',          '01/01/2003', N'Nam', 315, 'TMDT'),
('SV21521608', N'Trần Minh Tuấn',           '10/09/2003', N'Nam', 308, 'TMDT'),
('SV21520143', N'Vũ Quí San',               '01/06/2003', N'Nam', 301, 'TMDT'),
('SV21520285', N'Nguyễn Lê Hoàng Hùng',     '24/02/2003', N'Nam', 294, 'TMDT'),
('SV21520691', N'Nguyễn Thị Hà',            '05/06/2003', N'Nữ',  287, 'TMDT'),
('SV21520882', N'Dương Lê Tường Khang',     '25/09/2003', N'Nam', 280, 'TMDT'),
('SV21521247', N'Phan Lê Phú',              '15/03/2003', N'Nam', 273, 'MMT'),
('SV21521394', N'Nguyễn Hoàng Thắng',       '06/09/2003', N'Nam', 266, 'MMT'),
('SV21521596', N'Huỳnh Minh Tuấn',          '19/10/2003', N'Nam', 259, 'MMT'),
('SV21520035', N'Nguyễn Hoàng Khánh Duy',   '19/12/2003', N'Nam', 252, 'MMT'),
('SV21520102', N'Phạm Nhật Minh',           '29/11/2003', N'Nam', 245, 'MMT'),
('SV21520135', N'Nguyễn Thị Phương',        '07/01/2003', N'Nữ',  238, 'MMT'),
('SV21520270', N'Hoàng Thị Ánh Dương',      '15/03/2003', N'Nữ',  231, 'MMT'),
('SV21520291', N'Liêu Gia Khánh',           '24/04/2003', N'Nam', 224, 'MMT'),
('SV21520574', N'Nguyễn Quốc Đạt',          '26/08/2003', N'Nam', 217, 'MMT'),
('SV21520596', N'Nguyễn Thị Bích Diễm',     '20/10/2003', N'Nữ',  210, 'MMT'),
('SV21520723', N'Nguyễn Thị Thu Hiền',      '21/05/2003', N'Nữ',  203, 'MMT'),
('SV21520747', N'Nguyễn Minh Hiếu',         '29/09/2003', N'Nam', 196, 'ATTT'),
('SV21520834', N'Lê Quốc Huy',              '03/05/2003', N'Nam', 189, 'ATTT'),
('SV21520894', N'Nguyễn Thịnh Khang',       '14/12/2003', N'Nam', 182, 'ATTT'),
('SV21521074', N'Ngân Văn Luyện',           '14/09/2003', N'Nam', 175, 'ATTT'),
('SV21521251', N'Đinh Ngọc Phúc',           '22/01/2003', N'Nam', 168, 'ATTT'),
('SV21521292', N'Đoàn Minh Quang',          '11/06/2003', N'Nam', 161, 'ATTT'),
('SV21521300', N'Nguyễn Nhật Quang',        '07/11/2003', N'Nam', 154, 'ATTT'),
('SV21521312', N'Tống Đình Quốc',           '10/10/2003', N'Nam', 147, 'ATTT'),
('SV21521399', N'Trần Quốc Thắng',          '04/09/2003', N'Nam', 140, 'ATTT'),
('SV21521487', N'Nguyễn Hữu Tiến',          '13/11/2003', N'Nam', 133, 'ATTT'),
('SV21521511', N'Phạm Đức Toàn',            '07/01/2003', N'Nam', 126, 'ATTT'),
('SV21521514', N'Vũ Đức Tới',               '20/03/2003', N'Nam', 119, 'CNTT'),
('SV21521581', N'Mai Xuân Tú',              '10/01/2003', N'Nam', 112, 'CNTT'),
('SV21521586', N'Phạm Anh Tú',              '07/08/2003', N'Nam', 105, 'CNTT'),
('SV21521645', N'Đỗ Quốc Vinh',				'19/10/2003', N'Nam', 98,  'CNTT'),
('SV21521695', N'Trần Huy Thắng',			'31/07/2003', N'Nam', 91,  'CNTT'),
('SV21520570', N'Lê Phan Thành Đạt',		'20/07/2003', N'Nam', 84,  'CNTT'),
('SV21520641', N'Võ Thành Trung Dũng',		'25/05/2003', N'Nam', 77,  'CNTT'),
('SV21520711', N'Dương Thị Hồng Hạnh',		'19/10/2003', N'Nữ',  70,  'CNTT'),
('SV21520714', N'Huỳnh Nhật Hào',			'30/09/2003', N'Nam', 63,  'CNTT'),
('SV21520754', N'Trần Trung Hiếu',			'05/04/2003', N'Nam', 56,  'KHDL'),
('SV21520758', N'Võ Trung Hiếu',			'12/11/2003', N'Nam', 49,  'KHDL'),
('SV21520767', N'Võ Kiều Hoa',				'20/03/2003', N'Nữ',  42,  'KHDL'),
('SV21520938', N'Trần Nguyễn Anh Khoa',		'24/02/2003', N'Nam', 35,  'KHDL'),
('SV21521046', N'Nguyễn Thiên Long',		'26/11/2003', N'Nam', 28,  'KHDL'),
('SV21521176', N'Nguyễn Hoàng Nhân',		'02/09/2003', N'Nam', 21,  'KHDL'),
('SV21521227', N'Trịnh Ngọc Pháp',			'04/03/2003', N'Nam', 14,  'KHDL'),
('SV21521384', N'Nguyễn Thị Thắm',			'24/11/2003', N'Nữ',  7,   'KHDL'),
('SV21521470', N'Nguyễn Quang Thuận',		'21/04/2003', N'Nam', 443, 'KHDL'),
('SV21521636', N'Nguyễn Thanh Tường Vi',	'15/11/2003', N'Nữ',  668, 'KHDL');

-- table SINHVIEN_DOITUONG
insert into SINHVIEN_DOITUONG(MaSV, MaDT) values 
('SV21520007', 1),
('SV21520007', 3),
('SV21520013', 1),
('SV21520053', 1),
('SV21520167', 1),
('SV21520179', 1),
('SV21520210', 1),
('SV21520302', 1),
('SV21520438', 1),
('SV21520608', 1),
('SV21520626', 1),
('SV21521066', 1),
('SV21521079', 1),
('SV21521117', 1),
('SV21521528', 1),
('SV21521585', 1),
('SV21521604', 1),
('SV21521616', 1),
('SV21520251', 1),
('SV21520266', 1),
('SV21520032', 1),
('SV21520093', 1),
('SV21521457', 1),
('SV21521477', 1),
('SV21521477', 4),
('SV21520378', 1),
('SV21521495', 1),
('SV21521495', 3),
('SV21521572', 1),
('SV21521572', 3),
('SV21521156', 1),
('SV21521236', 1),
('SV21521332', 1),
('SV21521415', 1),
('SV21520365', 1),
('SV21521544', 1),
('SV21520182', 1),
('SV21520423', 1),
('SV21520423', 3),
('SV21520262', 1),
('SV21520648', 1),
('SV21520800', 1),
('SV21520863', 1),
('SV21520863', 4),
('SV21520866', 1),
('SV21520879', 1),
('SV21520099', 1),
('SV21521286', 1),
('SV21521520', 1),
('SV21521525', 1),
('SV21520190', 1),
('SV21520136', 1),
('SV21520381', 1),
('SV21520591', 1),
('SV21520597', 1),
('SV21520984', 1),
('SV21520984', 3),
('SV21521021', 1),
('SV21521065', 1),
('SV21521178', 1),
('SV21521197', 1),
('SV21521250', 1),
('SV21521449', 1),
('SV21521449', 3),
('SV21521608', 1),
('SV21520143', 1),
('SV21520285', 1),
('SV21520691', 1),
('SV21520882', 1),
('SV21521247', 1),
('SV21521394', 1),
('SV21521596', 1),
('SV21520035', 1),
('SV21520102', 1),
('SV21520135', 1),
('SV21520270', 1),
('SV21520291', 1),
('SV21520574', 1),
('SV21520596', 1),
('SV21520723', 1),
('SV21520747', 1),
('SV21520834', 1),
('SV21520894', 1),
('SV21521074', 1),
('SV21521251', 1),
('SV21521292', 1),
('SV21521300', 1),
('SV21521312', 1),
('SV21521399', 1),
('SV21521487', 1),
('SV21521511', 1),
('SV21521514', 1),
('SV21521581', 1),
('SV21521586', 1),
('SV21521645', 1),
('SV21521695', 1),
('SV21520570', 1),
('SV21520641', 1),
('SV21520711', 1),
('SV21520714', 1),
('SV21520754', 1),
('SV21520754', 3),
('SV21520758', 1),
('SV21520767', 1),
('SV21520938', 1),
('SV21521046', 1),
('SV21521176', 1),
('SV21521227', 1),
('SV21521384', 1),
('SV21521470', 1),
('SV21521470', 4),
('SV21521636', 1);

update SINHVIEN_DOITUONG 
set MaDT = 2
where MaDT = 1
and MaSV in
(
	select MaSV
	from SINHVIEN, HUYEN
	where SINHVIEN.MaHuyen = HUYEN.MaHuyen
	and HUYEN.VungUT = 1
);

-- table LOAIMONHOC
insert into LOAIMONHOC values 
(N'Lý thuyết', 15, 27000), 
(N'Thực hành', 30, 37000);

-- table MONHOC
-- Ba81t buộc
insert into MONHOC values ('IT001.LT', N'Nhập môn lập trình (LT)', 1, 45);
insert into MONHOC values ('IT001.TH', N'Nhập môn lập trình (TH)', 2, 30);
insert into MONHOC values ('IT002.LT', N'Lập trình hướng đối tượng (LT)', 1, 45);
insert into MONHOC values ('IT002.TH', N'Lập trình hướng đối tượng (TH)', 2, 30);
insert into MONHOC values ('IT003.LT', N'Cấu trúc dữ liệu và giải thuật (LT)', 1, 45);
insert into MONHOC values ('IT003.TH', N'Cấu trúc dữ liệu và giải thuật (TH)', 2, 30);
insert into MONHOC values ('IT004.LT', N'Cơ sở dữ liệu (LT)', 1, 45);
insert into MONHOC values ('IT004.TH', N'Cơ sở dữ liệu (TH)', 2, 30);
insert into MONHOC values ('IT005.LT', N'Nhập môn mạng máy tính (LT)', 1, 45);
insert into MONHOC values ('IT005.TH', N'Nhập môn mạng máy tính (TH)', 2, 30);
insert into MONHOC values ('IT006', N'Kiến trúc máy tính', 1, 45);
insert into MONHOC values ('IT007.LT', N'Hệ điều hành', 1, 45);
insert into MONHOC values ('IT007.TH', N'Hệ điều hành', 2, 30);
insert into MONHOC values ('IT008.LT', N'Lập trình trực quan (LT)', 1, 45);
insert into MONHOC values ('IT008.TH', N'Lập trình trực quan (TH)', 2, 30);
insert into MONHOC values ('IT010', N'Tổ chức và cấu trúc máy tính', 1, 30);
insert into MONHOC values ('IT012.LT', N'Tổ chức và cấu trúc máy tính II', 1, 45);
insert into MONHOC values ('IT012.TH', N'Tổ chức và cấu trúc máy tính II', 2, 30);

insert into MONHOC values ('MA003', N'Đại số tuyến tính', 1, 45);
insert into MONHOC values ('MA004', N'Cấu trúc rời rạc', 1, 60);
insert into MONHOC values ('MA005', N'Xác suất thống kê', 1, 45);
insert into MONHOC values ('MA006', N'Giải tích', 1, 60);

insert into MONHOC values ('SS003', N'Tư tưởng Hồ Chí Minh', 1, 30);
insert into MONHOC values ('SS004', N'Kỹ năng nghề nghiệp', 1, 30);
insert into MONHOC values ('SS006', N'Pháp luật đại cương', 1, 30);
insert into MONHOC values ('SS007', N'Triết học Mác - Lênin', 1, 45);
insert into MONHOC values ('SS008', N'Kinh tế chính trị Mác - Lênin', 1, 30);
insert into MONHOC values ('SS009', N'Chủ nghĩa xã hội khoa học', 1, 30);
insert into MONHOC values ('SS010', N'Lịch sử Đảng Cộng sản Việt Nam', 1, 30);

insert into MONHOC values ('IE005', N'Giới thiệu ngành Công nghệ Thông tin', 1, 15);
insert into MONHOC values ('IE101.LT', N'Cơ sở hạ tầng công nghệ thông tin (LT)', 1, 30);
insert into MONHOC values ('IE101.TH', N'Cơ sở hạ tầng công nghệ thông tin (TH)', 2, 30);
insert into MONHOC values ('IE103.LT', N'Quản lý thông tin (LT)', 1, 45);
insert into MONHOC values ('IE103.TH', N'Quản lý thông tin (TH)', 2, 30);
insert into MONHOC values ('IE104.LT', N'Internet và công nghệ Web (LT)', 1, 45);
insert into MONHOC values ('IE104.TH', N'Internet và công nghệ Web (TH)', 2, 30);
insert into MONHOC values ('IE105.LT', N'Nhập môn đảm bảo và an ninh thông tin (LT)', 1, 45);
insert into MONHOC values ('IE105.TH', N'Nhập môn đảm bảo và an ninh thông tin (TH)', 1, 45);
insert into MONHOC values ('IE106.LT', N'Thiết kế giao diện người dùng (LT)', 1, 45);
insert into MONHOC values ('IE106.TH', N'Thiết kế giao diện người dùng (TH)', 2, 30);
insert into MONHOC values ('IE108.LT', N'Phân tích thiết kế phần mềm (LT)', 1, 45);
insert into MONHOC values ('IE108.TH', N'Phân tích thiết kế phần mềm (TH)', 2, 30);
insert into MONHOC values ('IE207', N'Đồ án', 2, 60);
insert into MONHOC values ('IE505', N'Khóa luận tốt nghiệp', 1, 150);

insert into MONHOC values ('IS005', N'Giới thiệu ngành hệ thống thông tin', 1, 15);
insert into MONHOC values ('IS201.LT', N'Phân tích thiết kế hệ thống thông tin (LT)', 1, 45);
insert into MONHOC values ('IS201.TH', N'Phân tích thiết kế hệ thống thông tin (TH)', 2, 30);
insert into MONHOC values ('IS207.LT', N'Phát triển ứng dụng web (LT)', 1, 45);
insert into MONHOC values ('IS207.TH', N'Phát triển ứng dụng web (TH)', 2, 30);
insert into MONHOC values ('IS208.LT', N'Quản lý dự án công nghệ thông tin (LT)', 1, 45);
insert into MONHOC values ('IS208.TH', N'Quản lý dự án công nghệ thông tin (TH)', 2, 30);
insert into MONHOC values ('IS210.LT', N'Hệ quản trị cơ sở dữ liệu (LT)', 1, 45);
insert into MONHOC values ('IS210.TH', N'Hệ quản trị cơ sở dữ liệu (TH)', 2, 30);
insert into MONHOC values ('IS211.LT', N'Cơ sở dữ liệu phân tán (LT)', 1, 45);
insert into MONHOC values ('IS211.TH', N'Cơ sở dữ liệu phân tán (TH)', 2, 30);
insert into MONHOC values ('IS216.LT', N'Lập trình Java (LT)', 1, 45);
insert into MONHOC values ('IS216.TH', N'Lập trình Java (TH)', 2, 30);
insert into MONHOC values ('IS217', N'Kho dữ liệu và OLAP', 1, 45);
insert into MONHOC values ('IS252.LT', N'Khai thác dữ liệu (LT)', 1, 25);
insert into MONHOC values ('IS252.TH', N'Khai thác dữ liệu (TH)', 2, 30);
insert into MONHOC values ('IS334', N'Thương mại điện tử', 1, 45);
insert into MONHOC values ('IS336.LT', N'Hoạch định nguồn lực doanh nghiệp (LT)', 1, 45);
insert into MONHOC values ('IS336.TH', N'Hoạch định nguồn lực doanh nghiệp (TH)', 2, 30);
insert into MONHOC values ('IS401', N'Khóa luận tốt nghiệp', 1, 150);
insert into MONHOC values ('IS403', N'Phân tích dữ liệu kinh doanh', 1, 45);
insert into MONHOC values ('IS405.LT', N'Dữ liệu lớn (LT)', 1, 45);
insert into MONHOC values ('IS405.TH', N'Dữ liệu lớn (TH)', 2, 30);
insert into MONHOC values ('IS502', N'Thực tập doanh nghiệp', 1, 30);

insert into MONHOC values ('CS005', N'Giới thiệu ngành Khoa học máy tính', 1, 15);
insert into MONHOC values ('CS106.LT', N'Trí tuệ nhân tạo (LT)', 1, 45);
insert into MONHOC values ('CS106.TH', N'Trí tuệ nhân tạo (TH)', 2, 30);
insert into MONHOC values ('CS112.LT', N'Phân tích và thiết kế thuật toán (LT)', 1, 45);
insert into MONHOC values ('CS112.TH', N'Phân tích và thiết kế thuật toán (TH)', 2, 30);
insert into MONHOC values ('CS114.LT', N'Máy học (LT)', 1, 45);
insert into MONHOC values ('CS114.TH', N'Máy học (TH)', 2, 30);
insert into MONHOC values ('CS115', N'Toán cho Khoa học máy tính', 1, 60);
insert into MONHOC values ('CS505', N'Khóa luận tốt nghiệp', 1, 150);

insert into MONHOC values ('AI001', N'Giới thiệu ngành trí tuệ nhân tạo', 1, 15);
insert into MONHOC values ('AI002.LT', N'Tư duy trí tuệ nhân tạo (LT)', 1, 45);
insert into MONHOC values ('AI002.TH', N'Tư duy trí tuệ nhân tạo (TH)',2, 30);

insert into MONHOC values ('SE005', N'Giới thiệu ngành Kỹ thuật Phần mềm', 1, 15);
insert into MONHOC values ('SE100.LT', N'Phương pháp Phát triển phần mềm hướng đối tượng (LT)', 1, 45);
insert into MONHOC values ('SE100.TH', N'Phương pháp Phát triển phần mềm hướng đối tượng (TH)', 2, 30);
insert into MONHOC values ('SE104.LT', N'Nhập môn Công nghệ phần mềm (LT)', 1, 45);
insert into MONHOC values ('SE104.TH', N'Nhập môn Công nghệ phần mềm (TH)', 2, 30);
insert into MONHOC values ('SE121', N'Đồ án 1', 1, 30);
insert into MONHOC values ('SE122', N'Đồ án 2', 1, 30);
insert into MONHOC values ('SE501', N'Thực tập tốt nghiệp', 1, 30);
insert into MONHOC values ('SE505', N'Khóa luận tốt nghiệp', 1, 150);

insert into MONHOC values ('CE005', N'Giới thiệu ngành Kỹ Thuật Máy tính', 1, 15);
insert into MONHOC values ('CE103.LT', N'Vi xử lý - vi điều khiển (LT)', 1, 45);
insert into MONHOC values ('CE103.TH', N'Vi xử lý - vi điều khiển (TH)', 2, 30);
insert into MONHOC values ('CE118.LT', N'Thiết kế luận lý số (LT)', 1, 45);
insert into MONHOC values ('CE118.TH', N'Thiết kế luận lý số (TH)', 1, 45);
insert into MONHOC values ('CE119', N'Thực hành Kiến trúc máy tính', 1, 15);
insert into MONHOC values ('CE121.LT', N'Lý thuyết mạch điện (LT)', 1, 45);
insert into MONHOC values ('CE121.TH', N'Lý thuyết mạch điện (TH)', 2, 30);
insert into MONHOC values ('CE124.LT', N'Các thiết bị và mạch điện tử (LT)', 1, 45);
insert into MONHOC values ('CE124.TH', N'Các thiết bị và mạch điện tử (TH)', 2, 30);
insert into MONHOC values ('CE201', N'Đồ án 1', 1, 30);
insert into MONHOC values ('CE206', N'Đồ án 2', 1, 30);
insert into MONHOC values ('CE213.LT', N'Thiết kế hệ thống số với HDL (LT)', 1, 45);
insert into MONHOC values ('CE213.TH', N'Thiết kế hệ thống số với HDL (TH)', 2, 30);
insert into MONHOC values ('CE224.LT', N'Thiết kế hệ thống nhúng (LT)', 1, 45);
insert into MONHOC values ('CE224.TH', N'Thiết kế hệ thống nhúng (TH)', 2, 30);
insert into MONHOC values ('CE502', N'Thực tập doanh nghiệp', 1, 30);
insert into MONHOC values ('CE505', N'Khóa luận tốt nghiệp', 1, 150);

insert into MONHOC values ('NT005', N'Giới thiệu ngành Mạng máy tính và Truyền thông dữ liệu', 1, 15);
insert into MONHOC values ('NT015', N'Giới thiệu ngành An toàn thông tin', 1, 15);
insert into MONHOC values ('NT101.LT', N'An toàn mạng máy tính (LT)', 1, 45);
insert into MONHOC values ('NT101.TH', N'An toàn mạng máy tính (TH)', 2, 30);
insert into MONHOC values ('NT105.LT', N'Truyền dữ liệu (LT)', 1, 45);
insert into MONHOC values ('NT105.TH', N'Truyền dữ liệu (TH)', 2, 30);
insert into MONHOC values ('NT106.LT', N'Lập trình mạng căn bản (LT)', 1, 30);
insert into MONHOC values ('NT106.TH', N'Lập trình mạng căn bản (TH)', 2, 30);
insert into MONHOC values ('NT113.LT', N'Thiết kế mạng (LT)', 1, 30);
insert into MONHOC values ('NT113.TH', N'Thiết kế mạng (TH)', 2, 30);
insert into MONHOC values ('NT114', N'Đồ án chuyên ngành', 1, 30);
insert into MONHOC values ('NT118.LT', N'Phát triển ứng dụng trên thiết bị di động (LT)', 1, 30);
insert into MONHOC values ('NT118.TH', N'Phát triển ứng dụng trên thiết bị di động (TH)', 2, 30);
insert into MONHOC values ('NT131.LT', N'Hệ thống nhúng Mạng không dây (LT)', 1, 45);
insert into MONHOC values ('NT131.TH', N'Hệ thống nhúng Mạng không dây (TH)', 2, 30);
insert into MONHOC values ('NT132.LT', N'Quản trị mạng và hệ thống (LT)', 1, 45);
insert into MONHOC values ('NT132.TH', N'Quản trị mạng và hệ thống (TH)', 2, 30);
insert into MONHOC values ('NT208.LT', N'Lập trình ứng dụng web (LT)', 1, 30);
insert into MONHOC values ('NT208.TH', N'Lập trình ứng dụng web (TH)', 2, 30);
insert into MONHOC values ('NT209.LT', N'Lập trình hệ thông (LT)', 1, 30);
insert into MONHOC values ('NT209.TH', N'Lập trình hệ thông (TH)', 2, 30);
insert into MONHOC values ('NT215', N'Thực tập doanh nghiệp', 1, 30);
insert into MONHOC values ('NT219.LT', N'Mật mã học (LT)', 1, 30);
insert into MONHOC values ('NT219.TH', N'Mật mã học (TH)', 2, 30);
insert into MONHOC values ('NT230.LT', N'Cơ chế hoạt động của mã độc (LT)', 1, 30);
insert into MONHOC values ('NT230.TH', N'Cơ chế hoạt động của mã độc (TH)', 2, 30);
insert into MONHOC values ('NT505', N'Khóa luận tốt nghiệp', 1, 150);
insert into MONHOC values ('NT521.LT', N'Lập trình an toàn và khai thác lỗ hổng phần mềm (LT)', 1, 45);
insert into MONHOC values ('NT521.TH', N'Lập trình an toàn và khai thác lỗ hổng phần mềm (TH)', 2, 30);

insert into MONHOC values ('EC001', N'Kinh tế học đại cương', 1, 60);
insert into MONHOC values ('EC005', N'Giới thiệu ngành Thương mai Điện tử', 1, 15);
insert into MONHOC values ('EC101', N'Marketing căn bản', 1, 45);
insert into MONHOC values ('EC201.LT', N'Phân tích thiết kế quy trình nghiệp vụ doanh nghiệp (LT)', 1, 45);
insert into MONHOC values ('EC201.TH', N'Phân tích thiết kế quy trình nghiệp vụ doanh nghiệp (TH)', 2, 30);
insert into MONHOC values ('EC204.LT', N'Marketing điện tử (LT)', 1, 30);
insert into MONHOC values ('EC204.TH', N'Marketing điện tử (TH)', 2, 30);
insert into MONHOC values ('EC208', N'Quản trị dự án TMĐT', 1, 45);
insert into MONHOC values ('EC213.LT', N'Quản trị quan hệ khách hàng và nhà cung cấp (LT)', 1, 30);
insert into MONHOC values ('EC213.TH', N'Quản trị quan hệ khách hàng và nhà cung cấp (TH)', 2, 30);
insert into MONHOC values ('EC222', N'Thực tập doanh nghiệp', 1, 30);
insert into MONHOC values ('EC229', N'Pháp luật trong thương mai điện tử', 1, 30);
insert into MONHOC values ('EC312.LT', N'Thiết kế hệ thống thương mại điện tử (LT)', 1, 30);
insert into MONHOC values ('EC312.TH', N'Thiết kế hệ thống thương mại điện tử (TH)', 2, 30);
insert into MONHOC values ('EC335', N'An toán và bảo mật thương mại điện tử', 1, 45);
insert into MONHOC values ('EC337', N'Hệ thống thanh toán trực tuyến', 1, 45);
insert into MONHOC values ('EC401', N'Khóa luận tốt nghiệp', 1, 150);

insert into MONHOC values ('DS005', N'Giới thiệu ngành Khoa học Dữ liệu', 1, 15);
insert into MONHOC values ('DS101.LT', N'Thống kế và xác suất chuyên sâu (LT)', 1, 30);
insert into MONHOC values ('DS101.TH', N'Thống kế và xác suất chuyên sâu (TH)', 2, 30);
insert into MONHOC values ('DS102.LT', N'Học máy thống kê (LT)', 1, 45);
insert into MONHOC values ('DS102.TH', N'Học máy thống kê (TH)', 2, 30);
insert into MONHOC values ('DS103.LT', N'Thu thập và tiền xử lý dữ liệu (LT)', 1, 45);
insert into MONHOC values ('DS103.TH', N'Thu thập và tiền xử lý dữ liệu (TH)', 2, 30);
insert into MONHOC values ('DS105.LT', N'Phân tích và trực quan dữ liệu (LT)', 1, 45);
insert into MONHOC values ('DS105.TH', N'Phân tích và trực quan dữ liệu (TH)', 2, 30);
insert into MONHOC values ('DS107.LT', N'Tư duy tính toán cho khoa học dữ liệu (LT)', 1, 45);
insert into MONHOC values ('DS107.TH', N'Tư duy tính toán cho khoa học dữ liệu (TH)', 2, 30);
insert into MONHOC values ('DS207', N'Đồ án', 2, 30);
insert into MONHOC values ('DS505', N'Khóa luận tốt nghiệp', 1, 150);

insert into MONHOC values ('PH002.LT', N'Nhập môn mạch số (LT)', 1, 45);
insert into MONHOC values ('PH002.TH', N'Nhập môn mạch số (TH)', 2, 30);

insert into MONHOC values ('ENG01', N'Anh văn 1', 1, 60);
insert into MONHOC values ('ENG02', N'Anh văn 2', 1, 60);
insert into MONHOC values ('ENG03', N'Anh văn 3', 1, 60);

insert into MONHOC values ('ME001', N'Giáo dục quốc phòng', 1, 60);

insert into MONHOC values ('PE001', N'Giáo dục thể chất 1', 2, 0);
insert into MONHOC values ('PE002', N'Giáo dục thể chất 2', 2, 0);
insert into MONHOC values ('PE012', N'Giáo dục thể chất', 2, 0);

-------------------------------------------------------------------------
-- Tự chọn
insert into MONHOC values ('CE101', N'Lý thuyết mạch điện', 1, 45);
insert into MONHOC values ('CE102', N'Hệ thống số', 2, 60);
insert into MONHOC values ('CE104', N'Các thiết bị và mạch điện tử', 2, 30);
insert into MONHOC values ('CE105', N'Xử lý tín hiệu số', 1, 30);
insert into MONHOC values ('CE106', N'Thiết kế mạch với HDL', 1, 45);
insert into MONHOC values ('CE107', N'Hệ thống nhúng', 2, 30);
insert into MONHOC values ('CE108', N'Hệ điều hành nâng cao', 2, 30);
insert into MONHOC values ('CE109', N'Lập trình nhúng căn bản', 2, 60);
insert into MONHOC values ('CE110', N'Lập trình hệ thống với Java', 1, 45);
insert into MONHOC values ('CE111', N'Kiến trúc máy tính nâng cao', 1, 45);
insert into MONHOC values ('CE112', N'Đồ án môn học thiết kế mạch', 1, 15);
insert into MONHOC values ('CE113', N'Điều khiển tự động', 1, 60);
insert into MONHOC values ('CE114', N'Lập trình trên thiết bị di động', 1, 45);
insert into MONHOC values ('CE115', N'Thiết kế mạng', 2, 30);
insert into MONHOC values ('CE116', N'Đồ án môn học ngành KTMT', 2, 60);
insert into MONHOC values ('CE117', N'Thực hành điện - điện tử', 2, 30);
insert into MONHOC values ('CE212', N'Điều khiển tự động', 1, 45);
insert into MONHOC values ('CS003', N'Máy học nâng cao', 1, 45);
insert into MONHOC values ('CS004', N'Máy học trong xử lý ngôn ngữ tự nhiên', 1, 45);
insert into MONHOC values ('CS101', N'Nguyên lý và phương pháp lập trình', 1, 45);
insert into MONHOC values ('CS102', N'Phân tích và thiết kế thuật toán', 1, 45);
insert into MONHOC values ('CS103', N'Cơ sở lập trình', 1, 60);
insert into MONHOC values ('CS105', N'Đồ họa máy tính', 2, 30);
insert into MONHOC values ('CS107', N'Các hệ cơ sở tri thức', 1, 60);
insert into MONHOC values ('CS108', N'Lý thuyết thông tin', 1, 45);
insert into MONHOC values ('CS109', N'Máy học', 1, 60);
insert into MONHOC values ('CS110', N'Nhập môn công nghệ tri thức và máy học', 1, 45);
insert into MONHOC values ('CS113', N'Đồ họa máy tính và xử lý ảnh', 2, 30);
insert into MONHOC values ('CS116', N'Lập trình Python cho máy học', 2, 30);
insert into MONHOC values ('CS117', N'Tư duy tính toán', 1, 30);
insert into MONHOC values ('CS211', N'Trí tuệ nhân tạo nâng cao', 1, 45);
insert into MONHOC values ('CS214', N'Biểu diễn tri thức và suy luận', 2, 60);
insert into MONHOC values ('DS104', N'Tính toán song song và phân tán', 1, 45);
insert into MONHOC values ('DS106', N'Tối ưu hóa ứng dụng', 1, 30);
insert into MONHOC values ('DS200', N'Phân tích dữ liệu lớn', 2, 30);
insert into MONHOC values ('DS201', N'Deep learning trong khoa học dữ liệu', 1, 45);
insert into MONHOC values ('DS202', N'Đồ án khoa học dữ liệu và ứng dụng 1', 2, 60);
insert into MONHOC values ('DS203', N'Đồ án khoa học dữ liệu và ứng dụng 2', 2, 60);
insert into MONHOC values ('DS204', N'Đồ án khoa học dữ liệu và ứng dụng', 2, 30);
insert into MONHOC values ('DS300', N'Hệ khuyến nghị', 1, 45);
insert into MONHOC values ('DS301', N'Các giải thuậ khai phá dữ liệu lớn', 2, 30);
insert into MONHOC values ('DS302', N'Phân tích thống kê đa biến', 1, 30);
insert into MONHOC values ('DS303', N'Thống kê Bayes', 1, 30);
insert into MONHOC values ('DS304', N'Thiết kế và phân tích thực nghiệm', 1, 45);
insert into MONHOC values ('DS305', N'Phân tích dữ liệu chuỗi thời gian và ứng dụng', 1, 30);
insert into MONHOC values ('DS306', N'Phân tích dữ liệu lớn trong tài chính', 1, 45);
insert into MONHOC values ('DS307', N'Phân tích dữ liệu truyền thông xã hội', 1, 45);
insert into MONHOC values ('EC002', N'Quản trị doanh nghiệp', 1, 45);
insert into MONHOC values ('EC003', N'Tiếp thị căn bản', 1, 45);
insert into MONHOC values ('EC214', N'Nhập môn quản trị chuỗi cung ứng', 1, 45);
insert into MONHOC values ('EC232', N'Nguyên lý kế toán', 1, 45);
insert into MONHOC values ('EC304', N'Tối ưu hóa công cụ tìm kiếm trong Thương mại điện tử', 1, 45);
insert into MONHOC values ('EC311', N'Tiếp thị trực tuyến', 2, 30);
insert into MONHOC values ('EC331', N'Quản trị chiến lược kinh doanh điện tử', 1, 45);
insert into MONHOC values ('EC332', N'Quản trị sản xuất', 1, 45);
insert into MONHOC values ('EC333', N'Quản trị tài chính doanh nghiệp', 1, 45);
insert into MONHOC values ('EC334', N'Quản trị kênh phân phối', 1, 45);
insert into MONHOC values ('EC336', N'Quản trị nhân lực', 1, 45);
insert into MONHOC values ('EC338', N'Quản trị bán hàng', 1, 45);
insert into MONHOC values ('EC402', N'Phát triển ứng dụng thương mại điện tử', 2, 30);
insert into MONHOC values ('EC403', N'Thương mại xã hội', 1, 45);
insert into MONHOC values ('ENGA1', N'Anh văn sơ cấp 1', 1, 15);
insert into MONHOC values ('ENGA2', N'Anh văn sơ cấp 2', 1, 15);
insert into MONHOC values ('ENG04', N'Anh văn 4', 1, 60);
insert into MONHOC values ('ENG05', N'Anh văn 5', 1, 60);
insert into MONHOC values ('ENG06', N'Anh văn 6', 1, 60);
insert into MONHOC values ('ENG07', N'Anh văn 7', 1, 60);
insert into MONHOC values ('IE102', N'Các công nghệ nền', 2, 30);
insert into MONHOC values ('IE201', N'Xử lý dữ liệu thống kê', 1, 45);
insert into MONHOC values ('IE202', N'Quản trị doanh nghiệp', 1, 45);
insert into MONHOC values ('IE203', N'Hệ thống quản trị quy trình nghiệp vụ', 1, 45);
insert into MONHOC values ('IE204', N'Tối ưu hóa công cụ tìm kiếm', 2, 30);
insert into MONHOC values ('IE205', N'Xử lý ảnh vệ tinh', 1, 45);
insert into MONHOC values ('IE206', N'Đồ án chuẩn bị tốt nghiệp', 2, 60);
insert into MONHOC values ('IE209', N'Công nghệ Java', 1, 45);
insert into MONHOC values ('IE212', N'Công nghệ Dữ liệu lớn', 1, 45);
insert into MONHOC values ('IE213', N'Kỹ thuật phát triển hệ thống web', 2, 30);
insert into MONHOC values ('IE216', N'Các chủ đề toán học cho KHDL', 1, 45);
insert into MONHOC values ('IE218', N'Xử lý dữ liệu lớn', 1, 45);
insert into MONHOC values ('IE221', N'Kỹ thuật lập trình Python', 2, 60);
insert into MONHOC values ('IS105', N'Hệ quản trị cơ sở dữ liệu Oracle', 1, 45);
insert into MONHOC values ('IS212', N'Công nghệ dữ liệu lớn', 1, 45);
insert into MONHOC values ('IS215', N'Thiết kế hướng đối tượng với UML', 1, 45);
insert into MONHOC values ('IS220', N'Xây dựng HTTT trên các framework', 2, 30);
insert into MONHOC values ('IS232', N'Hệ thống thông tin kế toán', 1, 60);
insert into MONHOC values ('IS251', N'Nhập môn hệ thống thông tin địa lý', 1, 45);
insert into MONHOC values ('IS254', N'Hệ hỗ trợ quyết định', 1, 45);
insert into MONHOC values ('IS311', N'Đồ án xây dựng hệ thống thông tin', 1, 45);
insert into MONHOC values ('IS332', N'Hệ thống thông tin quản lý', 1, 60);
insert into MONHOC values ('IS335', N'An toàn và bảo mật hệ thống thông tin', 1, 45);
insert into MONHOC values ('IS336', N'Hoạch định nguồn lực doanh nghiệp', 1, 45);
insert into MONHOC values ('IT009', N'Giới thiệu ngành', 1, 30);
insert into MONHOC values ('IT011', N'Nhập môn lập trình thi đấu', 2, 30);
insert into MONHOC values ('IT013', N'Cấu trúc dữ liệu cho lập trình thi đấu', 2, 30);
insert into MONHOC values ('MATH2114', N'Giải tích I', 1, 60);
insert into MONHOC values ('MATH2153', N'Giải tích II', 1, 45);
insert into MONHOC values ('MATH3013', N'Đại số tuyến tính', 1, 45);
insert into MONHOC values ('NT103', N'Hệ điều hành Linux', 1, 45);
insert into MONHOC values ('NT104', N'Lý thuyết thông tin', 1, 45);
insert into MONHOC values ('NT109', N'Lập trình ứng dụng mạng', 2, 30);
insert into MONHOC values ('NT111', N'Thiết bị mạng và truyền thông ĐPT', 1, 45);
insert into MONHOC values ('NT117', N'Đồ án môn học lập trình ứng dụng mạng', 2, 60);
insert into MONHOC values ('NT137', N'Kỹ thuật phân tích mã độc', 1, 30);
insert into MONHOC values ('NT201', N'Phân tích thiết kế hệ thống và truyền thông mạng', 1, 45);
insert into MONHOC values ('NT204', N'Hệ thống tìm kiếm, phát hiện và ngăn ngừa xâm nhập', 2, 30);
insert into MONHOC values ('NT205', N'Tấn công mạng', 1, 30);
insert into MONHOC values ('NT207', N'Quản lý rủi ro và an toàn thông tin trong doanh nghiệp', 1, 30);
insert into MONHOC values ('NT210', N'Thương mại Điện tử và triển khai ứng dung', 2, 30);
insert into MONHOC values ('NT211', N'An ninh nhân sự, định danh và chứng thực', 1, 45);
insert into MONHOC values ('NT212', N'An toàn dữ liệu, khôi phục thông tin sau sự cố ', 1, 45);
insert into MONHOC values ('NT213', N'Bảo mật web và ứng dụng', 1, 45);
insert into MONHOC values ('NT216', N'Bảo mật hệ thống dữ liệu', 1, 30);
insert into MONHOC values ('PH001', N'Nhập môn điện tử', 1, 45);
insert into MONHOC values ('PHYS1114', N'Vật lý đại cương I', 1, 60);
insert into MONHOC values ('PHYS1214', N'Vật lý đại cương II', 1, 60);
insert into MONHOC values ('SC203', N'Phương pháp khoa học', 1, 45);
insert into MONHOC values ('SE101', N'Phương pháp mô hình hóa', 1, 45);
insert into MONHOC values ('SE102', N'Nhập môn phát triển game', 2, 30);
insert into MONHOC values ('SE106', N'Đặc tả hình thức', 1, 60);
insert into MONHOC values ('SE109', N'Phát triển, vận hành, bảo trì phần mềm', 1, 45);
insert into MONHOC values ('SE111', N'Phương pháp phát triển phần mềm hướng đối tượng', 1, 45);
insert into MONHOC values ('SE112', N'Đồ án chuyên ngành', 1, 30);
insert into MONHOC values ('SE113', N'Kiểm chứng phần mềm', 2, 30);
insert into MONHOC values ('SE114', N'Nhập môn ứng dụng di động', 2, 30);
insert into MONHOC values ('SE214', N'Công nghệ phần mềm chuyên sâu', 1, 45);
insert into MONHOC values ('SE215', N'Giao tiếp người máy', 1, 45);
insert into MONHOC values ('SE220', N'Thiết kế Game', 1, 45);
insert into MONHOC values ('SE221', N'Lập trình game nâng cao', 2, 30);
insert into MONHOC values ('SE301', N'Phát triển phần mềm mã nguồn mở', 1, 45);
insert into MONHOC values ('SE310', N'Công nghệ .NET', 1, 45);

-- table CHUONGTRINHHOC
-- CNTT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'SS006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'SS004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'PE012', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT012.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT012.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'MA005', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'SS003', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'SS007', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT007.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IT007.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE101.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE101.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE103.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE103.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'SS008', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'SS009', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE104.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE104.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE106.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE106.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'SS010', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE105.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE105.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE108.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE108.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE207', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('CNTT', 'IE505', 8);

-- HTTT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT010', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'PE012', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'SS007', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'SS008', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'SS006', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'SS004', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS201.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS201.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS210.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS210.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS208.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS208.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS216.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS216.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT007.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IT007.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'SS010', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS403', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS217', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS207.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS207.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS336.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS336.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'SS003', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS252.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS252.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS211.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS211.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS405.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS405.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'SS009', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS502', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'NT118.LT', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'NT118.TH', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('HTTT', 'IS401', 8);

-- KHMT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'CS005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT012.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT012.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'PE012', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT007.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'IT007.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'CS115', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'SS007', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'CS112.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'CS112.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'SS004', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'SS008', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'SS009', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'SS010', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'SS003', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'SS006', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHMT', 'CS505', 7);

-- TTNT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'AI001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'SS004', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'PE001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT012.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT012.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'PE002', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT007.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'IT007.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS115', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS112.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS112.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS106.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS106.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS114.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS114.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'SS007', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'SS008', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'AI002.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'AI002.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'SS009', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'SS010', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'SS003', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'SS006', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TTNT', 'CS505', 7);

-- KTPM
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT012.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT012.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'PE012', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT007.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT007.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT008.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'IT008.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE104.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE104.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SS007', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SS008', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SS004', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SS009', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SS010', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE100.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE100.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SS006', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SS003', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE121', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE501', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE122', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTPM', 'SE505', 8);

-- KTMT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'SS007', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'PE012', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'PH002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'PH002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT003.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT003.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT006', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE119', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'SS003', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE103.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE103.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT007.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT007.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE121.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE121.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'SS009', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'SS010', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT004.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'IT004.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE124.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE124.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE224.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE224.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE118.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE118.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE213.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE213.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'SS004', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE201', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE502', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE206', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'SS008', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'SS006', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KTMT', 'CE505', 8);

-- MMT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'PH002.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'PH002.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'PE012', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT006', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'SS004', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT132.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT132.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT106.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT106.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT007.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'IT007.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'SS009', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT105.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT105.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT101.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT101.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT131.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT131.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT118.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT118.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'SS003', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT114', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'SS007', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT113.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT113.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT215', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'SS006', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'SS008', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'SS010', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('MMT', 'NT505', 8);

-- ATTT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'PH002.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'PH002.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT015', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'PE012', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT006', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'SS004', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'SS007', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'SS010', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'SS006', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT007.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'IT007.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT106.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT106.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT209.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT209.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT219.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT219.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT208.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT208.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'SS008', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'SS009', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT132.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT132.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT101.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT101.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT521.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT521.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT230.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT230.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'SS003', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT114', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT215', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('ATTT', 'NT505', 7);

-- TMDT
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'PE012', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT002.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT002.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC001', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IS334', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'SS004', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC101', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IS207.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IS207.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC208', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC201.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC201.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'SS009', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC312.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC312.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC204.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC204.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC213.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC213.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'SS003', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'SS006', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IS336.LT', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'IS336.TH', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC335', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC229', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'SS007', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC222', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC337', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'SS008', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'SS010', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('TMDT', 'EC401', 8);

-- KHDL
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT001.LT', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT001.TH', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'MA006', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'MA003', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT010', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS005', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'ENG01', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'ME001', 1);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'SS006', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'SS004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT003.LT', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT003.TH', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'MA004', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'MA005', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'ENG02', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'PE012', 2);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT004.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT004.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT005.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT005.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT002.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT002.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS101.LT', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS101.TH', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'ENG03', 3);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'SS007', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT007.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'IT007.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS103.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS103.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS107.LT', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS107.TH', 4);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'SS008', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS105.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS105.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS102.LT', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS102.TH', 5);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'SS009', 6);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'SS010', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'SS003', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS207', 7);
insert into CHUONGTRINHHOC(MaNganh, MaMH, HocKy) values ('KHDL', 'DS505', 8);

-- table HOCKY
insert into HOCKY values
('HK I'), 
('HK II'), 
('HK Hè');

-- table DANHSACHMONHOCMO
insert into DANHSACHMONHOCMO(MaMH, MaHocKy, NamHoc)
select distinct MaMH, 1, 2024
from CHUONGTRINHHOC
where HocKy % 2 = 1;

insert into DANHSACHMONHOCMO(MaMH, MaHocKy, NamHoc)
select distinct MaMH, 1, 2024
from MONHOC
where MaMH not in
(
	select MaMH
	from CHUONGTRINHHOC
);

insert into DANHSACHMONHOCMO(MaMH, MaHocKy, NamHoc)
select distinct MaMH, 2, 2024
from CHUONGTRINHHOC
where HocKy % 2 = 0;

insert into DANHSACHMONHOCMO(MaMH, MaHocKy, NamHoc)
select distinct MaMH, 2, 2024
from MONHOC
where MaMH not in
(
	select MaMH
	from CHUONGTRINHHOC
);

insert into DANHSACHMONHOCMO(MaMH, MaHocKy, NamHoc)
select distinct MaMH, 3, 2024
from MONHOC;

-- table KHOANGTGDONGHP
insert into KHOANGTGDONGHP values
(1, 2024, 3), 
(2, 2024, 3), 
(3, 2024, 5);

-- table THAMSO
insert into THAMSO(SoTinChiToiDa, SoTinChiToiThieu) values (25, 8);

-- table TINHTRANG
insert into TINHTRANG values
(N'Chờ xác nhận'), 
(N'Chờ thanh toán'), 
(N'Đã thanh toán'),
(N'Đã hủy');

-- table NHOMNGUOIDUNG
insert into NHOMNGUOIDUNG values
('ad', N'Admin'), 
('gv', N'Nhân viên phòng tài vụ'), 
('sv', N'Sinh viên');

-- table NGUOIDUNG
insert into NGUOIDUNG values ('admin1', 'FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE', 'ad');
insert into NGUOIDUNG values ('teacher1', 'FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE', 'gv');
insert into NGUOIDUNG values ('SV21520007', 'FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE', 'sv');
insert into NGUOIDUNG values ('SV21520013', 'FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE', 'sv');
insert into NGUOIDUNG values ('SV21520053', 'FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE', 'sv');

-- Store Procedures
--spNGUOIDUNG_LayBangTenDangNhapVaMatKhau
go
create proc spNGUOIDUNG_LayBangTenDangNhapVaMatKhau (@TenDangNhap nvarchar(10), @MatKhau nvarchar(200))
as
begin
	select *
	from NGUOIDUNG
	where TenDangNhap = @TenDangNhap
	and MatKhau = @MatKhau
end
go

--spspGLOBALCONFIG_LayNamHocHienTai
create proc spGLOBALCONFIG_LayNamHocHienTai
as
begin
	select max(NamHoc)
	from DANHSACHMONHOCMO
end
go

--spGLOBALCONFIG_LayMaHocKyHienTai
create proc spGLOBALCONFIG_LayMaHocKyHienTai (@NamHocHienTai int)
as
begin
	select max(MaHocKy)
	from DANHSACHMONHOCMO
	where NamHoc = @NamHocHienTai
end
go

--spSINHVIEN_LayDSSVChuaCoTK
create proc spSINHVIEN_LayDSSVChuaCoTK
as
begin
	select * 
	from SINHVIEN
	where MaSV not in
	(
		select TenDangNhap
		from NGUOIDUNG
	)
end
go

--spNGUOIDUNG_LayDSNguoiDung
create proc spNGUOIDUNG_LayDSNguoiDung
as
begin
	select NGUOIDUNG.*, TenNhom
	from NGUOIDUNG, NHOMNGUOIDUNG
	where NGUOIDUNG.MaNhom = NHOMNGUOIDUNG.MaNhom
end
go

--spNGUOIDUNG_ThemTaiKhoanSV
create proc spNGUOIDUNG_ThemTaiKhoanSV (@MaSV nvarchar(10))
as
begin
	insert into NGUOIDUNG
	values (@MaSV, 'FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE', 'sv')
end
go

--spNGUOIDUNG_XoaTaiKhoan
create proc spNGUOIDUNG_XoaTaiKhoan (@TenDangNhap nvarchar(10))
as
begin
	delete from NGUOIDUNG
	where TenDangNhap = @TenDangNhap
end
go

--spNGUOIDUNG_DoiMatKhau
create proc spNGUOIDUNG_DoiMatKhau (@TenDangNhap nvarchar(10), @MatKhauHT nvarchar(200), @MatKhauMoi nvarchar(200))
as
begin
	update NGUOIDUNG
	set MatKhau = @MatKhauMoi
	where TenDangNhap = @TenDangNhap
	and MatKhau = @MatKhauHT
end
go

--spNHOMNGUOIDUNG_LayDSNhomNguoiDung
create proc spNHOMNGUOIDUNG_LayDSNhomNguoiDung
as
begin
	select *
	from NHOMNGUOIDUNG
	where MaNhom <> 'sv'
end
go

--spNGUOIDUNG_SuaTaiKhoan
create proc spNGUOIDUNG_SuaTaiKhoan (@TenDangNhapBD nvarchar(10), @TenDangNhap nvarchar(10), @MaNhom nvarchar(20))
as
begin
	update NGUOIDUNG
	set TenDangNhap = @TenDangNhap, MaNhom = @MaNhom
	where TenDangNhap = @TenDangNhapBD
end
go

--spNGUOIDUNG_ThemTaiKhoan
create proc spNGUOIDUNG_ThemTaiKhoan (@TenDangNhap nvarchar(10), @MaNhom nvarchar(20))
as
begin
	insert into NGUOIDUNG
	values (@TenDangNhap, 'FA585D89C851DD338A70DCF535AA2A92FEE7836DD6AFF1226583E88E0996293F16BC009C652826E0FC5C706695A03CDDCE372F139EFF4D13959DA6F1F5D3EABE', @MaNhom)
end
go

--spDOITUONG_LayDSDoiTuong
create proc spDOITUONG_LayDSDoiTuong
as
begin
	select *
	from DOITUONG
	where MaDT <> 1
end
go

--spDOITUONG_SuaDoiTuong
create proc spDOITUONG_SuaDoiTuong (@MaDT int, @TenDT nvarchar(100), @TiLeGiamHocPhi float)
as
begin
	update DOITUONG
	set TenDT = @TenDT, TiLeGiamHocPhi = @TiLeGiamHocPhi
	where MaDT = @MaDT
end
go

--spDOITUONG_ThemDoiTuong
create proc spDOITUONG_ThemDoiTuong (@TenDT nvarchar(100), @TiLeGiamHocPhi float)
as
begin
	insert into DOITUONG
	values (@TenDT, @TiLeGiamHocPhi)
end
go

--spDOITUONG_XoaDoiTuong
create proc spDOITUONG_XoaDoiTuong (@MaDT int)
as
begin
	delete from DOITUONG
	where MaDT = @MaDT
end
go

--spLOAIMONHOC_LayDSLoaiMonHoc
create proc spLOAIMONHOC_LayDSLoaiMonHoc
as
begin
	select * 
	from LOAIMONHOC
end
go

--spGLOBALCONFIG_LaySoTinChiToiDa
create proc spGLOBALCONFIG_LaySoTinChiToiDa
as
begin
	select SoTinChiToiDa
	from THAMSO
end
go

--spGLOBALCONFIG_LaySoTinChiToiThieu
create proc spGLOBALCONFIG_LaySoTinChiToiThieu
as
begin
	select SoTinChiToiThieu
	from THAMSO
end
go

--spGLOBALCONFIG_SuaGioiHanTinChi
create proc spGLOBALCONFIG_SuaGioiHanTinChi (@SoTinChiToiDa int, @SoTinChiToiThieu int)
as
begin
	update THAMSO
	set SoTinChiToiDa = @SoTinChiToiDa, SoTinChiToiThieu = @SoTinChiToiThieu
end
go

--spLOAIMONHOC_XoaLoaiMonHoc
create proc spLOAIMONHOC_XoaLoaiMonHoc (@MaLoaiMonHoc int)
as
begin
	delete from LOAIMONHOC
	where MaLoaiMonHoc = @MaLoaiMonHoc
end
go

--trgMONHOC_udt_SuaSoTiet
create trigger trgMONHOC_udt_SuaSoTiet on LOAIMONHOC
after update
as
begin
	if update(SoTiet)
	begin
		declare @SoTietLoaiMonCu int = (select SoTiet from deleted);
		declare @SoTietLoaiMonMoi int = (select SoTiet from inserted);

		update MONHOC
		set SoTiet = SoTiet * @SoTietLoaiMonMoi / @SoTietLoaiMonCu
		where MaLoaiMonHoc = (select MaLoaiMonHoc from inserted)
	end
end
go

--spLOAIMONHOC_SuaLoaiMonHoc
create proc spLOAIMONHOC_SuaLoaiMonHoc (@MaLoaiMonHoc int, @TenLoaiMonHoc nvarchar(100), @SoTiet int, @SoTien decimal)
as
begin
	update LOAIMONHOC
	set TenLoaiMonHoc = @TenLoaiMonHoc, SoTiet = @SoTiet, SoTien = @SoTien
	where MaLoaiMonHoc = @MaLoaiMonHoc
end
go

--spLOAIMONHOC_ThemLoaiMonHoc
create proc spLOAIMONHOC_ThemLoaiMonHoc(@TenLoaiMonHoc nvarchar(100), @SoTiet int, @SoTien decimal)
as
begin
	insert into LOAIMONHOC
	values (@TenLoaiMonHoc, @SoTiet, @SoTien)
end
go

--spTINH_LayDSTinh
create proc spTINH_LayDSTinh
as
begin
	select * 
	from TINH
end
go

--spTINH_SuaTinh
create proc spTINH_SuaTinh (@MaTinh int, @TenTinh nvarchar(100))
as
begin
	update TINH
	set TenTTP = @TenTinh 
	where MaTinh = @MaTinh
end
go

--spTINH_ThemTinh
create proc spTINH_ThemTinh (@TenTinh nvarchar(100))
as
begin
	insert into TINH
	values (@TenTinh)
end
go

--spTINH_XoaTinh
create proc spTINH_XoaTinh (@MaTinh int)
as
begin
	delete from TINH
	where MaTinh = @MaTinh
end
go

--spHUYEN_LayDSHuyen
create proc spHUYEN_LayDSHuyen
as
begin
	select HUYEN.*, TenTTP
	from HUYEN, TINH 
	where HUYEN.MaTinh = TINH.MaTinh
end
go

--spHUYEN_SuaHuyen
create proc spHUYEN_SuaHuyen (@MaHuyen nvarchar(50), @TenHuyen nvarchar(100), @VungUT int, @MaTinh int)
as
begin
	update HUYEN
	set TenHuyen = @TenHuyen, VungUT = @VungUT, MaTinh = @MaTinh
	where MaHuyen = @MaHuyen
end
go

--spHUYEN_ThemHuyen
create proc spHUYEN_ThemHuyen (@TenHuyen nvarchar(100), @VungUT int, @MaTinh int) 
as
begin
	insert into HUYEN
	values (@TenHuyen, @VungUT, @MaTinh)
end
go

--spHUYEN_XoaHuyen
create proc spHUYEN_XoaHuyen (@MaHuyen int)
as
begin
	delete from HUYEN
	where MaHuyen = @MaHuyen
end
go

--spNGANH_LayDSNganh
create proc spNGANH_LayDSNganh
as
begin
	select NGANH.*, TenKhoa
	from NGANH, KHOA
	where NGANH.MaKhoa = KHOA.MaKhoa
end
go

--spKHOA_LayDSKhoa
create proc spKHOA_LayDSKhoa
as
begin
	select * 
	from KHOA
end
go

--spNGANH_XoaNganh
create proc spNGANH_XoaNganh (@MaNganh nvarchar(50))
as
begin
	delete from NGANH
	where MaNganh = @MaNganh
end
go

--spKHOA_SuaKhoa
create proc spKHOA_SuaKhoa (@MaKhoaBanDau nvarchar(20), @MaKhoaSua nvarchar(20), @TenKhoaSua nvarchar(100))
as
begin
	update KHOA
	set MaKhoa = @MaKhoaSua, TenKhoa = @TenKhoaSua
	where MaKhoa = @MaKhoaBanDau
end
go

--spKHOA_ThemKhoa
create proc spKHOA_ThemKhoa(@MaKhoa nvarchar(50), @TenKhoa nvarchar(100))
as
begin
	insert into KHOA
	values (@MaKhoa, @TenKhoa)
end
go

--spNGANH_SuaNganh
create proc spNGANH_SuaNganh (@MaNganhBanDau nvarchar(50), @MaNganh nvarchar(50), @TenNganh nvarchar(100), @MaKhoa nvarchar(50))
as
begin
	update NGANH
	set MaNganh = @MaNganh, TenNganh = @TenNganh, MaKhoa = @MaKhoa
	where MaNganh = @MaNganhBanDau
end
go

--spNGANH_ThemNganh
create proc spNGANH_ThemNganh (@MaNganh nvarchar(50), @TenNganh nvarchar(50), @MaKhoa nvarchar(50))
as
begin
	insert into NGANH
	values (@MaNganh, @TenNganh, @MaKhoa)
end
go