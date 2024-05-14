using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        ISubAboutService SubAboutManager = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = SubAboutManager.TGetlist();
            return View(values);
        }
    }
}
