﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulAppSube2BIL
{
    public partial class FrmSec : Form
    {
        public FrmSec()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FrmOgretmenKyt frmOgretmenKyt = new FrmOgretmenKyt();
            frmOgretmenKyt.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmOgrKayit frmOgr = new frmOgrKayit();
            frmOgr.ShowDialog();
        }
    }
}
