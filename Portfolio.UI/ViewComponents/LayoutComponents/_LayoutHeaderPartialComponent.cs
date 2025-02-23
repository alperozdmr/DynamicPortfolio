using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
