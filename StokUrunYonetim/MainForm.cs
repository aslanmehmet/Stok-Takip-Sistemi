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
    public partial class MainForm : Form
    {
        ParcaForm parcaForm = new ParcaForm();
        ParcaStokForm parcaStokGirisForm = new ParcaStokForm();
        UrunTanimlamaForm urunTanimlamaForm = new UrunTanimlamaForm();
        UrunStokForm urunStokForm = new UrunStokForm();
        public MainForm()
        {
            InitializeComponent();
        }

        private void parcaTanim_button_Click(object sender, EventArgs e)
        {
            parcaForm.ShowDialog();
        }

        private void parcaStok_button_Click(object sender, EventArgs e)
        {
            parcaStokGirisForm.ShowDialog();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void urunTanim_button_Click(object sender, EventArgs e)
        {
           
            urunTanimlamaForm.ShowDialog();
            
        }

        private void urunStok_button_Click(object sender, EventArgs e)
        {
            urunStokForm.ShowDialog();
        }
    }
}
