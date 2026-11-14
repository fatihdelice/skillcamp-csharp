namespace FibonacciAverage.Services
{
    public class FibonacciService
    {
        // Fibonacci serisini olusturur
        public List<int> FibonacciSerisiOlustur(int derinlik)
        {
            List<int> sayilar = new List<int>();

            int ilkSayi = 0;
            int ikinciSayi = 1;

            for (int i = 0; i < derinlik; i++)
            {
                sayilar.Add(ilkSayi);

                int sonrakiSayi = ilkSayi + ikinciSayi;

                ilkSayi = ikinciSayi;
                ikinciSayi = sonrakiSayi;
            }

            return sayilar;
        }

        // Fibonacci serisinin ortalamasini hesaplar
        public double OrtalamaHesapla(List<int> sayilar)
        {
            if (sayilar.Count == 0)
                return 0;

            return sayilar.Average();
        }
    }
}
