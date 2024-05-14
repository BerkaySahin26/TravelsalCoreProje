using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalCoreProje.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        IDestinationService destinationManager;

        public _PopularDestinations(IDestinationService destinationManager)
        {
            this.destinationManager = destinationManager;
        }

        public IViewComponentResult Invoke()
        {
            var values= destinationManager.TGetlist();
            return View(values);

        }
    }
}
