namespace ATMApp.Models
{
    public class Transaction
    {
        public string Username { get; set; }

        public string TransactionType { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Transaction(
            string username,
            string transactionType,
            decimal amount,
            string description)
        {
            Username = username;
            TransactionType = transactionType;
            Amount = amount;
            Description = description;
            Date = DateTime.Now;
        }
    }
}