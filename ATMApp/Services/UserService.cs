using ATMApp.Models;
using System.Globalization;

namespace ATMApp.Services
{
    public class UserService
    {
        private readonly string _filePath;

        public List<User> Users { get; private set; }

        public UserService()
        {
            _filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "users.txt"
            );

            Users = new List<User>();

            DosyaKontrolEt();
            KullanicilariYukle();
        }

        private void DosyaKontrolEt()
        {
            string? directory = Path.GetDirectoryName(_filePath);

            if (directory != null)
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                string[] varsayilanKullanicilar =
                {
                    "fatih|1234|10000",
                    "ahmet|5678|5000",
                    "mehmet|1111|7500"
                };

                File.WriteAllLines(_filePath, varsayilanKullanicilar);
            }
        }

        private void KullanicilariYukle()
        {
            Users.Clear();

            string[] satirlar = File.ReadAllLines(_filePath);

            foreach (string satir in satirlar)
            {
                string[] bilgiler = satir.Split('|');

                if (bilgiler.Length != 3)
                {
                    continue;
                }

                if (!decimal.TryParse(
                    bilgiler[2],
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal balance))
                {
                    continue;
                }

                User user = new User(
                    bilgiler[0],
                    bilgiler[1],
                    balance
                );

                Users.Add(user);
            }
        }

        public User? KullaniciDogrula(string username, string pin)
        {
            return Users.FirstOrDefault(user =>
                user.Username.Equals(
                    username,
                    StringComparison.OrdinalIgnoreCase
                ) && user.Pin == pin
            );
        }

        public void BakiyeGuncelle(User user, decimal yeniBakiye)
        {
            user.Balance = yeniBakiye;

            string[] satirlar = Users.Select(user =>
                $"{user.Username}|{user.Pin}|{user.Balance.ToString(CultureInfo.InvariantCulture)}"
            ).ToArray();

            File.WriteAllLines(_filePath, satirlar);
        }
    }
}