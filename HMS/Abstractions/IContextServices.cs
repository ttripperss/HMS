namespace HMS.Abstractions
{
    public interface IContextServices
    {
        bool IsUserLoggedIn();
        string GetUserId();
        string GetUserName();
    }
}
