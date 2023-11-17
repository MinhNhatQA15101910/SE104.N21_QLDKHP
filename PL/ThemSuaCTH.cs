using BLL.IServices;
using BLL.Services;
using ComponentFactory.Krypton.Toolkit;
using DAL.Services;
using DTO;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class ThemSuaCTH : KryptonForm
    {
        private readonly IKhoaBLLService _khoaBLLService;
        private readonly INganhBLLService _nganhBLLService;
        private readonly IChuongTrinhHocBLLService _chuongtrinhhocBLLService;
        private readonly IMonHocBLLService _monHocBLLService;

        BindingList<Khoa> mKhoa;
        BindingList<Nganh> mNganh;
        BindingList<MonHoc> mMonHoc;
        BindingList<MonHoc> mChuongTrinhHoc;
        BindingList<ChuongTrinhHoc> mDSMonHocThem = new BindingList<ChuongTrinhHoc>();
        BindingList<ChuongTrinhHoc> mDSMonHocXoa = new BindingList<ChuongTrinhHoc>();
        public ThemSuaCTH(IKhoaBLLService khoaBLLService, INganhBLLService nganhBLLService, IChuongTrinhHocBLLService chuongTrinhHocBLLService, IMonHocBLLService monHocBLLService)
        {
            _khoaBLLService = khoaBLLService;
            _nganhBLLService = nganhBLLService;
            _chuongtrinhhocBLLService = chuongTrinhHocBLLService;
            _monHocBLLService = monHocBLLService;

            InitializeComponent();
            SettingColumnDgvDSMonHoc();
            SettingColumnDgvDSMonHocChon();
            GetCbKhoaItems();
            GetCbNganhItems();
            GetCbHocKyItems();
            GetSetting();
            SetUpDgvMonHoc();
        }
        public void SettingColumnDgvDSMonHoc()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Mã MH";
            column1.Name = "mamh";
            dgv_DSMonHoc.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Tên môn học";
            column2.Name = "TenMH";
            dgv_DSMonHoc.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Loại môn";
            column3.Name = "loaimon";
            dgv_DSMonHoc.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Số tiết";
            column4.Name = "sotiet";
            dgv_DSMonHoc.Columns.Add(column4);
            dgv_DSMonHoc.Columns[0].Width = 90;
            dgv_DSMonHoc.Columns[1].Width = 200;
            dgv_DSMonHoc.Columns[2].Width = 100;
            dgv_DSMonHoc.Columns[3].Width = 80;
        }
        public void SettingColumnDgvDSMonHocChon()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Mã MH";
            column1.Name = "mamh";
            dgv_DSMonHocChon.Columns.Add(column1);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Tên môn học";
            column2.Name = "TenMH";
            dgv_DSMonHocChon.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Loại môn";
            column3.Name = "loaimon";
            dgv_DSMonHocChon.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Số tiết";
            column4.Name = "sotiet";
            dgv_DSMonHocChon.Columns.Add(column4);
            dgv_DSMonHocChon.Columns[0].Width = 90;
            dgv_DSMonHocChon.Columns[1].Width = 200;
            dgv_DSMonHocChon.Columns[2].Width = 100;
            dgv_DSMonHocChon.Columns[3].Width = 80;
        }


        public void GetSetting()
        {
            cb_Khoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Nganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_HocKy.DropDownStyle = ComboBoxStyle.DropDownList;
            dgv_DSMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_DSMonHoc.ReadOnly = true;
            dgv_DSMonHoc.AllowUserToAddRows = false;
            dgv_DSMonHoc.AllowUserToDeleteRows = false;
            dgv_DSMonHocChon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_DSMonHocChon.ReadOnly = true;
            dgv_DSMonHocChon.AllowUserToAddRows = false;
            dgv_DSMonHocChon.AllowUserToDeleteRows = false;
        }
        public void GetCbKhoaItems()
        {
            cb_Khoa.Items.Clear();
            mKhoa = new BindingList<DTO.Khoa>(_khoaBLLService.LayDSKhoa());
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
                    if (cb_Khoa.Text.ToString() == item.TenKhoa.ToString())
                    {
                        mNganh = new BindingList<DTO.Nganh>(_nganhBLLService.GetNganh(item.MaKhoa));
                        break;
                    }
                }
            }
            else
            {
                mNganh = new BindingList<DTO.Nganh>(_nganhBLLService.GetNganh(null));
            }
            foreach (var item in mNganh)
            {
                cb_Nganh.Items.Add(item.TenNganh);
            }

        }
        public void GetCbHocKyItems()
        {
            cb_HocKy.Items.Clear();
            for (int i = 0; i < 8; i++)
            {
                cb_HocKy.Items.Add("Học kỳ " + (i + 1));
            }
        }
        public void SetUpDgvMonHoc()
        {
            dgv_DSMonHoc.Rows.Clear();
            mMonHoc = new BindingList<MonHoc>(_monHocBLLService.LayDSMonHoc2());
            foreach (var item in mMonHoc)
            {
                dgv_DSMonHoc.Rows.Add(item.MaMH, item.TenMH, item.MaLoaiMonHoc, item.SoTiet);
            }
        }

        public void SetUpDgvMonHocChon()
        {
            dgv_DSMonHocChon.Rows.Clear();
            if (cb_HocKy.Text != "" && cb_Nganh.Text != "")
            {
                int x = cb_HocKy.SelectedIndex + 1;
                mNganh = new BindingList<DTO.Nganh>(_nganhBLLService.GetNganh(null));
                foreach (var item in mNganh)
                {
                    if (item.TenNganh == cb_Nganh.Text)
                    {
                        mChuongTrinhHoc = new BindingList<MonHoc>(_monHocBLLService.GetChuongTrinhHoc(item.MaNganh, x));
                        break;
                    }
                }
                foreach (var item in mChuongTrinhHoc)
                {
                    dgv_DSMonHocChon.Rows.Add(item.MaMH, item.TenMH, item.MaLoaiMonHoc, item.SoTiet);
                }
            }
        }

        public void DeleteSameRows()
        {
            foreach (DataGridViewRow row1 in dgv_DSMonHoc.Rows)
            {
                foreach (DataGridViewRow row2 in dgv_DSMonHocChon.Rows)
                {
                    if (row2.Cells[0].Value.ToString() != null && row2.Cells[0].Value.ToString() == row1.Cells[0].Value.ToString())
                    {
                        dgv_DSMonHoc.Rows.Remove(row1);
                        break;
                    }
                }
            }
        }

        private void cb_Nganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUpDgvMonHocChon();
            SetUpDgvMonHoc();
            DeleteSameRows();
            if (mDSMonHocThem != null) mDSMonHocThem.Clear();
            if (mDSMonHocXoa != null) mDSMonHocXoa.Clear();
        }

        private void cb_HocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUpDgvMonHocChon();
            SetUpDgvMonHoc();
            DeleteSameRows();
            if (mDSMonHocThem != null) mDSMonHocThem.Clear();
            if (mDSMonHocXoa != null) mDSMonHocXoa.Clear();
        }

        private void cb_Khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCbNganhItems();
            if (mDSMonHocThem != null) mDSMonHocThem.Clear();
            if (mDSMonHocXoa != null) mDSMonHocXoa.Clear();
        }

        private void txt_Search_Enter(object sender, EventArgs e)
        {
            if (txt_Search.Text == "🔎 Tìm kiếm môn học\r\n")
            {
                txt_Search.Text = "";
                txt_Search.ForeColor = Color.Black;
            }
        }

        private void txt_Search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Search.Text))
            {
                txt_Search.Text = "🔎 Tìm kiếm môn học\r\n";
                txt_Search.ForeColor = Color.Gray;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int failed = 0, success = 0;
            if (mDSMonHocThem != null)
            {
                foreach (var item in mDSMonHocThem)
                {
                    if (item != null)
                    {
                        MessageAddCTHoc message = _chuongtrinhhocBLLService.AddCTHoc(item);
                        switch (message)
                        {
                            case MessageAddCTHoc.Failed:
                                failed++;
                                break;
                            case MessageAddCTHoc.Success:
                                success++;
                                break;
                        }
                    }
                }
            }
            if (mDSMonHocXoa != null)
            {
                foreach (var item in mDSMonHocXoa)

                    if (item != null)
                    {
                        MessageDeleteCTHoc message = _chuongtrinhhocBLLService.DeleteCTHoc(item.MaMH, item.MaNganh, item.HocKy);
                        switch (message)
                        {
                            case MessageDeleteCTHoc.Failed:
                                failed++;
                                break;
                            case MessageDeleteCTHoc.Success:
                                success++;
                                break;
                        }
                    }
            }
            if (success > 0) MessageBox.Show("Cập nhật chương trình học thành công!");
            else if (failed > 0) MessageBox.Show("Failed to connect databse");
            SetUpDgvMonHocChon();
            SetUpDgvMonHoc();
            DeleteSameRows();
            if (mDSMonHocThem != null) mDSMonHocThem.Clear();
            if (mDSMonHocXoa != null) mDSMonHocXoa.Clear();
        }

        private void img_Sort_Click(object sender, EventArgs e)
        {
            dgv_DSMonHoc.Rows.Clear();
            mMonHoc = new BindingList<MonHoc>(_monHocBLLService.LayDSMonHoc2());
            foreach (var item in mMonHoc)
            {
                if (item.TenMH.Contains(txt_Search.Text) || (item.MaMH.Contains(txt_Search.Text)))
                {
                    dgv_DSMonHoc.Rows.Add(item.MaMH, item.TenMH, item.MaLoaiMonHoc, item.SoTiet);
                }
            }
            DeleteSameRows();
        }

        private void img_DeleteSort_Click(object sender, EventArgs e)
        {
            SetUpDgvMonHoc();
            DeleteSameRows();
        }

        private void img_AddMonHoc_Click(object sender, EventArgs e)
        {
            if (dgv_DSMonHoc.RowCount > 0)
            {
                if (cb_Nganh.Text != "" && cb_HocKy.Text != "")
                {
                    DataGridViewRow selectedRow = dgv_DSMonHoc.SelectedRows[0];
                    DTO.ChuongTrinhHoc cth = new DTO.ChuongTrinhHoc();
                    cth.MaMH = selectedRow.Cells[0].Value.ToString();
                    foreach (var item in mNganh)
                    {
                        if (item.TenNganh == cb_Nganh.Text)
                        {
                            cth.MaNganh = item.MaNganh;
                            break;
                        }
                    }
                    cth.HocKy = cb_HocKy.SelectedIndex + 1;
                    mDSMonHocThem.Add(cth);
                    dgv_DSMonHoc.Rows.Remove(selectedRow);
                    dgv_DSMonHocChon.Rows.Add(selectedRow);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ngành và học kì chương trình học");
                }
            }
            else MessageBox.Show("Đã hết môn học để chọn");
        }

        private void img_Delete_MonHoc_Click(object sender, EventArgs e)
        {
            if (dgv_DSMonHocChon.RowCount > 0)
            {
                DataGridViewRow selectedRow = dgv_DSMonHocChon.SelectedRows[0];
                DTO.ChuongTrinhHoc cth = new ChuongTrinhHoc();
                cth.MaMH = selectedRow.Cells[0].Value.ToString();
                foreach (var item in mNganh)
                {
                    if (item.TenNganh == cb_Nganh.Text)
                    {
                        cth.MaNganh = item.MaNganh;
                        break;
                    }
                }
                cth.HocKy = cb_HocKy.SelectedIndex + 1;
                mDSMonHocXoa.Add(cth);
                dgv_DSMonHocChon.Rows.Remove(selectedRow);
                dgv_DSMonHoc.Rows.Add(selectedRow);
            }
        }

        private void dgv_DSMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DSMonHoc.CurrentRow != null)
            {
                dgv_DSMonHoc.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void dgv_DSMonHocChon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DSMonHocChon.CurrentRow != null)
            {
                dgv_DSMonHocChon.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
            if (mDSMonHocThem != null) mDSMonHocThem.Clear();
            if (mDSMonHocXoa != null) mDSMonHocXoa.Clear();
        }
    }
}
