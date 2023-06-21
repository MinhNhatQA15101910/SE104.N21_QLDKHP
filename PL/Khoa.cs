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
    public partial class Khoa : KryptonForm
    {
        public Khoa()
        {
            InitializeComponent();
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void grbThongTinChiTiet_Enter(object sender, EventArgs e)
        {

        }

        private void Khoa_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ThemKhoa t = new ThemKhoa();
            t.ShowDialog();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            SuaKhoa k = new SuaKhoa();
            k.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
