using GreenStreetCoffee.Feature.Navigation.Repositories;
using System.Web.Mvc;

namespace GreenStreetCoffee.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        private readonly NavigationRepo navigationRepo;
        public NavigationController()
        {
            navigationRepo = new NavigationRepo();
        }
        public ActionResult PrimaryNavigation()
        {
            var model = navigationRepo.BuildPrimaryNavigation();
            return View("~/Views/GreenStreetCoffee/Navigation/PrimaryNavigation.cshtml", model);
        }

        public ActionResult Footer()
        {
            var model = navigationRepo.BuildFooterViewModel();
            return View("~/Views/GreenStreetCoffee/Navigation/Footer.cshtml", model);
        }

        public ActionResult Breadcrumb()
        {
            var model = navigationRepo.BuildBreadcrumb();
            return View("~/Views/GreenStreetCoffee/Navigation/Breadcrumb.cshtml", model);
        }
    }
}