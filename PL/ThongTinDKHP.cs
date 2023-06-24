using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace PL
{
    public partial class ThongTinDKHP : KryptonForm
    {
        public ThongTinDKHP()
        {
            InitializeComponent();
        }

        private void ThongTinDKHP_Load(object sender, EventArgs e)
        {
            LoadCmbHK();
            LoadDSMH();
        }
        private void LoadCmbHK()
        {
            List<HocKy> ds = HocKyBLL.LayDanhSachHK();
            cmbHocKy.DisplayMember = "TenHocKy";
            cmbHocKy.ValueMember = "MaHocKy";
            cmbHocKy.DataSource = ds;
        }

        private void LoadDSMH()
        {
            if (dgvDSMH.Columns.Count == 0)
            {
                dgvDSMH.Columns.Add("MaMH", "Mã môn học");
                dgvDSMH.Columns["MaMH"].Width = 100;

                dgvDSMH.Columns.Add("TenMH", "Tên môn học");
                dgvDSMH.Columns["TenMH"].Width = 180;

                dgvDSMH.Columns.Add("SoTC", "Số tín chỉ");
                dgvDSMH.Columns["SoTC"].Width = 100;

            }
        }

        private int TinhTongSoTC()
        {
            int output = 0;
            foreach (DataGridViewRow i in dgvDSMH.Rows)
            {

                DataGridViewRow dr = i;
                if (dr.Cells["SoTC"].Value != null)
                    output += int.Parse(dr.Cells["SoTC"].Value.ToString().Trim());

            }
            return output;

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgTimKiem_Click(object sender, EventArgs e)
        {
            txtSoPhieuDKHP.Text = "";
            txtTongSoTC.Text = "0";
            dgvDSMH.Rows.Clear();
            txtNgayLap.Text = "";
            if (cmbHocKy.SelectedItem != null)
            {
                string namHocS = txtNamHoc.Text.Trim();
                TimKiemPhieuDKHPMessage message = PhieuDKHPBLL.KtTimKiemPhieuDKHP(namHocS);
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
                            List<PhieuDKHP> ds = PhieuDKHPBLL.LayTTPhieuDKHP(GlobalConfig.CurrNguoiDung.TenDangNhap, hocKy, namHoc);
                            if (ds.Count > 0 && ds[0] != null)
                            {
                                PhieuDKHP kq = ds[0];
                                int maPhieuDKHP = int.Parse(kq.MaPhieuDKHP.ToString().Trim());

                                if (kq != null)
                                {
                                    txtSoPhieuDKHP.Text = maPhieuDKHP.ToString();
                                    txtNgayLap.Text = kq.NgayLap.ToString("dd/MM/yyyy");
                                }

                                List<dynamic> dsMonHoc = PhieuDKHPBLL.LayDSMHThuocHP(maPhieuDKHP);
                                foreach (var mh in dsMonHoc)
                                {
                                    dgvDSMH.Rows.Add(mh.MaMH, mh.TenMH, mh.SoTC);
                                }

                                txtTongSoTC.Text = TinhTongSoTC().ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tồn tại thông tin đăng ký học phần");
                            }
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chọn học kì");
            }
        }
    }
}
