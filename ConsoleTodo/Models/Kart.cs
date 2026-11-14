namespace ConsoleTodo.Models
{
    public class Kart
    {
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        public TakimUyesi AtananKisi { get; set; }

        public Buyukluk Buyukluk { get; set; }

        public BoardLine Line { get; set; }

        public Kart(
            string baslik,
            string icerik,
            TakimUyesi atananKisi,
            Buyukluk buyukluk,
            BoardLine line)
        {
            Baslik = baslik;
            Icerik = icerik;
            AtananKisi = atananKisi;
            Buyukluk = buyukluk;
            Line = line;
        }
    }
}
