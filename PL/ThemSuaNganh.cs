using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaNganh : KryptonForm, IThemSuaKhoaRequester
	{
        private readonly IKhoaBLLService _khoaBLLService 
			= new KhoaBLLService(
				new KhoaDALService(
					ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
					new DapperWrapper()),
				new NganhDALService(
					ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
					new DapperWrapper()));
        private readonly INganhBLLService _nganhBLLService 
			= new NganhBLLService(
				new NganhDALService(
					ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
					new DapperWrapper()),
				new SinhVienDALService(
					ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
					new DapperWrapper()),
				new ChuongTrinhHocDALService(
					ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
					new DapperWrapper()));

		private IThemSuaNganhRequester themSuaNganhRequester;
		private CT_Nganh nganh;
		private BindingList<DTO.Khoa> mKhoa;
		private BindingSource mKhoaSource;

		public ThemSuaNganh(IThemSuaNganhRequester requester, CT_Nganh nganh)
		{
			InitializeComponent();

			themSuaNganhRequester = requester;
			this.nganh = nganh;

			SettingProperties();
		}

		public ThemSuaNganh(IThemSuaNganhRequester requester)
		{
			InitializeComponent();

			themSuaNganhRequester = requester;

			SettingProperties();
		}

		private void SettingProperties()
		{
			if (nganh != null)
			{
				Text = "Sửa ngành";
				lblThemSuaNganh.Text = "SỬA NGÀNH";

				txtMaNganh.Text = nganh.MaNganh;
				txtTenNganh.Text = nganh.TenNganh;
			}
			else
			{
				Text = "Thêm ngành";
				lblThemSuaNganh.Text = "THÊM NGÀNH";
			}
		}

		public void OnThemSuaKhoaClosing()
		{
			mKhoa = new BindingList<DTO.Khoa>(_khoaBLLService.LayDSKhoa());
			mKhoaSource.DataSource = mKhoa;
		}

		private void ThemSuaNganh_Load(object sender, EventArgs e)
		{
			mKhoa = new BindingList<DTO.Khoa>(_khoaBLLService.LayDSKhoa());
			mKhoaSource = new BindingSource(mKhoa, null);
			cmbKhoa.DataSource = mKhoaSource;
			cmbKhoa.DisplayMember = "DisplayKhoa";
			cmbKhoa.ValueMember = "MaKhoa";

			if (nganh != null)
			{
				cmbKhoa.SelectedValue = nganh.MaKhoa;
				txtMaNganh.ReadOnly = true;
			}
			else
			{
				txtMaNganh.ReadOnly = false;
			}
		}

		private void btnThemKhoa_Click(object sender, EventArgs e)
		{
			ThemSuaKhoa themSuaKhoa = new ThemSuaKhoa(this);
			themSuaKhoa.ShowDialog();
		}

		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtMaNganh.Clear();
			txtTenNganh.Clear();
		}

		private void btnXacNhan_Click(object sender, EventArgs e)
		{
			if (nganh != null)
			{
				string maNganhBanDau = nganh.MaNganh;
				string maNganhSua = txtMaNganh.Text.Trim();
				string tenNganhSua = txtTenNganh.Text.Trim();
				string maKhoaSua = cmbKhoa.Text.Trim().Split(' ')[0];

				SuaNganhMessage message = _nganhBLLService.SuaNganh(maNganhBanDau, maNganhSua, tenNganhSua, maKhoaSua);
				switch (message)
				{
					case SuaNganhMessage.EmptyMaNganh:
						MessageBox.Show("Mã ngành không được để trống!");
						break;
					case SuaNganhMessage.EmptyTenNganh:
						MessageBox.Show("Tên ngành không được để trống!");
						break;
					case SuaNganhMessage.DuplicateMaNganh:
						MessageBox.Show("Mã ngành đã tồn tại, vui lòng nhập giá trị khác!");
						break;
					case SuaNganhMessage.DuplicateTenNganh:
						MessageBox.Show("Tên ngành đã tồn tại, vui lòng nhập giá trị khác!");
						break;
                    case SuaNganhMessage.UnableForSinhVien:
                        MessageBox.Show("Không thể sửa ngành này do có sinh viên thuộc ngành!");
                        break;
                    case SuaNganhMessage.UnableForChuongTrinhHoc:
                        MessageBox.Show("Không thể sửa ngành này do có chương trình học của ngành!");
                        break;
                    case SuaNganhMessage.Success:
						MessageBox.Show("Sửa ngành thành công!");
						Close();
						break;
				}
			}
			else
			{
				string maNganh = txtMaNganh.Text.Trim();
				string tenNganh = txtTenNganh.Text.Trim();
				string maKhoa = cmbKhoa.Text.Trim().Split(' ')[0];

				ThemNganhMessage message = _nganhBLLService.ThemNganh(maNganh, tenNganh, maKhoa);
				switch (message)
				{
					case ThemNganhMessage.EmptyMaNganh:
						MessageBox.Show("Mã ngành không được để trống!");
						break;
					case ThemNganhMessage.EmptyTenNganh:
						MessageBox.Show("Tên ngành không được để trống!");
						break;
					case ThemNganhMessage.DuplicateMaNganh:
						MessageBox.Show("Mã ngành đã tồn tại, vui lòng nhập giá trị khác!");
						break;
					case ThemNganhMessage.DuplicateTenNganh:
						MessageBox.Show("Tên ngành đã tồn tại, vui lòng nhập giá trị khác!");
						break;
					case ThemNganhMessage.Success:
						if (themSuaNganhRequester != null)
						{
							themSuaNganhRequester.OnThemSuaNganhClosing();
						}

						MessageBox.Show("Thêm ngành thành công!");
						break;
				}
			}
		}

		private void ThemSuaNganh_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (themSuaNganhRequester != null)
			{
				themSuaNganhRequester.OnThemSuaNganhClosing();
			}
		}
	}
}
