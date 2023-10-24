using BLL;
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
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaSinhVien : KryptonForm, IThemSuaNganhRequester, IThemSuaHuyenRequester, IThemSuaDoiTuongRequester
    {
        private readonly INganhBLLService _nganhBLLService = new NganhBLLService(new NganhDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly IDoiTuongBLLService _doiTuongBLLService = new DoiTuongBLLService(new DoiTuongDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
		    private readonly ISinhVienBLLService _sinhVienBLLService = new SinhVienBLLService(new SinhVienDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));

		    private readonly IThemSuaSinhVienRequester themSuaSinhVienRequester;
        private readonly CT_SinhVien sinhVien;

        private BindingList<DoiTuong> mDoiTuongSelected;
        private BindingList<DoiTuong> mDoiTuongAll;
        private BindingList<CT_Nganh> mNganh;
        private BindingList<CT_Huyen> mHuyen;

        private BindingSource mDoiTuongSelectedSource;
        private BindingSource mDoiTuongAllSource;
        private BindingSource mNganhSource;
        private BindingSource mHuyenSource;


        public ThemSuaSinhVien(IThemSuaSinhVienRequester requester, CT_SinhVien sinhVien)
        {
            InitializeComponent();

            themSuaSinhVienRequester = requester;
            this.sinhVien = sinhVien;

            SettingProperties();
        }

        public ThemSuaSinhVien(IThemSuaSinhVienRequester requester)
        {
            InitializeComponent();

            themSuaSinhVienRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            Text = "Hồ sơ sinh viên";

            if (sinhVien != null)
            {
                txtMSSV.Text = sinhVien.MaSV;
                txtHoTen.Text = sinhVien.HoTen;
                if (sinhVien.GioiTinh == "Nam")
                {
                    rbtnNam.Checked = true;
                    rbtnNu.Checked = false;
                }
                else
                {
                    rbtnNam.Checked = false;
                    rbtnNu.Checked = true;
                }
                dtpickerNgaySinh.Value = sinhVien.NgaySinh;
                txtMSSV.ReadOnly = true;
            }
            else
            {
                txtMSSV.ReadOnly = false;
            }
        }

        public void OnThemSuaNganhClosing()
        {
            RefreshNganhList();
        }

        public void OnThemSuaHuyenClosing()
        {
            RefreshHuyenList();
        }

        private void RefreshHuyenList()
        {
            mHuyen = new BindingList<CT_Huyen>(HuyenBLL.LayDSHuyen());
            mHuyenSource.DataSource = mHuyen;
        }

        public void OnThemSuaDoiTuongClosing()
        {
            RefreshDoiTuongAllList();
        }

        private void ThemSuaSinhVien_Load(object sender, EventArgs e)
        {
            if (sinhVien != null)
            {
                // Nganh
                mNganh = new BindingList<CT_Nganh>(_nganhBLLService.LayDSNganh());
                mNganhSource = new BindingSource(mNganh, null);
                cmbNganh.DataSource = mNganhSource;
                cmbNganh.DisplayMember = "DisplayNganh";
                cmbNganh.ValueMember = "MaNganh";

                // DoiTuongSelected
                mDoiTuongSelected = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuongBangMaSV(sinhVien.MaSV));
                mDoiTuongSelectedSource = new BindingSource(mDoiTuongSelected, null);
                lbSelectedDoiTuong.DataSource = mDoiTuongSelectedSource;
                lbSelectedDoiTuong.DisplayMember = "TenDT";
                lbSelectedDoiTuong.ValueMember = "MaDT";

                // DoiTuongAll
                mDoiTuongAll = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuongKhongThuocVeMaSV(sinhVien.MaSV));
                mDoiTuongAllSource = new BindingSource(mDoiTuongAll, null);
                cmbDoiTuongAll.DataSource = mDoiTuongAllSource;
                cmbDoiTuongAll.DisplayMember = "TenDT";
                cmbDoiTuongAll.ValueMember = "MaDT";

                // Huyen
                mHuyen = new BindingList<CT_Huyen>(HuyenBLL.LayDSHuyen());
                mHuyenSource = new BindingSource(mHuyen, null);
                cmbHuyen.DataSource = mHuyenSource;
                cmbHuyen.DisplayMember = "DisplayHuyen";
                cmbHuyen.ValueMember = "MaHuyen";


                cmbNganh.SelectedValue = sinhVien.MaNganh;
                cmbHuyen.SelectedValue = sinhVien.MaHuyen;
            }
            else
            {
                // Nganh
                mNganh = new BindingList<CT_Nganh>(_nganhBLLService.LayDSNganh());
                mNganhSource = new BindingSource(mNganh, null);
                cmbNganh.DataSource = mNganhSource;
                cmbNganh.DisplayMember = "DisplayNganh";
                cmbNganh.ValueMember = "MaNganh";

                // DoiTuongSelected
                mDoiTuongSelected = new BindingList<DoiTuong>
                {
                    new DoiTuong
                    {
                        MaDT = 1,
                        TenDT = "Không thuộc đối tượng ưu tiên"
                    }
                };
                mDoiTuongSelectedSource = new BindingSource(mDoiTuongSelected, null);
                lbSelectedDoiTuong.DataSource = mDoiTuongSelectedSource;
                lbSelectedDoiTuong.DisplayMember = "TenDT";
                lbSelectedDoiTuong.ValueMember = "MaDT";

                // DoiTuongAll
                mDoiTuongAll = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuong2());
                mDoiTuongAllSource = new BindingSource(mDoiTuongAll, null);
                cmbDoiTuongAll.DataSource = mDoiTuongAllSource;
                cmbDoiTuongAll.DisplayMember = "TenDT";
                cmbDoiTuongAll.ValueMember = "MaDT";

                // Huyen
                mHuyen = new BindingList<CT_Huyen>(HuyenBLL.LayDSHuyen());
                mHuyenSource = new BindingSource(mHuyen, null);
                cmbHuyen.DataSource = mHuyenSource;
                cmbHuyen.DisplayMember = "DisplayHuyen";
                cmbHuyen.ValueMember = "MaHuyen";
            }
        }

        private void btnThemDoiTuong_Click(object sender, EventArgs e)
        {
            ThemSuaDoiTuong themSuaDoiTuong = new ThemSuaDoiTuong(this);
            themSuaDoiTuong.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            RefreshNganhList();
            RefreshDoiTuongSelectedList();
            RefreshDoiTuongAllList();
            RefreshHuyenList();
        }

        private void RefreshDoiTuongAllList()
        {
            mDoiTuongAll = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuong2());
            mDoiTuongAllSource.DataSource = mDoiTuongAll;
        }

        private void RefreshDoiTuongSelectedList()
        {
            if (sinhVien != null)
            {
                mDoiTuongSelected = new BindingList<DoiTuong>(_doiTuongBLLService.LayDSDoiTuongBangMaSV(sinhVien.MaSV));
                mDoiTuongSelectedSource.DataSource = mDoiTuongSelected;
            }
            else
            {
                mDoiTuongSelected = new BindingList<DoiTuong>
                {
                    new DoiTuong
                    {
                        MaDT = 1,
                        TenDT = "Không thuộc đối tượng ưu tiên"
                    }
                };
                mDoiTuongSelectedSource.DataSource = mDoiTuongSelected;
            }
        }

        private void RefreshNganhList()
        {
            mNganh = new BindingList<CT_Nganh>(_nganhBLLService.LayDSNganh());
            mNganhSource.DataSource = mNganh;
        }

        private void btnThemNganh_Click(object sender, EventArgs e)
        {
            ThemSuaNganh themSuaNganh = new ThemSuaNganh(this);
            themSuaNganh.ShowDialog();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (sinhVien != null)
            {
                string mssvBanDau = sinhVien.MaSV;
                string mssv = txtMSSV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                DateTime ngaySinh = dtpickerNgaySinh.Value;
                string gioiTinh = "Nam";
                if (rbtnNu.Checked)
                {
                    gioiTinh = "Nữ";
                }
                int maHuyen = (int)cmbHuyen.SelectedValue;
                string maNganh = (string)cmbNganh.SelectedValue;
                List<int> maDTList = new List<int>();
                foreach (DoiTuong doiTuong in lbSelectedDoiTuong.Items)
                {
                    maDTList.Add(doiTuong.MaDT);
                }

                SuaSinhVienMessage message = _sinhVienBLLService.SuaSinhVien(mssvBanDau, mssv, hoTen, ngaySinh, gioiTinh, maHuyen, maNganh, maDTList);
                switch (message)
                {
                    case SuaSinhVienMessage.EmptyMaSV:
                        MessageBox.Show("Mã sinh viên không được để trống!");
                        break;
                    case SuaSinhVienMessage.EmptyTenSV:
                        MessageBox.Show("Tên sinh viên không được để trống!");
                        break;
                    case SuaSinhVienMessage.DuplicateMaSV:
                        MessageBox.Show("Mã sinh viên đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case SuaSinhVienMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case SuaSinhVienMessage.Success:
                        MessageBox.Show("Cập nhật sinh viên thành công!");
                        Close();
                        break;
                }
            }
            else
            {
                string mssv = txtMSSV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                DateTime ngaySinh = dtpickerNgaySinh.Value;
                string gioiTinh = "Nam";
                if (rbtnNu.Checked)
                {
                    gioiTinh = "Nữ";
                }
                int maHuyen = (int)cmbHuyen.SelectedValue;
                string maNganh = (string)cmbNganh.SelectedValue;
                List<int> maDTList = new List<int>();
                foreach (DoiTuong doiTuong in lbSelectedDoiTuong.Items)
                {
                    maDTList.Add(doiTuong.MaDT);
                }

                ThemSinhVienMessage message = _sinhVienBLLService.ThemSinhVien(mssv, hoTen, ngaySinh, gioiTinh, maHuyen, maNganh, maDTList);
                switch (message)
                {
                    case ThemSinhVienMessage.EmptyMaSV:
                        MessageBox.Show("Mã sinh viên không được để trống!");
                        break;
                    case ThemSinhVienMessage.EmptyTenSV:
                        MessageBox.Show("Tên sinh viên không được để trống!");
                        break;
                    case ThemSinhVienMessage.DuplicateMaSV:
                        MessageBox.Show("Mã sinh viên đã tồn tại, vui lòng nhập giá trị khác!");
                        break;
                    case ThemSinhVienMessage.Error:
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        break;
                    case ThemSinhVienMessage.Success:
                        if (themSuaSinhVienRequester != null)
                        {
                            themSuaSinhVienRequester.OnThemSuaSinhVienClosing();
                        }

                        MessageBox.Show("Thêm sinh viên thành công!");
                        break;
                }
            }

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picChonDoiTuong_Click(object sender, EventArgs e)
        {
            DoiTuong selectedDoiTuong = (DoiTuong)cmbDoiTuongAll.SelectedItem;

            if (selectedDoiTuong != null)
            {
                if (lbSelectedDoiTuong.Items.Count == 1 && ((DoiTuong)lbSelectedDoiTuong.Items[0]).MaDT == 1)
                {
                    mDoiTuongSelected.Remove((DoiTuong)lbSelectedDoiTuong.Items[0]);
                }
                mDoiTuongSelected.Add(selectedDoiTuong);
                mDoiTuongAll.Remove(selectedDoiTuong);

                mDoiTuongSelectedSource.DataSource = mDoiTuongSelected;
                cmbDoiTuongAll.DataSource = mDoiTuongAll;
            }
        }

        private void picBoChonDoiTuong_Click(object sender, EventArgs e)
        {
            DoiTuong selectedDoiTuong = (DoiTuong)lbSelectedDoiTuong.SelectedItem;

            if (selectedDoiTuong != null)
            {
                if (selectedDoiTuong.MaDT == 1)
                {
                    return;
                }

                if (lbSelectedDoiTuong.Items.Count == 1 && ((DoiTuong)lbSelectedDoiTuong.Items[0]).MaDT == 1)
                {
                    mDoiTuongSelected.Remove((DoiTuong)lbSelectedDoiTuong.Items[0]);
                }
                mDoiTuongAll.Add(selectedDoiTuong);
                mDoiTuongSelected.Remove(selectedDoiTuong);

                if (lbSelectedDoiTuong.Items.Count == 0)
                {
                    mDoiTuongSelected.Add(new DoiTuong
                    {
                        MaDT = 1,
                        TenDT = "Không thuộc đối tượng ưu tiên"
                    });
                }

                mDoiTuongSelectedSource.DataSource = mDoiTuongSelected;
                cmbDoiTuongAll.DataSource = mDoiTuongAll;
            }
        }

        private void ThemSuaSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (themSuaSinhVienRequester != null)
            {
                themSuaSinhVienRequester.OnThemSuaSinhVienClosing();
            }
        }

        private void picThemHuyen_Click(object sender, EventArgs e)
        {
            ThemSuaHuyen themSuaHuyen = new ThemSuaHuyen(this);
            themSuaHuyen.Show();
        }
    }
}
