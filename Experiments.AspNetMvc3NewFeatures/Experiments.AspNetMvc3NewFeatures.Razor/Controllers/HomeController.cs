using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            
            return View(data);
        }
    }
}
