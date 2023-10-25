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
    public partial class ThemSuaMonHoc : KryptonForm, IThemSuaLoaiMonHocRequester
    {
        #region Register Services
        private readonly IMonHocBLLService _monHocBLLService = new MonHocBLLService(new MonHocDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly ILoaiMonHocBLLService _loaiMonHocBLLService = new LoaiMonHocBLLService(new LoaiMonHocDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        #endregion

        private IThemSuaMonHocRequester themSuaMonHocRequester;
        private CT_MonHoc monHoc;
        private BindingList<LoaiMonHoc> mLoaiMonHoc;
        private BindingSource mLoaiMonHocSource;

        public ThemSuaMonHoc(IThemSuaMonHocRequester requester, CT_MonHoc monHoc)
        {
            InitializeComponent();

            themSuaMonHocRequester = requester;
            this.monHoc = monHoc;

            SettingProperties();
        }

        public ThemSuaMonHoc(IThemSuaMonHocRequester requester)
        {
            InitializeComponent();

            themSuaMonHocRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            if (monHoc != null)
            {
                Text = "Sửa môn học";
                lblThemSuaMonHoc.Text = "SỬA MÔN HỌC";

                txtMaMonHoc.Text = monHoc.MaMH;
                txtTenMonHoc.Text = monHoc.TenMH;
                txtSoTiet.Text = monHoc.SoTiet.ToString();

                txtMaMonHoc.ReadOnly = true;
            }
            else
            {
                Text = "Thêm môn học";
                lblThemSuaMonHoc.Text = "THÊM MÔN HỌC";

                txtMaMonHoc.ReadOnly = false;
            }
        }

        private void ThemSuaMonHoc_Load(object sender, EventArgs e)
        {
            mLoaiMonHoc = new BindingList<LoaiMonHoc>(_loaiMonHocBLLService.LayDSLoaiMonHoc());
            mLoaiMonHocSource = new BindingSource(mLoaiMonHoc, null);
            cmbLoaiMonHoc.DataSource = mLoaiMonHocSource;
            cmbLoaiMonHoc.DisplayMember = "TenLoaiMonHoc";
            cmbLoaiMonHoc.ValueMember = "MaLoaiMonHoc";

            if (monHoc != null)
            {
                cmbLoaiMonHoc.SelectedValue = monHoc.MaLoaiMonHoc;
            }
        }

        private void btnThemLoaiMonHoc_Click(object sender, EventArgs e)
        {
            ThemSuaLoaiMonHoc themSuaLoaiMonHoc = new ThemSuaLoaiMonHoc(this);
            themSuaLoaiMonHoc.Show();
        }

        public void OnThemSuaLoaiMonHocClosing()
        {
            mLoaiMonHoc = new BindingList<LoaiMonHoc>(_loaiMonHocBLLService.LayDSLoaiMonHoc());
            mLoaiMonHocSource.DataSource = mLoaiMonHoc;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThemSuaMonHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaMonHocRequester != null)
            {
                themSuaMonHocRequester.OnThemSuaMonHocClosing();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (monHoc != null)
            {
                string maMHBanDau = monHoc.MaMH;
                string maMH = txtMaMonHoc.Text.Trim();
                string tenMH = txtTenMonHoc.Text.Trim();
                int maLoaiMonHoc = (int)cmbLoaiMonHoc.SelectedValue;
                string soTiet = txtSoTiet.Text.Trim();
                int soTietLoaiMon = monHoc.SoTietLoaiMon;

                SuaMonHocMessage message = _monHocBLLService.SuaMonHoc(maMHBanDau, maMH, tenMH, maLoaiMonHoc, soTiet, soTietLoaiMon);
                switch (message)
                {
                    case SuaMonHocMessage.Unable:
                        MessageBox.Show("Không thể chỉnh sửa môn học trong danh sách môn học đang mở!");
                        break;
                    case SuaMonHocMessage.EmptyMaMH:
                        MessageBox.Show("Mã môn học không được để trống!");
                        break;
                    case SuaMonHocMessage.EmptyTenMH:
                        MessageBox.Show("Tên môn học không được để trống!");
                        break;
                    case SuaMonHocMessage.EmptySoTiet:
                        MessageBox.Show("Số tiết không được để trống!");
                        break;
                    case SuaMonHocMessage.InvalidSoTiet:
                        MessageBox.Show("Số tiết không hợp lệ, vui lòng nhập lại!");
                        break;
                    case SuaMonHocMessage.DuplicateMaMH:
                        MessageBox.Show("Mã môn học đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaMonHocMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case SuaMonHocMessage.Success:
                        MessageBox.Show("Sửa môn học thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string maMH = txtMaMonHoc.Text.Trim();
                string tenMH = txtTenMonHoc.Text.Trim();
                int maLoaiMonHoc = (int)cmbLoaiMonHoc.SelectedValue;
                string soTiet = txtSoTiet.Text.Trim();
                int soTietLoaiMon = monHoc.SoTietLoaiMon;

                ThemMonHocMessage message = _monHocBLLService.ThemMonHoc(maMH, tenMH, maLoaiMonHoc, soTiet, soTietLoaiMon);
                switch (message)
                {
                    case ThemMonHocMessage.EmptyMaMH:
                        MessageBox.Show("Mã môn học không được để trống!");
                        break;
                    case ThemMonHocMessage.EmptyTenMH:
                        MessageBox.Show("Tên môn học không được để trống!");
                        break;
                    case ThemMonHocMessage.EmptySoTiet:
                        MessageBox.Show("Số tiết không được để trống!");
                        break;
                    case ThemMonHocMessage.InvalidSoTiet:
                        MessageBox.Show("Số tiết không hợp lệ, vui lòng nhập lại!");
                        break;
                    case ThemMonHocMessage.DuplicateMaMH:
                        MessageBox.Show("Mã môn học đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemMonHocMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case ThemMonHocMessage.Success:
                        MessageBox.Show("Thêm môn học thành công!");
                        Close();
                        break;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            txtSoTiet.Clear();
        }
    }
}
