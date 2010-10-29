using System.Web.Mvc;

namespace Experiments.AspNetMvc3NewFeatures.GlobalActionFilters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);

            var response = filterContext.RequestContext.HttpContext.Response;
            
            //response.Write("<!-- Buuu! -->");  // Works for Cassini and IIS
            response.Headers.Add("MyActionFilter", "Buuu!"); // Works for IIS only
        }
    }
}