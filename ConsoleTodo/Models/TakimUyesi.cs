namespace ConsoleTodo.Models
{
    public class TakimUyesi
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; }

        public TakimUyesi(int id, string adSoyad)
        {
            Id = id;
            AdSoyad = adSoyad;
        }

        public override string ToString()
        {
            return $"{Id} - {AdSoyad}";
        }
    }
}
