namespace CharacterSwapApp.Services
{
    public class StringService
    {
        public string KarakterleriDegistir(string metin)
        {
            string[] kelimeler = metin.Split(' ');

            for (int i = 0; i < kelimeler.Length; i++)
            {
                if (kelimeler[i].Length > 1)
                {
                    char[] karakterler = kelimeler[i].ToCharArray();

                    char ilkKarakter = karakterler[0];

                    karakterler[0] = karakterler[karakterler.Length - 1];

                    karakterler[karakterler.Length - 1] = ilkKarakter;

                    kelimeler[i] = new string(karakterler);
                }
            }

            return string.Join(" ", kelimeler);
        }
    }
}