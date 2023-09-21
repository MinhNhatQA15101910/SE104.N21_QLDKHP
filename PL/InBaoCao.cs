using System;
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
