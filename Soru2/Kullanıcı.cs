using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru2
{
    public class Kullanıcı
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Email { get; set; }
        public object Sifre { get; set; }
        public Kullanıcı(string ad,string soyad, DateTime dogumTarihi,string eMail,object sifre)
        {
            Ad = ad;
            Soyad = soyad;
            DogumTarihi = dogumTarihi;
            Email = eMail;
            Sifre = sifre;
        }
        public Kullanıcı()
        {

        }
    }
}
