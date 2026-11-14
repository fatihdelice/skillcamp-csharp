namespace StringCharacterApp.Services
{
    public class StringService
    {
        // Her kelimenin ilk karakterini sona tasir
        public string KarakterleriDegistir(string metin)
        {
            string[] kelimeler = metin.Split(' ');

            for (int i = 0; i < kelimeler.Length; i++)
            {
                if (kelimeler[i].Length > 1)
                {
                    kelimeler[i] =
                        kelimeler[i].Substring(1) + kelimeler[i][0];
                }
            }

            return string.Join(" ", kelimeler);
        }
    }
}
