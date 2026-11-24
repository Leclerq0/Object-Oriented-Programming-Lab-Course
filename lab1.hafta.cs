using System;
using System.Collections.Generic;

namespace EvCihazlariYonetimi
{
    enum CihazTuru
    {
        Lamba = 1,
        Klima = 2,
        GuvenlikSistemi = 3
    }

    interface ICihaz
    {
        void Ac();
        void Kapat();
        void BilgileriGoster();
    }

    class Cihaz : ICihaz
    {
        public int Kimlik { get; set; }
        public string Ad { get; set; }
        public CihazTuru Tur { get; set; }
        public bool AcikMi { get; set; }

        public Cihaz(int kimlik, string ad, CihazTuru tur)
        {
            Kimlik = kimlik;
            Ad = ad;
            Tur = tur;
            AcikMi = false;
        }

        public void Ac()
        {
            if (AcikMi)
            {
                Console.WriteLine(Ad + " zaten açık.");
            }
            else
            {
                AcikMi = true;
                Console.WriteLine(Ad + " açıldı.");
            }
        }

        public void Kapat()
        {
            if (!AcikMi)
            {
                Console.WriteLine(Ad + " zaten kapalı.");
            }
            else
            {
                AcikMi = false;
                Console.WriteLine(Ad + " kapatıldı.");
            }
        }

        public void BilgileriGoster()
        {
            string durum = AcikMi ? "Açık" : "Kapalı";
            Console.WriteLine($"Kimlik: {Kimlik} | Ad: {Ad} | Tür: {Tur} | Durum: {durum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cihaz> cihazlar = new List<Cihaz>();
            cihazlar.Add(new Cihaz(1, "Lamba", CihazTuru.Lamba));
            cihazlar.Add(new Cihaz(2, "Klima", CihazTuru.Klima));
            cihazlar.Add(new Cihaz(3, "Güvenlik Sistemi", CihazTuru.GuvenlikSistemi));

            bool devam = true;

            while (devam)
            {
                Console.WriteLine("\n--- AKILLI EV CİHAZ YÖNETİMİ ---");
                Console.WriteLine("1. Cihazları Listele");
                Console.WriteLine("2. Yeni Cihaz Ekle");
                Console.WriteLine("3. Cihaz Aç");
                Console.WriteLine("4. Cihaz Kapat");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                Console.WriteLine();

                switch (secim)
                {
                    case "1":
                        if (cihazlar.Count == 0)
                        {
                            Console.WriteLine("Sistemde kayıtlı cihaz yok.");
                        }
                        else
                        {
                            foreach (Cihaz cihaz in cihazlar)
                            {
                                cihaz.BilgileriGoster();
                            }
                        }
                        break;

                    case "2":
                        Console.Write("Cihaz Kimliği (sayı): ");
                        int yeniKimlik;
                        if (!int.TryParse(Console.ReadLine(), out yeniKimlik))
                        {
                            Console.WriteLine("Hata: Geçerli bir sayı giriniz.");
                            break;
                        }

                        bool ayniKimlikVar = false;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == yeniKimlik)
                            {
                                ayniKimlikVar = true;
                                break;
                            }
                        }

                        if (ayniKimlikVar)
                        {
                            Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz zaten var");
                            break;
                        }

                        Console.Write("Cihaz Adı: ");
                        string yeniAd = Console.ReadLine();

                        Console.WriteLine("Cihaz Türü Seçiniz:");
                        Console.WriteLine("1. Lamba");
                        Console.WriteLine("2. Klima");
                        Console.WriteLine("3. GuvenlikSistemi");
                        Console.Write("Tür seçiminiz: ");
                        string turSecim = Console.ReadLine();

                        CihazTuru secilenTur;
                        if (turSecim == "1")
                        {
                            secilenTur = CihazTuru.Lamba;
                        }
                        else if (turSecim == "2")
                        {
                            secilenTur = CihazTuru.Klima;
                        }
                        else if (turSecim == "3")
                        {
                            secilenTur = CihazTuru.GuvenlikSistemi;
                        }
                        else
                        {
                            Console.WriteLine("Hata: Geçersiz cihaz türü seçtiniz");
                            break;
                        }

                        Cihaz yeniCihaz = new Cihaz(yeniKimlik, yeniAd, secilenTur);
                        cihazlar.Add(yeniCihaz);
                        Console.WriteLine("Cihaz başarıyla eklendi.");
                        break;

                    case "3":
                        Console.Write("Açmak istediğiniz cihazın kimliği: ");
                        int acilacakKimlik;
                        if (!int.TryParse(Console.ReadLine(), out acilacakKimlik))
                        {
                            Console.WriteLine("Hata: Geçerli bir sayı giriniz.");
                            break;
                        }

                        Cihaz acilacakCihaz = null;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == acilacakKimlik)
                            {
                                acilacakCihaz = cihaz;
                                break;
                            }
                        }

                        if (acilacakCihaz == null)
                        {
                            Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz bulunamadı");
                        }
                        else
                        {
                            acilacakCihaz.Ac();
                        }
                        break;

                    case "4":
                        Console.Write("Kapatmak istediğiniz cihazın kimliği: ");
                        int kapatilacakKimlik;
                        if (!int.TryParse(Console.ReadLine(), out kapatilacakKimlik))
                        {
                            Console.WriteLine("Hata: Geçerli bir sayı giriniz.");
                            break;
                        }

                        Cihaz kapatilacakCihaz = null;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == kapatilacakKimlik)
                            {
                                kapatilacakCihaz = cihaz;
                                break;
                            }
                        }

                        if (kapatilacakCihaz == null)
                        {
                            Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz bulunamadı");
                        }
                        else
                        {
                            kapatilacakCihaz.Kapat();
                        }
                        break;

                    case "5":
                        devam = false;
                        Console.WriteLine("Programdan çıkılıyor...");
                        break;

                    default:
                        Console.WriteLine("Hata: Geçersiz seçim, lütfen 1-5 arası bir değer giriniz.");
                        break;
                }
            }
        }
    }
}
