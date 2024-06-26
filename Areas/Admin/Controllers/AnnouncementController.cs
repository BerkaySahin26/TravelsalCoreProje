﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService  _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.TGetlist();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddAnnouncement(string x)
        {
            return View();
        }
    }
}
