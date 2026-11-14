namespace AbsoluteSquareApp.Services
{
    public class NumberCalculationService
    {
        private const int ReferansDeger = 67;

        public (int KucuklerinToplami, int BuyuklerinToplami)
            Hesapla(int[] sayilar)
        {
            int kucuklerinToplami = 0;
            int buyuklerinToplami = 0;

            foreach (int sayi in sayilar)
            {
                if (sayi < ReferansDeger)
                {
                    int fark = ReferansDeger - sayi;

                    kucuklerinToplami += fark;
                }
                else if (sayi > ReferansDeger)
                {
                    int fark = Math.Abs(sayi - ReferansDeger);

                    buyuklerinToplami += fark * fark;
                }
            }

            return (kucuklerinToplami, buyuklerinToplami);
        }
    }
}