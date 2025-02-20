using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
