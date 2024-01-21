using System;
using System.Collections.Generic;
using System.Linq;
using UcakRezervasyonKonsol.Methods;
using UcakRezervasyonKonsol.Models;

class Program
{
    static void Main(string[] args)
    {
        DosyadanOkuma okuyucu = new DosyadanOkuma();
        DosyayaYazma yazici = new DosyayaYazma();
        Random random = new Random();

        Console.WriteLine("****************************************************");
        Console.WriteLine("*                                                  *");
        Console.WriteLine("*                   Hoş Geldiniz!                  *");
        Console.WriteLine("*             DERIN TUFAN - 20220108065            *");
        Console.WriteLine("*                      Flight                      *");
        Console.WriteLine("****************************************************");

        List<Lokasyon> konumlar = GetAndDisplayLocations(okuyucu);

        int konumNoFrom = GetValidLocationNumber("Nereden Uçmak İstediğinizi Seçiniz", konumlar);
        int konumNoTo = GetValidLocationNumber("Nereye Uçmak İstediğinizi Seçiniz", konumlar);

        Console.WriteLine("\nSeçtiğiniz konumlara ait uçuş bilgileri aşağıdadır : \n");
        List<Ucus> ucuslar = okuyucu.UcuslariOku();
        List<Ucak> ucaklar = okuyucu.UcaklariOku();

        DisplayFlightInformation(konumNoFrom, konumNoTo, ucuslar, ucaklar);

        int selectedFlightNumber = GetSelectedFlightNumber(ucuslar);

        Musteri musteri = GetCustomerInformation();
        yazici.MusteriKaydet(musteri);

        Rezervasyon rezervasyon = CreateReservation(random, selectedFlightNumber, ucaklar, ucuslar, musteri);
        yazici.RezervasyonKaydet(rezervasyon);

        Console.WriteLine($"Rezervasyonunuz başarıyla gerçekleşmiştir. Koltuk Numaranız: {rezervasyon.KoltukNo}");
    }

    static List<Lokasyon> GetAndDisplayLocations(DosyadanOkuma okuyucu)
    {
        List<Lokasyon> konumlar = okuyucu.KonumlariOku();

        Console.WriteLine("\nUçuş Rotaları");
        foreach (var item in konumlar)
        {
            Console.WriteLine($"{item.LokasyonNo}, {item.Ulke}, {item.Sehir}, {item.Havaalani}, {(item.KapaliMi ? "Kapalı" : "Açık")}");
        }

        return konumlar;
    }

    static int GetValidLocationNumber(string message, List<Lokasyon> konumlar)
    {
        int konumNo;

        do
        {
            Console.WriteLine($"{message} (Açık olan havalanlarını tercih ediniz!)");
            Console.WriteLine("Konum Numarasını giriniz: ");
            konumNo = Convert.ToInt32(Console.ReadLine());

            if (konumlar[konumNo - 1].KapaliMi)
            {
                Console.WriteLine("Kapalı olan bir konum seçtiniz");
            }
            else
            {
                break;
            }
        } while (true);

        return konumNo;
    }

    static void DisplayFlightInformation(int konumNoFrom, int konumNoTo, List<Ucus> ucuslar, List<Ucak> ucaklar)
    {
        int kalanKoltuk;

        foreach (var item in ucuslar)
        {
            if (item.Nereden == konumNoFrom && item.Nereye == konumNoTo)
            {
                Console.WriteLine($"Uçuş Numarası: {item.UcusNo}");
                var ucak = ucaklar.FirstOrDefault(u => u.SeriNo == item.UcakSeriNo);
                Console.WriteLine($"Uçak Modeli: {ucak.Model}");
                kalanKoltuk = ucak.KoltukKapasitesi - item.RezerveYolcuSayisi;
                Console.WriteLine($"Kalan Koltuk Sayısı: {kalanKoltuk}");
                Console.WriteLine($"Uçuş Tarihi: {item.UcusTarihi}\n\n\n");
            }
        }
    }

    static int GetSelectedFlightNumber(List<Ucus> ucuslar)
    {
        Console.WriteLine("Listelenen Uçuşlardan birinin numarasını giriniz: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static Musteri GetCustomerInformation()
    {
        Musteri musteri = new Musteri();

        Console.WriteLine("İşleminizi tamamlayabilmemiz için aşağıdaki müşteri bilgilerini doldurunuz ");
        Console.WriteLine("Ad: ");
        musteri.Ad = Console.ReadLine();
        Console.WriteLine("Soyad: ");
        musteri.Soyad = Console.ReadLine();
        Console.WriteLine("Cinsiyet: ");
        musteri.Cinsiyet = Console.ReadLine();
        Console.WriteLine("Yaş: ");
        musteri.Yas = Convert.ToInt32(Console.ReadLine());
        musteri.YasliMi = musteri.Yas > 65;
        Console.WriteLine("Herhangi bir engeliniz var mı (E veya H giriniz): ");
        musteri.EngelliMi = Console.ReadLine() == "E";

        return musteri;
    }

    static Rezervasyon CreateReservation(Random random, int selectedFlightNumber, List<Ucak> ucaklar, List<Ucus> ucuslar, Musteri musteri)
    {
        Ucak ucak = ucaklar.FirstOrDefault(u => u.SeriNo == ucuslar[selectedFlightNumber - 1].UcakSeriNo);

        return new Rezervasyon
        {
            Musteri = musteri,
            Ucus = ucuslar[selectedFlightNumber - 1],
            KoltukNo = random.Next(1, ucak.KoltukKapasitesi)
        };
    }
}
