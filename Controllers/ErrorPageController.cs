using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
