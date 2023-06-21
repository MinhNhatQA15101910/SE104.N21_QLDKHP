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
    public partial class SinhVien : KryptonForm
    {
        private ISinhVienRequester sinhVienRequester;

        public SinhVien(ISinhVienRequester requester)
        {
            InitializeComponent();

            sinhVienRequester = requester;
        }

        private void SinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sinhVienRequester != null)
            {
                sinhVienRequester.OnSinhVienClosing();
            }
        }
    }
}
