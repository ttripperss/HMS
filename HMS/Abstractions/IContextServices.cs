using HMS.Models;

namespace HMS.Abstractions
{
    public interface IContextServices
    {
        bool IsUserLoggedIn();
        string GetUserId();
        string GetUserName();
        string GetProfilePicture();

        void SomeServiceMethod();

        User GetUser();
    }
}
