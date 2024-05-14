using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {

        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id) /// int id kısmı ıd filtrelemesi olduğu için
        {
            var values = commentManager.TGetDestinationById(id); ///  Burasıda Destination id filtrelemesi var ondan farklı diğerlerinden
            return View(values); 
        }
    }
}
