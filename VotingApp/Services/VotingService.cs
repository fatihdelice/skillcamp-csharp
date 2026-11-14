using VotingApp.Models;

namespace VotingApp.Services
{
    public class VotingService
    {
        public bool OyVer(User user, Category category)
        {
            if (user.VotedCategoryIds.Contains(category.Id))
            {
                return false;
            }

            category.VoteCount++;

            user.VotedCategoryIds.Add(category.Id);

            return true;
        }
    }
}