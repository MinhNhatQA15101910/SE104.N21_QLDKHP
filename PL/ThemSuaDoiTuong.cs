using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaDoiTuong : KryptonForm
    {
        private IThemSuaDoiTuongRequester themSuaDoiTuongRequester;
        private DoiTuong doiTuong;

        public ThemSuaDoiTuong(IThemSuaDoiTuongRequester requester, DoiTuong doiTuong)
        {
            InitializeComponent();

            themSuaDoiTuongRequester = requester;
            this.doiTuong = doiTuong;

            SettingProperties();
        }

        public ThemSuaDoiTuong(IThemSuaDoiTuongRequester requester)
        {
            InitializeComponent();

            themSuaDoiTuongRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            if (doiTuong != null)
            {
                Text = "Sửa đối tượng";
                lblThemSuaDoiTuong.Text = "SỬA ĐỐI TƯỢNG";

                txtTenDoiTuong.Text = doiTuong.TenDT;
                txtTiLeGiam.Text = doiTuong.TiLeGiamHocPhi.ToString();
            }
            else
            {
                Text = "Thêm đối tượmg";
                lblThemSuaDoiTuong.Text = "THÊM ĐỐI TƯỢNG";
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenDoiTuong.Clear();
            txtTiLeGiam.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (doiTuong != null)
            {
                int maDTBanDau = doiTuong.MaDT;
                string tenDT = txtTenDoiTuong.Text.Trim();
                string tiLeGiam = txtTiLeGiam.Text.Trim();

                SuaDoiTuongMessage message = DoiTuongBLL.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);
                switch (message)
                {
                    case SuaDoiTuongMessage.EmptyTenDoiTuong:
                        MessageBox.Show("Tên đối tượng không được để trống!");
                        break;
                    case SuaDoiTuongMessage.EmptyTiLeGiam:
                        MessageBox.Show("Tỉ lệ giảm học phí không được để trống!");
                        break;
                    case SuaDoiTuongMessage.TiLeGiamKhongHopLe:
                        MessageBox.Show("Tỉ lệ giảm học phí không hợp lệ, vui lòng nhập lại!");
                        break;
                    case SuaDoiTuongMessage.DuplicateTenDoiTuong:
                        MessageBox.Show("Tên đối tượng đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaDoiTuongMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case SuaDoiTuongMessage.Success:
                        MessageBox.Show("Sửa đối tượng thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                //string tenDT = txtTenDoiTuong.Text.Trim();
                //string tiLeGiam = txtTiLeGiam.Text.Trim();

                //ThemDoiTuongMessage message = DoiTuongBLL.ThemDoiTuong(tenDT, tiLeGiam);
                //switch (message)
                //{
                //    case ThemDoiTuongMessage.EmptyTenDoiTuong:
                //        MessageBox.Show("Tên đối tượng không được để trống!");
                //        break;
                //    case ThemDoiTuongMessage.EmptyTiLeGiam:
                //        MessageBox.Show("Tỉ lệ giảm học phí không được để trống!");
                //        break;
                //    case ThemDoiTuongMessage.TiLeGiamKhongHopLe:
                //        MessageBox.Show("Tỉ lệ giảm học phí không hợp lệ, vui lòng nhập lại!");
                //        break;
                //    case ThemDoiTuongMessage.DuplicateTenDoiTuong:
                //        MessageBox.Show("Tên đối tượng đã tồn tại, vui lòng nhập giá trị khác!");
                //        break;
                //    case ThemDoiTuongMessage.Error:
                //        MessageBox.Show("Đã có lỗi xảy ra!");
                //        break;
                //    case ThemDoiTuongMessage.Success:
                //        MessageBox.Show("Thêm đối tượng thành công!");
                //        Close();
                //        break;
                //}
            }
        }

        private void ThemSuaDoiTuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaDoiTuongRequester != null)
            {
                themSuaDoiTuongRequester.OnThemSuaDoiTuongClosing();
            }
        }
    }
}
