using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class XacNhanHocPhi : KryptonForm
    {
		private readonly IPhieuDKHPBLLService _phieuDKHPBLLService = new PhieuDKHPBLLService(new PhieuDKHPDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
		private readonly IPhieuThuHPBLLService _phieuThuHPBLLService = new PhieuThuHPBLLService(new PhieuThuHPDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));

		private IThanhToanHocPhiRequester thanhToanHocPhiRequester;
        BindingList<PhieuThuHP> mPhieuThuHP;
        BindingList<PhieuDKHP> mPhieuDKHP;

        public XacNhanHocPhi(IThanhToanHocPhiRequester requester)
        {
            InitializeComponent();

            thanhToanHocPhiRequester = requester;
            SettingColumnXacNhanHocPhi();
            Setting();
            SetUpDgvPhieuDKHP();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (thanhToanHocPhiRequester != null)
            {
                thanhToanHocPhiRequester.OnThanhToanHocPhiClosing();
            }
        }
        public void SettingColumnXacNhanHocPhi()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Mã phiếu thu";
            column1.Name = "mapt";
            dgv_PhieuThuHP.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Mã PDKHP";
            column2.Name = "mapdkhp";
            dgv_PhieuThuHP.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Mã SV";
            column3.Name = "masv";
            dgv_PhieuThuHP.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Ngày lập";
            column4.Name = "ngaylap";
            dgv_PhieuThuHP.Columns.Add(column4);
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "Học kỳ";
            column5.Name = "hocky";
            dgv_PhieuThuHP.Columns.Add(column5);
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            column6.HeaderText = "Năm học";
            column6.Name = "namhoc";
            dgv_PhieuThuHP.Columns.Add(column6);
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            column7.HeaderText = "Số tiền thu";
            column7.Name = "sotienthu";
            dgv_PhieuThuHP.Columns.Add(column7);
            dgv_PhieuThuHP.Columns[0].Width = 130;
            dgv_PhieuThuHP.Columns[1].Width = 130;
            dgv_PhieuThuHP.Columns[2].Width = 120;
            dgv_PhieuThuHP.Columns[3].Width = 120;
            dgv_PhieuThuHP.Columns[4].Width = 110;
            dgv_PhieuThuHP.Columns[5].Width = 110;
            dgv_PhieuThuHP.Columns[6].Width = 120;
        }
        public void Setting()
        {
            dgv_PhieuThuHP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_PhieuThuHP.ReadOnly = true;
            dgv_PhieuThuHP.AllowUserToAddRows = false;
            dgv_PhieuThuHP.AllowUserToDeleteRows = false;
        }

        public void SetUpDgvPhieuDKHP()
        {
            mPhieuDKHP = new BindingList<PhieuDKHP>(_phieuDKHPBLLService.GetAllPhieuDKHP());
            mPhieuThuHP = new BindingList<DTO.PhieuThuHP>(_phieuThuHPBLLService.GetPhieuThuHP(1));
            dgv_PhieuThuHP.Rows.Clear();
            foreach (var item1 in mPhieuThuHP)
            {
                foreach (var item2 in mPhieuDKHP)
                {
                    if (item2.MaPhieuDKHP == item1.MaPhieuDKHP)
                    {
                        string date = item1.NgayLap.ToString("dd/MM/yyyy");
                        dgv_PhieuThuHP.Rows.Add(item1.MaPhieuThuHP, item1.MaPhieuDKHP, item2.MaSV, date, item2.MaHocKy, item2.NamHoc, item1.SoTienThu);
                    }
                }

            }

        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgv_PhieuThuHP.SelectedRows[0];
            int maphieuthuhp = Int32.Parse(selectedRow.Cells[0].Value.ToString());
            MessagePhieuThuHPUpdateTinhTrang message = _phieuThuHPBLLService.PhieuThuHPUpdateTinhTrang(maphieuthuhp, 2);
            switch (message)
            {
                case MessagePhieuThuHPUpdateTinhTrang.Failed:
                    MessageBox.Show("Không thể xác nhận phiếu thu học phí");
                    break;
                case MessagePhieuThuHPUpdateTinhTrang.Success:
                    SetUpDgvPhieuDKHP();
                    break;
            }

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_PhieuThuHP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_PhieuThuHP.CurrentRow != null)
            {
                dgv_PhieuThuHP.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }
    }
}
