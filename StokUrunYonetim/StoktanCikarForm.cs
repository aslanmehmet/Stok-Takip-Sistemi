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
    public partial class StoktanCikarForm : Form
    {
        public StoktanCikarForm()
        {
            InitializeComponent();
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            int parcaStokID = 0;
            int mevcutAdet = 0;

            DataTable dt = Program.kmt.parcaStokGosterId(Program.seciliStok);

            if (dt.Rows.Count > 0)
            {
                parcaStokID = Convert.ToInt32(dt.Rows[0][0]);
                mevcutAdet = Convert.ToInt32(dt.Rows[0][2]);
            }
            //if (dt.Rows.Count > 0)
            //{
            //    parcaStokID = Convert.ToInt32(dt.Rows[0][0]);
            //    mevcutAdet = Convert.ToInt32(dt.Rows[0][1]);
            //}

            if (parcaStokID > 0)
            {
                Program.adet = Convert.ToInt32(txtMiktar.Text);

                if (mevcutAdet > Program.adet)
                {
                    // Giriş mevcut, update edicez                    
                    Program.kmt.parcaStokGuncelle(Program.seciliStok, mevcutAdet - Program.adet, DateTime.Now, true);
                    Program.kmt.parcaStokCikis(Program.adet, DateTime.Now, Program.seciliStok);
                }
                else if(mevcutAdet == Program.adet)
                {
                    Program.kmt.parcaStokSil(Program.seciliStok);
                    MessageBox.Show("Girilen miktar kadar parca stoktan çıkarıldı.(Stokta mevcut parçadan hiç kalmadı)");
                    Program.kmt.parcaStokCikis(Program.adet, DateTime.Now, Program.seciliStok);
                }
                else
                {
                    MessageBox.Show("Stokta yeterli parca bulunmamamktadır...!");
                    Program.yetersizParca = true;
                }
            }

            Program.seciliStok = 0;
            this.Close();
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
