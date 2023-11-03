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
    public partial class TraCuuMonHocMo : KryptonForm
    {
        #region Register Services
        private readonly IMonHocBLLService _monHocBLLService = new MonHocBLLService(new MonHocDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
        private readonly IMonHocMoBLLService _monHocMoBLLService = new MonHocMoBLLService(new MonHocMoDALService(new DapperService(ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString)));
        #endregion

        private ITraCuuMonHocMoRequester traCuuMonHocMoRequester;
        BindingList<int> mNamHoc;
        BindingList<MonHoc> mMonHoc;
        BindingList<HocKyNamHoc> mHocKyNamHoc;
        public TraCuuMonHocMo(ITraCuuMonHocMoRequester requester)
        {
            InitializeComponent();

            traCuuMonHocMoRequester = requester;
            SettingHocKyNamHoc();
            SettingColumnDgvMonHoc();
            GetSetting();
            SetUpNamHoc();
            SetUpHocKyNamHocMHM();
        }

        public void SettingHocKyNamHoc()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Học kỳ";
            column1.Name = "hocky";
            dgv_MonHocMo.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Năm học";
            column2.Name = "namhoc";
            dgv_MonHocMo.Columns.Add(column2);
            dgv_MonHocMo.Columns[0].Width = 100;
            dgv_MonHocMo.Columns[1].Width = 100;
        }
        public void SettingColumnDgvMonHoc()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Mã MH";
            column1.Name = "mamh";
            dgv_MonHoc.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Tên môn học";
            column2.Name = "TenMH";
            dgv_MonHoc.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Loại môn";
            column3.Name = "loaimon";
            dgv_MonHoc.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Số tiết";
            column4.Name = "sotiet";
            dgv_MonHoc.Columns.Add(column4);
            dgv_MonHoc.Columns[0].Width = 90;
            dgv_MonHoc.Columns[1].Width = 200;
            dgv_MonHoc.Columns[2].Width = 100;
            dgv_MonHoc.Columns[3].Width = 80;
        }

        public void GetSetting()
        {
            dgv_MonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MonHoc.ReadOnly = true;
            dgv_MonHoc.AllowUserToAddRows = false;
            dgv_MonHoc.AllowUserToDeleteRows = false;
            dgv_MonHocMo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MonHocMo.ReadOnly = true;
            dgv_MonHocMo.AllowUserToAddRows = false;
            dgv_MonHocMo.AllowUserToDeleteRows = false;
        }

        public void SetUpNamHoc()
        {
            mNamHoc = new BindingList<int>(_monHocMoBLLService.GetAllNamHoc());
            cb_SearchNH.Items.Clear();
            foreach (var item in mNamHoc)
            {
                cb_SearchNH.Items.Add(item);
            }
        }

        public void SetUpHocKyNamHocMHM()
        {
            mHocKyNamHoc = new BindingList<DTO.HocKyNamHoc>(_monHocMoBLLService.GetAllHocKyNamHoc());
            dgv_MonHocMo.Rows.Clear();
            foreach (var item in mHocKyNamHoc)
            {
                if (item.MaHocKy == 1)
                {
                    dgv_MonHocMo.Rows.Add("Học kỳ I", item.NamHoc);
                }
                else if (item.MaHocKy == 2)
                {
                    dgv_MonHocMo.Rows.Add("Học kỳ II", item.NamHoc);
                }
                else if (item.MaHocKy == 3)
                {
                    dgv_MonHocMo.Rows.Add("Học kỳ hè", item.NamHoc);
                }
            }
        }
        public void GetMonHocMHM(int HocKy, int NamHoc)
        {
            mMonHoc = new BindingList<DTO.MonHoc>(_monHocBLLService.GetTermMonHocMo(HocKy, NamHoc));
            dgv_MonHoc.Rows.Clear();
            foreach (var item in mMonHoc)
            {
                dgv_MonHoc.Rows.Add(item.MaMH, item.TenMH, item.MaLoaiMonHoc, item.SoTiet);
            }
        }

        private void dgv_MonHocMo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgv_MonHocMo.SelectedRows[0];
            int hk = 0;
            if (selectedRow.Cells[0].Value.ToString() == "Học kỳ I")
            {
                hk = 1;
            }
            else if (selectedRow.Cells[0].Value.ToString() == "Học kỳ II")
            {
                hk = 2;
            }
            else if (selectedRow.Cells[0].Value.ToString() == "Học kỳ hè")
            {
                hk = 3;
            }
            int nh = Int32.Parse(selectedRow.Cells[1].Value.ToString());
            cb_SearchHK.SelectedIndex = hk - 1;
            cb_SearchNH.Text = nh.ToString();
            GetMonHocMHM(hk, nh);

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int rowCount = dgv_MonHocMo.Rows.Count;
            DataGridViewRow selectedRow = dgv_MonHocMo.SelectedRows[0];
            if (selectedRow.Index != rowCount - 1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa danh sách môn học mở này không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int hk = 0;
                    if (selectedRow.Cells[0].Value.ToString() == "Học kỳ I")
                    {
                        hk = 1;
                    }
                    else if (selectedRow.Cells[0].Value.ToString() == "Học kỳ II")
                    {
                        hk = 2;
                    }
                    else if (selectedRow.Cells[0].Value.ToString() == "Học kỳ hè")
                    {
                        hk = 3;
                    }
                    int nh = Int32.Parse(selectedRow.Cells[1].Value.ToString());
                    MessageDeleteHocKyNamHocMHM message = _monHocMoBLLService.DeleteHocKyNamHocMHM(hk, nh);
                    switch (message)
                    {
                        case MessageDeleteHocKyNamHocMHM.Failed:
                            MessageBox.Show("Failed to Delete data.");
                            break;
                        case MessageDeleteHocKyNamHocMHM.Success:
                            MessageBox.Show("Xóa danh sách môn học mở thành công.");
                            break;
                    }
                    SetUpHocKyNamHocMHM();
                    dgv_MonHoc.Rows.Clear();
                    cb_SearchHK.Text = "";
                    cb_SearchNH.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bạn không thể xóa danh sách môn học mở hiện tại");
            }

        }

        private void img_SeachMHM_Click(object sender, EventArgs e)
        {
            if (cb_SearchHK.Text != "" || cb_SearchNH.Text != "")
            {
                dgv_MonHocMo.Rows.Clear();
                if (cb_SearchHK.Text == "")
                {
                    foreach (var item in mHocKyNamHoc)
                    {
                        if (item.NamHoc.ToString().Contains(cb_SearchNH.Text.ToString()))
                        {
                            dgv_MonHocMo.Rows.Add(item.MaHocKy, item.NamHoc);
                        }
                    }
                }
                else if (cb_SearchNH.Text == "")
                {
                    foreach (var item in mHocKyNamHoc)
                    {
                        string s = (cb_SearchHK.SelectedIndex + 1).ToString();
                        if (item.MaHocKy.ToString().Contains(s))
                        {
                            dgv_MonHocMo.Rows.Add(item.MaHocKy, item.NamHoc);
                        }
                    }
                }
                else
                {
                    foreach (var item in mHocKyNamHoc)
                    {
                        string s = (cb_SearchHK.SelectedIndex + 1).ToString();
                        if (item.MaHocKy.ToString().Contains(s) && item.NamHoc.ToString().Contains(cb_SearchNH.Text.ToString()))
                        {
                            dgv_MonHocMo.Rows.Add(item.MaHocKy, item.NamHoc);
                            GetMonHocMHM(item.MaHocKy, item.NamHoc);
                            break;
                        }
                    }
                }
            }
        }

        private void img_CancelSeachMHM_Click(object sender, EventArgs e)
        {
            SetUpHocKyNamHocMHM();
            dgv_MonHoc.Rows.Clear();
            cb_SearchHK.Text = "";
            cb_SearchNH.Text = "";
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TraCuuMonHocMo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (traCuuMonHocMoRequester != null)
            {
                traCuuMonHocMoRequester.OnTraCuuMonHocMoClosing();
            }
        }

        private void dgv_MonHocMo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_MonHocMo.CurrentRow != null)
            {
                dgv_MonHocMo.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void dgv_MonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_MonHoc.CurrentRow != null)
            {
                dgv_MonHoc.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }
    }
}
