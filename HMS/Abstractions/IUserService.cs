using HMS.Models;

namespace HMS.Abstractions
{
    public interface IUserService
    {
        void Register(User user);
        User? GetUser(string emailOrUsername, string password);
    }
}
