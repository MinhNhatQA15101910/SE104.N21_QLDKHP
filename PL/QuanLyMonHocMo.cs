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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PL
{
    public partial class QuanLyMonHocMo : KryptonForm, ITraCuuMonHocMoRequester
    {
        #region Register Service
        private readonly IMonHocBLLService _monHocBLLService = new MonHocBLLService(new MonHocDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly IGlobalConfigBLLService _globalConfigBLLService = new GlobalConfigBLLService(new GlobalConfigDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        private readonly IMonHocMoBLLService _monHocMoBLLService = new MonHocMoBLLService(new MonHocMoDALService(new DapperService(), ConfigurationManager.ConnectionStrings["QuanLyDangKyHP"].ConnectionString));
        #endregion

        private IMonHocMoRequester monHocMoRequester;
        BindingList<HocKyNamHoc> mHocKyNamHoc;
        BindingList<MonHoc> mMonHoc;
        BindingList<MonHocMo> mDSMonHocThem = new BindingList<MonHocMo>();
        int NamHocNow = 0;
        int HocKyNow = 0;

        public QuanLyMonHocMo(IMonHocMoRequester requester)
        {
            InitializeComponent();

            monHocMoRequester = requester;
            SettingColumnDgvDSMonHocMo();
            SettingColumnDgvMonHoc();
            SetUpCurrentHocKyNamHoc();
            SetUpHocKyNamHoc();
            Setting();
            SetUpDgv_MonHoc();
            DeleteSameRows();
        }

        public void SettingColumnDgvDSMonHocMo()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Mã MH";
            column1.Name = "mamh";
            dgv_DSMonHocMo.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Tên môn học";
            column2.Name = "TenMH";
            dgv_DSMonHocMo.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Loại môn";
            column3.Name = "loaimon";
            dgv_DSMonHocMo.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Số tiết";
            column4.Name = "sotiet";
            dgv_DSMonHocMo.Columns.Add(column4);
            dgv_DSMonHocMo.Columns[0].Width = 90;
            dgv_DSMonHocMo.Columns[1].Width = 180;
            dgv_DSMonHocMo.Columns[2].Width = 80;
            dgv_DSMonHocMo.Columns[3].Width = 80;
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


        public void Setting()
        {
            txt_HocKyMHM.ReadOnly = true;
            txt_NamHocMHM.ReadOnly = true;
            dgv_MonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MonHoc.ReadOnly = true;
            dgv_MonHoc.AllowUserToAddRows = false;
            dgv_MonHoc.AllowUserToDeleteRows = false;
            dgv_DSMonHocMo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_DSMonHocMo.ReadOnly = true;
            dgv_DSMonHocMo.AllowUserToAddRows = false;
            dgv_DSMonHocMo.AllowUserToDeleteRows = false;
        }

        public void SetUpCurrentHocKyNamHoc()
        {
            mHocKyNamHoc = new BindingList<HocKyNamHoc>(_monHocMoBLLService.GetAllHocKyNamHoc());
            int maxHocKy = 0;
            int maxNamHoc = 0;
            foreach (var item in mHocKyNamHoc)
            {
                HocKyNamHoc lastItem = mHocKyNamHoc[mHocKyNamHoc.Count - 1];
                maxHocKy = lastItem.MaHocKy;
                maxNamHoc = lastItem.NamHoc;
            }
            GlobalConfig.CurrMaHocKy = maxHocKy;
            GlobalConfig.CurrNamHoc = maxNamHoc;
        }

        public void SetUpDgv_MonHoc()
        {
            mMonHoc = new BindingList<MonHoc>(_monHocBLLService.GetTermMonHoc(HocKyNow));
            dgv_MonHoc.Rows.Clear();
            foreach (var mh in mMonHoc)
            {
                dgv_MonHoc.Rows.Add(mh.MaMH, mh.TenMH, mh.MaLoaiMonHoc, mh.SoTiet);
            }
        }
        public void SetUpHocKyNamHoc()
        {
            if (GlobalConfig.CurrMaHocKy < 3)
            {
                HocKyNow = GlobalConfig.CurrMaHocKy + 1;
                NamHocNow = GlobalConfig.CurrNamHoc;
            }
            if (GlobalConfig.CurrMaHocKy == 3)
            {
                HocKyNow = 1;
                NamHocNow = GlobalConfig.CurrNamHoc + 1;
            }
            txt_HocKyMHM.Text = HocKyNow.ToString();
            txt_NamHocMHM.Text = NamHocNow.ToString();

        }
        public void DeleteSameRows()
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row1 in dgv_MonHoc.Rows)
            {
                foreach (DataGridViewRow row2 in dgv_DSMonHocMo.Rows)
                {
                    if (row2.Cells[0].Value != null && row2.Cells[0].Value.ToString() == row1.Cells[0].Value.ToString())
                    {
                        rowsToRemove.Add(row1);
                        break;
                    }
                }
            }

            foreach (DataGridViewRow row in rowsToRemove)
            {
                dgv_MonHoc.Rows.Remove(row);
            }
        }
        public void SearchDgv_MonHoc()
        {
            dgv_MonHoc.Rows.Clear();
            foreach (var mh in mMonHoc)
            {
                if (mh.TenMH.ToString().ToUpper().Contains(txt_SearchMH.Text.ToUpper()) || mh.MaMH.ToString().ToUpper().Contains(txt_SearchMH.Text.ToUpper()))
                    dgv_MonHoc.Rows.Add(mh.MaMH, mh.TenMH, mh.MaLoaiMonHoc, mh.SoTiet);

            }
            DeleteSameRows();
        }


        //Event enter leave tìm kiếm
        public void txt_SearchMH_Enter(object sender, EventArgs e)
        {
            if (txt_SearchMH.Text == "🔎 Tìm kiếm môn học\r\n")
            {
                txt_SearchMH.Text = "";
                txt_SearchMH.ForeColor = Color.Black;
            }
        }
        public void txt_SearchMH_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_SearchMH.Text))
            {
                txt_SearchMH.Text = "🔎 Tìm kiếm môn học\r\n";
                txt_SearchMH.ForeColor = Color.Gray;
            }
        }

        public void btn_Save_Click(object sender, EventArgs e)
        {
            if (dgv_DSMonHocMo.RowCount > 0)
            {
                DialogResult result = MessageBox.Show("Bạn sẽ không được chỉnh sửa sau khi thêm môn học mở.", "Lưu ý", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (txt_SoNgayDongHp.Text == "" || txt_SoNgayDongHp.Text == "0")
                    {
                        MessageBox.Show("Vui lòng nhập lại số ngày đóng học phí.");
                    }
                    else
                    {
                        MessageKhoangTGDongHP message = _globalConfigBLLService.KhoangTGDongHP(HocKyNow, NamHocNow, Int32.Parse(txt_SoNgayDongHp.Text.ToString()));
                        switch (message)
                        {
                            case MessageKhoangTGDongHP.Failed:
                                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại.");
                                break;
                            case MessageKhoangTGDongHP.Success:

                                int addfailed = 0;
                                int addsuccess = 0;
                                foreach (var item in mDSMonHocThem)
                                {
                                    MessageAddMonHocMo Message = _monHocMoBLLService.AddMonHocMo(item.MaMH, item.MaHocKy, item.NamHoc);
                                    switch (Message)
                                    {
                                        case MessageAddMonHocMo.Failed:
                                            addfailed++;
                                            break;
                                        case MessageAddMonHocMo.Success:
                                            addsuccess++;
                                            break;
                                    }
                                }
                                if (addsuccess > 0) MessageBox.Show("Thêm môn học mở thành công.");
                                SetUpCurrentHocKyNamHoc();
                                SetUpHocKyNamHoc();
                                SetUpDgv_MonHoc();
                                dgv_DSMonHocMo.Rows.Clear();
                                break;
                        }
                    }

                }
            }
            else MessageBox.Show("Bạn chưa thêm môn học vào danh sách môn học mở.");
        }

        private void btn_ViewDSMHM_Click(object sender, EventArgs e)
        {
            TraCuuMonHocMo monHocMoTraCuu = new TraCuuMonHocMo(this);
            monHocMoTraCuu.Show();
            Hide();
        }

        private void txt_SoNgayDongHp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void OnTraCuuMonHocMoClosing()
        {
            Show();
        }

        private void img_SearachMH_Click(object sender, EventArgs e)
        {
            SearchDgv_MonHoc();
        }

        private void img_Delete_SearchMH_Click(object sender, EventArgs e)
        {
            SetUpDgv_MonHoc();
            DeleteSameRows();
        }

        private void img_AddMH_Click(object sender, EventArgs e)
        {
            if (dgv_MonHoc.RowCount != 0)
            {
                DataGridViewRow selectedRow = dgv_MonHoc.SelectedRows[0];
                MonHocMo mhm = new MonHocMo();
                mhm.MaMH = selectedRow.Cells[0].Value.ToString();
                mhm.NamHoc = NamHocNow;
                mhm.MaHocKy = HocKyNow;
                bool alreadyExists = mDSMonHocThem.Any(item => item.MaMH == mhm.MaMH);

                if (!alreadyExists)
                {
                    mDSMonHocThem.Add(mhm);
                    dgv_MonHoc.Rows.Remove(selectedRow);
                    dgv_DSMonHocMo.Rows.Add(selectedRow);
                }
            }
        }

        private void img_DeleteMH_Click(object sender, EventArgs e)
        {
            if (dgv_DSMonHocMo.RowCount != 0)
            {
                DataGridViewRow selectedRow = dgv_DSMonHocMo.SelectedRows[0];
                DTO.MonHocMo mhm = new DTO.MonHocMo();
                mhm.MaMH = selectedRow.Cells[0].Value.ToString();
                mhm.NamHoc = NamHocNow;
                mhm.MaHocKy = HocKyNow;
                foreach (var item in mDSMonHocThem)
                {
                    if (item == mhm)
                    {
                        mDSMonHocThem.Remove(item);
                    }
                }
                dgv_DSMonHocMo.Rows.Remove(selectedRow);
                dgv_MonHoc.Rows.Add(selectedRow);
            }
        }

        private void MonHocMo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (monHocMoRequester != null)
            {
                monHocMoRequester.OnMonHocMoClosing();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_MonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_MonHoc.CurrentRow != null)
            {
                dgv_MonHoc.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void dgv_DSMonHocMo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_MonHoc.CurrentRow != null)
            {
                dgv_MonHoc.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }
    }
}