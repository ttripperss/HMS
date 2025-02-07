//using System.Security.Cryptography;
//using System.Text;
//using HMS.Abstractions;

//namespace HMS.Services
//{
//    public class PasswordHasher : IPasswordHasher
//    {
//        public string ComputeHash(string password, string salt)
//        {

//            using var sha512 = SHA512.Create();

//            var passwordSalt = $"{password}{salt}";

//            var byteValue = Encoding.UTF8.GetBytes(passwordSalt);

//            var byteHash = sha512.ComputeHash(byteValue);

//            var hash = Convert.ToBase64String(byteHash);

//            return hash;
//        }

//        public string ComputeHash(string input)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
using System.Security.Cryptography;
using System.Text;
using HMS.Abstractions;

namespace HMS.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        // Method to compute hash using password and salt (salt as string)
        public string ComputeHash(string password, string salt)
        {
            // Use SHA256 instead of SHA512
            using var sha256 = SHA256.Create();

            // Combine password and salt
            var passwordSalt = $"{password}{salt}";

            // Convert to byte array
            var byteValue = Encoding.UTF8.GetBytes(passwordSalt);

            // Compute the hash
            var byteHash = sha256.ComputeHash(byteValue);

            // Convert the byte array to a Base64 string
            var hash = Convert.ToBase64String(byteHash);

            return hash;
        }

        public string ComputeHash(string input)
        {
            throw new NotImplementedException();
        }
    }
}

