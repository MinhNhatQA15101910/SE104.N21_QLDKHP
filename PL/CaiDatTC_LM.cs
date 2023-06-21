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
    public partial class CaiDatTC_LM : KryptonForm
    {
        public CaiDatTC_LM()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            ThemLoaiMon t = new ThemLoaiMon();
            t.ShowDialog();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            SuaLoaiMon s = new SuaLoaiMon();
            s.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            SettingVUT t = new SettingVUT();
            t.ShowDialog();
        }
    }
}
