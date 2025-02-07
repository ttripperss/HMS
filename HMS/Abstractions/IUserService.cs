using HMS.Models;

namespace HMS.Abstractions
{
    public interface IUserService
    {
        void Register(User user);
        User? GetUser(string emailOrUsername, string password);
        void AddUser(User user);
        User GetUserbyId(string userId);
        void Update(User user);
        bool IsUpdate(User user);



    }
}