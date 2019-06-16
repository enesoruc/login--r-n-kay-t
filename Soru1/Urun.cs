using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru1
{
    public class Urun
    {
        static int _instanceCounter = 0;
        public string UrunAd { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }

        public Urun(string urunAd,string renk,decimal fiyat)
        {
            UrunAd = urunAd;
            Renk = renk;
            Fiyat = fiyat;
            _instanceCounter++;
            
        }
        public override string ToString()
        {
            return this.UrunAd + " " + this.Fiyat + " " + this.Renk;
        }
        public static Urun GetInstance(string urunAd,string renk, decimal fiyat)
        {

            if (_instanceCounter < 10)
            {
                return new Urun(urunAd,renk,fiyat);
            }
            return null;
        }
    }
}
