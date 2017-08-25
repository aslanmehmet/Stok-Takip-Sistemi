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
    public partial class UrunStokSil : Form
    {
        public UrunStokSil()
        {
            InitializeComponent();
        }

        private void btnOkey_Click(object sender, EventArgs e)
        {
            Program.urunStokSilMiktar = Convert.ToInt32(txtMiktar.Text);
            if(Program.urunStokSilMiktar == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünün miktarını giriniz...!");
            }
            else
            {
                this.Close();
            }
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
