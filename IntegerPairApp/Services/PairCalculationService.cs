namespace IntegerPairApp.Services
{
    public class PairCalculationService
    {
        public int Hesapla(int sayi1, int sayi2)
        {
            int toplam = sayi1 + sayi2;

            if (sayi1 == sayi2)
            {
                return toplam * toplam;
            }

            return toplam;
        }
    }
}