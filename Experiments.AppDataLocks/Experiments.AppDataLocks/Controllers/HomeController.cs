using System.Web.Mvc;
using Application.Data.Locks.Example.Models;
using System.Threading;

namespace Application.Data.Locks.Example.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Clear();
            Response.ContentType = "text/plain";

            var product = new Product { Id = 1, Name = "Heineken", Price = 1.2M };
            
            if(!LockManager.Lock(product, Session.SessionID))
            {
                Response.Write("Object has already lock on it!\r\n");
                Response.End();
                return null;
            }

            Response.Write("Object successfully locked\r\n");
            Response.Flush();
            Thread.Sleep(20000);

            Response.Write("Releasing lock\r\n");
            LockManager.ReleaseLock(product, Session.SessionID);
            Response.Write("Lock released\r\n");

            Response.End();
            return null;
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
