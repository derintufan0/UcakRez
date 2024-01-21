using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcakRezervasyonKonsol.Models;

namespace UcakRezervasyonKonsol.Interfaces
{
    public interface IRezervasyon
    {
        public Musteri Musteri { get; set;}
        public Ucus Ucus { get; set; }
        public int KoltukNo { get; set; }
    }
}
