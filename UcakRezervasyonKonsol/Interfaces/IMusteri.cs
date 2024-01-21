using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakRezervasyonKonsol.Interfaces
{
    public interface IMusteri
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cinsiyet { get; set; }
        public int Yas { get; set; }
        public bool YasliMi { get; set; }
        public bool EngelliMi { get; set; }
    }
}
