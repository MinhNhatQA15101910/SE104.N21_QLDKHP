using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaLoaiMonHoc : KryptonForm
    {
        private IThemSuaLoaiMonHocRequester themSuaLoaiMonHocRequester;
        private LoaiMonHoc loaiMonHoc;

        public ThemSuaLoaiMonHoc(IThemSuaLoaiMonHocRequester requester, LoaiMonHoc loaiMonHoc)
        {
            InitializeComponent();

            themSuaLoaiMonHocRequester = requester;
            this.loaiMonHoc = loaiMonHoc;

            SettingProperties();
        }

        public ThemSuaLoaiMonHoc(IThemSuaLoaiMonHocRequester requester)
        {
            InitializeComponent();

            themSuaLoaiMonHocRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            if (loaiMonHoc != null)
            {
                Text = "Sửa loại môn học";
                lblThemSuaLoaiMonHoc.Text = "SỬA LOẠI MÔN HỌC";

                txtTenLoaiMonHoc.Text = loaiMonHoc.TenLoaiMonHoc;
                txtSoTiet.Text = loaiMonHoc.SoTiet.ToString();
                txtSoTien.Text = loaiMonHoc.SoTien.ToString();
            }
            else
            {
                Text = "Thêm loại môn học";
                lblThemSuaLoaiMonHoc.Text = "THÊM LOẠI MÔN HỌC";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenLoaiMonHoc.Clear();
            txtSoTiet.Clear();
            txtSoTien.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (loaiMonHoc != null)
            {
                int maLoaiMonHoc = loaiMonHoc.MaLoaiMonHoc;
                string tenLoaiMonHoc = txtTenLoaiMonHoc.Text.Trim();
                string soTiet = txtSoTiet.Text.Trim();
                string soTien = txtSoTien.Text.Trim();

                SuaLoaiMonHocMessage message = LoaiMonHocBLL.SuaLoaiMonHoc(maLoaiMonHoc, tenLoaiMonHoc, soTiet, soTien);
                switch (message)
                {
                    case SuaLoaiMonHocMessage.EmptyTenLoaiMonHoc:
                        MessageBox.Show("Tên loại môn học không được để trống!");
                        break;
                    case SuaLoaiMonHocMessage.EmptySoTiet:
                        MessageBox.Show("Số tiết không được để trống!");
                        break;
                    case SuaLoaiMonHocMessage.EmptySoTien:
                        MessageBox.Show("Số tiền không được để trống!");
                        break;
                    case SuaLoaiMonHocMessage.SoTietKhongHopLe:
                        MessageBox.Show("Số tiết không hợp lệ, vui lòng nhập lại!");
                        break;
                    case SuaLoaiMonHocMessage.SoTienKhongHopLe:
                        MessageBox.Show("Số tiền không hợp lệ, vui lòng nhập lại!");
                        break;
                    case SuaLoaiMonHocMessage.DuplicateTenLoaiMonHoc:
                        MessageBox.Show("Tên loại môn học đã tồn tại, vui lòng nhập lại giá trị khác!");
                        break;
                    case SuaLoaiMonHocMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case SuaLoaiMonHocMessage.Success:
                        MessageBox.Show("Sửa loại môn học thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string tenLoaiMonHoc = txtTenLoaiMonHoc.Text.Trim();
                string soTiet = txtSoTiet.Text.Trim();
                string soTien = txtSoTien.Text.Trim();

                ThemLoaiMonHocMessage message = LoaiMonHocBLL.ThemLoaiMonHoc(tenLoaiMonHoc, soTiet, soTien);
                switch (message)
                {
                    case ThemLoaiMonHocMessage.EmptyTenLoaiMonHoc:
                        MessageBox.Show("Tên loại môn học không được để trống!");
                        break;
                    case ThemLoaiMonHocMessage.EmptySoTiet:
                        MessageBox.Show("Số tiết không được để trống!");
                        break;
                    case ThemLoaiMonHocMessage.EmptySoTien:
                        MessageBox.Show("Số tiền không được để trống!");
                        break;
                    case ThemLoaiMonHocMessage.SoTietKhongHopLe:
                        MessageBox.Show("Số tiết không hợp lệ, vui lòng nhập lại!");
                        break;
                    case ThemLoaiMonHocMessage.SoTienKhongHopLe:
                        MessageBox.Show("Số tiền không hợp lệ, vui lòng nhập lại!");
                        break;
                    case ThemLoaiMonHocMessage.DuplicateTenLoaiMonHoc:
                        MessageBox.Show("Tên loại môn học đã tồn tại, vui lòng nhập lại giá trị khác!");
                        break;
                    case ThemLoaiMonHocMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case ThemLoaiMonHocMessage.Success:
                        if (themSuaLoaiMonHocRequester != null)
                        {
                            themSuaLoaiMonHocRequester.OnThemSuaLoaiMonHocClosing();
                        }

                        MessageBox.Show("Thêm loại môn học thành công!");
                        break;
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThemSuaLoaiMonHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaLoaiMonHocRequester != null)
            {
                themSuaLoaiMonHocRequester.OnThemSuaLoaiMonHocClosing();
            }
        }

        private void btnQuayLai_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
