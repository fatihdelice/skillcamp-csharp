namespace ConsonantCheckApp.Services
{
    public class StringService
    {
        public bool SessizHarfKontrol(string kelime)
        {
            for (int i = 0; i < kelime.Length - 1; i++)
            {
                char ilkKarakter = char.ToLowerInvariant(kelime[i]);
                char ikinciKarakter = char.ToLowerInvariant(kelime[i + 1]);

                if (char.IsLetter(ilkKarakter) &&
                    char.IsLetter(ikinciKarakter) &&
                    !SesliHarfMi(ilkKarakter) &&
                    !SesliHarfMi(ikinciKarakter))
                {
                    return true;
                }
            }

            return false;
        }

        private bool SesliHarfMi(char karakter)
        {
            return "aeiou\u0131\u00f6\u00fc".Contains(karakter);
        }

        public bool[] MetinKontrol(string metin)
        {
            string[] kelimeler = metin.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries
            );

            bool[] sonuclar = new bool[kelimeler.Length];

            for (int i = 0; i < kelimeler.Length; i++)
            {
                sonuclar[i] = SessizHarfKontrol(kelimeler[i]);
            }

            return sonuclar;
        }
    }
}