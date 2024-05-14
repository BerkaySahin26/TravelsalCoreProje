using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService; // işlemleri manager üzerinden almıyoruz artık 

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //CommentManager commentManager = new CommentManager(new EfCommentDal()); // eski tarz 
        public IActionResult Index()
        {
            var values = _commentService.TGetListCommentWithDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values= _commentService.TGetByID(id);// id ile çek 
            _commentService.TDelete(values);
            return RedirectToAction("index");
        }
    }
}
