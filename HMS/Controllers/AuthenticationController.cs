using HMS.Models;
 using HMS.Data.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HMS.Abstractions;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using HMS.Services;
using HMS.DTO_s;
using static System.Net.WebRequestMethods;

namespace HMS.Controllers
{
    public class AuthenticationController : Controller
    {


        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        private readonly IConfigurationService _configurationService;
        public AuthenticationController(
            IUserService userService,
            IConfigurationService configurationService,
            IEmailService emailService)
        {
            _userService = userService;
            _configurationService = configurationService;
            _emailService = emailService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            _userService.Register(user);

            return RedirectToAction("Login");
        }

        



        [HttpPost]
        public async Task<IActionResult> Register(User user, IFormFile ProfilePicture)
        {
            if (ProfilePicture == null || ProfilePicture.Length == 0)
            {
                ModelState.AddModelError("ProfilePicture", "Profile picture is required.");
                return View(user);
            }

            var pictureGuid = Guid.NewGuid();
            var pictureName = "pp-" + pictureGuid + Path.GetExtension(ProfilePicture.FileName);

            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureName);

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"));
            }

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await ProfilePicture.CopyToAsync(stream);
            }

            // Assign the picture name to the new file name property
            user.ProfilePictureName = pictureName;

           

            _userService.AddUser(user);

            return RedirectToAction("Login");
        }



        //public async Task<IActionResult> Register(User user, IFormFile ProfilePicture)
        //{
        //    // Handle profile picture upload if available
        //    if (ProfilePicture != null)
        //    {
        //        // Generate a unique GUID for the profile picture
        //        var pictureGuid = Guid.NewGuid();

        //        // Name the profile picture file as pp-GUID.extension
        //        var pictureName = "pp-" + pictureGuid + Path.GetExtension(ProfilePicture.FileName);

        //        // Define the path to save the profile picture in the wwwroot/images/profile-pictures directory
        //        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile-pictures", pictureName);

        //        // Ensure the directory exists, otherwise create it
        //        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile-pictures")))
        //        {
        //            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile-pictures"));
        //        }

        //        // Save the profile picture file
        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            await ProfilePicture.CopyToAsync(stream);
        //        }

        //        // Assign the profile picture file name to the user model
        //        //user.ProfilePictureId = pictureName;
        //    }

        //    // Save the user (this could be registration or profile update)
        //    //_userService.RegisterUser(user);
        //    _userService.GetUser(user);
        //    // Redirect to a suitable page after successful registration
        //    return RedirectToAction("Login");
        //}




        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            // Get the user by email or username and password
            User? user = _userService.GetUser(model.EmailOrUserName, model.PassWord);

            if (user != null)
            {
                // Set profile picture path
                var profilePicturePath = string.IsNullOrEmpty(user.ProfilePictureName)
                    ? "images/default-profile.png"
                    : $"/images/{user.ProfilePictureName}";

                // Get expiration timeframe
                int expiryTimeFrame = _configurationService.GetExpiryTimeframeInMinutes();

                // Create claims for the user
                List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, model.EmailOrUserName),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Country, "Pakistan"),
            new Claim(ClaimTypes.Sid, user.UserId.ToString()),
            
        };

                // Create identity and authentication properties
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties
                {
                    AllowRefresh = true, // Allow refreshing the session
                    IsPersistent = model.KeepLoggedIn, // Persist session if "KeepLoggedIn" is checked
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                };

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                var emailModel = new SendEmailDto();
                emailModel.PlainText = "Welcome to Hms";
                emailModel.Html = $"Thanks for login in Hospital Mangement System ";
                emailModel.Subject = "Login Hms";
                emailModel.To = user.Email;
                 //_emailService.SendEmail(emailModel);
                  //_emailService.SendEmail(email);
                return RedirectToAction("Index", "Home");
            }

            // If user not found, display error message
            ViewData["ValidateMessage"] = "User not found";
            return View();
        }



        public async Task<IActionResult> LogOut()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return RedirectToAction("Login", "Authentication");
            }
        }
    }

