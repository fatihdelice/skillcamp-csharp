using ATMApp.Models;
using System.Globalization;
using System.Text;

namespace ATMApp.Services
{
    public class EODService
    {
        private readonly string _reportDirectory;

        public List<string> FraudLogs { get; }

        public EODService()
        {
            _reportDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "Logs"
            );

            Directory.CreateDirectory(_reportDirectory);

            FraudLogs = new List<string>();
        }

        public void FraudLogEkle(string username)
        {
            string log =
                $"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - Basarisiz giris denemesi. Username: {username}";

            FraudLogs.Add(log);
        }

        public string GunSonuRaporuOlustur(
            List<Transaction> transactions)
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine("========== ATM GUN SONU RAPORU ==========");
            report.AppendLine($"Tarih: {DateTime.Now:dd.MM.yyyy}");
            report.AppendLine();

            report.AppendLine("========== ISLEM LOGLARI ==========");

            if (transactions.Count == 0)
            {
                report.AppendLine("Bugun herhangi bir islem yapilmadi.");
            }
            else
            {
                foreach (Transaction transaction in transactions)
                {
                    report.AppendLine(
                        $"Tarih: {transaction.Date:dd.MM.yyyy HH:mm:ss}"
                    );

                    report.AppendLine(
                        $"Kullanici: {transaction.Username}"
                    );

                    report.AppendLine(
                        $"Islem: {transaction.TransactionType}"
                    );

                    report.AppendLine(
                        $"Tutar: {transaction.Amount.ToString("F2", CultureInfo.InvariantCulture)} TL"
                    );

                    report.AppendLine(
                        $"Aciklama: {transaction.Description}"
                    );

                    report.AppendLine("----------------------------------------");
                }
            }

            report.AppendLine();
            report.AppendLine("========== FRAUD / HATALI GIRIS LOGLARI ==========");

            if (FraudLogs.Count == 0)
            {
                report.AppendLine("Hatali giris denemesi bulunmamaktadir.");
            }
            else
            {
                foreach (string log in FraudLogs)
                {
                    report.AppendLine(log);
                }
            }

            report.AppendLine();
            report.AppendLine("========== OZET ==========");
            report.AppendLine($"Toplam Islem: {transactions.Count}");
            report.AppendLine($"Hatali Giris: {FraudLogs.Count}");

            string fileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";

            string filePath = Path.Combine(
                _reportDirectory,
                fileName
            );

            File.WriteAllText(
                filePath,
                report.ToString(),
                Encoding.UTF8
            );

            return filePath;
        }
    }
}