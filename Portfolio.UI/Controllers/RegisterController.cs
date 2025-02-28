using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entity.concrete;
using Portfolio.UI.CustomeModel;

namespace Portfolio.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Index(RegisterDto var)
        //{

        //    var appUser = new AppUser()
        //    {
        //        Name = var.Name,
        //        Surname = var.Surname,
        //        Email = var.Mail,
        //        UserName = var.Username,
        //    };
        //    var result = await _userManager.CreateAsync(appUser, var.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //    return View();
        //}
    }
}
