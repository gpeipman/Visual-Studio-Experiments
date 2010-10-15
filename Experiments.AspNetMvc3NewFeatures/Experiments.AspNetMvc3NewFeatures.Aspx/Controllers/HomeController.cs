using System.Web.Helpers;
using System.Web.Mvc;
using Experiments.AspNetMvc3NewFeatures.Aspx.Models;

namespace Experiments.AspNetMvc3NewFeatures.Aspx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChartModel _model;

        public HomeController(ChartModel model)
        {
            _model = model;
        }

        public ActionResult Index()
        {
            ViewModel.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ChartResult GetChart()
        {
            var data = _model.GetChartData();

            var chart = new Chart(400, 200, ChartTheme.Blue)
                        .AddTitle("Price enquiries")
                        .DataBindTable(data, "X");

            return new ChartResult(chart, "png");
        }

        public ActionResult About()
        {
            return View();
        }        
    }
}
