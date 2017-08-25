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
    public partial class UrunStokEkleForm : Form
    {
        public UrunStokEkleForm()
        {
            InitializeComponent();
        }

        int mevcut_parca_miktar = 0;
        int gereken_parca_miktar = 0;
        int gereken_parca_id = 0;
        int mevcut_parca_id = 0;
        string mevcut_parca_isim = "";
        double mevcut_parca_fiyat = 0;
        int urunStokMiktar = 0;

        public void urunStokKontrol()
        {
            urunStokMiktar = Convert.ToInt32(txtUrunStokMiktar.Text);
            //stokta aynı urun varsa üzerine ekle 
            //yoksa yeni urun oluştur
            int urunStokID = 0;
            int mevcutAdet = 0;
            DataTable dt = Program.kmt.urunStokGosterId(Program.seciliUrunId);

            if (dt.Rows.Count > 0)
            {
                urunStokID = Convert.ToInt32(dt.Rows[0][0]);
                mevcutAdet = Convert.ToInt32(dt.Rows[0][2]);
            }
            if (urunStokID > 0)
            {
                // Giriş mevcut, update edicez            
                Program.kmt.urunStokGuncelle(Program.seciliUrunId, urunStokMiktar + mevcutAdet, DateTime.Now);
            }
            else
            {
                //giriş yok yeni giriş ekle
                Program.kmt.urunStokEkle(Program.seciliUrunId, urunStokMiktar, DateTime.Now);
            }
        }


        private void UrunStokEkleForm_Load(object sender, EventArgs e)
        {
            btnUrunStokGoruntule.Enabled = true;

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ClearSelection();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.ClearSelection();

            lblEksikParcaMaliyet.Text = "00";
            lblToplamMaliyet.Text = "00";

            dataGridView1.DataSource = Program.kmt.urunParcalarGoster(Program.seciliUrunId);
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "İsim";
            dataGridView1.Columns[2].HeaderText = "Miktar";
        }

        private void btnUrunStokGoruntule_Click(object sender, EventArgs e)
        {
            //btnUrunStokGoruntule.Enabled = false;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();

            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.ClearSelection();

            dataGridView3.Columns.Clear();
            Program.gerekliParcaList.Clear();
            Program.eksikParcaList.Clear();
            Program.mevcutParcaDict.Clear();

            DataTable dt_urunParcaStok = Program.kmt.urunParcalarGoster(Program.seciliUrunId);

            int parca_id = 0;
            string parca_isim;
            int parca_miktar = 0;

            //parcaları liste ekle sonra adetle çarp datagrid 1 e yazdır.
            for (int i = 0; i < dt_urunParcaStok.Rows.Count; i++)
            {
                parca_id = (int)dt_urunParcaStok.Rows[i][0];
                parca_isim = dt_urunParcaStok.Rows[i][1].ToString();
                parca_miktar = (int)dt_urunParcaStok.Rows[i][2];
                parca_miktar = parca_miktar * Convert.ToInt32(txtUrunStokMiktar.Text);

                urunParca urunParca = new urunParca(parca_id, parca_isim, parca_miktar);
                urunParca.fiyat = parca_miktar * Program.kmt.parcaFiyat(parca_id);
                Program.gerekliParcaList.Add(urunParca);
            }

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("parca_id", "İd");
            dataGridView1.Columns.Add("parca_isim", "İsim");
            dataGridView1.Columns.Add("parca_miktar", "Miktar");
            dataGridView1.Columns.Add("fiyat", "Fiyat");

            for (int k = 0; k < Program.gerekliParcaList.Count; k++)
            {
                dataGridView1.Rows.Add();

                dataGridView1.Rows[k].Cells[0].Value = Program.gerekliParcaList[k].parca_id;
                dataGridView1.Rows[k].Cells[1].Value = Program.gerekliParcaList[k].parcaAdi;
                dataGridView1.Rows[k].Cells[2].Value = Program.gerekliParcaList[k].miktar;
                dataGridView1.Rows[k].Cells[3].Value = Program.gerekliParcaList[k].fiyat;
            }
            

            //Mevcut parcalar
            DataTable dt_mevcutParcalar = Program.kmt.parcaStokGoster(Program.seciliUrunId);
            if (dt_mevcutParcalar.Rows.Count > 0)
            {
                // PARÇA VAR
                for (int k = 0; k < dt_mevcutParcalar.Rows.Count; k++)
                {
                    mevcut_parca_id = (int)dt_mevcutParcalar.Rows[k][0];
                    mevcut_parca_isim = dt_mevcutParcalar.Rows[k][1].ToString();
                    mevcut_parca_miktar = (int)dt_mevcutParcalar.Rows[k][2];
                    mevcut_parca_fiyat = (double)dt_mevcutParcalar.Rows[k][3];
                    urunParca urunParca = new urunParca(mevcut_parca_id, mevcut_parca_isim, mevcut_parca_miktar);
                    urunParca.fiyat = mevcut_parca_fiyat;
                    Program.mevcutParcaDict.Add(mevcut_parca_id, urunParca);
                }
            }

            // GEREKLİ PARÇALARI ARA
            for (int i = 0; i < Program.gerekliParcaList.Count; i++)
            {
                int aranan_parca_id = Program.gerekliParcaList[i].parca_id;

                // ARADAĞIMIZ PARCA MEVCUT PARCALARDA VAR MI
                if(Program.mevcutParcaDict.ContainsKey(aranan_parca_id))
                {
                    // PARCA VAR
                    urunParca bulunanParca = Program.mevcutParcaDict[aranan_parca_id];
                    Program.bulunanParcaList.Add(bulunanParca);                  
                    urunParca gerekenParca = Program.gerekliParcaList[i];

                    if (gerekenParca.miktar > bulunanParca.miktar)
                    {
                        // STOK MİKTARI YETERSİZ
                        int eksikAdet = gerekenParca.miktar - bulunanParca.miktar;

                        urunParca eksikUrunParca = new urunParca(Program.gerekliParcaList[i].parca_id, Program.gerekliParcaList[i].parcaAdi, eksikAdet);
                        eksikUrunParca.fiyat = eksikAdet * (double)Program.mevcutParcaDict[aranan_parca_id].fiyat;
                        Program.eksikParcaList.Add(eksikUrunParca);
                    }
                }
                else
                {
                    // PARCA YOK
                    Program.eksikParcaList.Add(Program.gerekliParcaList[i]);
                }
            }


            //mevcut parca listesinin datagride yerleşimi
            /*dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            dataGridView2.Columns.Add("parca_id", "parca_id");
            dataGridView2.Columns.Add("parca_isim", "parca_isim");
            dataGridView2.Columns.Add("parca_miktar", "parca_miktar");

            for (int k = 0; k < Program.bulunanParcaList.Count; k++)
            {
                dataGridView2.Rows.Add();

                dataGridView2.Rows[k].Cells[0].Value = Program.bulunanParcaList[k].parca_id;
                dataGridView2.Rows[k].Cells[1].Value = Program.bulunanParcaList[k].parcaAdi;
                dataGridView2.Rows[k].Cells[2].Value = Program.bulunanParcaList[k].miktar;
            }*/
            
            dataGridView2.DataSource = Program.kmt.parcaStokGoster(Program.seciliUrunId);        
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[0].HeaderText = "İd";


            if (dataGridView3.Rows.Count == 0)
            {
                //eksik parca listin datagride yerlesimi
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();
                dataGridView3.Columns.Clear();

                dataGridView3.Columns.Add("parca_id", "İd");
                dataGridView3.Columns.Add("parca_isim", "İsim");
                dataGridView3.Columns.Add("parca_miktar", "Miktar");
                dataGridView3.Columns.Add("fiyat", "Fiyat");

                for (int k = 0; k < Program.eksikParcaList.Count; k++)
                {
                    dataGridView3.Rows.Add();

                    dataGridView3.Rows[k].Cells[0].Value = Program.eksikParcaList[k].parca_id;
                    dataGridView3.Rows[k].Cells[1].Value = Program.eksikParcaList[k].parcaAdi;
                    dataGridView3.Rows[k].Cells[2].Value = Program.eksikParcaList[k].miktar;
                    dataGridView3.Rows[k].Cells[3].Value = Program.eksikParcaList[k].fiyat;
                }
            }

            double toplamParcaMaliyet = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplamParcaMaliyet += (double)dataGridView1.Rows[i].Cells[3].Value;
            }
            lblToplamMaliyet.Text = Convert.ToString(toplamParcaMaliyet);

            double eksikParcaMaliyet = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                eksikParcaMaliyet += (double)dataGridView3.Rows[i].Cells[3].Value;
            }
            lblEksikParcaMaliyet.Text = Convert.ToString(eksikParcaMaliyet);

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }
        
        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void UrunStokEkleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //btnUrunStokGoruntule.Enabled = true;
            Program.gerekliParcaList.Clear();
            Program.eksikParcaList.Clear();
            Program.mevcutParcaDict.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
        }

        private void txtUrunStokMiktar_TextChanged(object sender, EventArgs e)
        {

        }
        
        public void parcaStokGuncelle()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                gereken_parca_id = (int)dataGridView1.Rows[i].Cells[0].Value;
                gereken_parca_miktar = (int)dataGridView1.Rows[i].Cells[2].Value;

                bool stokGuncellendi = false;
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                   
                    mevcut_parca_id = (int)dataGridView2.Rows[j].Cells[0].Value;
                    mevcut_parca_miktar = (int)dataGridView2.Rows[j].Cells[2].Value;

                    if (gereken_parca_id == mevcut_parca_id)
                    {
                        if (mevcut_parca_miktar <= gereken_parca_miktar)
                        {
                            Program.kmt.parcaStokSil(mevcut_parca_id);
                            Program.kmt.parcaStokCikis(gereken_parca_miktar, DateTime.Now, gereken_parca_id);
                            stokGuncellendi = true;
                        }
                        else
                        {
                            Program.kmt.parcaStokGuncelle(mevcut_parca_id,
                                mevcut_parca_miktar - gereken_parca_miktar,
                                DateTime.Now, false);
                            Program.kmt.parcaStokCikis(gereken_parca_miktar, DateTime.Now, gereken_parca_id);
                            stokGuncellendi = true;
                        }
                    }
                }
                if(stokGuncellendi == false)
                {
                    Program.kmt.parcaStokCikis(gereken_parca_miktar, DateTime.Now, gereken_parca_id);
                }
            }
        }

        private void btnUrunStokKaydet_Click(object sender, EventArgs e)
        {
            urunStokMiktar = Convert.ToInt32(txtUrunStokMiktar.Text);

            //eksik parca kontrol
            if (dataGridView3.Rows.Count > 0)
            {
                DialogResult secenek = MessageBox.Show("Eksik parçalar var yinede devam etmek istiyormusunuz..!","Bilgilendirme penceresi",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    //urunu kontrol et sonra ekle veya guncelle
                    urunStokKontrol();
                    //Program.kmt.urunStokEkle(Program.seciliUrunId, urunStokMiktar, DateTime.Now);

                    parcaStokGuncelle();
                    
                    MessageBox.Show("Urun başarı ile stoğa eklendi...!");
                }
                else if (secenek == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                //urunu kontrol et sonra ekle veya guncelle
                urunStokKontrol();
                //Program.kmt.urunStokEkle(Program.seciliUrunId, urunStokMiktar, DateTime.Now);
                parcaStokGuncelle();
                MessageBox.Show("Urun başarı ile stoğa eklendi...!");             
            }
            this.Close();
        }

        private void txtUrunStokMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
