using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StokUrunYonetim
{
    public partial class StokGuncelleGir : Form
    {
        public StokGuncelleGir()
        {
            InitializeComponent();
        }

        private void btnOkey_Click(object sender, EventArgs e)
        {
            
            int parcaStokID = 0;
            int adet;
            int mevcutAdet = 0;
            DataTable dt = Program.kmt.parcaStokGosterId(Program.seciliParca);

            if (dt.Rows.Count > 0)
            {
                parcaStokID = Convert.ToInt32(dt.Rows[0][0]);
                mevcutAdet = Convert.ToInt32(dt.Rows[0][2]);
            }


            if (parcaStokID > 0)
            {
                // Giriş mevcut, update edicez
                adet = Convert.ToInt32(txtMiktar.Text);
                Program.kmt.parcaStokGuncelle(Program.seciliParca,adet + mevcutAdet, DateTime.Now, true);
            }
            else
            {
                //giriş yok yeni giriş ekle
                adet = Convert.ToInt32(txtMiktar.Text);
                Program.kmt.parcaStokGir(adet, DateTime.Now, Program.seciliParca, true);
            }


            Program.seciliParca = 0;
            this.Close();
        }

        private void StokGuncelleGir_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
