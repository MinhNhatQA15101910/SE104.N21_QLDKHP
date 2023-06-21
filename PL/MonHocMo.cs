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
    public partial class MonHocMo : KryptonForm
    {
        public MonHocMo()
        {
            InitializeComponent();
        }

        private void MonHocMo_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            TraCuuMonHocMo m = new TraCuuMonHocMo();
            m.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            TraCuuMonHocMo t = new TraCuuMonHocMo();
            t.ShowDialog();
        }
    }
}
