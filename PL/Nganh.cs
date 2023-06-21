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
    public partial class Nganh : KryptonForm
    {
        public Nganh()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

        }

        private void Nganh_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            ThemNganh n = new ThemNganh();
            n.ShowDialog();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            SuaNganh n = new SuaNganh();
            n.ShowDialog();
        }
    }
}
