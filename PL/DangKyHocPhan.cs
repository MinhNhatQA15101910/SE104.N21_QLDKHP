using BLL;
using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class DangKyHocPhan : KryptonForm
    {
        private readonly ICT_PhieuDKHPBLLService _CT_phieuDKHPBLLService = new CT_DKHPBLLService(new CT_PhieuDKHPDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly IDanhSachMonHocMoBLLService _danhSachMonHocMoBLLService = new DanhSachMonHocMoBLLService(new DanhSachMonHocMoDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly IHocKyBLLService _hocKyBLLService = new HocKyBLLService(new HocKyDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly IPhieuDKHPBLLService _phieuDKHPBLLService = new PhieuDKHPBLLService(new PhieuDKHPDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private IDangKyHocPhanRequester dangKyHocPhanRequester;
        private bool dangKy = false;
        private int selectedIndex1 = -1;
        private int selectedIndex2 = -1;

        public DangKyHocPhan(IDangKyHocPhanRequester requester)
        {
            InitializeComponent();

            dangKyHocPhanRequester = requester;
        }

        private void DangKyHocPhan_Load(object sender, EventArgs e)
        {
            dgvDSMonHocMo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSMonHocMo.MultiSelect = false;
            dgvDSMonHocMo.ReadOnly = true;
            dgvDSMonHocMo.AllowUserToAddRows = false;
            dgvDSMonHocMo.AllowUserToDeleteRows = false;

            dgvDSMHDaChon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSMHDaChon.MultiSelect = false;
            dgvDSMHDaChon.ReadOnly = true;
            dgvDSMHDaChon.AllowUserToAddRows = false;
            dgvDSMHDaChon.AllowUserToDeleteRows = false;

            List<dynamic> listMH = _danhSachMonHocMoBLLService.LayDanhSachMonHocMo(GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc);
            LoadHocKyNamHoc();
            LoadDSMHDaChon();
            LoadDSMonHocMo();
            LoadDataDSMonHocMo(listMH);
            KtDangKyHocPhan();
        }

        private void KtDangKyHocPhan()
        {
            List<PhieuDKHP> list = _phieuDKHPBLLService.LayTTPhieuDKHP(GlobalConfig.CurrNguoiDung.TenDangNhap, GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc);
            if (list.Count > 0 && list[0].MaTinhTrang == 1)
            {
                dangKy = true;
                btnDangKy.Text = "LƯU";

                LoadDataDSMonHocDaChon(list[0].MaPhieuDKHP);

                RemoveMHTrung();
            }

        }
        private void RemoveMHTrung()
        {
            for (int i = 0; i < dgvDSMHDaChon.Rows.Count - 1; i++)
            {
                DataGridViewRow selectedRow1 = dgvDSMHDaChon.Rows[i];

                for (int j = 0; j < dgvDSMonHocMo.Rows.Count - 1; j++)
                {
                    DataGridViewRow selectedRow2 = dgvDSMonHocMo.Rows[j];



                    if (selectedRow1.Cells["MaMH"].Value.ToString().Trim() == selectedRow2.Cells["MaMH"].Value.ToString().Trim())
                    {
                        dgvDSMonHocMo.Rows.Remove(selectedRow2);
                        break;
                    }
                }
            }
        }

        private void LoadDataDSMonHocDaChon(int maPhieuDangKyHocPhan)
        {
            List<dynamic> listMH = _phieuDKHPBLLService.LayDSMHThuocHP2(maPhieuDangKyHocPhan);

            if (listMH.Count > 0)
            {
                foreach (var i in listMH)
                {
                    dgvDSMHDaChon.Rows.Add(i.MaMH, i.TenMH, i.SoTC, i.SoTiet, i.TenLoaiMonHoc);
                }
            }

        }

        private void LoadDSMHDaChon()
        {
            if (dgvDSMHDaChon.Columns.Count == 0)
            {
                dgvDSMHDaChon.Columns.Add("MaMH", "Mã môn học");
                dgvDSMHDaChon.Columns["MaMH"].Width = 100;

                dgvDSMHDaChon.Columns.Add("TenMH", "Tên môn học");
                dgvDSMHDaChon.Columns["TenMH"].Width = 189;

                dgvDSMHDaChon.Columns.Add("SoTC", "Số tín chỉ");
                dgvDSMHDaChon.Columns["SoTC"].Width = 100;

            }

        }

        private void LoadDataDSMonHocMo(List<dynamic> listMH)
        {

            dgvDSMonHocMo.Rows.Clear();
            if (listMH.Count > 0)
            {
                foreach (var i in listMH)
                {
                    dgvDSMonHocMo.Rows.Add(i.MaMH, i.TenMH, i.SoTinChi, i.SoTiet, i.TenLoaiMonHoc);
                }
            }
        }

        private void LoadDSMonHocMo()
        {
            if (dgvDSMonHocMo.Columns.Count == 0)
            {
                dgvDSMonHocMo.Columns.Add("MaMH", "Mã môn học");
                dgvDSMonHocMo.Columns["MaMH"].Width = 100;

                dgvDSMonHocMo.Columns.Add("TenMH", "Tên môn học");
                dgvDSMonHocMo.Columns["TenMH"].Width = 189;

                dgvDSMonHocMo.Columns.Add("SoTC", "Số tín chỉ");
                dgvDSMonHocMo.Columns["SoTC"].Width = 100;
            }
        }

        private void LoadHocKyNamHoc()
        {
            txtHocKy.Text = _hocKyBLLService.LayHKByMaHK(GlobalConfig.CurrMaHocKy);
            txtNamHoc.Text = GlobalConfig.CurrNamHoc.ToString();
        }

        private void dgvDSMonHocMo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                selectedIndex1 = e.RowIndex;

            }
        }

        private void dgvDSMHDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                selectedIndex2 = e.RowIndex;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvDSMHDaChon.Rows.Count > 1)
            {
                if (KtSoTC())
                {
                    if (!dangKy)
                    {
                        // tạo ra phiếu đkhp
                        if (_phieuDKHPBLLService.TaoPhieuDKHP(GlobalConfig.CurrNguoiDung.TenDangNhap, GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc))
                        {
                            int maPhieu = _phieuDKHPBLLService.LayMaPhieuDKHP(GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc); // next: lấy ma Phieu
                            List<string> dsMaMH = new List<string>();
                            // tạo ra ct_phiếu đkhp
                            for (int i = 0; i < dgvDSMHDaChon.Rows.Count - 1; i++)
                                dsMaMH.Add(dgvDSMHDaChon.Rows[i].Cells["MaMH"].Value.ToString());
                            _CT_phieuDKHPBLLService.TaoCT_PhieuDKHP(maPhieu, dsMaMH);
                            MessageBox.Show("Đăng ký thành công");
                            Close();
                        }
                    }
                    else
                    {
                        // update 

                        int maPhieu = _phieuDKHPBLLService.LayMaPhieuDKHP(GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc); // next: lấy ma Phieu
                         _CT_phieuDKHPBLLService.XoaDSMHDKHP(maPhieu);
                        // tạo ra ct_phiếu đkhp
                        List<string> dsMaMH = new List<string>();
                        for (int i = 0; i < dgvDSMHDaChon.Rows.Count - 1; i++)
                            dsMaMH.Add(dgvDSMHDaChon.Rows[i].Cells["MaMH"].Value.ToString());
                        _CT_phieuDKHPBLLService.TaoCT_PhieuDKHP(maPhieu, dsMaMH);
                        MessageBox.Show("Lưu thành công");
                        Close();
                    }

                }
            }
            else
                MessageBox.Show("Bạn chưa chọn môn học nào");
        }

        private bool KtSoTC()
        {
            int soTCToiDa = GlobalConfigBLL.LaySoTinChiToiDa();
            int soTCToiThieu = GlobalConfigBLL.LaySoTinChiToiThieu();
            int tongSoTC = 0;
            foreach (DataGridViewRow i in dgvDSMHDaChon.Rows)
            {
                DataGridViewRow dr = i;

                if (dr.Cells["SoTC"].Value != null)
                {
                    int soTC = int.Parse(dr.Cells["SoTC"].Value.ToString().Trim()); // Chuyển đổi sang decimal
                    tongSoTC += soTC;
                }

            }
            if (tongSoTC <= soTCToiDa && tongSoTC >= soTCToiThieu)
            {

                return true;
            }
            MessageBox.Show("Chưa đủ số tín chỉ quy định!!!\nChú ý:\n  + Số tín chỉ tối đa: " + soTCToiDa.ToString() + "\n  + Số tín chỉ tối thiểu: " + soTCToiThieu.ToString());

            return false;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            imgAll.Visible = false;
            imgTimKiem.Visible = true;
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "🔎 Tìm kiếm";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "🔎 Tìm kiếm")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void DangKyHocPhan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dangKyHocPhanRequester != null)
            {
                dangKyHocPhanRequester.OnDKHPClosing();
            }
        }

        private void dgvDSMonHocMo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSMonHocMo.CurrentRow != null)
            {
                dgvDSMonHocMo.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void dgvDSMHDaChon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSMHDaChon.CurrentRow != null)
            {
                dgvDSMHDaChon.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgAll_Click(object sender, EventArgs e)
        {
            List<dynamic> list = _danhSachMonHocMoBLLService.LayDanhSachMonHocMo(GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc);
            LoadDataDSMonHocMo(list);
            RemoveMHTrung();
            txtTimKiem.Text = "";
            imgAll.Visible = false;
            imgTimKiem.Visible = true;
        }

        private void imgTimKiem_Click(object sender, EventArgs e)
        {
            string monHoc = txtTimKiem.Text.Trim();
            if (monHoc != "")
            {
                List<dynamic> listMH = _danhSachMonHocMoBLLService.TimKiemDanhSachMonHocMo(GlobalConfig.CurrMaHocKy, GlobalConfig.CurrNamHoc, monHoc);
                LoadDataDSMonHocMo(listMH);
                RemoveMHTrung();

            }


            imgTimKiem.Visible = false;
            imgAll.Visible = true;
        }

        private void imgChon_Click(object sender, EventArgs e)
        {
            if (selectedIndex1 != -1)
            {
                if (selectedIndex1 != -1 && dgvDSMonHocMo.Rows[selectedIndex1] != null)
                {
                    DataGridViewRow selectedRow = dgvDSMonHocMo.Rows[selectedIndex1];
                    if (selectedRow.Cells["MaMH"].Value != null)
                    {
                        dgvDSMonHocMo.Rows.RemoveAt(selectedIndex1);
                        dgvDSMHDaChon.Rows.Add(selectedRow);
                    }

                }
                selectedIndex1 = -1;
            }
        }

        private void imgXoa_Click(object sender, EventArgs e)
        {
            if (selectedIndex2 != -1)
            {
                if (selectedIndex2 != -1 && dgvDSMHDaChon.Rows[selectedIndex2] != null)
                {
                    DataGridViewRow selectedRow = dgvDSMHDaChon.Rows[selectedIndex2];
                    if (selectedRow.Cells["MaMH"].Value != null)
                    {
                        dgvDSMonHocMo.Rows.Add(selectedRow.Cells["MaMH"].Value, selectedRow.Cells["TenMH"].Value, selectedRow.Cells["SoTC"]);
                        dgvDSMHDaChon.Rows.RemoveAt(selectedIndex2);
                    }

                }
                selectedIndex2 = -1;
            }
        }
    }
}
