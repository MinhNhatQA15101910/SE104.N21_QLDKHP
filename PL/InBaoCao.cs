using Microsoft.Reporting.WinForms;
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
    public partial class InBaoCao : Form
    {
        private int hocKy, namHoc;

        public InBaoCao(int HOCKY, int NAMHOC)
        {
            InitializeComponent();
            hocKy = HOCKY;
            namHoc = NAMHOC;
        }

        private void InBaoCao_Load(object sender, EventArgs e)
        {
            sp_SINHVIEN_baoCaoTableAdapter.Fill(quanLyDangKyHPDataSet.sp_SINHVIEN_baoCao, hocKy, namHoc);
            rpViewer.RefreshReport();
        }
    }
}
