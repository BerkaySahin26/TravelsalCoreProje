using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
      GuideManager guideManager = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke() /// int id kısmı ıd filtrelemesi olduğu için
        {
            var values = guideManager.TGetlist(); ///  Burasıda Destination id filtrelemesi var ondan farklı diğerlerinden
            return View(values); 
        }

    }
}
