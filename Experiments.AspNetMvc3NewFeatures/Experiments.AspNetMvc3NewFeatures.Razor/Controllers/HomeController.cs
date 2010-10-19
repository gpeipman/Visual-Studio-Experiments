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
            var model = new ContentPagesModel();
            var page = model.GetAboutPage();

            return View(page);
        }

        public void MyChart()
        {
            var model = new ChartModel();
            var data = model.GetChartData();

            new Chart(400, 200, ChartTheme.Blue)
                .AddTitle("Price enquiries")
                .DataBindTable(data, "X")
                .Write("png");
        }

        public void MyCachedChart()
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
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(string email, string subject, string body)
        {            
            try
            {
                WebMail.SmtpServer = "gprsmail.emt.ee";
                WebMail.Send(
                        "gpeipman@hotmail.com",
                        subject,
                        body,
                        email
                    );

                return RedirectToAction("FeedbackSent");
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_FORM", ex.ToString());
            }

            return View();
        }

        public ActionResult FeedbackSent()
        {
            return View();
        }
    }
}
