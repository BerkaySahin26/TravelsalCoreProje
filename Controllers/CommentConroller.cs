using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entitiy_layer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TravelsalCoreProje.Controllers
{
    public class CommentConroller : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            commentManager.TAdd(p);
            return RedirectToAction("index", "destination");  //dışardan veri girişi yapıyoruz ancak bagzıları manuel girişli
            
        }
    }
}
