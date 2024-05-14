using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Controllers
{
    public class AdminController : Controller
    {
      public IActionResult PartialHeader()
        {
            return PartialView();
        }
        public IActionResult PartialAppBrandDemo()
        {
            return PartialView();
        }
        public IActionResult PartialSideBar()
        {
            return PartialView();
        }
        public IActionResult PartialNavBar()
        {
            return PartialView();
        }
        public IActionResult PartialFooter()
        {
            return PartialView();
        }
        public IActionResult PartialScript()
        {
            return PartialView();
        }
    }
}
