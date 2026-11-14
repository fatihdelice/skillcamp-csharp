namespace VotingApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int VoteCount { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            VoteCount = 0;
        }
    }
}