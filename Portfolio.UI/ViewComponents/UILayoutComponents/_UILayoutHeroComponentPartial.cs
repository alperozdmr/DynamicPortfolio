using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeroComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
