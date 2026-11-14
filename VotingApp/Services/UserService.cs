using VotingApp.Models;

namespace VotingApp.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>();

        public User? KullaniciBul(string username)
        {
            return _users.FirstOrDefault(
                user => user.Username.Equals(
                    username,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

        public User? KayitOl(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            if (KullaniciBul(username) != null)
            {
                return null;
            }

            User yeniKullanici = new User(username);

            _users.Add(yeniKullanici);

            return yeniKullanici;
        }
    }
}