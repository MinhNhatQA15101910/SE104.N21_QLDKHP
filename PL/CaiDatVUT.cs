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
    public partial class SettingVUT : KryptonForm
    {
        public SettingVUT()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void SettingVUT_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            CaiDatTC_LM t = new CaiDatTC_LM();
            t.ShowDialog();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            ThemKhuVucUT k = new ThemKhuVucUT();
            k.ShowDialog();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            SuaKhuVucUT k = new SuaKhuVucUT();
            k.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            ThemLoaiUT k = new ThemLoaiUT();
            k.ShowDialog();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            SuaLoaiUT k = new SuaLoaiUT();
            k.ShowDialog();
        }
    }
}
