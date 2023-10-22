using BLL;
using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.IServices;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace PL
{
    public partial class BaoCao : KryptonForm
    {
		private readonly ISinhVienBLLService _sinhVienBLLService = new SinhVienBLLService(new SinhVienDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
		private readonly IPhieuDKHPBLLService _phieuDKHPBLLService = new PhieuDKHPBLLService(new PhieuDKHPDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));

		private IBaoCaoRequester baoCaoRequester;

        public BaoCao(IBaoCaoRequester requester)
        {
            InitializeComponent();

            baoCaoRequester = requester;
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            LoadHocKy();
            LoadDSSV();
        }

        private void LoadDSSV()
        {
            if (dgvDSSV.Columns.Count == 0)
            {
                dgvDSSV.Columns.Add("MSSV", "MSSV");
                dgvDSSV.Columns["MSSV"].Width = 135;

                dgvDSSV.Columns.Add("TienDK", "Số tiền đăng ký");
                dgvDSSV.Columns["TienDK"].Width = 200;

                dgvDSSV.Columns.Add("TienPhaiDong", "Số tiền phải đóng");
                dgvDSSV.Columns["TienPhaiDong"].Width = 200;

                dgvDSSV.Columns.Add("TienConLai", "Số tiền còn lại");
                dgvDSSV.Columns["TienConLai"].Width = 200;
            }
        }

        private void LoadHocKy()
        {
            List<HocKy> ds = HocKyBLL.LayDanhSachHK();
            cmbHocKy.DisplayMember = "TenHocKy";
            cmbHocKy.ValueMember = "MaHocKy";
            cmbHocKy.DataSource = ds;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dgvDSSV.Rows.Clear();

            if (cmbHocKy.SelectedItem != null)
            {
                string namHocS = txtNamHoc.Text.Trim();
                TimKiemPhieuDKHPMessage message = _phieuDKHPBLLService.KtTimKiemPhieuDKHP(namHocS);
                switch (message)
                {
                    case TimKiemPhieuDKHPMessage.EmptyNamHoc:
                        MessageBox.Show("Vui lòng nhập năm học");
                        break;
                    case TimKiemPhieuDKHPMessage.InvalidNamHoc:
                        MessageBox.Show("Năm học không hợp lệ");
                        break;
                    case TimKiemPhieuDKHPMessage.Sucess:
                        {
                            // kt đk năm học 
                            int namHoc = int.Parse(txtNamHoc.Text.Trim());
                            int hocKy = int.Parse(cmbHocKy.SelectedValue.ToString());
                            LoadDataDSSV(hocKy, namHoc);


                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chọn học kì");
            }
        }

        private void LoadDataDSSV(int hocKy, int namHoc)
        {
            List<dynamic> ds = _sinhVienBLLService.BaoCaoSinhVienChuaDongHocPhi(hocKy, namHoc);

            foreach (var i in ds)
            {
                dgvDSSV.Rows.Add(i.MSSV, i.TienDK, i.TienPhaiDong, i.TienConLai);
            }

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            if (cmbHocKy.SelectedItem != null)
            {
                string namHocS = txtNamHoc.Text.Trim();
                TimKiemPhieuDKHPMessage message = _phieuDKHPBLLService.KtTimKiemPhieuDKHP(namHocS);
                switch (message)
                {
                    case TimKiemPhieuDKHPMessage.EmptyNamHoc:
                        MessageBox.Show("Vui lòng nhập năm học");
                        break;
                    case TimKiemPhieuDKHPMessage.InvalidNamHoc:
                        MessageBox.Show("Năm học không hợp lệ");
                        break;
                    case TimKiemPhieuDKHPMessage.Sucess:
                        {
                            // kt đk năm học 
                            int namHoc = int.Parse(txtNamHoc.Text.Trim());
                            int hocKy = int.Parse(cmbHocKy.SelectedValue.ToString());

                            InBaoCao i = new InBaoCao(hocKy, namHoc);
                            i.Show();
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chọn học kì");
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BaoCao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (baoCaoRequester != null)
            {
                baoCaoRequester.OnBaoCaoClosing();
            }
        }
    }
}
