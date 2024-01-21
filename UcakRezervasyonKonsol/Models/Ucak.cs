using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcakRezervasyonKonsol.Interfaces;

namespace UcakRezervasyonKonsol.Models
{
    public class Ucak : IUcak
    {
        public string Model { get; set; }
        public string SeriNo { get; set; }
        public DateTime BakimTarihi { get; set; }
        public int KoltukKapasitesi { get; set; }
    }
}
