using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelsalCoreProje.Models;

namespace TravelsalCoreProje.Controllers
{
    [AllowAnonymous]

    public class HomeController : Controller
    {
       

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          
            _logger.LogInformation("Index sayfası çağırıldı");
            _logger.LogError("Error log çağırıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime d = Convert.ToDateTime(DateTime.Now.ToLongDateString()); //logun yanına tarih de verdirdik
            _logger.LogInformation("Privacy sayfası çağrıldı");
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfası çağırıldı");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
