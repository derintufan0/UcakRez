using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcakRezervasyonKonsol.Interfaces;

namespace UcakRezervasyonKonsol.Models
{
    public class Musteri : IMusteri
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cinsiyet { get; set; }
        public int Yas { get; set; }
        public bool YasliMi { get; set; }
        public bool EngelliMi { get; set; }
    }
}
