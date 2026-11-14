using VotingApp.Models;

namespace VotingApp.Services
{
    public class ReportService
    {
        public void RaporGoster(List<Category> categories)
        {
            int toplamOy = categories.Sum(category => category.VoteCount);

            Console.WriteLine("\n========== OYLAMA SONUCLARI ==========");

            Console.WriteLine($"Toplam Oy: {toplamOy}\n");

            foreach (Category category in categories)
            {
                double yuzde = toplamOy > 0
                    ? (double)category.VoteCount / toplamOy * 100
                    : 0;

                Console.WriteLine($"Kategori: {category.Name}");
                Console.WriteLine($"Oy Sayisi: {category.VoteCount}");
                Console.WriteLine($"Oy Yuzdesi: %{yuzde:F2}");
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}