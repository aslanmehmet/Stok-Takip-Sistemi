using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StokUrunYonetim
{
    [Serializable()]
    public class parca
    {
        public int id { get; set; }
        public string isim { get; set; }
        public string tur { get; set; }
        public string urunKodu { get; set; }
        public string ozellik { get; set; }
        public string aciklama { get; set; }
        public double eskiFiyat { get; set; }
        public double guncelFiyat { get; set; }
        public DateTime fiyatGuncellemeTarihi { get; set; }

        public parca(int id,string isim,string tur,string urunKodu,string ozellik,string aciklama,double eskiFiyat,double guncelFiyat,DateTime fiyatGuncellemeTarihi)
        {
            this.id = id;
            this.isim = isim;
            this.tur = tur;
            this.urunKodu = urunKodu;
            this.ozellik = ozellik;
            this.aciklama = aciklama;
            this.eskiFiyat = eskiFiyat;
            this.guncelFiyat = guncelFiyat;
            this.fiyatGuncellemeTarihi = fiyatGuncellemeTarihi;
        }
    }
}
