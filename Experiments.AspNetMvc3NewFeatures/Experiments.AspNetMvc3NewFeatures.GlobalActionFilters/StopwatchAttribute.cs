using System.Diagnostics;
using System.Web.Mvc;

namespace Experiments.AspNetMvc3NewFeatures.GlobalActionFilters
{
    // Credits to Nick Berardi: http://coderjournal.com/2010/10/timing-the-execution-time-of-your-mvc-actions/?utm_source=feedburner&utm_medium=feed&utm_campaign=Feed:+coderjournal+(Nick+Berardi's+Coder+Journal)
    public class StopwatchAttribute : ActionFilterAttribute
    {
        private readonly Stopwatch _stopwatch;

        public StopwatchAttribute()
        {
            _stopwatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopwatch.Stop();

            var httpContext = filterContext.HttpContext;
            var response = httpContext.Response;
            var elapsed = _stopwatch.Elapsed.ToString();

            // Works for Cassini and IIS
            response.Write(string.Format("<!-- X-Stopwatch: {0} -->", elapsed));  

            // Works for IIS
            //response.AddHeader("X-Stopwatch", elapsed);
        }
    }
}