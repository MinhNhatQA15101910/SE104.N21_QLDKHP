using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using Dapper;
using DTO;
using PL.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaKhoa : KryptonForm
    {
        private readonly IKhoaBLLService _khoaBLLService 
            = new KhoaBLLService(
                new KhoaDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()),
                new NganhDALService(
                    ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString, 
                    new DapperWrapper()));

        private IThemSuaKhoaRequester themSuaKhoaRequester;
        private Khoa khoa;

        public ThemSuaKhoa(IThemSuaKhoaRequester requester, DTO.Khoa khoa)
        {
            InitializeComponent();

            themSuaKhoaRequester = requester;
            this.khoa = khoa;

            SettingProperties();
        }

        public ThemSuaKhoa(IThemSuaKhoaRequester requester)
        {
            InitializeComponent();

            themSuaKhoaRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            if (khoa != null)
            {
                Text = "Sửa khoa";
                lblThemSuaKhoa.Text = "SỬA KHOA";

                txtMaKhoa.Text = khoa.MaKhoa;
                txtTenKhoa.Text = khoa.TenKhoa;
                txtMaKhoa.ReadOnly = true;
            }
            else
            {
                Text = "Thêm khoa";
                lblThemSuaKhoa.Text = "THÊM KHOA";
                txtMaKhoa.ReadOnly = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (khoa != null)
            {
                string maKhoaBanDau = khoa.MaKhoa;
                string maKhoaSua = txtMaKhoa.Text.Trim();
                string tenKhoaSua = txtTenKhoa.Text.Trim();

                SuaKhoaMessage message = _khoaBLLService.SuaKhoa(maKhoaBanDau, maKhoaSua, tenKhoaSua);
                switch (message)
                {
                    case SuaKhoaMessage.EmptyMaKhoa:
                        MessageBox.Show("Mã khoa không được để trống!");
                        break;
                    case SuaKhoaMessage.EmptyTenKhoa:
                        MessageBox.Show("Tên khoa không được để trống!");
                        break;
                    case SuaKhoaMessage.DuplicateMaKhoa:
                        MessageBox.Show("Mã khoa đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaKhoaMessage.DuplicateTenKhoa:
                        MessageBox.Show("Tên khoa đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaKhoaMessage.Unable:
                        MessageBox.Show("Không thể sửa khoa này vì mã khoa đang là khoa của ngành khác!");
                        break;
                    case SuaKhoaMessage.Success:
                        MessageBox.Show("Sửa khoa thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string maKhoa = txtMaKhoa.Text.Trim();
                string tenKhoa = txtTenKhoa.Text.Trim();

                ThemKhoaMessage message = _khoaBLLService.ThemKhoa(maKhoa, tenKhoa);
                switch (message)
                {
                    case ThemKhoaMessage.EmptyMaKhoa:
                        MessageBox.Show("Mã khoa không được để trống!");
                        break;
                    case ThemKhoaMessage.EmptyTenKhoa:
                        MessageBox.Show("Tên khoa không được để trống!");
                        break;
                    case ThemKhoaMessage.DuplicateMaKhoa:
                        MessageBox.Show("Mã khoa đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemKhoaMessage.DuplicateTenKhoa:
                        MessageBox.Show("Tên khoa đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemKhoaMessage.Success:
                        if (themSuaKhoaRequester != null)
                        {
                            themSuaKhoaRequester.OnThemSuaKhoaClosing();
                        }

                        MessageBox.Show("Thêm khoa thành công!");
                        break;
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThemSuaKhoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaKhoaRequester != null)
            {
                themSuaKhoaRequester.OnThemSuaKhoaClosing();
            }
        }
    }
}
