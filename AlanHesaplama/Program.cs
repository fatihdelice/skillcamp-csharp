using AlanHesaplama.Enums;
using AlanHesaplama.Services;

namespace AlanHesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputService inputService = new InputService();
            ShapeCalculator calculator = new ShapeCalculator();

            Console.WriteLine("=== ALAN HESAPLAMA UYGULAMASI ===");

            Console.WriteLine("\nGeometrik Sekiller:");
            Console.WriteLine("1 - Daire");
            Console.WriteLine("2 - Ucgen");
            Console.WriteLine("3 - Kare");
            Console.WriteLine("4 - Dikdortgen");
            Console.WriteLine("5 - Kup");
            Console.WriteLine("6 - Dikdortgenler Prizmasi");

            int sekilSecimi = inputService.SecimAl(
                "\nIslem yapmak istediginiz sekli seciniz: ",
                1,
                6
            );

            ShapeType secilenSekil = (ShapeType)sekilSecimi;

            double[] kenarlar = KenarBilgileriniAl(
                secilenSekil,
                inputService
            );

            Console.WriteLine("\nHesaplama Turleri:");

            if (secilenSekil <= ShapeType.Dikdortgen)
            {
                Console.WriteLine("1 - Alan");
                Console.WriteLine("2 - Cevre");
            }
            else
            {
                Console.WriteLine("3 - Hacim");
            }

            int olcuSecimi = inputService.SecimAl(
                "\nHesaplamak istediginiz olcuyu seciniz: ",
                secilenSekil <= ShapeType.Dikdortgen ? 1 : 3,
                secilenSekil <= ShapeType.Dikdortgen ? 2 : 3
            );

            MeasurementType secilenOlcu =
                (MeasurementType)olcuSecimi;

            if (!calculator.HesaplamaDestekleniyor(
                secilenSekil,
                secilenOlcu))
            {
                Console.WriteLine("Bu hesaplama desteklenmiyor!");
                return;
            }

            double sonuc = 0;

            switch (secilenOlcu)
            {
                case MeasurementType.Alan:
                    sonuc = calculator.AlanHesapla(
                        secilenSekil,
                        kenarlar
                    );
                    break;

                case MeasurementType.Cevre:
                    sonuc = calculator.CevreHesapla(
                        secilenSekil,
                        kenarlar
                    );
                    break;

                case MeasurementType.Hacim:
                    sonuc = calculator.HacimHesapla(
                        secilenSekil,
                        kenarlar
                    );
                    break;
            }

            Console.WriteLine("\n=== HESAPLAMA SONUCU ===");
            Console.WriteLine($"Sekil: {secilenSekil}");
            Console.WriteLine($"Islem: {secilenOlcu}");
            Console.WriteLine($"Sonuc: {sonuc:F2}");
        }

        static double[] KenarBilgileriniAl(
            ShapeType sekil,
            InputService inputService)
        {
            switch (sekil)
            {
                case ShapeType.Daire:
                    return new double[]
                    {
                        inputService.PozitifSayiAl("Yaricap: ")
                    };

                case ShapeType.Ucgen:
                    double kenar1 = inputService.PozitifSayiAl(
                        "Birinci kenar: "
                    );

                    double kenar2 = inputService.PozitifSayiAl(
                        "Ikinci kenar: "
                    );

                    double kenar3;

                    while (true)
                    {
                        kenar3 = inputService.PozitifSayiAl(
                            "Ucuncu kenar: "
                        );

                        if (kenar1 + kenar2 > kenar3 &&
                            kenar1 + kenar3 > kenar2 &&
                            kenar2 + kenar3 > kenar1)
                        {
                            break;
                        }

                        Console.WriteLine(
                            "Girdiginiz kenarlar bir ucgen olusturmuyor!"
                        );
                    }

                    return new double[]
                    {
                        kenar1,
                        kenar2,
                        kenar3
                    };

                case ShapeType.Kare:
                case ShapeType.Kup:
                    return new double[]
                    {
                        inputService.PozitifSayiAl("Kenar uzunlugu: ")
                    };

                case ShapeType.Dikdortgen:
                    return new double[]
                    {
                        inputService.PozitifSayiAl("Uzun kenar: "),
                        inputService.PozitifSayiAl("Kisa kenar: ")
                    };

                case ShapeType.DikdortgenlerPrizmasi:
                    return new double[]
                    {
                        inputService.PozitifSayiAl("Uzunluk: "),
                        inputService.PozitifSayiAl("Genislik: "),
                        inputService.PozitifSayiAl("Yukseklik: ")
                    };

                default:
                    throw new ArgumentException("Gecersiz sekil!");
            }
        }
    }
}