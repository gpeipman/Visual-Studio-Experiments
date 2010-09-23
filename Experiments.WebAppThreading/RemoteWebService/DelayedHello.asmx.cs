using System.Threading;
using System.Web.Services;

namespace RemoteWebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class DelayedHello : WebService
    {
        [WebMethod]
        public string HelloWorld(int delay)
        {
            if(delay > 0)
                Thread.Sleep(delay);
            return "Hello World, delay: " + delay;
        }
    }
}
