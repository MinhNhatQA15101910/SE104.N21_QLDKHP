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
    public partial class DSSV : KryptonForm
    {
        public DSSV()
        {
            InitializeComponent();
        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void DSSV_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            ThemSinhVien t = new ThemSinhVien();
            t.ShowDialog();

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            SuaSinhVien s = new SuaSinhVien();
            s.ShowDialog();
        }
    }
}
