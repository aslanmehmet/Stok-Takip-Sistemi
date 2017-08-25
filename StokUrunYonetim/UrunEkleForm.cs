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
    public partial class UrunEkleForm : Form
    {
        Int32 seciliUrunID = 0;

        public UrunEkleForm()
        {
            InitializeComponent();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            string urun_isim = txtUrunIsim.Text;
            string urun_ozellik = txtUrunOzellik.Text;
            string urun_aciklama = txtUrunAciklama.Text;

            if (Program.urunGuncelle == false)
            {
                Program.kmt.urunEkle(urun_isim, urun_ozellik, urun_aciklama, DateTime.Now,true);

                //son eklenen urunun urun_id sini bulduk.
                seciliUrunID = Program.kmt.urunSonEklenenID();

                for (int i = 0; i < Program.parcaList.Count; i++)
                {
                    Program.kmt.urunParcalarEkle(seciliUrunID, Program.parcaList[i].parca_id, Program.parcaList[i].miktar);
                }
            }
            else
            {
                //GUNCELLE

                //mevcut uruunun bilgilerini guncelle
                Program.kmt.urunGuncelle(Program.seciliUrunId, urun_isim, urun_ozellik, urun_aciklama, DateTime.Now,true);
                //database deki urune kayitli parcalari sil
                Program.kmt.urunParcalarSil(Program.seciliUrunId);
                //mevcut urune parcalari ekle
                for (int i = 0; i < Program.parcaList.Count; i++)
                {
                    Program.kmt.urunParcalarEkle(Program.seciliUrunId, Program.parcaList[i].parca_id, Program.parcaList[i].miktar);
                }
            }
            Program.parcaList.Clear();         
            this.Close();
        }

        private void UrunEkleForm_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            txtUrunIsim.Text = "";
            txtUrunOzellik.Text = "";
            txtUrunAciklama.Text = "";

            btnUrunEkle.Text = "Urunu Kaydet";

            if (Program.urunGuncelle)
            {
                
                //form acildiginda urun bilgilerini otomatik doldur
                txtUrunIsim.Text = Program.seciliUrunIsim;
                txtUrunOzellik.Text = Program.seciliUrunOzellik;
                txtUrunAciklama.Text = Program.seciliUrunAciklama;

                btnUrunEkle.Text = "Urunu Guncelle";
                dataGridView2.DataSource = Program.kmt.urunParcalarGoster(Program.seciliUrunId);
                Program.parcaList.Clear();

                //guncellerken datagriddeki verileri liste atıyoruz
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    urunParca urunParcaEkle = new urunParca((int)dataGridView2.Rows[i].Cells[0].Value,
                       dataGridView2.Rows[i].Cells[1].Value.ToString(), (int)dataGridView2.Rows[i].Cells[2].Value);
                    Program.parcaList.Add(urunParcaEkle);
                }

                txtUrunIsim.Text = Program.seciliUrunIsim;
                txtUrunOzellik.Text = Program.seciliUrunOzellik;
                txtUrunAciklama.Text = Program.seciliUrunAciklama;
           
            }
            
            dataGridView1.DataSource = Program.kmt.parcaStokIsim();
            dataGridView1.Columns[0].Visible = false; //tablodaki id kısmını gizliyoruz
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // (parça_id, miktar)
            
            int parca_id = Program.seciliParca;
            string parcaIsim = Program.seciliParcaIsim;
            bool parcaMiktariGuncellendi = false;


            if (txtMiktar.Text == "")
            {
                MessageBox.Show("Lütfen EKLEMEK/CIKARTMAK istediğiniz parça miktarını giriniz..!");
            }
            else
            {
                int parca_sayisi = Convert.ToInt32(txtMiktar.Text);

                if (parca_id == 0)
                {
                    MessageBox.Show("Lütfen Bir Parça Seçiniz...!");
                }
                else
                {                
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        if (parca_id == (int)dataGridView2.Rows[i].Cells[0].Value)
                        {
                            for (int j = 0; j < Program.parcaList.Count; j++)
                            {
                                if (Program.parcaList[j].parca_id == (int)dataGridView2.Rows[i].Cells[0].Value)
                                {
                                    int guncelMiktar = Program.parcaList[j].miktar + parca_sayisi;
                                    Program.parcaList[j].miktar = guncelMiktar;
                                    parcaMiktariGuncellendi = true;
                                    break;
                                }
                            }
                        }


                    }
                    if (parcaMiktariGuncellendi == false)
                    {
                        urunParca urunParcaEkle = new urunParca(parca_id, parcaIsim, parca_sayisi);
                        Program.parcaList.Add(urunParcaEkle);
                    }
                }

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                dataGridView2.Columns.Add("parca_id", "İd");
                dataGridView2.Columns.Add("parcaAdi", "İsim");
                dataGridView2.Columns.Add("miktar", "Miktar");

                for (int k = 0; k < Program.parcaList.Count; k++)
                {
                    dataGridView2.Rows.Add();

                    dataGridView2.Rows[k].Cells[0].Value = Program.parcaList[k].parca_id;
                    dataGridView2.Rows[k].Cells[1].Value = Program.parcaList[k].parcaAdi;
                    dataGridView2.Rows[k].Cells[2].Value = Program.parcaList[k].miktar;
                }

                //dataGridView2.DataSource = Program.parcaList;


                //Program.kmt.urunParcalarEkle(parca_id, parca_sayisi);

                //(parça adı, miktar) Yazdır datagrid2 ye.


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
                    Program.seciliParcaIsim = Convert.ToString(dataGridView1.Rows[SecilenRow].Cells[1].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            if (txtMiktar.Text == "")
            {
                MessageBox.Show("Lütfen EKLEMEK/CIKARTMAK istediğiniz parça miktarını giriniz..!");
            }
            else
            {
                int parca_sayisi = Convert.ToInt32(txtMiktar.Text);
                //eklenen parcanın miktarını değiştirme
                for (int i = 0; i < Program.parcaList.Count; i++)
                {
                    if (Program.parcaList[i].parca_id == Program.seciliEklenenParca)
                    {
                        int guncelMiktar = Program.seciliEklenenParcaMiktar - Convert.ToInt32(txtMiktar.Text);
                        if (guncelMiktar > 0)
                        {
                            Program.parcaList[i].miktar = guncelMiktar;
                        }
                        else if (guncelMiktar == 0)
                        {
                            Program.parcaList.RemoveAt(i);
                        }
                        else
                        {
                            MessageBox.Show("Yeterli parça miktarı yok...!");
                        }
                    }
                }


                //data gridi guncelle
                dataGridView2.DataSource = null;
                //dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                dataGridView2.Columns.Add("parca_id", "İd");
                dataGridView2.Columns.Add("parcaAdi", "İsim");
                dataGridView2.Columns.Add("miktar", "Miktar");

                for (int i = 0; i < Program.parcaList.Count; i++)
                {
                    dataGridView2.Rows.Add();

                    dataGridView2.Rows[i].Cells[0].Value = Program.parcaList[i].parca_id;
                    dataGridView2.Rows[i].Cells[1].Value = Program.parcaList[i].parcaAdi;
                    dataGridView2.Rows[i].Cells[2].Value = Program.parcaList[i].miktar;
                }
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                try
                {
                    int SecilenRow = dataGridView2.CurrentCell.RowIndex;
                    int SecilenColumn = dataGridView2.CurrentCell.ColumnIndex;
                    Program.seciliEklenenParca = Convert.ToInt32(dataGridView2.Rows[SecilenRow].Cells[0].Value);
                    Program.seciliEklenenParcaMiktar = Convert.ToInt32(dataGridView2.Rows[SecilenRow].Cells[2].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UrunEkleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.urunGuncelle = false;
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
