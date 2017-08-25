using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StokUrunYonetim
{
    static class Program
    {

        public static Komutlar kmt = new Komutlar();

        public static List<urunParca> parcaList = new List<urunParca>();
        public static Dictionary<int,urunParca> mevcutParcaDict = new Dictionary<int, urunParca>();
        public static List<urunParca> bulunanParcaList = new List<urunParca>();
        public static List<urunParca> gerekliParcaList = new List<urunParca>();
        public static List<urunParca> eksikParcaList = new List<urunParca>();
        public static int seciliParca;
        public static int seciliEklenenParca;
        public static int seciliEklenenParcaMiktar;
        public static int seciliStok;
        public static int seciliUrunId;
        public static int seciliStokUrunId;
        public static string seciliUrunIsim;
        public static string seciliUrunOzellik;
        public static string seciliUrunAciklama;
        public static int seciliStokUrunMiktar;
        public static string seciliParcaIsim;
        public static bool urunGuncelle = false;
        public static bool yetersizParca = false;
        public static bool urunSecildi = false;
        public static int urunStokSilMiktar = 0;




        public static int adet;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
