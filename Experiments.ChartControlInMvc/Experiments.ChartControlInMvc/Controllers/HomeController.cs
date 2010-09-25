using System;
using System.Web.Mvc;

namespace Experiments.ChartControlInMvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetChart()
        {
            var date = DateTime.Now.Date;
            date = date.AddDays(-1*date.Day);

            var data = new[] 
            {
                new { Date = date.AddMonths(-2), Count = 30 },
                new { Date = date.AddMonths(-1), Count = 25 },
                new { Date = date, Count = 15 }
            };

            Response.Clear();
            Response.ContentType = "image/png";
            ChartLoader.SaveChartImage(
                        "PriceEnquiriesPerMonth.ascx",
                        data,
                        Response.OutputStream);
            Response.End();
            return null; // have to return something
        }
    }
}
