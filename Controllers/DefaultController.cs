using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
