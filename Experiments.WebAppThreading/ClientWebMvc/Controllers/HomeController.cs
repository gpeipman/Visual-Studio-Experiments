using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using ClientWebMvc.ServiceReference1;

namespace ClientWebMvc.Controllers
{
    [HandleError]
    public class HomeController : AsyncController
    {
        public void IndexAsync()
        {            
            var random = new Random();

            for (var i = 0; i < 4; i++)
            {
                AsyncManager.OutstandingOperations.Increment();

                var delay = random.Next(1, 5) * 1000;
                var service = new DelayedHelloSoapClient();
                service.HelloWorldCompleted += HelloWorldCompleted;
                service.HelloWorldAsync(delay);

                Debug.WriteLine("Started: " + service.GetHashCode());
            }
        }

        public ActionResult IndexCompleted(List<string> result)
        {
            return View(result);
        }
    
        void HelloWorldCompleted(object sender, HelloWorldCompletedEventArgs e)
        {            
            var hash = 0;
            var service = e.UserState as DelayedHelloSoapClient;
            if (service != null)
                hash = service.GetHashCode();

            List<string> list;
            if (AsyncManager.Parameters.ContainsKey("result"))
            {
                list = (List<string>) AsyncManager.Parameters["result"];
            }
            else
            {
                list = new List<string>();
                AsyncManager.Parameters["result"] = list;
            }

            list.Add(e.Result);

            Debug.WriteLine("Finished: " + hash + " " + e.Result);
            AsyncManager.OutstandingOperations.Decrement();            
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
