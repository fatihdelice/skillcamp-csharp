using ATMApp.Models;

namespace ATMApp.Services
{
    public class ATMService
    {
        private readonly UserService _userService;

        public List<Transaction> Transactions { get; }

        public ATMService(UserService userService)
        {
            _userService = userService;
            Transactions = new List<Transaction>();
        }

        public bool ParaYatir(User user, decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            decimal yeniBakiye = user.Balance + amount;

            _userService.BakiyeGuncelle(user, yeniBakiye);

            IslemKaydet(
                user,
                "Para Yatirma",
                amount,
                "Hesaba para yatirildi."
            );

            return true;
        }

        public bool ParaCek(User user, decimal amount)
        {
            if (amount <= 0 || amount > user.Balance)
            {
                return false;
            }

            decimal yeniBakiye = user.Balance - amount;

            _userService.BakiyeGuncelle(user, yeniBakiye);

            IslemKaydet(
                user,
                "Para Cekme",
                amount,
                "Hesaptan para cekildi."
            );

            return true;
        }

        public bool OdemeYap(User user, decimal amount)
        {
            if (amount <= 0 || amount > user.Balance)
            {
                return false;
            }

            decimal yeniBakiye = user.Balance - amount;

            _userService.BakiyeGuncelle(user, yeniBakiye);

            IslemKaydet(
                user,
                "Odeme",
                amount,
                "Fatura veya diger odeme islemi yapildi."
            );

            return true;
        }

        public decimal BakiyeSorgula(User user)
        {
            IslemKaydet(
                user,
                "Bakiye Sorgulama",
                0,
                "Bakiye sorgulandi."
            );

            return user.Balance;
        }

        private void IslemKaydet(
            User user,
            string type,
            decimal amount,
            string description)
        {
            Transactions.Add(
                new Transaction(
                    user.Username,
                    type,
                    amount,
                    description
                )
            );
        }
    }
}