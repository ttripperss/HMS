using System.Security.Claims;
using HMS.Abstractions;
using HMS.Models;

namespace HMS.Services
{
    public class ContextServices : IContextServices

    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;
        
        public ContextServices(IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _contextAccessor = contextAccessor;
            _userService = userService;
          
        }

        public string GetUserId()
        {
            string id = _contextAccessor?.HttpContext?.User?
        .Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            return id;
        }

        public User GetUser()
        {
            var userId = GetUserId();
            if (userId != null)
            {
                var user = _userService.GetUserbyId(userId);
                if (user != null)
                {

                    return user;
                }
            }
            return null;
        }


        public string GetProfilePicture()
        {
            var userId = GetUserId();
            var user = _userService.GetUserbyId(userId);
            string profileImage = "/images/" + user.ProfilePictureName;
            return profileImage;
        }
        public string GetUserName()
        {
            var Username = _contextAccessor? .HttpContext?.User.Claims?
                .FirstOrDefault(c =>c.Type == ClaimTypes.GivenName)?.Value;
            return Username;
        }

        public bool IsUserLoggedIn()
        {
            return _contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? true;
        }

        public void SomeServiceMethod()
        {
            throw new NotImplementedException();
        }
       
    }

}

