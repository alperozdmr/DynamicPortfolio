using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
