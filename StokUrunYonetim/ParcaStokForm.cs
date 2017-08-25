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
    public partial class ParcaStokForm : Form
    {
        StokGuncelleGir stokGuncelleGir = new StokGuncelleGir();
        StoktanCikarForm stoktanCikarForm = new StoktanCikarForm();

        public ParcaStokForm()
        {
            InitializeComponent();
        }

        private void ParcaStokGirisForm_Load(object sender, EventArgs e)
        {         
            dataGridView1.DataSource = Program.kmt.parcaStokIsim();
            dataGridView1.Columns[1].HeaderText = "İsim";

            dataGridView2.DataSource = Program.kmt.parcaStokTumu();
            dataGridView2.Columns[0].HeaderText = "İd";
            dataGridView2.Columns[1].HeaderText = "İsim";
            dataGridView2.Columns[2].HeaderText = "Miktar";
            dataGridView2.Columns[3].HeaderText = "İşlemTarihi";

            dataGridView3.DataSource = Program.kmt.parcaCikisGoster();
            dataGridView3.Columns[0].HeaderText = "İd";
            dataGridView3.Columns[1].HeaderText = "İsim";
            dataGridView3.Columns[2].HeaderText = "Miktar";
            dataGridView3.Columns[3].HeaderText = "İşlemTarihi";

            //secili durumdan cikarttik
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
                        
            dataGridView1.Columns[0].Visible = false; // tablodan id kısmını gizliyoruz
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = Program.kmt.parcaIsim(txtIsim.Text);

            //secili durumdan cikarttik
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.seciliParca == 0)
            {
                MessageBox.Show("Lütfen bir parça seçiniz..!");
            }
            else
            {
                stokGuncelleGir.ShowDialog();

                dataGridView2.DataSource = Program.kmt.parcaStokTumu();

                //secili durumdan cikarttik
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    int SecilenRow = dataGridView1.CurrentCell.RowIndex;
                    int SecilenColumn = dataGridView1.CurrentCell.ColumnIndex;
                    Program.seciliParca = Convert.ToInt32(dataGridView1.Rows[SecilenRow].Cells[0].Value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        //Data GRiddeki secili olan satirin id sini veriyor
        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                try
                {
                    int SecilenRow = dataGridView2.CurrentCell.RowIndex;
                    int SecilenColumn = dataGridView2.CurrentCell.ColumnIndex;
                    Program.seciliStok = Convert.ToInt32(dataGridView2.Rows[SecilenRow].Cells[0].Value);
                }
                catch
                {
                }
            }
        }

        private void btnStokSil_Click(object sender, EventArgs e)
        {
            if (Program.seciliStok == 0)
            {
                MessageBox.Show("Lütfen stoktan bir parça seçiniz...!");
            }
            else
            {
                stoktanCikarForm.ShowDialog();
                dataGridView2.DataSource = Program.kmt.parcaStokTumu();

                //Program.kmt.parcaStokCikis(Program.adet, DateTime.Now, Program.seciliStok);
                dataGridView3.DataSource = Program.kmt.parcaCikisGoster();



                //secili durumdan cikarttik
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();

                //Program.kmt.stokSil(Program.seciliStok);
                //dataGridView2.DataSource = Program.kmt.;
            }
        }

        private void txtIsim_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
