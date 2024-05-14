using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.ViewComponents.AdminDashboard
{
    public class _DashboardBanner: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
