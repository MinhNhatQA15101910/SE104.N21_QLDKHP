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
    public partial class QuanLyChuongTrinhHoc : KryptonForm
    {
        private IChuongTrinhHocRequester chuongTrinhHocRequester;
        BindingList<Khoa> mKhoa;
        BindingList<Nganh> mNganh;
        BindingList<MonHoc> mChuongTrinhHoc;
        BindingList<ChuongTrinhHoc> mAllCTHoc;

        public QuanLyChuongTrinhHoc(IChuongTrinhHocRequester requester)
        {
            InitializeComponent();

            chuongTrinhHocRequester = requester;
            SettingColumnDgvCTH();
            GetSetting();
            GetCbKhoaItems();
            GetCbNganhItems();
            GetCbHocKyItems();
        }

        public void SettingColumnDgvCTH()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "STT";
            column1.Name = "stt";
            dgv_ChuongTrinhHoc.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Mã MH";
            column2.Name = "mamh";
            dgv_ChuongTrinhHoc.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Tên môn học";
            column3.Name = "TenMH";
            dgv_ChuongTrinhHoc.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Loại môn";
            column4.Name = "loaimon";
            dgv_ChuongTrinhHoc.Columns.Add(column4);
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "Số tiết";
            column5.Name = "sotiet";
            dgv_ChuongTrinhHoc.Columns.Add(column5);
            dgv_ChuongTrinhHoc.Columns[0].Width = 50;
            dgv_ChuongTrinhHoc.Columns[1].Width = 90;
            dgv_ChuongTrinhHoc.Columns[2].Width = 200;
            dgv_ChuongTrinhHoc.Columns[3].Width = 100;
            dgv_ChuongTrinhHoc.Columns[4].Width = 80;
        }
        public void GetSetting()
        {
            cb_Khoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Nganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_HocKy.DropDownStyle = ComboBoxStyle.DropDownList;
            dgv_ChuongTrinhHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ChuongTrinhHoc.MultiSelect = false;
            dgv_ChuongTrinhHoc.ReadOnly = true;
            dgv_ChuongTrinhHoc.AllowUserToAddRows = false;
            dgv_ChuongTrinhHoc.AllowUserToDeleteRows = false;
        }
        public void GetCbKhoaItems()
        {
            cb_Khoa.Items.Clear();
            mKhoa = new BindingList<DTO.Khoa>(KhoaBLL.LayDSKhoa());
            foreach (var item in mKhoa)
            {
                cb_Khoa.Items.Add(item.TenKhoa);
            }
        }
        public void GetCbNganhItems()
        {
            cb_Nganh.Items.Clear();
            cb_Nganh.Text = "";
            if (cb_Khoa.Text != "")
            {
                foreach (var item in mKhoa)
                {
                    if (cb_Khoa.SelectedItem.ToString() == item.TenKhoa.ToString())
                    {
                        mNganh = new BindingList<Nganh>(NganhBLL.GetNganh(item.MaKhoa));
                        break;
                    }
                }
            }
            else
            {
                mNganh = new BindingList<Nganh>(NganhBLL.GetNganh(null));
            }
            foreach (var item in mNganh)
            {
                cb_Nganh.Items.Add(item.TenNganh);
            }

        }
        public void GetCbHocKyItems()
        {
            cb_HocKy.Items.Clear();
            cb_HocKy.Items.Add("Tất cả");
            for (int i = 0; i < 8; i++)
            {
                cb_HocKy.Items.Add("Học kỳ " + (i + 1));
            }
        }

        public void cb_Khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCbNganhItems();
            dgv_ChuongTrinhHoc.Rows.Clear();
        }

        private void cb_Nganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_ChuongTrinhHoc.Rows.Clear();
        }

        private void cb_HocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_ChuongTrinhHoc.Rows.Clear();
        }

        private void btn_AddUpdate_Click(object sender, EventArgs e)
        {
            ThemSuaCTH addUpdate = new ThemSuaCTH();
            addUpdate.Show();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (cb_HocKy.Text != "" && cb_Nganh.Text != "")
            {
                if (dgv_ChuongTrinhHoc.RowCount > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa chương trình học này không?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int x = cb_HocKy.SelectedIndex;
                        string s = null;
                        foreach (var item in mNganh)
                        {
                            if (item.TenNganh == cb_Nganh.Text)
                                s = item.MaNganh;
                            break;
                        }
                        MessageDeleteListCTHoc message = ChuongTrinhHocBLL.DeleteListCTHoc(s, x);
                        switch (message)
                        {
                            case MessageDeleteListCTHoc.Failed:
                                MessageBox.Show("False to connect database");
                                break;
                            case MessageDeleteListCTHoc.ErrorData:
                                MessageBox.Show("False to get data");
                                break;
                            case MessageDeleteListCTHoc.Success:
                                MessageBox.Show("Xóa chương trình học thành công");
                                dgv_ChuongTrinhHoc.Rows.Clear();
                                cb_Nganh.Text = "";
                                cb_Khoa.Text = "";
                                cb_HocKy.Text = "";
                                break;
                        }
                    }

                }
                else MessageBox.Show("Không có chương trình học cần xóa.");
            }
            else MessageBox.Show("Vui lòng chọn ngành và học kì cần xóa.");

        }

        private void img_Sort_Click(object sender, EventArgs e)
        {
            int hk = cb_HocKy.SelectedIndex;
            string ng = null;
            foreach (var nganh in mNganh)
            {
                if ((string)cb_Nganh.SelectedItem == nganh.TenNganh)
                {
                    ng = nganh.MaNganh;
                    break;
                }
            }
            mChuongTrinhHoc = new BindingList<MonHoc>(MonHocBLL.GetChuongTrinhHoc(ng, hk));
            dgv_ChuongTrinhHoc.Rows.Clear();
            if (hk > 0)
            {
                int index = 1;
                foreach (var item in mChuongTrinhHoc)
                {
                    dgv_ChuongTrinhHoc.Rows.Add(index, item.MaMH, item.TenMH, item.MaLoaiMonHoc, item.SoTiet);
                    index++;
                }
                if (dgv_ChuongTrinhHoc.ColumnCount > 5)
                    dgv_ChuongTrinhHoc.Columns.RemoveAt(5);
            }
            else
            {
                mAllCTHoc = new BindingList<DTO.ChuongTrinhHoc>(ChuongTrinhHocBLL.GetAllCTHoc());
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = "Học kỳ";
                column.Name = "hocky";
                dgv_ChuongTrinhHoc.Columns.Add(column);

                int index = 1;
                foreach (var item1 in mChuongTrinhHoc)
                {
                    foreach (var item2 in mAllCTHoc)
                    {
                        if (item1.MaMH == item2.MaMH)
                        {
                            dgv_ChuongTrinhHoc.Rows.Add(index, item1.MaMH, item1.TenMH, item1.MaLoaiMonHoc, item1.SoTiet, item2.HocKy);
                            break;
                        }
                    }
                    index++;
                }

            }
        }

        private void img_CancelSort_Click(object sender, EventArgs e)
        {
            GetCbKhoaItems();
            GetCbNganhItems();
            GetCbHocKyItems();
            dgv_ChuongTrinhHoc.Rows.Clear();
            if (dgv_ChuongTrinhHoc.ColumnCount > 5) dgv_ChuongTrinhHoc.Columns.RemoveAt(5);
        }

        private void QuanLyChuongTrinhHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chuongTrinhHocRequester != null)
            {
                chuongTrinhHocRequester.OnChuongTrinhHocClosing();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_ChuongTrinhHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ChuongTrinhHoc.CurrentRow != null)
            {
                dgv_ChuongTrinhHoc.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }
    }
}
