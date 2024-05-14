using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using Entitiy_layer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetlist();
            return View(values);
        }
        [Route("AddGuide")]

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [Route("Index")]

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validaitonRules = new GuideValidator();
            ValidationResult result = validaitonRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [Route("EditGuide")]

        [HttpGet]

        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeTrue(int id) 
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Guide", new {area="Admin"});
        }
        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index","Guide", new { area = "Admin" });
        }
    }
}
