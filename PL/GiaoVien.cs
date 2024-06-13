using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class GiaoVien :
        KryptonForm,
        ICaiDatRequester,
        IMonHocMoRequester,
        IXacNhanDKHPRequester,
        INganhRequester,
        IKhoaRequester,
        IChuongTrinhHocRequester,
        IMonHocRequester,
        IDanhSachSinhVienRequester,
        IXacNhanHocPhiRequester,
        IBaoCaoRequester,
        IThanhToanHocPhiRequester
    {
        private readonly IGVRequester gvRequester;

        public GiaoVien (IGVRequester requester)
        {
            InitializeComponent();

            gvRequester = requester;
        }

        public void OnBaoCaoClosing()
        {
            Show();
        }

        public void OnCaiDatClosing()
        {
            Show();
        }

        public void OnChuongTrinhHocClosing()
        {
            Show();
        }

        public void OnDSSVClosing()
        {
            Show();
        }

        public void OnKhoaClosing()
        {
            Show();
        }

        public void OnMonHocClosing()
        {
            Show();
        }

        public void OnMonHocMoClosing()
        {
            Show();
        }

        public void OnNganhClosing()
        {
            Show();
        }

        public void OnThanhToanHocPhiClosing()
        {
            Show();
        }

        public void OnXacNhanDKHPClosing()
        {
            Show();
        }

        public void OnXacNhanHocPhiClosing()
        {
            Show();
        }

        private void GV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                if (gvRequester != null)
                {
                    gvRequester.OnGVClosing();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void picCaiDat_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                QuanLyLoaiMonHoc quanLyLoaiMonHoc = new QuanLyLoaiMonHoc(this);
                quanLyLoaiMonHoc.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.Show();
        }

        private void imgDangXuat_Click(object sender, EventArgs e)
        {
            pnlDangXuat.Visible = !pnlDangXuat.Visible;
        }

        private void btnNganh_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                QuanLyNganh quanLyNganh = new QuanLyNganh(this);
                quanLyNganh.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                QuanLyKhoa quanLyKhoa = new QuanLyKhoa(this);
                quanLyKhoa.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                QuanLyMonHoc quanLyMonHoc = new QuanLyMonHoc(this);
                quanLyMonHoc.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnDSSV_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                QuanLySinhVien quanLySinhVien = new QuanLySinhVien(this);
                quanLySinhVien.Show();
                Hide();
            } 
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void picBaoCao_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "tv")
            {
                BaoCao baoCao = new BaoCao(this);
                baoCao.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnQuanLyMonHocMo_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                QuanLyMonHocMo quanLyMonHocMo = new QuanLyMonHocMo(this);
                quanLyMonHocMo.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnChuongTrinhHoc_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                QuanLyChuongTrinhHoc quanLyChuongTrinhHoc = new QuanLyChuongTrinhHoc(this);
                quanLyChuongTrinhHoc.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnXacNhanDKHP_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "gv")
            {
                XacNhanDKHP xacNhanDKHP = new XacNhanDKHP(this);
                xacNhanDKHP.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.",
                    "Không cho phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void btnXacNhanThanhToanHP_Click(object sender, EventArgs e)
        {
            if (GlobalConfig.CurrNguoiDung.MaNhom == "tv")
            {
                XacNhanHocPhi xacNhanHocPhi = new XacNhanHocPhi(this);
                xacNhanHocPhi.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Bạn không thể sử dụng chức năng này.", 
                    "Không cho phép", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
    }
}
