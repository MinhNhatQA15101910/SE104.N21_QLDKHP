using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class XacNhanDKHP : KryptonForm
    {
        private IXacNhanDKHPRequester xacNhanDKHPRequester;
        int thisTerm = 3;
        int thisYear = 2024;
        BindingList<PhieuDKHP> mPhieuDKHP;
        BindingList<LoaiMonHoc> mLoaiMonHoc;
        BindingList<DTO.MonHoc> mMonHoc;

        public XacNhanDKHP(IXacNhanDKHPRequester requester)
        {
            InitializeComponent();

            xacNhanDKHPRequester = requester;
            SettingColumnDgvPhieuDKHP();
            SettingColumnDgvMonHoc();
            GetSetting();
            SetUpDgvPhieuDKHP();
            SettingCbSearch();
        }

        private void XacNhanDKHP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xacNhanDKHPRequester != null)
            {
                xacNhanDKHPRequester.OnXacNhanDKHPClosing();
            }
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
            column4.HeaderText = "Số TC";
            column4.Name = "sotc";
            dgv_MonHoc.Columns.Add(column4);
            dgv_MonHoc.Columns[0].Width = 90;
            dgv_MonHoc.Columns[1].Width = 200;
            dgv_MonHoc.Columns[2].Width = 100;
            dgv_MonHoc.Columns[3].Width = 80;
        }
        public void SettingColumnDgvPhieuDKHP()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Mã Phiếu";
            column1.Name = "maphieu";
            dgv_PhieuDKHP.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Ngày Lập";
            column2.Name = "ngaylap";
            dgv_PhieuDKHP.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Học kì";
            column3.Name = "hocky";
            dgv_PhieuDKHP.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Năm Học";
            column4.Name = "namhoc";
            dgv_PhieuDKHP.Columns.Add(column4);
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "MSSV";
            column5.Name = "sotiet";
            dgv_PhieuDKHP.Columns.Add(column5);
            dgv_PhieuDKHP.Columns[0].Width = 100;
            dgv_PhieuDKHP.Columns[1].Width = 120;
            dgv_PhieuDKHP.Columns[2].Width = 100;
            dgv_PhieuDKHP.Columns[3].Width = 120;
            dgv_PhieuDKHP.Columns[4].Width = 100;
        }
        public void GetSetting()
        {
            dgv_MonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MonHoc.ReadOnly = true;
            dgv_MonHoc.AllowUserToAddRows = false;
            dgv_MonHoc.AllowUserToDeleteRows = false;
            dgv_PhieuDKHP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_PhieuDKHP.ReadOnly = true;
            dgv_PhieuDKHP.AllowUserToAddRows = false;
            dgv_PhieuDKHP.AllowUserToDeleteRows = false;
            txt_MaPhieuDKHP.ReadOnly = true;
            txt_MaSV.ReadOnly = true;
            txt_HocKy.ReadOnly = true;
            txt_NamHoc.ReadOnly = true;
            txt_NgayLap.ReadOnly = true;
        }

        public void SettingCbSearch()
        {
            cb_Search.Items.Clear();
            cb_Search.Items.Add("Mã phiếu");
            cb_Search.Items.Add("Ngày lập");
            cb_Search.Items.Add("Học kì");
            cb_Search.Items.Add("Năm học");
            cb_Search.Items.Add("MSSV");
            cb_Search.SelectedIndex = 0;
        }

        public void SetUpDgvPhieuDKHP()
        {
            dgv_PhieuDKHP.Rows.Clear();
            mPhieuDKHP = new BindingList<PhieuDKHP>(PhieuDKHPBLL.GetPhieuDKHP(thisTerm, thisYear, 1));
            foreach (var item in mPhieuDKHP)
            {
                string date = item.NgayLap.ToString("dd/MM/yyyy");
                dgv_PhieuDKHP.Rows.Add(item.MaPhieuDKHP, date, item.MaHocKy, item.NamHoc, item.MaSV);
            }
        }

        public void SetUpDgvMonHoc(int x)
        {
            dgv_MonHoc.Rows.Clear();
            mMonHoc = new BindingList<DTO.MonHoc>(MonHocBLL.GetMonHocPhieuDKHP(x));
            mLoaiMonHoc = new BindingList<DTO.LoaiMonHoc>(LoaiMonHocBLL.LayDSLoaiMonHoc());
            foreach (var item in mMonHoc)
            {
                foreach (var item2 in mLoaiMonHoc)
                {
                    if (item.MaLoaiMonHoc == item2.MaLoaiMonHoc)
                    {
                        int sotc = item.SoTiet / item2.SoTiet;
                        dgv_MonHoc.Rows.Add(item.MaMH, item.TenMH, item.MaLoaiMonHoc, sotc);
                    }
                }
            }
        }

        public void ResetFormXacNhanDKHP()
        {
            SetUpDgvPhieuDKHP();
            txt_MaPhieuDKHP.Text = "";
            txt_NgayLap.Text = "";
            txt_HocKy.Text = "";
            txt_NamHoc.Text = "";
            txt_MaSV.Text = "";
            dgv_MonHoc.Rows.Clear();

        }

        private void dgv_PhieuDKHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgv_PhieuDKHP.SelectedRows[0];
            txt_MaPhieuDKHP.Text = selectedRow.Cells[0].Value.ToString();
            txt_NgayLap.Text = selectedRow.Cells[1].Value.ToString();
            txt_HocKy.Text = selectedRow.Cells[2].Value.ToString();
            txt_NamHoc.Text = selectedRow.Cells[3].Value.ToString();
            txt_MaSV.Text = selectedRow.Cells[4].Value.ToString();
            int x = Int32.Parse(selectedRow.Cells[0].Value.ToString());
            SetUpDgvMonHoc(x);
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (dgv_PhieuDKHP.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_PhieuDKHP.SelectedRows[0];
                int x = Int32.Parse(selectedRow.Cells[0].Value.ToString());
                MessagePhieuDKHPUpdateTinhTrang message = PhieuDKHPBLL.PhieuDKHPUpdateTinhTrang(x, 2);
                switch (message)
                {
                    case MessagePhieuDKHPUpdateTinhTrang.Failed:
                        MessageBox.Show("Xác nhận phiếu ĐKHP thất bại.");
                        break;
                    case MessagePhieuDKHPUpdateTinhTrang.Success:
                        MessageBox.Show("Xác nhận phiếu ĐKHP thành công.");
                        ResetFormXacNhanDKHP();
                        break;
                }
            }
        }

        private void img_Sort_Click(object sender, EventArgs e)
        {
            mPhieuDKHP = new BindingList<PhieuDKHP>(PhieuDKHPBLL.GetPhieuDKHP(thisTerm, thisYear, 1));
            dgv_PhieuDKHP.Rows.Clear();
            foreach (var item in mPhieuDKHP)
            {
                string date = item.NgayLap.ToString("dd/MM/yyyy");
                switch (cb_Search.SelectedIndex)
                {
                    case 0:
                        if (item.MaPhieuDKHP.ToString().ToUpper().Contains(txt_Search.Text.ToString().ToUpper()))
                        {
                            dgv_PhieuDKHP.Rows.Add(item.MaPhieuDKHP, date, item.MaHocKy, item.NamHoc, item.MaSV);
                        }
                        break;
                    case 1:
                        if (date.ToUpper().Contains(txt_Search.Text.ToString().ToUpper()))
                        {
                            dgv_PhieuDKHP.Rows.Add(item.MaPhieuDKHP, date, item.MaHocKy, item.NamHoc, item.MaSV);
                        }
                        break;
                    case 2:
                        if (item.MaHocKy.ToString().ToUpper().Contains(txt_Search.Text.ToString().ToUpper()))
                        {
                            dgv_PhieuDKHP.Rows.Add(item.MaPhieuDKHP, date, item.MaHocKy, item.NamHoc, item.MaSV);
                        }
                        break;
                    case 3:
                        if (item.NamHoc.ToString().ToUpper().Contains(txt_Search.Text.ToString().ToUpper()))
                        {
                            dgv_PhieuDKHP.Rows.Add(item.MaPhieuDKHP, date, item.MaHocKy, item.NamHoc, item.MaSV);
                        }
                        break;
                    case 4:
                        if (item.MaSV.ToString().ToUpper().Contains(txt_Search.Text.ToString().ToUpper()))
                        {
                            dgv_PhieuDKHP.Rows.Add(item.MaPhieuDKHP, date, item.MaHocKy, item.NamHoc, item.MaSV);
                        }
                        break;

                }
            }
        }

        private void img_CancelSort_Click(object sender, EventArgs e)
        {
            SetUpDgvPhieuDKHP();
        }

        private void txt_Search_Enter(object sender, EventArgs e)
        {
            if (txt_Search.Text == "🔎 Tìm kiếm ")
            {
                txt_Search.Text = "";
                txt_Search.ForeColor = Color.Black;
            }
        }

        private void txt_Search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Search.Text))
            {
                txt_Search.Text = "🔎 Tìm kiếm ";
                txt_Search.ForeColor = Color.Gray;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_PhieuDKHP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_PhieuDKHP.CurrentRow != null)
            {
                dgv_PhieuDKHP.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
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
