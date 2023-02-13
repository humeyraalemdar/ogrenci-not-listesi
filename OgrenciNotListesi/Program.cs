using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciNotListesi
{
    class Program
    {
        static void Main(string[] args)
        {
            var ogrenciler = new List<Ogrenci>();
            var sinavlar = new List<Sinav>();
            Console.WriteLine("   Ogrenci Not Listesi Programi  ");
            Console.WriteLine("---------------------------------");
            Menu(ogrenciler, sinavlar);
            Console.ReadKey();
        }

        class Ogrenci
        {
            public string TC;
            public string Adi;
            public string Soyadi;

        }

        class Sinav
        {
            public string TC;
            public double Vize;
            public double Final;
        }

        private static void Menu(List<Ogrenci> ogrenciler, List<Sinav> sinavlar)
        {
            Console.WriteLine("               Menü              ");
            Console.WriteLine("*       1- Ogrenci Girisi       *");
            Console.WriteLine("*       2- Sinav Girisi         *");
            Console.WriteLine("*       3- Ogrenci Listesi      *");
            Console.WriteLine("*    4- Ogrenci Sinav Listesi   *");
            Console.WriteLine("*    5- Sinav Notu Degistirme   *");
            Console.WriteLine("*            6- Cikis           *");
            Console.WriteLine("         Lütfen Seçim Yapınız    ");
            int Secim = Convert.ToInt16(Console.ReadLine());
            switch (Secim)
            {
                case 1:
                    //Ogrenci Girisi Yapilir
                    OgrenciListesi(ogrenciler, sinavlar);
                    break;
                case 2:
                    //Sinav Notu Girisi Yapilir
                    SinavListesi(ogrenciler, sinavlar);
                    break;
                case 3:
                    //Ogrenci Listesini Gosterir
                    ListeyiGoster(ogrenciler, sinavlar);
                    break;
                case 4:
                    //Ogrenci Sinav Listesini Gosterir
                    OgrenciSinavListesi(ogrenciler, sinavlar);
                    break;
                case 5:
                    //Sinav Notu Degistirir
                    SinavNotuDegistirme(ogrenciler, sinavlar);
                    break;
                case 6:
                    Console.WriteLine("Cikis Yaptiniz!");
                    System.Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("Menuden Bir Secim Yapiniz ........ !");
                    break;
            }
        }

        private static void OgrenciListesi(List<Ogrenci> ogrenciler, List<Sinav> sinavlar)
        {
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Ogrenci Adini Giriniz:");
                string ad = Console.ReadLine();
                Console.WriteLine("Ogrenci Soyadini Giriniz:");
                string soyad = Console.ReadLine();
                Console.WriteLine("Tc No Giriniz:");
                string tc = Console.ReadLine();

                foreach (var item in ogrenciler) //TC Numarasi Kontrol Edilir
                {
                    if (tc == item.TC)
                    {
                        Console.WriteLine(tc + " TC Kimlik Numarali Ogrenci Zaten Kayitli!");
                        Menu(ogrenciler, sinavlar);
                    }
                }
                ogrenciler.Add(new Ogrenci { Adi = ad, Soyadi = soyad, TC = tc });
                ListeyiGoster(ogrenciler, sinavlar);

                Console.WriteLine("Devam Etmek Istiyor musunuz ? (E/H)");
                string devam = Console.ReadLine();
                if (devam == "E" || devam == "e")
                {
                    Menu(ogrenciler, sinavlar);
                }
            }
            ListeyiGoster(ogrenciler, sinavlar);
        }

        private static void SinavListesi(List<Ogrenci> ogrenciler, List<Sinav> sinavlar)
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Sinav Girisi Yapilacak Ogrenci Listesi Bos. Ogrenci Kaydi Yapiniz.");
                Menu(ogrenciler, sinavlar);
            }
            else
            {
                Console.WriteLine("Sinav Notu Eklemek Istediginiz TC Numarasini Giriniz:");
                string girilentc = Console.ReadLine();


                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    if (ogrenciler[i].TC == girilentc)
                    {
                        for (int k = 0; k < 1; k++)
                        {
                            Console.WriteLine("Vize Notunu Girin:");
                            double vize = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Final Notunu Girin:");
                            double final = Convert.ToDouble(Console.ReadLine());

                            sinavlar.Add(new Sinav { TC = girilentc, Vize = vize, Final = final });
                        }

                        Console.WriteLine("Devam Etmek Istiyor musunuz ? (E/H)");
                        string devam = Console.ReadLine();
                        if (devam == "E" || devam == "e")
                        {
                            Menu(ogrenciler, sinavlar);
                        }
                    }
                    else
                    {

                        Console.WriteLine("Girilen TC Icin Kayit Bulunmadi");
                    }
                }
            }
        }

        private static void ListeyiGoster(List<Ogrenci> ogrenciler, List<Sinav> sinavlar)
        {
            bool ogrencivar = false;

            foreach (var item in ogrenciler)
            {
                ogrencivar = true;
                Console.WriteLine("Adı:{0},Soyadı:{1}, Tc:{2}", item.Adi, item.Soyadi, item.TC);
            }
            if (!ogrencivar)
            {
                Console.WriteLine("Gosterilecek Kayit Bulunmadi");
            }

            Console.WriteLine("Devam Etmek Istiyor musunuz ? (E/H)");
            string devam = Console.ReadLine();
            if (devam == "E" || devam == "e")
            {
                Menu(ogrenciler, sinavlar);
            }
        }

        private static void OgrenciSinavListesi(List<Ogrenci> ogrenciler, List<Sinav> sinavlar)
        {
            bool tumliste = false;

            foreach (var item in ogrenciler)
            {
                if (ogrenciler.Count > 0)
                {
                    foreach (var item2 in sinavlar)
                    {
                        if (sinavlar.Count > 0)
                        {
                            if (item2.TC == item.TC)
                            {
                                tumliste = true;
                                Console.WriteLine("Adı:{0},Soyadı:{1}, Tc:{2}, Vize:{3}, Final:{4} ", item.Adi, item.Soyadi, item.TC, item2.Vize, item2.Final);
                            }
                            else
                            {
                                tumliste = false;
                                Console.WriteLine("Adı:{0},Soyadı:{1}, Tc:{2}, Vize:{3}, Final:{4} ", item.Adi, item.Soyadi, item.TC, 0, 0);
                            }

                        }
                    }
                }
                if (tumliste == false)
                {
                    Console.WriteLine("Adı:{0},Soyadı:{1}, Tc:{2}, Vize:{3}, Final:{4} ", item.Adi, item.Soyadi, item.TC, 0, 0);
                }
            }
            if (tumliste == false)
            {
                Console.WriteLine("Gösterilecek Kayit Bulunmadi");
            }

            Console.WriteLine("Devam Etmek Istiyor musunuz ? (E/H)");
            string devam = Console.ReadLine();
            if (devam == "E" || devam == "e")
            {
                Menu(ogrenciler, sinavlar);
            }
        }

        private static void SinavNotuDegistirme(List<Ogrenci> ogrenciler, List<Sinav> sinavlar)
        {
            if (ogrenciler.Count > 0)
            {
                Console.WriteLine("Notunu Degistirmek Istediginiz Ogrenci TC Numarasini Giriniz: ");
                string secilenOgrenci = Console.ReadLine();
                for (int i = 0; i < sinavlar.Count; i++)
                {

                    if (sinavlar[i].TC == secilenOgrenci)
                    {
                        sinavlar.Remove(sinavlar[i]);
                        Console.WriteLine(secilenOgrenci + " TC Numarali Ogrencinin Sinav Bilgileri Silindi.");
                        SinavListesi(ogrenciler, sinavlar);
                    }
                    else
                    {
                        Console.WriteLine(secilenOgrenci + "TC Numarali Kayit Bulunamadı.");
                        Menu(ogrenciler, sinavlar);
                    }

                }
            }
            else
            {
                Console.WriteLine("Degistirilecek Kayit Bulunamadi");
                Menu(ogrenciler, sinavlar);
            }
        }
    }
}
