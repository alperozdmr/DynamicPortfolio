using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entity.concrete;
using Portfolio.UI.CustomeModel;

namespace Portfolio.UI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto var = new UserEditDto();
            var.Surname = values.Surname;
            var.Name = values.Name;
            var.Username = values.UserName;
            var.Mail = values.Email;
            return View(var);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto var)
        {
            if (var.Password == var.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = var.Name;
                user.Surname = var.Surname;
                user.Email = var.Mail;
                user.UserName = var.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, var.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "About");
            }
            return View();
        }
    }
}
