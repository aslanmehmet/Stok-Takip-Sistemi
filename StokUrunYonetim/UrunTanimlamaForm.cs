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
    public partial class UrunTanimlamaForm : Form
    {
        UrunEkleForm urunEkleForm = new UrunEkleForm();


        public UrunTanimlamaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            urunEkleForm.ShowDialog();
            dataGridView1.DataSource = Program.kmt.urunGosterTumu();

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void UrunTanimlamaForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Program.kmt.urunGosterTumu();
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "İsim";
            dataGridView1.Columns[2].HeaderText = "Özellik";
            dataGridView1.Columns[3].HeaderText = "Açıklama";
            dataGridView1.Columns[4].HeaderText = "İşlemTarihi";

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (Program.seciliUrunId == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz..!");
            }
            else
            {
                //Data griddeki secili ürünü sil.
                Program.kmt.urunSil(Program.seciliUrunId,true);
                Program.kmt.urunParcalarSil(Program.seciliUrunId);

                //Data gridi yenile.
                dataGridView1.DataSource = Program.kmt.urunGosterTumu();
                dataGridView2.DataSource = null;
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();

            }
            Program.seciliUrunId = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (Program.seciliUrunId == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz..!");
            }
            else
            {
                Program.urunGuncelle = true;

                //urun guncelle formunu ac
                urunEkleForm.ShowDialog();

                Program.urunGuncelle = false;

                //data gridleri yenile
                dataGridView1.DataSource = Program.kmt.urunGosterTumu();
                dataGridView2.DataSource = Program.kmt.urunParcalarGoster(Program.seciliUrunId);

                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
            }
            Program.seciliUrunId = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    int SecilenRow = dataGridView1.CurrentCell.RowIndex;
                    int SecilenColumn = dataGridView1.CurrentCell.ColumnIndex;
                    Program.seciliUrunId = Convert.ToInt32(dataGridView1.Rows[SecilenRow].Cells[0].Value);

                    //guncelle formu acildiginda bilgileri otomatik doldurmak için
                    Program.seciliUrunIsim = dataGridView1.Rows[SecilenRow].Cells[1].Value.ToString();
                    Program.seciliUrunOzellik = dataGridView1.Rows[SecilenRow].Cells[2].Value.ToString();
                    Program.seciliUrunAciklama = dataGridView1.Rows[SecilenRow].Cells[3].Value.ToString();                    
                }
                catch
                {
                }
                dataGridView2.DataSource = Program.kmt.urunParcalarGoster(Program.seciliUrunId);
                dataGridView2.Columns[0].HeaderText = "İd";
                dataGridView2.Columns[1].HeaderText = "İsim";
                dataGridView2.Columns[2].HeaderText = "İşlemTarihi";
            }
            dataGridView2.ClearSelection();
        }
    }
}
