using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
