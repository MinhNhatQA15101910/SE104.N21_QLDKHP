using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using PL.Interfaces;

namespace PL
{
    public partial class ThanhToanHocPhi : KryptonForm
    {
        private IThanhToanHocPhiRequester thanhToanHocPhiRequester;
        CultureInfo cultureInfo = new CultureInfo("vi-VN");

        public ThanhToanHocPhi(IThanhToanHocPhiRequester requester)
        {
            InitializeComponent();

            thanhToanHocPhiRequester = requester;
        }

        private void ThanhToanHocPhi_Load(object sender, EventArgs e)
        {
            LoadColumnDSHP();
            LoadDSHP();
        }

        private void LoadDSHP()
        {
            dgvDSHPChuaThanhToan.Rows.Clear();
            List<PhieuDKHP> ds = PhieuDKHPBLL.LayDanhSachDKHPDaXacNhan(GlobalConfig.CurrNguoiDung.TenDangNhap);

            foreach (var i in ds)
            {
                float tienConThieu = PhieuDKHPBLL.TinhHocPhiConThieu(i.MaPhieuDKHP);
                if (i.MaHocKy == 3)
                    dgvDSHPChuaThanhToan.Rows.Add(i.MaPhieuDKHP, "Hè", i.NamHoc, i.NgayLap.ToString("dd/MM/yyyy"), tienConThieu.ToString("c", cultureInfo));
                else
                    dgvDSHPChuaThanhToan.Rows.Add(i.MaPhieuDKHP, i.MaHocKy, i.NamHoc, i.NgayLap.ToString("dd/MM/yyyy"), tienConThieu.ToString("c", cultureInfo));
            }
            txtTongTien.Text = TinhTongTien().ToString("c", cultureInfo);

        }

        private float TinhTongTien()
        {
            float output = 0;
            foreach (DataGridViewRow i in dgvDSHPChuaThanhToan.Rows)
            {
                DataGridViewRow dr = i;

                if (dr.Cells["SoTienConThieu"].Value != null)
                {
                    decimal tienConThieuDecimal = decimal.Parse(dr.Cells["SoTienConThieu"].Value.ToString().Trim(), NumberStyles.Currency, cultureInfo); // Chuyển đổi sang decimal
                    string tienConThieuNormalString = tienConThieuDecimal.ToString(); // Chuyển đổi sang chuỗi định dạng bình thường
                    output += float.Parse(tienConThieuNormalString);
                }

            }
            return output;

        }

        private void LoadColumnDSHP()
        {
            if (dgvDSHPChuaThanhToan.Columns.Count == 0)
            {
                dgvDSHPChuaThanhToan.Columns.Add("MaPhieuDKHP", "Mã phiếu ĐKHP");
                dgvDSHPChuaThanhToan.Columns["MaPhieuDKHP"].Width = 150;

                dgvDSHPChuaThanhToan.Columns.Add("HocKy", "Học kỳ");
                dgvDSHPChuaThanhToan.Columns["HocKy"].Width = 70;

                dgvDSHPChuaThanhToan.Columns.Add("NamHoc", "Năm học");
                dgvDSHPChuaThanhToan.Columns["HocKy"].Width = 100;

                dgvDSHPChuaThanhToan.Columns.Add("NgayLap", "Ngày lập");
                dgvDSHPChuaThanhToan.Columns["NgayLap"].Width = 120;

                dgvDSHPChuaThanhToan.Columns.Add("SoTienConThieu", "Số tiền còn thiếu");
                dgvDSHPChuaThanhToan.Columns["SoTienConThieu"].Width = 150;
                dgvDSHPChuaThanhToan.Columns["SoTienConThieu"].DefaultCellStyle.ForeColor = Color.Red;

                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.HeaderText = "Thanh toán";
                btnColumn.Name = "btnThanhToan";
                btnColumn.Text = "T";
                btnColumn.ToolTipText = "Thanh toán";
                btnColumn.UseColumnTextForButtonValue = true;

                dgvDSHPChuaThanhToan.Columns.Add(btnColumn);


                btnColumn.Width = 100;
            }
        }

        private void dgvDSHPChuaThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột được click là cột button 'Thanh toán'
            if (e.ColumnIndex == dgvDSHPChuaThanhToan.Columns["btnThanhToan"].Index && e.RowIndex >= 0 && dgvDSHPChuaThanhToan.Rows[e.RowIndex].Cells["MaPhieuDKHP"].Value != null)
            {
                int maHP = Convert.ToInt32(dgvDSHPChuaThanhToan.Rows[e.RowIndex].Cells["MaPhieuDKHP"].Value);
                int hocKy;

                if (dgvDSHPChuaThanhToan.Rows[e.RowIndex].Cells["HocKy"].Value.ToString().Trim() == "Hè")
                {
                    hocKy = 3;
                }
                else
                    hocKy = Convert.ToInt32(dgvDSHPChuaThanhToan.Rows[e.RowIndex].Cells["HocKy"].Value);
                int namHoc = Convert.ToInt32(dgvDSHPChuaThanhToan.Rows[e.RowIndex].Cells["NamHoc"].Value);
                string ngayLapStr = dgvDSHPChuaThanhToan.Rows[e.RowIndex].Cells["NgayLap"].Value.ToString();
                DateTime ngayLap;
                if (!DateTime.TryParseExact(ngayLapStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayLap))
                {
                    MessageBox.Show("Lỗi ngày lập");
                }
                // kiểm tra còn trong khoảng tgian đóng hp không ?
                int khoangTGDongHP = GlobalConfigBLL.LayKhoangTGDongHP(hocKy, namHoc);
                TimeSpan kc = ngayLap.Subtract(DateTime.Now);
                if (kc.Days * -1 <= khoangTGDongHP)
                {
                    CT_ThanhToanHocPhi ct_tt = new CT_ThanhToanHocPhi(maHP);
                    ct_tt.ShowDialog();
                    LoadDSHP();
                }
                else
                {
                    MessageBox.Show("Đã hết thời hạn đóng học phí. Vui lòng kiểm tra lại");
                }
            }
        }

        private void ThanhToanHocPhi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thanhToanHocPhiRequester != null)
            {
                thanhToanHocPhiRequester.OnThanhToanHocPhiClosing();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
