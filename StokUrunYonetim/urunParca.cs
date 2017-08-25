using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StokUrunYonetim
{
    public class urunParca
    {
        public int parca_id { get; set; }
        public string parcaAdi { get; set; }
        public int miktar { get; set; }
        public double fiyat{ get; set; }

        public urunParca(int parca_id, string parcaAdi, int miktar)
        {
            this.parca_id = parca_id;
            this.parcaAdi = parcaAdi;
            this.miktar = miktar;
        }
    }
}
