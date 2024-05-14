using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
