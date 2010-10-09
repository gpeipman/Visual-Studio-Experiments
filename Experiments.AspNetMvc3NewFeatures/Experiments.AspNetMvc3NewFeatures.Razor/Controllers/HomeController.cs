using System.Web.Helpers;
using System.Web.Mvc;
using Experiments.AspNetMvc3NewFeatures.Razor.Models;

namespace Experiments.AspNetMvc3NewFeatures.Razor.Controllers
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

        public ActionResult Chart()
        {
            var model = new ChartModel();
            var data = model.GetChartData();

            new Chart(400, 200, ChartTheme.Blue)
                .AddTitle("Price enquiries")
                .DataBindTable(data, "X")
                .Write("png");

            return null;
        }
    }
}
