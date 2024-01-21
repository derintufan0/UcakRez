using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcakRezervasyonKonsol.Models;

namespace UcakRezervasyonKonsol.Methods
{
    public class DosyayaYazma
    {
        public void MusteriKaydet(Musteri musteri)
        {
            string dosyaAdresi = @"C:\Users\enese\OneDrive\Masaüstü\UcakRezervasyonKonsol\UcakRezervasyonKonsol\Veriler\Musteriler.txt";

            using (StreamWriter dosya = new StreamWriter(dosyaAdresi))
            {
                
                    dosya.WriteLine($"{musteri.Ad},{musteri.Soyad},{musteri.Cinsiyet},{musteri.Yas},{musteri.YasliMi},{musteri.EngelliMi}");
                
            }

        }
        public void RezervasyonKaydet(Rezervasyon rezervasyon)
        {
            string dosyaAdresi = @"C:\Users\enese\OneDrive\Masaüstü\UcakRezervasyonKonsol\UcakRezervasyonKonsol\Veriler\Rezervasyonlar.txt";

            using (StreamWriter dosya = new StreamWriter(dosyaAdresi))
            {

                dosya.WriteLine($"{rezervasyon.Musteri.Ad},{rezervasyon.Musteri.Soyad},{rezervasyon.Ucus.UcusNo}," +
                    $"{rezervasyon.Ucus.Nereye},{rezervasyon.Ucus.Nereden},{rezervasyon.Ucus.UcusTarihi},,{rezervasyon.KoltukNo}");

            }

        }
    }
}
