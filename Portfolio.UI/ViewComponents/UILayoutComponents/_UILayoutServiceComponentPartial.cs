using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutServiceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
