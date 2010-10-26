using System.Web.Mvc;

namespace Experiments.MobileWeb.JqueryMobile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewModel.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Heineken()
        {
            return View();
        }

        public ActionResult Amstel()
        {
            return View();
        }
    }
}
