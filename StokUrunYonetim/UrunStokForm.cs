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
    public partial class UrunStokForm : Form
    {
        UrunStokEkleForm urunStokEkleForm = new UrunStokEkleForm();
        UrunStokSil urunStokSil = new UrunStokSil();
        public UrunStokForm()
        {
            InitializeComponent();
        }

        private void btnUrunStokEkle_Click(object sender, EventArgs e)
        {
            //urun seciliyse urunStokEkle Formuna git
            if (Program.urunSecildi)
            {
                urunStokEkleForm.ShowDialog();              
            }
            else
            {
                MessageBox.Show("Lutfen Urun Seciniz.");
            }
            Program.urunSecildi = false;
            dataGridView3.DataSource = Program.kmt.urunStokTumu();
            dataGridView1.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
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
                    Program.urunSecildi = true;

                    //urune ait parcalari listele
                    dataGridView2.DataSource = Program.kmt.urunParcalarGoster(Program.seciliUrunId);
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[2].HeaderText = "miktar";
                }
                catch
                {
                }
            }
            dataGridView2.ClearSelection();
        }

        private void UrunStokForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Program.kmt.urunGosterTumu();

            //dataGridView1.Columns[0].Visible = false; //id gizle
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "İsim";
            dataGridView1.Columns[2].HeaderText = "Özellik";
            dataGridView1.Columns[3].HeaderText = "Açıklama";
            dataGridView1.Columns[4].HeaderText = "İşlemTarihi";

            dataGridView3.DataSource = Program.kmt.urunStokTumu();
            dataGridView3.Columns[0].HeaderText = "İd";
            dataGridView3.Columns[1].HeaderText = "İsim";
            dataGridView3.Columns[2].HeaderText = "Miktar";
            dataGridView3.Columns[3].HeaderText = "İşlemTarihi";

            dataGridView4.DataSource = Program.kmt.urunStokCikisTumu();
            dataGridView4.Columns[0].HeaderText = "İd";
            dataGridView4.Columns[1].HeaderText = "İsim";
            dataGridView4.Columns[2].HeaderText = "Miktar";
            dataGridView4.Columns[3].HeaderText = "İşlemTarihi";

            //secili durumdan cikarttik
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
            dataGridView2.DataSource = null; 
        }

        private void btnUrunStokSil_Click(object sender, EventArgs e)
        {
            if (Program.seciliStokUrunId == 0)
            {
                MessageBox.Show("Lütfen stoktan bir ürün seçiniz..!");
            }
            else
            {
                urunStokSil.ShowDialog();

                DialogResult secenek = MessageBox.Show("Silmek istediğiniz ürüne ait parçaları stoğa eklemek istermisiniz.!", "Bilgilendirme Mesajı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    //urune ait parcalari parca_stok a ekle

                    int parcaID = 0;
                    int urunAdet = 0;
                    int urunParcaAdet = 0;
                    int parcaMevcutStokAdet = 0;

                    // URUNE AIT BUTUN PARCALARI ALIYORUZ
                    DataTable dt_urunParcalar = Program.kmt.urunParcalarGoster(Program.seciliStokUrunId);
                    // STOKTA BULUNAN PARCA
                    DataTable dt_parcaStoklar = Program.kmt.parcaStokTumu();


                    if (dt_urunParcalar.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_urunParcalar.Rows.Count; i++)
                        {
                            // SIRADAN PARCALARI SECIYORUZ
                            parcaID = Convert.ToInt32(dt_urunParcalar.Rows[i][0]);
                            urunParcaAdet = Convert.ToInt32(dt_urunParcalar.Rows[i][2]);

                            DataTable dt_seciliParca = Program.kmt.parcaStokGosterId(parcaID);

                            // SILINECEK URUN ADETINI AL
                            urunAdet = Program.urunStokSilMiktar;

                            if (dt_seciliParca.Rows.Count > 0)
                            {
                                // Giriş mevcut, update edicez
                                parcaMevcutStokAdet = Convert.ToInt32(dt_seciliParca.Rows[i][2]);
                                Program.kmt.parcaStokGuncelle(parcaID, (urunAdet * urunParcaAdet) + parcaMevcutStokAdet, DateTime.Now, false);
                            }
                            else
                            {
                                //giriş yok yeni giriş ekle
                                Program.kmt.parcaStokGir(urunAdet * urunParcaAdet, DateTime.Now, parcaID, false);
                            }
                        }
                    }

                    //stoktan silme islemi

                    if (Program.seciliStokUrunMiktar == Program.urunStokSilMiktar)
                    {
                        //0 adet kalırsa sil
                        Program.kmt.urunStokSil(Program.seciliStokUrunId);
                        MessageBox.Show("Ürünü stoktan silme işlemi başarı ile gerçekleşti...!");
                    }
                    else if (Program.seciliStokUrunMiktar < Program.urunStokSilMiktar)
                    {
                        //yetersiz stok
                        MessageBox.Show("Stokta yeteri kadar ürün bulunmamaktadır..!");
                    }
                    else
                    {
                        //stoktan güncelle
                        Program.kmt.urunStokGuncelle(Program.seciliStokUrunId, Program.seciliStokUrunMiktar - Program.urunStokSilMiktar, DateTime.Now);
                        MessageBox.Show("Ürünü stoktan silme işlemi başarı ile gerçekleşti...!");
                    }




                    //if (dt.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        parcaStokID = Convert.ToInt32(dt.Rows[i][0]);
                    //        mevcutAdet = Convert.ToInt32(dt.Rows[i][2]);

                    //        for (int j = 0; j < dtparcastokmiktar.Rows.Count; j++)
                    //        {
                    //            if ((int)dtparcastokmiktar.Rows[j][0] == (int)dt.Rows[i][0])
                    //            {
                    //                if (parcaStokID > 0)
                    //                {
                    //                    // Giriş mevcut, update edicez
                    //                    adet = Program.urunStokSilMiktar;
                    //                    Program.kmt.parcaStokGuncelle(parcaStokID, adet + mevcutAdet, DateTime.Now);
                    //                }

                    //            }
                    //            else
                    //            {
                    //                adet = Program.urunStokSilMiktar;
                    //                Program.kmt.parcaStokGir(adet, DateTime.Now, parcaStokID);
                    //            }

                    //        }
                    //    }
                    //}

                }
                else if (secenek == DialogResult.No)
                {
                    int farkUrunStok = Program.seciliStokUrunMiktar - Program.urunStokSilMiktar;
                    //urunu ve parcalarini sil
                    if ((farkUrunStok) > 0)
                    {
                        Program.kmt.urunStokGuncelle(Program.seciliStokUrunId, farkUrunStok, DateTime.Now);

                    }
                    else if (farkUrunStok == 0)
                    {
                        Program.kmt.urunStokSil(Program.seciliStokUrunId);
                    }
                    else if (farkUrunStok < 0)
                    {
                        MessageBox.Show("Stokta yeterli ürün bulunmamaktadır...!");
                    }
                }
                dataGridView3.DataSource = Program.kmt.urunStokTumu();
                dataGridView3.ClearSelection();
            }
            Program.seciliStokUrunId = 0;
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                try
                {
                    int SecilenRow = dataGridView3.CurrentCell.RowIndex;
                    int SecilenColumn = dataGridView3.CurrentCell.ColumnIndex;
                    Program.seciliStokUrunId = Convert.ToInt32(dataGridView3.Rows[SecilenRow].Cells[0].Value);

                    Program.seciliStokUrunMiktar = Convert.ToInt32(dataGridView3.Rows[SecilenRow].Cells[2].Value);
                }
                catch
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.seciliStokUrunId == 0)
            {
                MessageBox.Show("Lütfen stoktan bir ürün seçiniz..!");
            }
            else
            {
                //URUNU STOKTAN SILME
                urunStokSil.ShowDialog();
                int urunStokID = 0;
                int mevcutAdet = 0;
                int silAdet = 0;
                DataTable dt = Program.kmt.urunStokGosterId(Program.seciliStokUrunId);

                if (dt.Rows.Count > 0)
                {
                    urunStokID = Convert.ToInt32(dt.Rows[0][0]);
                    mevcutAdet = Convert.ToInt32(dt.Rows[0][2]);
                }

                if (urunStokID > 0)
                {
                    silAdet = Program.urunStokSilMiktar;

                    if (mevcutAdet > silAdet)
                    {
                        // Giriş mevcut, update edicez                    
                        Program.kmt.urunStokGuncelle(Program.seciliStokUrunId, mevcutAdet - silAdet, DateTime.Now);
                        Program.kmt.urunStokCikis(Program.seciliStokUrunId, silAdet, DateTime.Now);
                    }
                    else if (mevcutAdet == silAdet)
                    {
                        Program.kmt.urunStokSil(Program.seciliStokUrunId);
                        Program.kmt.urunStokCikis(Program.seciliStokUrunId, mevcutAdet, DateTime.Now);
                        MessageBox.Show("Girilen miktar kadar ürün stoktan çıkarıldı.(Stokta mevcut üründen hiç kalmadı)");
                    }
                    else
                    {
                        MessageBox.Show("Stokta yeterli ürün bulunmamaktadır...!");
                    }
                }
                //Urun stok giris tablosunu guncelle
                dataGridView3.DataSource = Program.kmt.urunStokTumu();
                dataGridView4.DataSource = Program.kmt.urunStokCikisTumu();

                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();

            }
            Program.seciliStokUrunId = 0;
        }
    }
}
