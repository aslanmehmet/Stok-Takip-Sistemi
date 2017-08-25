using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace StokUrunYonetim
{
    public partial class ParcaForm : Form
    {
        Random r = new Random();
        

        public ParcaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Program.kmt.parcaTumu();
            dataGridView1.ClearSelection();
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "Tur";
            dataGridView1.Columns[2].HeaderText = "İsim";
            dataGridView1.Columns[3].HeaderText = "ParçaKodu";
            dataGridView1.Columns[4].HeaderText = "Özellik";
            dataGridView1.Columns[5].HeaderText = "Açıklama";
            dataGridView1.Columns[6].HeaderText = "Fiyat";
            dataGridView1.Columns[7].HeaderText = "İşlemTarihi";

            //try
            //{
            //    using (Stream stream = File.Open("data.bin", FileMode.Open))
            //    {
            //        BinaryFormatter bin = new BinaryFormatter();
            //        Program.parcaList  = (List<parca>)bin.Deserialize(stream);                                      
            //    }
            //dataGridView1.Rows.Clear();

            //for (int i = 0; i < Program.parcaList.Count; i++)
            //{
            //    dataGridView1.Rows.Add();

            //    dataGridView1.Rows[i].Cells[0].Value = Program.parcaList[i].id;
            //    dataGridView1.Rows[i].Cells[1].Value = Program.parcaList[i].isim;
            //    dataGridView1.Rows[i].Cells[2].Value = Program.parcaList[i].tur;
            //    dataGridView1.Rows[i].Cells[3].Value = Program.parcaList[i].urunKodu;
            //    dataGridView1.Rows[i].Cells[4].Value = Program.parcaList[i].ozellik;
            //    dataGridView1.Rows[i].Cells[5].Value = Program.parcaList[i].aciklama;
            //    dataGridView1.Rows[i].Cells[6].Value = Program.parcaList[i].eskiFiyat;
            //    dataGridView1.Rows[i].Cells[7].Value = Program.parcaList[i].guncelFiyat;
            //    dataGridView1.Rows[i].Cells[8].Value = Program.parcaList[i].fiyatGuncellemeTarihi;
            //}
            //}
            //catch (IOException)
            //{
            //}
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //parca parca1 = new parca(r.Next(1, 1000),
            //    txtIsim.Text,
            //    txtTur.Text,
            //    txtUrunKodu.Text,
            //    txtOzellik.Text,
            //    txtAciklama.Text,
            //    Convert.ToDouble(txtEskiFiyat.Text),
            //    Convert.ToDouble(txtGuncelFiyat.Text),
            //    DateTime.Now);

            if (txtTur.Text == "" || txtIsim.Text == "" || txtUrunKodu.Text == "" || txtFiyat.Text == "") 
            {
                MessageBox.Show("Lütfen ürün bilgilerini eksiksiz giriniz..!");
            }
            else
            {
                Program.kmt.parcaEkle(
                                txtTur.Text,
                                txtIsim.Text,
                                txtUrunKodu.Text,
                                txtOzellik.Text,
                                txtAciklama.Text,
                                Convert.ToDouble(txtFiyat.Text),
                                DateTime.Now);

                dataGridView1.DataSource = Program.kmt.parcaTumu();
                dataGridView1.Columns[0].HeaderText = "İd";
                dataGridView1.Columns[1].HeaderText = "Tur";
                dataGridView1.Columns[2].HeaderText = "İsim";
                dataGridView1.Columns[3].HeaderText = "ParçaKodu";
                dataGridView1.Columns[4].HeaderText = "Özellik";
                dataGridView1.Columns[5].HeaderText = "Açıklama";
                dataGridView1.Columns[6].HeaderText = "Fiyat";
                dataGridView1.Columns[7].HeaderText = "İşlemTarihi";
            }

            txtTur.Text = "";
            txtOzellik.Text = "";
            txtUrunKodu.Text = "";
            txtIsim.Text = "";
            txtFiyat.Text = "";
            txtAciklama.Text = "";



            //Program.parcaList.Add(parca1);


            //dataGridView1.Rows.Clear();

            //for(int i = 0; i < Program.parcaList.Count; i++)
            //{
            //    dataGridView1.Rows.Add();

            //    dataGridView1.Rows[i].Cells[0].Value = Program.parcaList[i].id;
            //    dataGridView1.Rows[i].Cells[1].Value = Program.parcaList[i].isim;
            //    dataGridView1.Rows[i].Cells[2].Value = Program.parcaList[i].tur;
            //    dataGridView1.Rows[i].Cells[3].Value = Program.parcaList[i].urunKodu;
            //    dataGridView1.Rows[i].Cells[4].Value = Program.parcaList[i].ozellik;
            //    dataGridView1.Rows[i].Cells[5].Value = Program.parcaList[i].aciklama;
            //    dataGridView1.Rows[i].Cells[6].Value = Program.parcaList[i].eskiFiyat;
            //    dataGridView1.Rows[i].Cells[7].Value = Program.parcaList[i].guncelFiyat;
            //    dataGridView1.Rows[i].Cells[8].Value = Program.parcaList[i].fiyatGuncellemeTarihi;               
            //}
            ////dataGridView1.DataSource = Program.parcaList;
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
                    txtTur.Text = dataGridView1.Rows[SecilenRow].Cells[1].Value.ToString();
                    txtIsim.Text = dataGridView1.Rows[SecilenRow].Cells[2].Value.ToString();
                    txtUrunKodu.Text = dataGridView1.Rows[SecilenRow].Cells[3].Value.ToString();
                    txtOzellik.Text = dataGridView1.Rows[SecilenRow].Cells[4].Value.ToString();
                    txtAciklama.Text = dataGridView1.Rows[SecilenRow].Cells[5].Value.ToString();
                    txtFiyat.Text = dataGridView1.Rows[SecilenRow].Cells[6].Value.ToString();
                }
                catch
                {                   
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //seciliparcanin id si parcalisttekiyle ayniysa sil.        
            //for (int i = 0; i < Program.parcaList.Count; i++)
            //{
            //    if(Program.parcaList[i].id == Program.seciliParca)
            //    {
            //        Program.parcaList.RemoveAt(i);
            //        dataGridView1.Rows.RemoveAt(i);
            //        dataGridView1.ClearSelection(); 
            //    }
            //}
            if (Program.seciliParca == 0)
            {
                MessageBox.Show("Lütfen bir parça seçiniz");
            }
            else
            {
                Program.kmt.parcaSil(Program.seciliParca);
                dataGridView1.DataSource = Program.kmt.parcaTumu();//guncelle
                dataGridView1.Columns[0].HeaderText = "İd";
                dataGridView1.Columns[1].HeaderText = "Tur";
                dataGridView1.Columns[2].HeaderText = "İsim";
                dataGridView1.Columns[3].HeaderText = "ParçaKodu";
                dataGridView1.Columns[4].HeaderText = "Özellik";
                dataGridView1.Columns[5].HeaderText = "Açıklama";
                dataGridView1.Columns[6].HeaderText = "Fiyat";
                dataGridView1.Columns[7].HeaderText = "İşlemTarihi";
            }

            Program.seciliParca = 0;
        
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    using (Stream stream = File.Open("data.bin", FileMode.Create))
            //    {
            //        BinaryFormatter bin = new BinaryFormatter();
            //        bin.Serialize(stream, Program.parcaList);
            //    }
            //}
            //catch (IOException)
            //{
            //}
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < Program.parcaList.Count; i++)
            //{
            //    if (Program.parcaList[i].id == Program.seciliParca)
            //    {
            //        dataGridView1.Rows[i].Cells[0].Value = Program.parcaList[i].id;
            //        dataGridView1.Rows[i].Cells[1].Value = txtIsim.Text;
            //        dataGridView1.Rows[i].Cells[2].Value = txtTur.Text;
            //        dataGridView1.Rows[i].Cells[3].Value = txtUrunKodu.Text;
            //        dataGridView1.Rows[i].Cells[4].Value = txtOzellik.Text;
            //        dataGridView1.Rows[i].Cells[5].Value = txtAciklama.Text;
            //        dataGridView1.Rows[i].Cells[6].Value = txtEskiFiyat.Text;
            //        dataGridView1.Rows[i].Cells[7].Value = txtGuncelFiyat.Text;
            //        dataGridView1.Rows[i].Cells[8].Value = DateTime.Now;
            //    }
            //}

            if (Program.seciliParca == 0)
            {
                MessageBox.Show("Lütfen bir parça seçiniz");
            }
            else if (txtTur.Text == "" || txtIsim.Text == "" || txtUrunKodu.Text == "" || txtFiyat.Text == "")
            {
                MessageBox.Show("Lütfen ürün bilgilerini eksiksiz giriniz..!");
            }
            else
            {
                Program.kmt.parcaGuncelle(Program.seciliParca,
                    txtTur.Text,
                    txtIsim.Text,
                    txtUrunKodu.Text,
                    txtOzellik.Text,
                    txtAciklama.Text,
                    Convert.ToDouble(txtFiyat.Text),
                    DateTime.Now);

                dataGridView1.DataSource = Program.kmt.parcaTumu();
                dataGridView1.Columns[0].HeaderText = "İd";
                dataGridView1.Columns[1].HeaderText = "Tur";
                dataGridView1.Columns[2].HeaderText = "İsim";
                dataGridView1.Columns[3].HeaderText = "ParçaKodu";
                dataGridView1.Columns[4].HeaderText = "Özellik";
                dataGridView1.Columns[5].HeaderText = "Açıklama";
                dataGridView1.Columns[6].HeaderText = "Fiyat";
                dataGridView1.Columns[7].HeaderText = "İşlemTarihi";

                txtTur.Text = "";
                txtOzellik.Text = "";
                txtUrunKodu.Text = "";
                txtIsim.Text = "";
                txtFiyat.Text = "";
                txtAciklama.Text = "";
            }
            Program.seciliParca = 0;
        }

        //isim görüntülemeyi harfe göre yap
        private void btnIsimListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Program.kmt.parcaTumu();
        }

        private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void txtIsimListele_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Program.kmt.parcaIsim(Convert.ToString(txtIsimListele.Text)); //ismi goruntuler  
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtTur.Text = "";
            txtOzellik.Text = "";
            txtUrunKodu.Text = "";
            txtIsim.Text = "";
            txtFiyat.Text = "";
            txtAciklama.Text = "";
        }
    }
}
