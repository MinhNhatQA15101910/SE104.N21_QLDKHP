using ComponentFactory.Krypton.Toolkit;
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
    public partial class ThongTinSinhVien : KryptonForm 
    {
        public ThongTinSinhVien()
        {
            InitializeComponent();
        }

        private void kryptonTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThongTinSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            ThongTinDKHP ttdk = new ThongTinDKHP();
            ttdk.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            ThongTinHocPhi t = new ThongTinHocPhi();
            t.ShowDialog();
        }
    }
}
