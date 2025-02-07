using HMS.Abstractions;
using HMS.Data.ViewModels;
using HMS.Models;
using HMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace HMS.Controllers
{


    public class AccountController : Controller
    {
        
        private readonly IUserService _userService;
        private readonly IContextServices _contextService;
        

        public AccountController(IUserService userService, IContextServices contextService)
        {
            _userService = userService;
            _contextService = contextService;
        }

        public IActionResult Index()
        {
            var userId = _contextService.GetUserId();

            var user = _userService.GetUserbyId(userId);
           // user.ProfilePictureName = _contextService.GetProfilePicture();
            return View(user);
        }





        [HttpPost]
        public IActionResult UpdateProfile(User user)
        {
            // Get logged-in user ID
            //var userId = _userService.GetUserbyId(user.UserId);

          

            // Fetch the user details
            var users = _userService.GetUserbyId(user.UserId.ToString());
            if (users != null)
            {
                users.FirstName = user.FirstName;
                users.Email = user.Email;
                _userService.Update(users);
            }
            if (user == null)
            {
                return RedirectToAction("Error", "Home");
            }

            // Pass the user model to the view for editing
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(Guid userId, IFormFile profilepicture)
        {
            var user = _userService.GetUserbyId(userId.ToString());
            if (profilepicture == null || profilepicture.Length == 0)
            {
                ModelState.AddModelError("ProfilePicture", "Profile picture is required.");
                return RedirectToAction("Index");
            }

            var pictureGuid = Guid.NewGuid();
            var pictureName = "pp-" + pictureGuid + Path.GetExtension(profilepicture.FileName);

            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureName);

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"));
            }

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await profilepicture.CopyToAsync(stream);
            }

            // Assign the picture name to the new file name property
            user.ProfilePictureName = pictureName;



            _userService.Update(user);

            return RedirectToAction("Index");
        }
        //public IActionResult updatepassword(PasswordVM passwordVM)
        //{

        //    User? user = _userService.Users.FirstOrDefault(c =>c.Passwordhash == passwordVM.OldPassword);
        //    if ( user != null)
        //    {

        //        if (passwordVM.NewPassword == passwordVM.ConfirmPassword)
        //        {

        //            user.PasswordHash = passwordVM.NewPassword;

        //        }

        //    }    
        //    else
        //    {

        //        Console.WriteLine(" your new password and confrim paswword no match");
        //    }
        //    return RedirectToAction("Index", "Home");

        //}


        public async Task<IActionResult> PasswordUpdate(PasswordVM model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            var user = _contextService.GetUser();
            if (user == null)
            {
                return RedirectToAction("Login", "Authentication");
            }

            if(user.PasswordHash != model.OldPassword)
            {
                ModelState.AddModelError(string.Empty, "Please add correct old Password.");
                return View(model);
            }

            // Verify that the new password and confirm password match.
            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The new password and confirmation password do not match.");
                return View(model);
            }

            user.PasswordHash = model.NewPassword;


            // Update the user's password in the database.
            bool result = _userService.IsUpdate(user);

            if (result)
            {
                
                return RedirectToAction("PasswordChangeSuccefuly");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error changing password. Please try again.");
                return View(model);
            }


        }

        public IActionResult PasswordChangeSuccefuly()
        {
            return View();
        }
    }
}
