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
    public partial class Admin :  KryptonForm
    {
        private IAdminRequester adminRequester;

        public Admin(IAdminRequester requester)
        {
            InitializeComponent();

            adminRequester = requester;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (adminRequester != null)
            {
                adminRequester.OnAdminClosing();
            }
        }
    }
}
