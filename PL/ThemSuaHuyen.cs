using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaHuyen : KryptonForm, IThemSuaTinhRequester
    {
        #region Register Services
        private readonly ITinhBLLService _tinhBLLService = new TinhBLLService(
            new TinhDALService(new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)),
            new HuyenDALService(new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
        private readonly IHuyenBLLService _huyenBLLService = new HuyenBLLService(
            new HuyenDALService(new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)),
            new SinhVienDALService(new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
        #endregion

        private IThemSuaHuyenRequester themSuaHuyenRequester;
        private Huyen huyen;
        private BindingList<Tinh> mTinh;
        private List<string> mUT;
        private BindingSource mSource;

        public ThemSuaHuyen(IThemSuaHuyenRequester requester, Huyen huyen)
        {
            InitializeComponent();

            themSuaHuyenRequester = requester;
            this.huyen = huyen;

            SettingProperties();
        }

        public ThemSuaHuyen(IThemSuaHuyenRequester requester)
        {
            InitializeComponent();

            themSuaHuyenRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            mUT = new List<string>();
            mUT.Add("Có");
            mUT.Add("Không");
            cmbKVUT.DataSource = mUT;

            if (huyen != null)
            {
                Text = "Sửa huyện";
                lblThemSuaHuyen.Text = "SỬA HUYỆN";

                txtTenHuyen.Text = huyen.TenHuyen;
                cmbKVUT.SelectedIndex = 0;
            }
            else
            {
                Text = "Thêm huyện";
                lblThemSuaHuyen.Text = "THÊM HUYỆN";
            }
        }

        public void OnThemSuaTinhClosing()
        {
            mTinh = new BindingList<Tinh>(_tinhBLLService.LayDSTinh());
            mSource.DataSource = mTinh;
        }

        private void ThemSuaHuyen_Load(object sender, EventArgs e)
        {
            mTinh = new BindingList<Tinh>(_tinhBLLService.LayDSTinh());
            mSource = new BindingSource(mTinh, null);
            cmbTinh.DataSource = mSource;
            cmbTinh.DisplayMember = "TenTTP";
            cmbTinh.ValueMember = "MaTinh";

            if (huyen != null)
            {
                cmbTinh.SelectedValue = huyen.MaTinh;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenHuyen.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (huyen != null)
            {
                int maHuyen = huyen.MaHuyen;
                string tenHuyen = txtTenHuyen.Text.Trim();
                int vungUT = 1;
                if (cmbKVUT.SelectedIndex == 1)
                {
                    vungUT = 0;
                }
                int maTinh = (int)cmbTinh.SelectedValue;

                SuaHuyenMessage message = _huyenBLLService.SuaHuyen(maHuyen, tenHuyen, vungUT, maTinh);
                switch (message)
                {
                    case SuaHuyenMessage.EmptyTenHuyen:
                        MessageBox.Show("Tên huyện không được để trống!");
                        break;
                    case SuaHuyenMessage.DuplicateTenHuyen:
                        MessageBox.Show("Tên huyện đã tồn tại trong tỉnh này, vui lòng nhập giá trị khác!");
                        break;
                    case SuaHuyenMessage.Success:
                        MessageBox.Show("Sửa huyện thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string tenHuyen = txtTenHuyen.Text.Trim();
                int vungUT = 1;
                if (cmbKVUT.SelectedIndex == 1)
                {
                    vungUT = 0;
                }
                int maTinh = (int)cmbTinh.SelectedValue;

                ThemHuyenMessage message = _huyenBLLService.ThemHuyen(tenHuyen, vungUT, maTinh);
                switch (message)
                {
                    case ThemHuyenMessage.EmptyTenHuyen:
                        MessageBox.Show("Tên huyện không được để trống!");
                        break;
                    case ThemHuyenMessage.DuplicateTenHuyen:
                        MessageBox.Show("Tên huyện đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemHuyenMessage.Success:
                        if (themSuaHuyenRequester != null)
                        {
                            themSuaHuyenRequester.OnThemSuaHuyenClosing();
                        }

                        MessageBox.Show("Thêm huyện thành công!");
                        break;
                }
            }
        }

        private void btnThemTinh_Click(object sender, EventArgs e)
        {
            ThemSuaTinh themSuaTinh = new ThemSuaTinh(this);
            themSuaTinh.ShowDialog();
        }

        private void ThemSuaHuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaHuyenRequester != null)
            {
                themSuaHuyenRequester.OnThemSuaHuyenClosing();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
