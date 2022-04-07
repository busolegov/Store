using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Store.Components
{
    public class UserViewComponent : ViewComponent
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //public UserViewComponent(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}

        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            return View("User", user);
    }
    }

}
