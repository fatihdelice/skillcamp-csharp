namespace AlanHesaplama.Services
{
    public class InputService
    {
        public double PozitifSayiAl(string mesaj)
        {
            double sayi;

            while (true)
            {
                Console.Write(mesaj);

                bool gecerli = double.TryParse(
                    Console.ReadLine(),
                    out sayi
                );

                if (gecerli && sayi > 0)
                {
                    return sayi;
                }

                Console.WriteLine(
                    "Lutfen sifirdan buyuk gecerli bir sayi giriniz!"
                );
            }
        }

        public int SecimAl(string mesaj, int minimum, int maximum)
        {
            int secim;

            while (true)
            {
                Console.Write(mesaj);

                bool gecerli = int.TryParse(
                    Console.ReadLine(),
                    out secim
                );

                if (gecerli && secim >= minimum && secim <= maximum)
                {
                    return secim;
                }

                Console.WriteLine("Gecersiz secim yaptiniz!");
            }
        }
    }
}