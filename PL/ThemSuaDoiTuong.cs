using BLL.IServices;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaDoiTuong : KryptonForm
    {
        private readonly IDoiTuongBLLService _doiTuongBLLService;

        private IThemSuaDoiTuongRequester themSuaDoiTuongRequester;
        private DoiTuong doiTuong;

        public ThemSuaDoiTuong(IThemSuaDoiTuongRequester requester, IDoiTuongBLLService doiTuongBLLService, DoiTuong doiTuong)
        {
            InitializeComponent();

            themSuaDoiTuongRequester = requester;
            _doiTuongBLLService = doiTuongBLLService;
            this.doiTuong = doiTuong;

            SettingProperties();
        }

        public ThemSuaDoiTuong(IThemSuaDoiTuongRequester requester, IDoiTuongBLLService doiTuongBLLService)
        {
            InitializeComponent();

            themSuaDoiTuongRequester = requester;
            _doiTuongBLLService = doiTuongBLLService;

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

        private void ThemSuaDoiTuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaDoiTuongRequester != null)
            {
                themSuaDoiTuongRequester.OnThemSuaDoiTuongClosing();
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

                SuaDoiTuongMessage message = _doiTuongBLLService.SuaDoiTuong(maDTBanDau, tenDT, tiLeGiam);
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
                    case SuaDoiTuongMessage.Unable:
                        MessageBox.Show("Không thể đổi tên đối tượng vùng sâu vùng xa!");
                        break;
                    case SuaDoiTuongMessage.DuplicateTenDoiTuong:
                        MessageBox.Show("Tên đối tượng đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaDoiTuongMessage.Failed:
                        MessageBox.Show("Sửa đối tượng thất bại!");
                        break;
                    case SuaDoiTuongMessage.Success:
                        MessageBox.Show("Sửa đối tượng thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string tenDT = txtTenDoiTuong.Text.Trim();
                string tiLeGiam = txtTiLeGiam.Text.Trim();

                ThemDoiTuongMessage message = _doiTuongBLLService.ThemDoiTuong(tenDT, tiLeGiam);
                switch (message)
                {
                    case ThemDoiTuongMessage.EmptyTenDoiTuong:
                        MessageBox.Show("Tên đối tượng không được để trống!");
                        break;
                    case ThemDoiTuongMessage.EmptyTiLeGiam:
                        MessageBox.Show("Tỉ lệ giảm học phí không được để trống!");
                        break;
                    case ThemDoiTuongMessage.TiLeGiamKhongHopLe:
                        MessageBox.Show("Tỉ lệ giảm học phí không hợp lệ, vui lòng nhập lại!");
                        break;
                    case ThemDoiTuongMessage.DuplicateTenDoiTuong:
                        MessageBox.Show("Tên đối tượng đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemDoiTuongMessage.Failed:
                        MessageBox.Show("Thêm đối tượng thất bại!");
                        break;
                    case ThemDoiTuongMessage.Success:
                        if (themSuaDoiTuongRequester != null)
                        {
                            themSuaDoiTuongRequester.OnThemSuaDoiTuongClosing();
                        }

                        MessageBox.Show("Thêm đối tượng thành công!");
                        break;
                }
            }
        }
    }
}
