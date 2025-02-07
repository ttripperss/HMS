using HMS.Abstractions;
using HMS.Extensions;
using HMS.Models;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HMS.Services
{
    public class UserService : IUserService
    {
        private readonly HmsContext _context;
        private readonly PasswordHasher _passwordHasher;
        private readonly string _uploadsFolder;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserService(HmsContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _passwordHasher = new PasswordHasher(); // Initialize PasswordHasher
            _webHostEnvironment = webHostEnvironment;
        }

        public string? ProfilePictureId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddUser(User user)
        {
            user.UserId = Guid.NewGuid();
            user.IsActive = true;
            _context.Users.Add(user);
            _context.SaveChanges();
            //public void AddPatient(Patient patient)
            //{
            //    patient.Id = GuidExtension.NewGuid();
            //    patient.IsDeleted = true;
            //    _hmsContext.Patients.Add(patient);
            //    _hmsContext.SaveChanges();
            //}
        }

        // Method to get user by username/email and verify password
        public User? GetUser(string emailOrUsername, string password)
        {
            // Find the user by username or email
            var user = _context.Users.FirstOrDefault(x => x.UserName == emailOrUsername || x.Email == emailOrUsername);
            //if (user == null || !VerifyPassword(password, user.PasswordHash, user.Salt))
            //{
            //    return null;
            //}
            return user;
        }

        // Method to register a new user
        public void Register(User user)
        {
            // Check if email already exists

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new Exception("A user with this email address already exists.");
            }

            // Generate UserId and Salt
            user.UserId = Guid.NewGuid();
            user.Salt = Guid.NewGuid();

            // Hash the password using the salt
            user.PasswordHash = ComputeHash(user.PasswordHash, user.Salt);

            // Add the new user to the context and save
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Method to compute the hash of the password using SHA256 and the salt
        private string ComputeHash(string password, Guid? salt)
        {
            if (salt == null)
            {
                throw new ArgumentNullException(nameof(salt), "Salt cannot be null.");
            }

            using (var sha256 = SHA256.Create())
            {
                // Combine password and salt
                var passwordSalt = $"{password}{salt.ToString()}";
                var byteValue = Encoding.UTF8.GetBytes(passwordSalt);

                // Compute the hash
                var byteHash = sha256.ComputeHash(byteValue);

                // Return the hash as a base64-encoded string
                return Convert.ToBase64String(byteHash);
            }
        }

        // Method to verify if the entered password matches the stored hash
        private bool VerifyPassword(string password, string storedHash, Guid? salt)
        {
            if (salt == null)
            {
                throw new ArgumentNullException(nameof(salt), "Salt cannot be null.");
            }

            // Compute the hash of the entered password with the same salt
            var computedHash = ComputeHash(password, salt);

            // Compare the computed hash with the stored hash
            return computedHash == storedHash;
        }
        public void Register(User user, IFormFile? profileImage)
        {
            user.UserId = Guid.NewGuid();

            //if (profileImage != null)
            //{
            //    // Save image to a folder
            //    var imagePath = Path.Combine("wwwroot/user", $"{user.UserId}_{profileImage.FileName}");
            //    using (var stream = new FileStream(imagePath, FileMode.Create))
            //    {
            //        profileImage.CopyTo(stream);
            //    }
            //    user.ProfileImage = $"/images/{user.UserId}_{profileImage.FileName}";
            //}
            if (profileImage != null)
            {


                var fileName = $"pp-{Guid.NewGuid()}{Path.GetExtension(profileImage.FileName)}";
                var filePath = Path.Combine(_uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    profileImage.CopyTo(stream);
                }

                user.ProfilePictureId = Guid.Parse(fileName);

            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserbyId(string userId)
        {
            var user = _context.Users.Where(x => x.UserId == Guid.Parse(userId)).FirstOrDefault();
            return user;
        }

        public void Update (User user)
        {
            if (user != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }

        public bool IsUpdate(User user)
        {
            //var existintnguser = GetUserById(user.UserId);
            if (user != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            return false;


        }
    }
}
