namespace HMS.Abstractions
{
    public interface IPasswordHasher
    {

        string ComputeHash(string input);
    }
}
