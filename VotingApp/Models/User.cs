namespace VotingApp.Models
{
    public class User
    {
        public string Username { get; set; }

        public HashSet<int> VotedCategoryIds { get; set; }

        public User(string username)
        {
            Username = username;
            VotedCategoryIds = new HashSet<int>();
        }
    }
}