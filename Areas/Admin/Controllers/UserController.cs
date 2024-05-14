using BusinessLayer.Abstract;
using Entitiy_layer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservation2Service _reservation2Service;

        public UserController(IAppUserService appUserService , IReservation2Service reservation2Service)
        {
            _appUserService = appUserService;
            _reservation2Service = reservation2Service;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetlist();
            return View(values);
        }
        public IActionResult DeleteUser(int id) 
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
           _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetlist();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservation2Service.GetlistWithReservationByAccepted(id);
            return View(values);
        }
    }
}
