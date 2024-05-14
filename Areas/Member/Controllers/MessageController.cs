using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
