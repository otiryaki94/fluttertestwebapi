using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlutterTest
{
    public class KullaniciDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Telefon { get; set; }
        public Nullable<bool> SilindiMi { get; set; }
    }
}