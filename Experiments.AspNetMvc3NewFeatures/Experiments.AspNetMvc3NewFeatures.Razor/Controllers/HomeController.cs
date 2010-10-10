using System;
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

        public ActionResult MyChart()
        {
            var model = new ChartModel();
            var data = model.GetChartData();

            new Chart(400, 200, ChartTheme.Blue)
                .AddTitle("Price enquiries")
                .DataBindTable(data, "X")
                .Write("png");

            return null;
        }

        public ActionResult MyCachedChart()
        {
            const string chartKey = "MyCachedChart";
            var chart = Chart.GetFromCache(chartKey);

            if (chart == null)
            {
                var model = new ChartModel();
                var data = model.GetChartData();

                chart = new Chart(400, 200, ChartTheme.Blue)
                        .AddTitle("Chart cached: " + DateTime.Now)
                        .DataBindTable(data, "X");
                chart.SaveToCache(chartKey,1,false);
            }

            chart.Write("png");
            return null;
        }
    }
}
