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
    public partial class GV :
        KryptonForm,
        ICaiDatRequester,
        IMonHocMoRequester,
        IXacNhanDKHPRequester,
        INganhRequester,
        IKhoaRequester,
        IChuongTrinhHocRequester,
        IMonHocRequester,
        IDSSVRequester,
        IXacNhanHocPhiRequester,
        IBaoCaoRequester,
        IThanhToanHocPhiRequester
    {
        private IGVRequester gvRequester;

        public GV (IGVRequester requester)
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
            QuanLyLoaiMonHoc quanLyLoaiMonHoc = new QuanLyLoaiMonHoc(this);
            quanLyLoaiMonHoc.Show();
            Hide();
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
            QuanLyNganh quanLyNganh = new QuanLyNganh(this);
            quanLyNganh.Show();
            Hide();
        }
    }
}
