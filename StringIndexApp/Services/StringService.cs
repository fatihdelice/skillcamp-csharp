namespace StringIndexApp.Services
{
    public class StringService
    {
        // Belirtilen indexteki karakteri siler
        public string KarakterSil(string metin, int index)
        {
            if (index < 0 || index >= metin.Length)
            {
                return metin;
            }

            return metin.Remove(index, 1);
        }
    }
}
