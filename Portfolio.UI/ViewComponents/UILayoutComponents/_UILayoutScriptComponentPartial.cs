using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
