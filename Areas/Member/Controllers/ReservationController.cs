using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Entitiy_layer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelsalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	public class ReservationController : Controller
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

		Reservation2Manager reservation2Manager = new Reservation2Manager(new EfReservation2Dal());

		private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservation2Manager.GetlistWithReservationByAccepted(values.Id);
            return View(valuesList);
        }	
		public async Task <IActionResult> MyOldReservation()
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservation2Manager.GetlistWithReservationByPrevious(values.Id);
            return View(valuesList);
        }

		public async Task<IActionResult> MyApprovalReservation()
		{ 
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = reservation2Manager.GetListWithReservationByWaitAprroval(values.Id);
            return View(valuesList);
		}

		[HttpGet]

		public IActionResult NewReservation()
		{
			List<SelectListItem> values = (from x in destinationManager.TGetlist() select new SelectListItem
			{
				Text = x.City,
				Value = x.DestinationID.ToString()
			}).ToList();
            ViewBag.v = values;
			return View();
		}	
		
		[HttpPost]

		public IActionResult NewReservation(Reservation2 p)
		{
			p.AppUserId = 5;
            p.Status2 = "Onay Bekliyor";
			reservation2Manager.TAdd(p);
			return RedirectToAction("MyCurrenReservation");
		}
	}
}
