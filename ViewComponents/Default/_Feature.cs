using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        { 
            var values = featureManager.TGetlist();
           // ViewBag.image1 = featureManager.TGetByID();
            return View(values);
        }
    }
}
