﻿using DAL.IServices;
using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Services
{
    public class SinhVienDALService : ISinhVienDALService
	{
		private readonly IDapperService _dapperService;
		public SinhVienDALService(IDapperService dapperService)
		{
			_dapperService = dapperService;
		}

		public List<SinhVien> LayDSSVChuaCoTK()
		{
            return _dapperService.Query<SinhVien>("spSINHVIEN_LayDSSVChuaCoTK").ToList();
        }

		public List<CT_SinhVien> LayDSSV()
		{
            return _dapperService.Query<CT_SinhVien>("spSINHVIEN_LayDSSV").ToList();
        }

		public SuaSinhVienMessage SuaSinhVien(string mssvBanDau, string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
			try
			{
                var p = new DynamicParameters();
                p.Add("@MaSV", mssvBanDau);
                p.Add("@HoTen", hoTen);
                p.Add("@NgaySinh", ngaySinh);
                p.Add("@GioiTinh", gioiTinh);
                p.Add("@MaHuyen", maHuyen);
                p.Add("@MaNganh", maNganh);
                _dapperService.Execute("spSINHVIEN_SuaSinhVien", p, commandType: CommandType.StoredProcedure);

                p = new DynamicParameters();
                p.Add("@MaSV", mssvBanDau);
                _dapperService.Execute("spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);

                foreach (int maDT in maDTList)
                {
                    p = new DynamicParameters();
                    p.Add("@MaSV", mssv);
                    p.Add("@MaDT", maDT);
                    _dapperService.Execute("spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
                }
            }
			catch (Exception)
			{
				return SuaSinhVienMessage.Error;
			}

			return SuaSinhVienMessage.Success;
		}

		public ThemSinhVienMessage ThemSinhVien(string mssv, string hoTen, DateTime ngaySinh, string gioiTinh, int maHuyen, string maNganh, List<int> maDTList)
		{
			try
			{
                var p = new DynamicParameters();
                p.Add("@MaSV", mssv);
                p.Add("@HoTen", hoTen);
                p.Add("@NgaySinh", ngaySinh);
                p.Add("@GioiTinh", gioiTinh);
                p.Add("@MaHuyen", maHuyen);
                p.Add("@MaNganh", maNganh);
                _dapperService.Execute("spSINHVIEN_ThemSinhVien", p, commandType: CommandType.StoredProcedure);

                foreach (int maDT in maDTList)
                {
                    p = new DynamicParameters();
                    p.Add("@MaSV", mssv);
                    p.Add("@MaDT", maDT);
                    _dapperService.Execute("spSINHVIEN_DOITUONG_Them", p, commandType: CommandType.StoredProcedure);
                }
            }
			catch (SqlException ex)
			{
                if (ex.Number == 2627 && ex.Message.Contains("PK_SINHVIEN"))
                {
                    return ThemSinhVienMessage.DuplicateMaSV;
                }
            }
			catch (Exception)
			{
				return ThemSinhVienMessage.Error;
			}

			return ThemSinhVienMessage.Success;
		}

		public XoaSinhVienMessage XoaSinhVien(string maSV)
		{
			try
			{
                var p = new DynamicParameters();
                p.Add("@MaSV", maSV);
                _dapperService.Execute("spSINHVIEN_DOITUONG_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperService.Execute("spCT_PHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperService.Execute("spPHIEUTHUHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperService.Execute("spPHIEUDKHP_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
                _dapperService.Execute("spSINHVIEN_XoaSinhVien", p, commandType: CommandType.StoredProcedure);
            }
			catch (Exception)
			{
				return XoaSinhVienMessage.Error;
			}

			return XoaSinhVienMessage.Success;
		}

		public string LayTenSV(string mssv)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@mssv", mssv);
            return _dapperService.QueryFirstOrDefault<string>("spSINHVIEN_LayTenSV", parameters, commandType: CommandType.StoredProcedure).ToString();
        }

		public List<dynamic> LayThongTinSV(string mssv)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@mssv", mssv);
            return _dapperService.Query<dynamic>("spSINHVIEN_LayThongTinSV", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

		public List<dynamic> BaoCaoSinhVienChuaDongHocPhi(int hocKy, int namHoc)
		{
            var parameters = new DynamicParameters();
            parameters.Add("@hocKy", hocKy);
            parameters.Add("@namHoc", namHoc);

            return _dapperService.Query<dynamic>("spSINHVIEN_BaoCao", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
	}
}
