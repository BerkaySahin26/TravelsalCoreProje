using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelsalCoreProje.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context(); // çok fazla çekilcek verimiz olmadığı için context oluşuturyoruz.
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Guides.Count();   // 2 tanesini oluşturduğumuz tablolardan çekicek v3 ise şuan tablosu yok manuel olarak alıyor 
            ViewBag.v3 = "285";
            return View();
        }
    }
}
