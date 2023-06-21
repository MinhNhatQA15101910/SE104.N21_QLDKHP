using ComponentFactory.Krypton.Toolkit;
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
    public partial class GV : KryptonForm
    {
        private IGVRequester gvRequester;

        public GV(IGVRequester requester)
        {
            InitializeComponent();

            gvRequester = requester;
        }

        private void GV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gvRequester != null)
            {
                gvRequester.OnGVClosing();
            }
        }
    }
}
