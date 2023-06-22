using BLL;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using PL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class QuanLyDoiTuong : KryptonForm, IThemSuaDoiTuongRequester
    {
        private ICaiDatRequester caiDatRequester;
        private BindingList<DoiTuong> mDoiTuong;
        private BindingSource mDoiTuongSource;

        public QuanLyDoiTuong(ICaiDatRequester requester)
        {
            InitializeComponent();

            caiDatRequester = requester;

            SettingProperties();
        }

        private void SettingProperties()
        {
            dgvDSDoiTuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSDoiTuong.MultiSelect = false;
            dgvDSDoiTuong.ReadOnly = true;
            dgvDSDoiTuong.AllowUserToAddRows = false;
            dgvDSDoiTuong.AllowUserToDeleteRows = false;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuanLyDoiTuong_Load(object sender, EventArgs e)
        {
            mDoiTuong = new BindingList<DoiTuong>(DoiTuongBLL.LayDSDoiTuong());
            mDoiTuongSource = new BindingSource(mDoiTuong, null);
            dgvDSDoiTuong.DataSource = mDoiTuongSource;

            dgvDSDoiTuong.Columns["TenDT"].HeaderText = "Tên đối tượng";
            dgvDSDoiTuong.Columns["TenDT"].Width = 230;

            dgvDSDoiTuong.Columns["TiLeGiamHocPhi"].HeaderText = "Tỉ lệ giảm học phí";
            dgvDSDoiTuong.Columns["TiLeGiamHocPhi"].Width = 159;

            dgvDSDoiTuong.Columns["MaDT"].Visible = false;
        }

        private void dgvDSDoiTuong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSDoiTuong.CurrentRow != null)
            {
                dgvDSDoiTuong.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Yellow;

                DoiTuong doiTuong = mDoiTuong[dgvDSDoiTuong.CurrentRow.Index];
                if (doiTuong != null)
                {
                    txtTenDoiTuong.Text = doiTuong.TenDT;
                    txtTiLeGiamHocPhi.Text = doiTuong.TiLeGiamHocPhi.ToString();
                }
            }
        }

        private void QuanLyDoiTuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caiDatRequester != null)
            {
                caiDatRequester.OnCaiDatClosing();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DoiTuong doiTuong = mDoiTuong[dgvDSDoiTuong.CurrentRow.Index];
            ThemSuaDoiTuong themSuaDoiTuong = new ThemSuaDoiTuong(this, doiTuong);
            themSuaDoiTuong.Show();
        }

        public void OnThemSuaDoiTuongClosing()
        {
            mDoiTuong = new BindingList<DoiTuong>(DoiTuongBLL.LayDSDoiTuong());
            mDoiTuongSource.DataSource = mDoiTuong;
        }
    }
}
