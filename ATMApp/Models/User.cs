namespace ATMApp.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Pin { get; set; }

        public decimal Balance { get; set; }

        public User(string username, string pin, decimal balance)
        {
            Username = username;
            Pin = pin;
            Balance = balance;
        }
    }
}