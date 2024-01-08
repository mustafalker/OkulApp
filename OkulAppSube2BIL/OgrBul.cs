using OkulApp.BLL;
using OkulApp.MODEL;
using System;
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
    public partial class OgrBul : Form
    {
        FrmOgretmenKyt frmOgretmenKyt;
        public OgrBul(FrmOgretmenKyt frmOgretmenKyt)
        {
            InitializeComponent();
            this.frmOgretmenKyt = frmOgretmenKyt;
        }

        private void btnOgrAra_Click(object sender, EventArgs e)
        {
            OgretmenBL obl = new OgretmenBL();
            Ogretmen ogr = obl.OgretmenBul (txtTc.Text.Trim());
            if (ogr != null)
            {
                frmOgretmenKyt.txtAd.Text = ogr.OgretmenAdi;
                frmOgretmenKyt.txtSoyad.Text = ogr.OgretmenSoyadi;
                frmOgretmenKyt.txtTc.Text = ogr.OgretmenTc;

                frmOgretmenKyt.btnOgrSil.Enabled = true;
                frmOgretmenKyt.btnOgrGuncelle.Enabled = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Öğrenci bulunamadı!!");
            }
        }
    }
}
