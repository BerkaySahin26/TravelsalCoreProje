using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelsalCoreProje.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic:ViewComponent
    {
        Context c = new Context(); // veri tabanına bağlan
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count(); //rota sayısını v1 e at
            ViewBag.v2 = c.Users.Count(); //üye sayısınını yolla
            return View();//döndür
        }
    }
}
